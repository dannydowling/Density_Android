using DensityServer.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DensityServer.Api.Controllers
{
    [Route("employee/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: employee/<controller>
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeRepository.GetAllEmployees());
        }

        // GET employee/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int Id)
        {
            return Ok(_employeeRepository.GetEmployeeById(Id));
        }
    }
}
