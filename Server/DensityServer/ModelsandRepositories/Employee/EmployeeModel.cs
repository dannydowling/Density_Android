using DensityServer.ModelsandRepositories.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DensityServer.Shared
{
    [Table("employeeModels", Schema = "Employees")]
    public class EmployeeModel : UserModel
    {
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public EmployeeModel(string firstName, string lastName, string email, string street, string zip, string city, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Street = street;
            Zip = zip;
            City = city;
            Password = password;
        }
              
    }
}
