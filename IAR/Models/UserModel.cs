using System.ComponentModel;


namespace IAR.Models
{
	public class UserModel
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Username")]
		public string UserName { get; set; }

		[DisplayName("Password")]
		public string Password { get; set; }
	}
}
