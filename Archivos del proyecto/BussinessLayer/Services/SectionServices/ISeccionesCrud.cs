using System;
using ServicesLayer.DTOs.BindingModel;
using System.Threading.Tasks;

namespace ServicesLayer.Bussiness
{
    public interface ISeccionesCrud
    {
        Task<bool> CrearSeccion(NewSeccion seccion);
    }
}
