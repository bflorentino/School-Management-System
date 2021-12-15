using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class ReportesAestudiante
    {
        public int CodigoReporte { get; set; }
        public string Matricula { get; set; }
        public string Causa { get; set; }
        public string CedulaMaestro { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Maestro CedulaMaestroNavigation { get; set; }
        public virtual Estudiante MatriculaNavigation { get; set; }
    }
}
