using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace IAR.Models
{
	public class ActivityModel
	{
		[DisplayName("№")]
		public int Id { get; set; }

		[DisplayName("User")]
		public string Username { get; set; }

		[DisplayName("Activity")]
		public string Activity { get; set; }

		[DisplayName("Time spent (minutes)")]
		public short Activity_duration { get; set; }

		[DisplayName("Date")]
		[DataType(DataType.Date)]
		public DateTime Date_value { get; set; }
	}
}
