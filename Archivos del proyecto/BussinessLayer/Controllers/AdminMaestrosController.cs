using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Services.TeachersServices;
using System.Threading.Tasks;

namespace ServicesLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMaestrosController : ControllerBase
    {
        private IMaestrosCrud _maestrosCrud;

        public AdminMaestrosController(IMaestrosCrud maestrosCrud)
        {
            _maestrosCrud = maestrosCrud;
        }

        [HttpPost]
        public async Task<IActionResult>AddTeacher(NewMaestro maestro)
        {
            return Ok(await _maestrosCrud.AddTeacher(maestro));
        }
    }
}
