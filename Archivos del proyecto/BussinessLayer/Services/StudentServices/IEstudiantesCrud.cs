using ServicesLayer;
using ServicesLayer.DTOs.BindingModel;
using System.Threading.Tasks;
using ServicesLayer.Services;

namespace ServicesLayer.Services.StudentServices
{
    public interface IEstudiantesCrud
    {
        Task<ServerResponse<string>> AddNewStudent(NewStudent student);
    }
}