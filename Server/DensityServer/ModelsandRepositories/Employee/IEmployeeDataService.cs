using System.Collections.Generic;
using System.Threading.Tasks;
using DensityServer.Shared;

namespace DensityServer.Server.Services
{
    public interface IEmployeeDataService
    {
        Task<EmployeeModel> GetEmployeeDetails(string name);
        Task<EmployeeModel> AddEmployee(EmployeeModel employee);
        Task<bool> UpdateEmployee(EmployeeModel employee);
        Task DeleteEmployee(string name);
    }
}
