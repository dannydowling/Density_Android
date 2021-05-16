using DensityServer.Api.Models;
using DensityServer.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DensityServer.Api.Controllers
{
    [Authorize(Policy = "CheckPassword")]
    [Authorize(Policy = "CheckFirstName")]
    [Authorize(Policy = "CheckLastName")]
    [Route("Employee/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository { get; set; }

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
        public IActionResult GetEmployeeById(string Id)
        {
            return Ok(_employeeRepository.GetEmployeeByName(Id));
        }
    }
}
