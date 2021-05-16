using System.Collections.Generic;
using System.Threading.Tasks;
using DensityServer.Shared;

namespace DensityServer.Server.Services
{
    public interface IEmployeeDataService
    {
        Task<Employee> GetEmployeeDetails(string name);
        Task<Employee> AddEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task DeleteEmployee(string name);
    }
}
