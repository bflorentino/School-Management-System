using System;

namespace ServicesLayer.DTOS.ViewModel
{
    public class ExcusesViewModel
    {
        public int IdExcusa { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }    
        public DateTime Fecha{ get; set; }
        public string Detalles { get; set; }
    }
}
