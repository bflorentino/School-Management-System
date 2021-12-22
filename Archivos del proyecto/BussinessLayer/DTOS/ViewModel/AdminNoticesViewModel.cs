using System;

namespace ServicesLayer.DTOS.ViewModel
{
    public class AdminNoticesViewModel
    {
        public int IdAviso { get; set; }

        public string DetalleAviso { get; set; }

        public string DirigidoA { get; set; }

        public DateTime Fecha { get; set; } 

        public DateTime VigenciaHasta { get; set; }
    }
}
