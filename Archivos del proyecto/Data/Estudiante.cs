using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            EstudiantesCalificaciones = new HashSet<EstudiantesCalificacione>();
            Excusas = new HashSet<Excusa>();
            HistorialAsistencia = new HashSet<HistorialAsistencium>();
            ReportesAestudiantes = new HashSet<ReportesAestudiante>();
        }

        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string NombrePadre { get; set; }
        public string NombreMadre { get; set; }
        public string CedulaPadre { get; set; }
        public string CedulaMadre { get; set; }
        public string Foto2x2 { get; set; }
        public int IdArea { get; set; }
        public string CodigoSeccion { get; set; }
        public bool Estatus { get; set; }

        public virtual Seccione CodigoSeccionNavigation { get; set; }
        public virtual ICollection<EstudiantesCalificacione> EstudiantesCalificaciones { get; set; }
        public virtual ICollection<Excusa> Excusas { get; set; }
        public virtual ICollection<HistorialAsistencium> HistorialAsistencia { get; set; }
        public virtual ICollection<ReportesAestudiante> ReportesAestudiantes { get; set; }
    }
}
