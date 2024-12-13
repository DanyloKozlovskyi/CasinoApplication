using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.Dtos
{
    public class UserCreate
    {
        [Required(ErrorMessage = "First Name can't be blank")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last Name can't be blank")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email can't be blank")]
        //[EmailAddress(ErrorMessage = "Email should be a valid email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number can't be blank")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
