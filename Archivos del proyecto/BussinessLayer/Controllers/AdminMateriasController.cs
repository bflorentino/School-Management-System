using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Services.SubjectServices;
using System.Threading.Tasks;

namespace ServicesLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMateriasController : ControllerBase
    {
        private IMateriasCrud _materiasCrud;

        public AdminMateriasController(IMateriasCrud materias)
        {
            _materiasCrud = materias;
        }

        [HttpPost]
        public async Task<IActionResult>AddSubjetct(NewSubject materia)
        {
            return Ok(await _materiasCrud.AddSubject(materia));
        }
    }
}
