using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class EstudiantesCalificacione
    {
        public int CodigoCalificacion { get; set; }
        public string Matricula { get; set; }
        public string CodigoMateria { get; set; }
        public int Periodo { get; set; }

        public virtual Materia CodigoMateriaNavigation { get; set; }
        public virtual Estudiante MatriculaNavigation { get; set; }
    }
}
