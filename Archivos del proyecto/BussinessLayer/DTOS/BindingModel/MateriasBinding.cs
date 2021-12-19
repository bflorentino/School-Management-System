using System.ComponentModel.DataAnnotations;

namespace ServicesLayer.DTOS.BindingModel
{
    public class NewSubject
    {
        [Required]
        public string CodigoMateria { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int? IdArea { get; set; }    
    }
}