using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PreFlightAI.Shared
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name is too long.")]
        public string firstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name is too long.")]
        public string lastName { get; set; }

       
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string street { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        

        [StringLength(1000, ErrorMessage = "Comment length can't exceed 1000 characters.")]
       

        [Timestamp]
        public byte[] rowVersion { get; set; }


        [DataType(DataType.Password)]
        public string password { get; set; }
              
    }
}
