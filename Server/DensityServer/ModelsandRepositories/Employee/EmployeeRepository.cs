using System.Collections.Generic;
using System.Linq;
using DensityServer.Shared;
using DensityServer.Data;

namespace DensityServer.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _appDbContext { get; set; }

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {

            return _appDbContext.employees;
        }

        public Employee GetEmployeeById(string employeeId)
        {
            return _appDbContext.employees.Single(c => c.EmployeeId == employeeId);
        }

        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = _appDbContext.employees.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            employee = _appDbContext.employees.Single(e => e.EmployeeId == employee.EmployeeId);
            _appDbContext.SaveChanges();
            return employee;
        }

        public object DeleteEmployee(Employee employee)
        {
            var foundEmployee = _appDbContext.employees.Single(e => e.EmployeeId == employee.EmployeeId);
            _appDbContext.employees.Remove(foundEmployee);
            return _appDbContext.SaveChanges();
        }
    }
}
