using System.ComponentModel;


namespace IAR.Models
{
	public class GoalModel
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Activity { get; set; }

		[DisplayName("Goal (hours)")]
		public int Goal { get; set; }

		[DisplayName("Current (total hours)")]
		public double CurrentUserHours { get; set; }
	}
}
