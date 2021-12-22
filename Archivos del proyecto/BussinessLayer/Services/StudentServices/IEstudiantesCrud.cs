using ServicesLayer;
using ServicesLayer.DTOs.BindingModel;
using System.Threading.Tasks;
using ServicesLayer.Services;
using System.Collections.Generic;
using ServicesLayer.DTOS.ViewModel;

namespace ServicesLayer.Services.StudentServices
{
    public interface IEstudiantesCrud
    {
        Task<ServerResponse<string>> AddNewStudent(NewStudent student);
        Task<ServerResponse<List<StudentsViewModel>>>GetStudentsBySection(string seccion);

    }
}