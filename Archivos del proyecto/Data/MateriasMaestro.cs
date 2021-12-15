using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class MateriasMaestro
    {
        public MateriasMaestro()
        {
            MaestrosAulas = new HashSet<MaestrosAula>();
        }

        public int IdAsignacion { get; set; }
        public string Cedula { get; set; }
        public string CodigoMateria { get; set; }

        public virtual Maestro CedulaNavigation { get; set; }
        public virtual Materia CodigoMateriaNavigation { get; set; }
        public virtual ICollection<MaestrosAula> MaestrosAulas { get; set; }
    }
}
