using System.Collections.Generic;
using System.ComponentModel;


namespace IAR.Models
{
	public class LeaderboardAgregateModel
	{
		public string Activity { get; set; }

		[DisplayName("Your Position")]
		public int CurrentUserPosition { get; set; }

		[DisplayName("Username")]
		public string CurrentUserName { get; set; }

		[DisplayName("Your Total hours")]
		public double CurrentUserHours { get; set; }

		public List<LeaderboardModel> LeaderboardItems { get; set; }
	}
}
