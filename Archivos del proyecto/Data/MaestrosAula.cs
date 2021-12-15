using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class MaestrosAula
    {
        public int IdAsignacion { get; set; }
        public string CodigoSeccion { get; set; }

        public virtual Seccione CodigoSeccionNavigation { get; set; }
        public virtual MateriasMaestro IdAsignacionNavigation { get; set; }
    }
}
