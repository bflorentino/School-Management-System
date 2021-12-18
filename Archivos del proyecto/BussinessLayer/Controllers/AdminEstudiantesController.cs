using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Bussiness;
using System.Threading.Tasks;
using ServicesLayer.Services.StudentServices;
using ServicesLayer.DTOs.BindingModel;

namespace ServicesLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminEstudiantesController : ControllerBase
    {
        private readonly  IEstudiantesCrud _estudiantesCrud;
        public AdminEstudiantesController(IEstudiantesCrud estudiantesCrud)
        {
            _estudiantesCrud = estudiantesCrud;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStudent(NewStudent student)
        {
            return Ok(await _estudiantesCrud.AddNewStudent(student));
        }
    }
}