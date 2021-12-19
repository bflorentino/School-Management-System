using Data;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLayer.Services.StudentServices;
using ServicesLayer.Services;

namespace ServicesLayer.Bussiness
{
    public class EstudiantesCrud:IEstudiantesCrud
    {
        private readonly School_Manage_SystemContext dbContext = DBaseContext.GetContexto().Ctxto;
        private readonly IMapper map;

        public EstudiantesCrud(IMapper mapper)
        {
            map = mapper;
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
                    NombreUsuario = est.NombreUsuario,
                    PasswordHash = PasswordEncrypter.Compute256Hash(est.passwordSalt),
                    IdRol = 3,
                    FotoPerfil = null
                });
                 await dbContext.SaveChangesAsync();
                 serverResponse.Data = "";
                 serverResponse.Message = "Estudiante registrado exitosamente";
            }
            catch (Exception ex)
            {
                serverResponse.Success = false;
                serverResponse.Message = ex.Message;
            }
                return serverResponse;
            }
         }
    }