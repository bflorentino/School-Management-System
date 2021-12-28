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
        private readonly IEstudiantesCrud _estudiantesCrud;
        public AdminEstudiantesController(IEstudiantesCrud estudiantesCrud)
        {
            _estudiantesCrud = estudiantesCrud;
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewStudent student)
        {
            return Ok(await _estudiantesCrud.AddNewStudent(student));
        }

        [HttpGet("{codigosec}")]
        public async Task<IActionResult> Get(string codigosec)
        {
            return Ok(await _estudiantesCrud.GetStudentsBySection(codigosec));
        }

        [HttpGet("reports/{matricula}")]    
        public async Task<IActionResult> GetReportes(string matricula)
        {
            return Ok(await _estudiantesCrud.GetReportesByStudent(matricula));
        }

        [HttpPut]
        public async Task<IActionResult>EditStudent(EditStudent student)
        {
            return Ok(await _estudiantesCrud.EditStudentInfo(student));
        }

        [HttpDelete("{matricula}")]
        public async Task<IActionResult>DeleteStudent(string matricula)
        {
            return Ok(await _estudiantesCrud.DeleteStudent(matricula));
        }
    }
}