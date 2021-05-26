using DensityServer.Api.Models;
using DensityServer.Data;
using DensityServer.ModelsandRepositories.User;
using DensityServer.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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

        //the constructor, injects the user database into the employee repository.
        //need to work on the filtering to select users that match the employee model.
        public EmployeeController(IEmployeeRepository employeeRepository, [FromServices] UserModelsDbContext userDb )
        {
            _employeeRepository = employeeRepository;
            foreach (EmployeeModel user in userDb.userModels)
            {
                _employeeRepository = (IEmployeeRepository)userDb.Add(user);
            }                      
        }
                
        //Post: Employee/employee
        [HttpPost("{id}")]
        public IActionResult AddEmployee(EmployeeModel employee)
        {            
            return Ok(_employeeRepository.AddEmployee(employee));
        }

        [HttpDelete("/Delete/{id}")]
        public IActionResult DeleteEmployee(EmployeeModel employee)
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
