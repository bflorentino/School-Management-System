using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.DTOS.ViewModel;
using System.Collections.Generic;
using ServicesLayer.Services;
using ServicesLayer;


namespace ServicesLayer.Services.TeachersServices
{
    public interface IMaestrosCrud
    {
        public Task<ServerResponse<string>> AddTeacher(NewMaestro maestro);
        public Task<ServerResponse<List<MaestrosViewModel>>>GetAllTeachers()
    }
}
