using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;

namespace ServicesLayer.Services.UsersServices
{
    public interface IUserAuth
    {
        Task<userAuthResponse> GetUser(UsuarioBinding user);
    }
}
