using System.Collections.Generic;
using System.Linq;
using DensityServer.Shared;
using DensityServer.Data;

namespace DensityServer.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {

            return _appDbContext.employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _appDbContext.employees.FirstOrDefault(c => c.Id == employeeId);
        }

        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = _appDbContext.employees.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var foundEmployee = _appDbContext.employees.FirstOrDefault(e => e.Id == employee.Id);

            if (foundEmployee != null)
            {
                
                foundEmployee.city = employee.city;
                foundEmployee.email = employee.email;
                foundEmployee.firstName = employee.firstName;
                foundEmployee.lastName = employee.lastName;
                foundEmployee.street = employee.street;
                foundEmployee.password = employee.password;
                

        _appDbContext.SaveChanges();

                return foundEmployee;
            }

            return null;
        }

        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _appDbContext.employees.FirstOrDefault(e => e.Id == employeeId);
            if (foundEmployee == null) return;

            _appDbContext.employees.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }
    }
}
