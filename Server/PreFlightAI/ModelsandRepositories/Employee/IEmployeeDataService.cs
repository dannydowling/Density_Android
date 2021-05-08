using System.Collections.Generic;
using System.Threading.Tasks;
using DensityServer.Shared;

namespace DensityServer.Server.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllEmployees(IEnumerable<Location> employeeLocations);
        Task<Employee> GetEmployeeDetails(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
    }
}
