using System;

namespace ServicesLayer.DTOS.ViewModel
{
    public class StudentsViewModel
    {
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
    }
}
