using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DensityServer.Shared
{
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name is too long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }

       
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        
        [Timestamp]
        public byte[] rowVersion { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Employee(string employeeId, string firstName, string lastName, string email, string street, string zip, string city, string password)
        {
            if (string.IsNullOrEmpty(employeeId))
            {   EmployeeId = Guid.NewGuid().ToString();    }
            EmployeeId = employeeId;
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
