using ServicesLayer;
using ServicesLayer.DTOs.BindingModel;
using System.Threading.Tasks;

namespace ServicesLayer.Services.StudentServices
{
    public interface IEstudiantesCrud
    {
        Task<bool> AddNewStudent(NewStudent student);
    }
}
