using EmployeeAnnualSalary.Api.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeAnnualSalary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IDataService _service;

        public EmployeesController(IDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetEmployeesById(id));
        }

        [HttpGet]
        [Route("/mockdata")]
        public async Task<IActionResult> InsertMockData()
        {
            return Ok(await _service.InsertMockData());
        }
    }
}
