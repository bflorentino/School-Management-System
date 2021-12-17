using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Bussiness;

namespace ServicesLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminEstudiantesController : ControllerBase
    {
        private readonly  EstudiantesCrud _estudiantesCrud;
        public AdminEstudiantesController(EstudiantesCrud estudiantesCrud)
        {
            _estudiantesCrud = estudiantesCrud;
        }
    }
}