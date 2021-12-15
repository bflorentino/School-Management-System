using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Seccione
    {
        public Seccione()
        {
            AvisosCursos = new HashSet<AvisosCurso>();
            MaestrosAulas = new HashSet<MaestrosAula>();
        }

        public string CodigoSeccion { get; set; }
        public int IdArea { get; set; }
        public string Nivel { get; set; }
        public string Seccion { get; set; }
        public int? Aula { get; set; }

        public virtual AreasTecnica IdAreaNavigation { get; set; }
        public virtual ICollection<AvisosCurso> AvisosCursos { get; set; }
        public virtual ICollection<MaestrosAula> MaestrosAulas { get; set; }
    }
}
