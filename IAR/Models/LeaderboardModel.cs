using System.ComponentModel;


namespace IAR.Models
{
	public class LeaderboardModel
	{
		[DisplayName("Position")]
		public int Position { get; set; }

		[DisplayName("Username")]
		public string Username { get; set; }

		[DisplayName("Total hours")]
		public double TimeSpent { get; set; }		
	}
}
