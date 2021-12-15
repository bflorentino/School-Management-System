using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Maestro
    {
        public Maestro()
        {
            AvisosMaestros = new HashSet<AvisosMaestro>();
            MateriasMaestros = new HashSet<MateriasMaestro>();
            ReportesAestudiantes = new HashSet<ReportesAestudiante>();
        }

        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int? IdArea { get; set; }

        public virtual AreasTecnica IdAreaNavigation { get; set; }
        public virtual ICollection<AvisosMaestro> AvisosMaestros { get; set; }
        public virtual ICollection<MateriasMaestro> MateriasMaestros { get; set; }
        public virtual ICollection<ReportesAestudiante> ReportesAestudiantes { get; set; }
    }
}
