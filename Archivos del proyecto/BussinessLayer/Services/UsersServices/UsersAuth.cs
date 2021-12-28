using Data;
using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.Bussiness;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;

namespace ServicesLayer.Services.UsersServices
{
    public class UsersAuth: IUserAuth
    {
        private readonly School_Manage_SystemContext dbContext;
        private readonly AppSettings _appSettings;

        public UsersAuth(School_Manage_SystemContext dbContext, IOptions<AppSettings> appSettings )
        {
            this.dbContext = dbContext;
            this._appSettings = appSettings.Value;
        }


        public async Task<userAuthResponse> GetUser(UsuarioBinding user)
        {
           userAuthResponse userAuthResponse = new userAuthResponse();
            
           var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == user.NombreUsuario && 
                                                                                               u.PasswordHash == PasswordEncrypter.Compute256Hash(user.PasswordSalt));

            if (usuario != null)
            {
                userAuthResponse.UserName = usuario.NombreUsuario;
                userAuthResponse.Token = GetToken(usuario);
               
                return userAuthResponse;
            }

            return null;
        }

        private string GetToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key=  Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.NombreUsuario),
                    new Claim(ClaimTypes.Role, user.IdRol.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
