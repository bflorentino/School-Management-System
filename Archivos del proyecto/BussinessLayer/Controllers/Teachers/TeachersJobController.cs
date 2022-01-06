using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Services.Teachers;
using System.Threading.Tasks;

namespace ServicesLayer.Controllers.Teachers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "2")]
    public class TeachersJobController : ControllerBase
    {
        private readonly ITeachersJobService _jobService;

        public TeachersJobController(ITeachersJobService teachersJobService)
        {
            _jobService = teachersJobService;
        }

        [HttpGet("{cedula}")]
       public async Task<IActionResult> Get(string cedula)
        {
            return Ok(await _jobService.GetJobSections(cedula));
        }

        [HttpGet("Viewnotices")]
        public async Task<IActionResult> GetJobSections()
        {
            return Ok(await _jobService.GetNewNotices());
        }

        [HttpGet("ViewExcuses/{section}")]
        public async Task<IActionResult> GetExcuses(string section)
        {
            return Ok(await _jobService.GetExcuses(section));
        }

        [HttpPost("Report")]
        public async Task<IActionResult>AddNewReport(ReportesAEstBinding report)
        {
            return Ok(await _jobService.AddReportToStudent(report));
        }
    }
}