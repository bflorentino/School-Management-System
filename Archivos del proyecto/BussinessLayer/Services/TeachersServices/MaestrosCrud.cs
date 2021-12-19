using System;
using Data;
using AutoMapper;
using ServicesLayer.Bussiness;
using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Services;

namespace ServicesLayer.Services.TeachersServices
{
    public class MaestrosCrud: IMaestrosCrud
    {
        private readonly School_Manage_SystemContext dbContext = DBaseContext.GetContexto().Ctxto;
        private readonly IMapper map;

        public MaestrosCrud (IMapper mapper)
        {
            map = mapper;
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
                serverResponse.Message = ex.Message;
                serverResponse.Success = false;
            }

            return serverResponse;
        }
    }
}