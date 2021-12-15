using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class AreasTecnica
    {
        public AreasTecnica()
        {
            Maestros = new HashSet<Maestro>();
            Materia = new HashSet<Materia>();
            Secciones = new HashSet<Seccione>();
        }

        public int IdArea { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Maestro> Maestros { get; set; }
        public virtual ICollection<Materia> Materia { get; set; }
        public virtual ICollection<Seccione> Secciones { get; set; }
    }
}
