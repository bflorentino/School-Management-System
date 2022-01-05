using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer;

namespace ServicesLayer.Services.SubjectServices
{
    public interface IMateriasCrud
    {
        public Task<ServerResponse<string>> AddSubject(NewSubject materia);
    }
}