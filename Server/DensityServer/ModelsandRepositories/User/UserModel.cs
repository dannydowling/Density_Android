using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.ModelsandRepositories.User
{
    [Table("userModels", Schema = "Users")]
    public class UserModel : IdentityUser<Guid>
    {
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required"), DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        public bool IsEmailConfirmed { get { return EmailConfirmed; } set { EmailConfirmed = value; } }

        public DateTime? EmailConfirmationDate { get; set; }

        public int Score { get; set; }
    }
}
