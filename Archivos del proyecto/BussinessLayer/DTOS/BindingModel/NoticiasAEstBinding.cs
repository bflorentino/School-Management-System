using System;
using System.Collections.Generic;

namespace ServicesLayer.DTOS.BindingModel
{
    public class NoticiasAEstBinding
    {
        public int IdAviso { get; set; }
        public string CedulaMaestro { get; set; }
        public string DetalleAviso { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public TimeSpan HoraRegistrado { get; set; } = DateTime.Now.TimeOfDay;
        public DateTime VigenciaHasta { get; set; }
        public List<string> CodigoSecciones { get; set; }
    }
}