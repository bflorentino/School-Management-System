using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Materia
    {
        public Materia()
        {
            EstudiantesCalificaciones = new HashSet<EstudiantesCalificacione>();
            HistorialAsistencia = new HashSet<HistorialAsistencium>();
            MateriasMaestros = new HashSet<MateriasMaestro>();
        }

        public string CodigoMateria { get; set; }
        public string Nombre { get; set; }
        public int? IdArea { get; set; }

        public virtual AreasTecnica IdAreaNavigation { get; set; }
        public virtual ICollection<EstudiantesCalificacione> EstudiantesCalificaciones { get; set; }
        public virtual ICollection<HistorialAsistencium> HistorialAsistencia { get; set; }
        public virtual ICollection<MateriasMaestro> MateriasMaestros { get; set; }
    }
}
