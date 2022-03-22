using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace IAR.Models
{
	public class UserRegistrationModel
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Username")]
		public string UserName { get; set; }

		[DisplayName("Password")]
		public string Password { get; set; }

		[DisplayName("Confirm Password")]
		public string Password2 { get; set; }
	}
}
