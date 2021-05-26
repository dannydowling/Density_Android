using System.Collections.Generic;
using System.Linq;
using DensityServer.Shared;
using DensityServer.Data;

namespace DensityServer.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private UserModelsDbContext _appDbContext { get; set; }

        public EmployeeRepository(UserModelsDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {

            return _appDbContext.employeeModels;
        }

        public EmployeeModel GetEmployeeByName(string name)
        {
            return _appDbContext.employeeModels.Single(c => c.FirstName + " " + c.LastName == name);
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            var addedEntity = _appDbContext.employeeModels.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public EmployeeModel UpdateEmployee(EmployeeModel employee)
        {
            employee = _appDbContext.employeeModels.Single(
                e => e.FirstName + " " + e.LastName == employee.FirstName + " " + employee.LastName);
            _appDbContext.SaveChanges();
            return employee;
        }

        public object DeleteEmployee(EmployeeModel employee)
        {
            var foundEmployee = _appDbContext.employeeModels.Single(
                e => e.FirstName + " " + e.LastName == employee.FirstName + " " + employee.LastName);
            _appDbContext.employeeModels.Remove(foundEmployee);
            return _appDbContext.SaveChanges();
        }
    }
}
