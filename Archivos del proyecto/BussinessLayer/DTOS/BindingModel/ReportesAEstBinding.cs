using System;

namespace ServicesLayer.DTOS.BindingModel
{
    public class ReportesAEstBinding
    {
        public int CodigoReporte { get; set; }
        public string Matricula { get; set; }
        public string Causa { get; set; }
        public string CedulaMaestro { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}