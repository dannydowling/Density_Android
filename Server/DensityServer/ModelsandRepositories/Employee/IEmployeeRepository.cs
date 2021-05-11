using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DensityServer.Shared;

namespace DensityServer.Api.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(string employeeId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        object DeleteEmployee(Employee employee);
    }
}
