using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Services.NoticesServices;
using System.Threading.Tasks;

namespace ServicesLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminNoticesController : ControllerBase
    {
        IAdminNoticesCrud _adminNoticesCrud;

        public AdminNoticesController(IAdminNoticesCrud adminNoticesCrud)
        {
            _adminNoticesCrud = adminNoticesCrud;
        }

        public async Task<IActionResult> AddNewNotice(NewAdminNotices notice)
        {
            return Ok(await _adminNoticesCrud.AddNewNotice(notice));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _adminNoticesCrud.GetAllNotices());
        }
    }
}
