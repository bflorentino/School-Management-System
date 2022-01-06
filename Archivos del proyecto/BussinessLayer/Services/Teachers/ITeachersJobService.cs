using System.Threading.Tasks;
using System.Collections.Generic;
using ServicesLayer;
using ServicesLayer.DTOS.ViewModel;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Services.Teachers;

namespace ServicesLayer.Services.Teachers
{
    public interface ITeachersJobService
    {
        Task<ServerResponse<List<Teachers_Sections_ViewModel>>> GetJobSections(string cedula);
        Task<ServerResponse<List<AdminNoticesViewModel>>> GetNewNotices();
        Task<ServerResponse<List<ExcusesViewModel>>> GetExcuses(string section);
        Task<ServerResponse<string>> AddReportToStudent(ReportesAEstBinding report);
    }
}