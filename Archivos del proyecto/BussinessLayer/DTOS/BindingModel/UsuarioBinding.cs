using System.ComponentModel.DataAnnotations;

namespace ServicesLayer.DTOS.BindingModel
{
    public class UsuarioBinding
    {
        [Required]
        public string NombreUsuario { get; set; }
        
        [Required] 
        public string PasswordSalt { get; set; }
    }
}
