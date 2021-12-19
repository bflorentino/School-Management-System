using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;

namespace ServicesLayer.Services.TeachersServices
{
    public interface IMaestrosCrud
    {
        public Task<bool> AddTeacher(NewMaestro maestro);
    }
}
