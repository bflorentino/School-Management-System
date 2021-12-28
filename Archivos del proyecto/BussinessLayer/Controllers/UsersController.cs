using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Services;
using ServicesLayer.Services.UsersServices;

namespace ServicesLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserAuth _userAuth;

        public UsersController(IUserAuth userAuth)
        {
            this._userAuth = userAuth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Autentificar(UsuarioBinding usuario)
        {
            ServerResponse<userAuthResponse> serverResponse = new ServerResponse<userAuthResponse>();
            var user = await _userAuth.GetUser(usuario);

            if (user == null)
            {
                serverResponse.Success = false;
                return BadRequest(serverResponse);
            }

            serverResponse.Data = user;

            return Ok(serverResponse);
        }
    }
}
