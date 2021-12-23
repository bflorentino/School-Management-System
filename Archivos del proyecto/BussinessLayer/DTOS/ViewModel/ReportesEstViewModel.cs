using System;

namespace ServicesLayer.DTOS.ViewModel
{
    public class ReportesEstViewModel
    {
        public int CodigoReporte { get; set; }
        public string Matricula { get; set; }
        public string Causa { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre {get; set;}
    }
}