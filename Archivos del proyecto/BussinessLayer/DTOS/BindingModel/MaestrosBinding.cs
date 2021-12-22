using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesLayer.DTOS.BindingModel
{
    public class NewMaestro
    {
        [Required]
        public string Cedula { get; set; }
        
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Telefono { get; set; }
        
        public string CorreoElectronico{ get; set; }

        public int? IdArea { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public string NombreUsuario { get; set; }
        
        [Required]
        public string passwordSalt { get; set; }
    }
}
