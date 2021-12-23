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
         Task<ServerResponse<string>> AddTeacher(NewMaestro maestro);
         Task<ServerResponse<List<MaestrosViewModel>>> GetAllTeachers();
         Task<ServerResponse<List<MaestrosViewModel>>> GetTeachersBySubject(string codigo);
         Task<ServerResponse<string>> AddSubjectToTeacher(MateriasMaestrosBinding materia);
    }
}
