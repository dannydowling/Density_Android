using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DensityServer.Shared;

namespace DensityServer.Api.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeModel> GetAllEmployees();
        EmployeeModel GetEmployeeByName(string employeeId);
        EmployeeModel AddEmployee(EmployeeModel employee);
        EmployeeModel UpdateEmployee(EmployeeModel employee);
        object DeleteEmployee(EmployeeModel employee);
    }
}
