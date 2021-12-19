using Data;
using AutoMapper;
using ServicesLayer.Bussiness;
using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;

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

        public async Task<bool>AddTeacher(NewMaestro maestro)
        {
            Maestro mstro = map.Map<Maestro>(maestro);

            await dbContext.AddAsync(mstro);

            await dbContext.Usuarios.AddAsync(new Usuario
            {
                NombreUsuario = maestro.NombreUsuario,
                PasswordHash = PasswordEncrypter.Compute256Hash(maestro.passwordSalt),
                IdRol = 2,
                FotoPerfil = null
            });

            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}