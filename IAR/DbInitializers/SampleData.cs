using IAR.Context;
using IAR.Models;
using System;
using System.Linq;

namespace IAR.DbInitializers
{
	public class SampleData
	{
		public static void Initialize(AppDbContext context)
		{
            if (!context.ActivityTypes.Any())
            {
                context.ActivityTypes.AddRange(
                    new ActivityTypeModel 
                    {                          
                        Activity = "Programming" 
                    }
                );
                context.SaveChanges();
            }

            if (!context.Activities.Any())
            {
                context.Activities.AddRange(
                    new ActivityModel 
                    {                          
                        Username = "Ivan", 
                        Activity = "Programming", 
                        Activity_duration = 180, 
                        Date_value = new DateTime(2022, 03, 01)
                    },
                    new ActivityModel
                    {                        
                        Username = "Maria",
                        Activity = "Programming",
                        Activity_duration = 12000,
                        Date_value = new DateTime(2022, 03, 01)
                    }
                );
                context.SaveChanges();
            }
        }
	}
}
