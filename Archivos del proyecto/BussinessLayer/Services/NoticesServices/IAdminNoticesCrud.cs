using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer;

namespace ServicesLayer.Services.NoticesServices
{
    public interface IAdminNoticesCrud
    {
        public Task<ServerResponse<string>> AddNewNotice(NewAdminNotices notice);
    }
}
