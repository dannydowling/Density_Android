using DensityServer.Api.Models;
using DensityServer.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DensityServer.Api.Controllers
{
    [Authorize]
    [Route("Employee/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        
        //Post: Employee/employee
        [HttpPost("{id}")]
        public IActionResult AddEmployee(Employee employee)
        {
            return Ok(_employeeRepository.AddEmployee(employee));
        }

        [HttpDelete("/Delete/{id}")]
        public IActionResult DeleteEmployee(Employee employee)
        {
            return Ok(_employeeRepository.DeleteEmployee(employee));
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
