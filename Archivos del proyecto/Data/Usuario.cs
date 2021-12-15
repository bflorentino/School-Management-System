using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Usuario
    {
        public string NombreUsuario { get; set; }
        public string PasswordHash { get; set; }
        public string FotoPerfil { get; set; }
        public int IdRol { get; set; }

        public virtual Role IdRolNavigation { get; set; }
    }
}
