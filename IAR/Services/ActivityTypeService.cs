using IAR.Context;
using IAR.Models;
using System.Collections.Generic;
using System.Linq;


namespace IAR.Services
{
	public class ActivityTypeService
	{
		private AppDbContext db = new AppDbContext(OptionsBuilder.optionsBuilder.Options);


		public List<ActivityTypeModel> GetActivitiesList()
		{			
			return db.ActivityTypes.ToList<ActivityTypeModel>();
		}
	}
}