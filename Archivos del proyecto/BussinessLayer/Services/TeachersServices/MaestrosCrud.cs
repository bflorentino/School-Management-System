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
                    NombreUsuario = maestro.NombreUsuario,
                    PasswordHash = PasswordEncrypter.Compute256Hash(maestro.passwordSalt),
                    IdRol = 2,
                    FotoPerfil = null
                });
                await dbContext.SaveChangesAsync();
                serverResponse.Data = "";
                serverResponse.Message = "Maestro registrado exitosamente";
            }
            catch(Exception ex)
            {
                serverResponse.Message = "Hubo un error al intentar ingresar el nuevo registro";
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
                serverResponse.Message = "Hubo un error al obtener los datos";
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
                serverResponse.Message = "Hubo un error al obtener los datos";
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
                serverResponse.Message = "Registro agregado exitosamente";
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serverResponse.Success=false;
                serverResponse.Message = ex.Message;
            }
            return serverResponse;
        }
    }
}