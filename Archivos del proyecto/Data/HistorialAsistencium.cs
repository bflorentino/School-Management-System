using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class HistorialAsistencium
    {
        public int Codigo { get; set; }
        public string Matricula { get; set; }
        public string CodigoMateria { get; set; }
        public DateTime Fecha { get; set; }
        public bool Asistencia { get; set; }

        public virtual Materia CodigoMateriaNavigation { get; set; }
        public virtual Estudiante MatriculaNavigation { get; set; }
    }
}
