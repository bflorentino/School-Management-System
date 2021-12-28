using System.ComponentModel.DataAnnotations;
using System;
using System.Text;

namespace ServicesLayer.DTOs.BindingModel
{
    public class NewStudent
    {
        [Required]
        public string Matricula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string NombrePadre { get; set; }

        [Required]
        public string NombreMadre { get; set; }

        [Required]
        public string CedulaPadre { get; set; }

        [Required]
        public string CedulaMadre { get; set; }

        [Required]
        public string Foto2x2 { get; set; }

        [Required]
        public int IDArea { get; set; }

        [Required]
        public string CodigoSeccion { get; set; }

        [Required]
        public bool Estatus { get; set; }

        public string NombreUsuario { get; set; }

        public string passwordSalt { get; set; } = "1234";
    }

    public class EditStudent
    {
        [Required]
        public string Matricula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string NombrePadre { get; set; }

        [Required]
        public string NombreMadre { get; set; }

        [Required]
        public string CedulaPadre { get; set; }

        [Required]
        public string CedulaMadre { get; set; }

        [Required]
        public string Foto2x2 { get; set; }

        [Required]
        public int IDArea { get; set; }

        [Required]
        public string CodigoSeccion { get; set; }

        [Required]
        public bool Estatus { get; set; }

        //[Required]
        //public string NombreUsuario { get; set; }
    }
}