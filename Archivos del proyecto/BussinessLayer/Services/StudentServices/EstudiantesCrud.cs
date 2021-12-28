using Data;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLayer.Services.StudentServices;
using ServicesLayer.Services;
using ServicesLayer.DTOS.ViewModel;
using ServicesLayer.DTOs.BindingModel;
using Microsoft.EntityFrameworkCore;

namespace ServicesLayer.Bussiness
{
    public class EstudiantesCrud:IEstudiantesCrud
    {
        private readonly School_Manage_SystemContext dbContext;
        private readonly IMapper map;

        public EstudiantesCrud(IMapper mapper, School_Manage_SystemContext dbCont)
        {
            map = mapper;
            dbContext = dbCont;
        }

        public  async Task<ServerResponse<string>>AddNewStudent(DTOs.BindingModel.NewStudent est)
        {
            ServerResponse<string> serverResponse = new ServerResponse<string>();
            Estudiante estudiante = map.Map<Estudiante>(est);

            try
            {
            // Agregar un nuevo estudiante
               await dbContext.AddAsync(estudiante);
               await dbContext.Usuarios.AddAsync(new Usuario
                {
                    NombreUsuario = est.Matricula,
                    PasswordHash = PasswordEncrypter.Compute256Hash(est.passwordSalt),
                    IdRol = 3,
                    FotoPerfil = null
                });
                 await dbContext.SaveChangesAsync();
                 serverResponse.Data = "";
            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
                return serverResponse;
        }

        public async Task<ServerResponse<List<StudentsViewModel>>>GetStudentsBySection(string section)
        {
            ServerResponse<List<StudentsViewModel>> serverResponse = new ServerResponse<List<StudentsViewModel>>();

            try
            {
                var estudiantes = await (from estudiante in dbContext.Estudiantes
                                      where estudiante.CodigoSeccion == section && estudiante.Estatus == true
                                      select estudiante).ToListAsync();

                serverResponse.Data =estudiantes.Select(s => map.Map<StudentsViewModel>(s)).ToList();
            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<ReportesEstViewModel>>>GetReportesByStudent(string matricula)
        {
            ServerResponse<List<ReportesEstViewModel>> serverResponse = new ServerResponse<List<ReportesEstViewModel>>();
            try
            {
                var reportes = await dbContext.ReportesAestudiantes.Where(n => n.Matricula == matricula )
                                                                                            .Include(n => n.CedulaMaestroNavigation).ToListAsync();

                serverResponse.Data = reportes.Select(s => map.Map<ReportesEstViewModel>(s)).ToList();
            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<StudentsViewModel>>> EditStudentInfo(EditStudent student) 
        {
            ServerResponse<List<StudentsViewModel>> serverResponse = new ServerResponse<List<StudentsViewModel>>();

            try
            {
                var estudiante = await dbContext.Estudiantes.FirstOrDefaultAsync(e => e.Matricula == student.Matricula);

                estudiante.Nombre = student.Nombre;
                estudiante.Apellido = student.Apellido;
                estudiante.Telefono = student.Telefono;
                estudiante.CorreoElectronico = student.CorreoElectronico;
                estudiante.Direccion = student.Direccion;
                estudiante.NombrePadre = student.NombrePadre;
                estudiante.NombreMadre = student.NombreMadre;
                estudiante.CedulaPadre = student.CedulaPadre;
                estudiante.CedulaMadre = student.CedulaMadre;
                estudiante.Foto2x2 = student.Foto2x2;
                estudiante.CodigoSeccion = student.CodigoSeccion;

                dbContext.Update(estudiante);
                await dbContext.SaveChangesAsync();

                serverResponse = await GetStudentsBySection(student.CodigoSeccion);

            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<StudentsViewModel>>> DeleteStudent(string matricula)
        {
            ServerResponse<List<StudentsViewModel>> serverResponse = new ServerResponse<List<StudentsViewModel>>();

            try
            {
                var estudiante = await dbContext.Estudiantes.FirstOrDefaultAsync(e => e.Matricula == matricula);

                estudiante.Estatus = false;
                dbContext.Update(estudiante);
                
                var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == matricula);

                if (usuario != null)
                {
                    dbContext.Remove(usuario);
                }

                await dbContext.SaveChangesAsync();

                serverResponse = await GetStudentsBySection(estudiante.CodigoSeccion);
            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
            return serverResponse;
        }
    }
}