using System;
using ServicesLayer.DTOs.BindingModel;
using System.Threading.Tasks;
using ServicesLayer.Services;

namespace ServicesLayer.Bussiness
{
    public interface ISeccionesCrud
    {
        Task<ServerResponse<string>> CrearSeccion(NewSeccion seccion);
    }
}
