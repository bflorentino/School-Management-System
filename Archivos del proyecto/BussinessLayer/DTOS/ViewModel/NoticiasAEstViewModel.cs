using System;
using System.Collections.Generic;

namespace ServicesLayer.DTOS.ViewModel
{
    public class NoticiasAEstViewModel
    {
        public int IdAviso { get; set; }
        public string CedulaMaestro { get; set; }
        public string DetalleAviso { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraRegistrado { get; set; }
        public DateTime VigenciaHasta { get; set; }
        public List<string> CodigoSecciones { get; set; }   
    }
}
