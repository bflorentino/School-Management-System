using Data;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLayer.Services.StudentServices;

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

        public  async Task<bool> AddNewStudent(DTOs.BindingModel.NewStudent est)
        {
            // Agregar un nuevo estudiante

            Estudiante estudiante = map.Map<Estudiante>(est);

               await dbContext.AddAsync(estudiante);

               await dbContext.Usuarios.AddAsync(new Usuario
                {
                    NombreUsuario = est.NombreUsuario,
                    PasswordHash = PasswordEncrypter.Compute256Hash(est.passwordSalt),
                    IdRol = 3,
                    FotoPerfil = null
                });

                await dbContext.SaveChangesAsync();
                return true;
            }
         }
    }