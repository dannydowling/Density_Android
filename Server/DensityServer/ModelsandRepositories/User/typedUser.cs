using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DensityServer.Shared
{
    public class typedUser
    {
        [Key]
        public int userId { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "First name is too long.")]
        public string firstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name is too long.")]
        public string lastName { get; set; }

        [Required]
        public string location { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
