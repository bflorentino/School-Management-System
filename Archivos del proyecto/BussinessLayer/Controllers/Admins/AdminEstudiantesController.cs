using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Bussiness;
using System.Threading.Tasks;
using ServicesLayer.Services.StudentServices;
using ServicesLayer.DTOs.BindingModel;
using Microsoft.AspNetCore.Authorization;

namespace ServicesLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = "1")]
    public class AdminEstudiantesController : ControllerBase
    {
        private readonly IEstudiantesCrud _estudiantesCrud;
        public AdminEstudiantesController(IEstudiantesCrud estudiantesCrud)
        {
            _estudiantesCrud = estudiantesCrud;
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> Post(NewStudent student)
        {
            return Ok(await _estudiantesCrud.AddNewStudent(student));
        }

        [Authorize (Roles = "1, 2")]
        [HttpGet("{codigosec}")]
        public async Task<IActionResult> Get(string codigosec)
        {
            return Ok(await _estudiantesCrud.GetStudentsBySection(codigosec));    
        }

        [Authorize(Roles = "1")]
        [HttpGet("reports/{matricula}")]    
        public async Task<IActionResult> GetReportes(string matricula)
        {
            return Ok(await _estudiantesCrud.GetReportesByStudent(matricula));
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public async Task<IActionResult>EditStudent(EditStudent student)
        {
            return Ok(await _estudiantesCrud.EditStudentInfo(student));
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{matricula}")]
        public async Task<IActionResult>DeleteStudent(string matricula)
        {
            return Ok(await _estudiantesCrud.DeleteStudent(matricula));
        }
    }
}