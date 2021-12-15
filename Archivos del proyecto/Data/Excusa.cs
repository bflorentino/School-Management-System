using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Excusa
    {
        public int IdExcusa { get; set; }
        public string Matricula { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Estudiante MatriculaNavigation { get; set; }
    }
}
