using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;

namespace ServicesLayer.Services.NoticesServices
{
    public interface IAdminNoticesCrud
    {
        public Task<bool> AddNewNotice(NewAdminNotices notice);
    }
}
