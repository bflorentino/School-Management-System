using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ServicesLayer.Bussiness;
using Microsoft.AspNetCore.Authorization;

namespace ServicesLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class AdminSeccionesController : ControllerBase
    {
        private readonly ISeccionesCrud _seccionesCrud;
        public AdminSeccionesController(ISeccionesCrud  seccionesCrud)
        {
            _seccionesCrud = seccionesCrud;
        }

        [HttpPost]
        public async Task<IActionResult> AddSeccion(DTOs.BindingModel.NewSeccion seccion)
        {
            return Ok(await _seccionesCrud.CrearSeccion(seccion));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _seccionesCrud.GetAllSections());
        }
    }
}