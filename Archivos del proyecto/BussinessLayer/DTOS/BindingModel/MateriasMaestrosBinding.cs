using System;

namespace ServicesLayer.DTOS.BindingModel
{
    public class MateriasMaestrosBinding
    {
        public int IdAsignacion { get; set; } = new Random().Next(1000000, 10000000);
        public string Cedula { get; set; }
        public string CodigoMateria { get; set; }
    }
}
