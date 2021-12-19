using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesLayer.DTOS.BindingModel
{
    public class NewAdminNotices
    {
        [Required]
        public int IdAviso { get; set; }

        [Required (ErrorMessage ="Se requieren los detalles del aviso")]
        public string DetalleAviso{ get; set; }

        [Required(ErrorMessage ="Se requiere seleccionar a quien va dirigido el aviso")]
        public string DirigidoA { get; set; }

        public DateTime Fecha { get; set; }
        
        [Required(ErrorMessage ="Se requiere la fecha hasta la que tendrá vigencia el aviso")]
        public DateTime VigenciaHasta { get; set; } 
    }
}
