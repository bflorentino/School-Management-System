using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Services.TeachersServices;
using System.Threading.Tasks;

namespace ServicesLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class AdminMaestrosController : ControllerBase
    {
        private IMaestrosCrud _maestrosCrud;

        public AdminMaestrosController(IMaestrosCrud maestrosCrud)
        {
            _maestrosCrud = maestrosCrud;
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(NewMaestro maestro)
        {
            return Ok(await _maestrosCrud.AddTeacher(maestro));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _maestrosCrud.GetAllTeachers());
        }

        [HttpGet("{codMateria}")]
        public async Task<IActionResult> Get(string codMateria)
        {
            return Ok(await _maestrosCrud.GetTeachersBySubject(codMateria));
        }

        [HttpPost("materiaMaestro")]
        public async Task<IActionResult> AddMateriaMaestro(MateriasMaestrosBinding materia)
        {
            return Ok(await _maestrosCrud.AddSubjectToTeacher(materia));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacherInfo(EditMaestro maestro)
        {
            return Ok(await _maestrosCrud.EditTeacherInfo(maestro));
        }

        [HttpDelete("{cedula}")]
        public async Task<IActionResult> UpdateTeacherInfo(string cedula)
        {
            return Ok(await _maestrosCrud.DeleteTeacher(cedula));
        }
    }
}