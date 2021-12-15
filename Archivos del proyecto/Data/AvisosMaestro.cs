using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class AvisosMaestro
    {
        public AvisosMaestro()
        {
            AvisosCursos = new HashSet<AvisosCurso>();
        }

        public int IdAviso { get; set; }
        public string CedulaMaestro { get; set; }
        public string DetalleAviso { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraRegistrado { get; set; }
        public DateTime VigenciaHasta { get; set; }

        public virtual Maestro CedulaMaestroNavigation { get; set; }
        public virtual ICollection<AvisosCurso> AvisosCursos { get; set; }
    }
}
