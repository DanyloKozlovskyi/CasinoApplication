using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.Models
{
	public class User
	{
		[Key]
		public Guid Id { get; set; }
		[Required(ErrorMessage = "First Name can't be blank")]
		public string FirstName { get; set; } = string.Empty;
		[Required(ErrorMessage = "Last Name can't be blank")]
		public string LastName { get; set; } = string.Empty;
		[Required(ErrorMessage = "Email can't be blank")]
		[EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Phone Number can't be blank")]
		public string PhoneNumber { get; set; } = string.Empty;
	}
}
