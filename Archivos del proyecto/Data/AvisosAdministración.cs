using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class AvisosAdministración
    {
        public int IdAviso { get; set; }
        public string DetalleAviso { get; set; }
        public string DirigidoA { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime VigenciaHasta { get; set; }
    }
}
