using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class AvisosCurso
    {
        public int IdAviso { get; set; }
        public string CodigoSeccion { get; set; }

        public virtual Seccione CodigoSeccionNavigation { get; set; }
        public virtual AvisosMaestro IdAvisoNavigation { get; set; }
    }
}
