using System;
using Data;
using AutoMapper;
using ServicesLayer.Bussiness;
using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.DTOS.ViewModel;
using ServicesLayer.Services;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServicesLayer.Services.TeachersServices
{
    public class MaestrosCrud: IMaestrosCrud
    {
        private readonly School_Manage_SystemContext dbContext;
        private readonly IMapper map;

        public MaestrosCrud (IMapper mapper, School_Manage_SystemContext dbCont)
        {
            map = mapper;
            dbContext = dbCont;
        }

        public async Task<ServerResponse<string>>AddTeacher(NewMaestro maestro)
        {
            ServerResponse<string> serverResponse = new ServerResponse<string>();
            Maestro mstro = map.Map<Maestro>(maestro);
         
            try
            {
                await dbContext.AddAsync(mstro);
                await dbContext.Usuarios.AddAsync(new Usuario
                {
                    NombreUsuario = maestro.Cedula,
                    PasswordHash = PasswordEncrypter.Compute256Hash(maestro.passwordSalt),
                    IdRol = 2,
                    FotoPerfil = null
                });
                await dbContext.SaveChangesAsync();
                serverResponse.Data = "";
            }
            catch(Exception ex)
            {
                serverResponse.Success = false;
            }

            return serverResponse;
        }

        public async Task <ServerResponse<List<MaestrosViewModel>>> GetAllTeachers()
        {
            ServerResponse<List<MaestrosViewModel>> serverResponse= new ServerResponse<List<MaestrosViewModel>>();

            try
            {
                var teachers = await (from teacher in dbContext.Maestros select teacher).ToListAsync();
                serverResponse.Data = teachers.Select(s => map.Map<MaestrosViewModel>(s)).ToList();
            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<MaestrosViewModel>>>GetTeachersBySubject(string codigo)
        {
            ServerResponse<List<MaestrosViewModel>> serverResponse = new ServerResponse<List<MaestrosViewModel>>();

            try
            {
                var teachers = await (from teacher in dbContext.Maestros 
                                               join materia in dbContext.MateriasMaestros
                                               on teacher.Cedula equals materia.Cedula
                                               where materia.CodigoMateria == codigo
                                               select teacher).ToListAsync();

                serverResponse.Data = teachers.Select(s => map.Map<MaestrosViewModel>(s)).ToList();
            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<string>> AddSubjectToTeacher(MateriasMaestrosBinding materia)
        {
           ServerResponse<string> serverResponse = new ServerResponse<string>();
            try
            {
                MateriasMaestro materiaM = map.Map<MateriasMaestro>(materia);
                await dbContext.MateriasMaestros.AddAsync(materiaM);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serverResponse.Success=false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<MaestrosViewModel>>> EditTeacherInfo(EditMaestro teacher)
        {
            ServerResponse<List<MaestrosViewModel>> serverResponse = new ServerResponse<List<MaestrosViewModel>>();

            try
            {
                var maestro = await dbContext.Maestros.FirstOrDefaultAsync(m => m.Cedula == teacher.Cedula);
                
                maestro.Nombre = teacher.Nombre;
                maestro.Apellido  = teacher.Apellido;
                maestro.IdArea = teacher.IdArea;
                maestro.Telefono = teacher.Telefono;
                maestro.CorreoElectronico = teacher.CorreoElectronico;

                dbContext.Update(maestro);
                await dbContext.SaveChangesAsync();

                serverResponse = await GetAllTeachers();
            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<MaestrosViewModel>>> DeleteTeacher(string cedula)
        {
            ServerResponse<List<MaestrosViewModel>> serverResponse = new ServerResponse<List<MaestrosViewModel>>();

            try
            {
                var maestro = await dbContext.Maestros.FirstOrDefaultAsync(m => m.Cedula == cedula);

                maestro.Estatus = false;
                dbContext.Update(maestro);

                var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == cedula);
                dbContext.Remove(usuario);
                await dbContext.SaveChangesAsync();

                serverResponse = await GetAllTeachers();
            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
            return serverResponse;
        }
    }
}