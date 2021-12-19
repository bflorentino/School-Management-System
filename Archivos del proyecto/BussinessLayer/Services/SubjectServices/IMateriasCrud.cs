using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;

namespace ServicesLayer.Services.SubjectServices
{
    public interface IMateriasCrud
    {
        public Task<bool> AddSubject(NewSubject materia);
    }
}