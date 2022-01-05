using System.Threading.Tasks;
using System.Collections.Generic;
using ServicesLayer;
using ServicesLayer.DTOS.ViewModel;
using ServicesLayer.Services.Teachers;

namespace ServicesLayer.Services.Teachers
{
    public interface ITeachersJobService
    {
        Task<ServerResponse<List<Teachers_Sections_ViewModel>>> GetJobSections(string cedula);
    }
}
