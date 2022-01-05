using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer;
using ServicesLayer.DTOS.ViewModel;
using System.Collections.Generic;

namespace ServicesLayer.Services.NoticesServices
{
    public interface IAdminNoticesCrud
    {
        public Task<ServerResponse<string>> AddNewNotice(NewAdminNotices notice);
        public Task<ServerResponse<List<AdminNoticesViewModel>>> GetAllNotices();
    }
}