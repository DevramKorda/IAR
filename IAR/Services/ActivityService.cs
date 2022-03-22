using IAR.Context;
using IAR.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace IAR.Services
{
	public class ActivityService
	{
		private AppDbContext db = new AppDbContext(OptionsBuilder.optionsBuilder.Options);


		public List<ActivityModel> GetAllActivities()
		{			
			var activities = from a in db.Activities
							 where a.Username == UserCurrent.Username
							 select a;

			List<ActivityModel> activitiesList = activities.ToList<ActivityModel>();
			activitiesList.Reverse();

			return activitiesList;
		}		


		public void AddNewActivity(ActivityModel activityModel)
		{			
			activityModel.Username = UserCurrent.Username;

			db.Activities.Add(activityModel);
			db.SaveChanges();			
		}


		public void DeleteActivity(ActivityModel activityModel)
		{			
			db.Activities.Remove(activityModel);
			db.SaveChanges();			
		}


		public List<LeaderboardModel> GetUsersDataForLeaderboard()
		{
			List<LeaderboardModel> usersDataList = new List<LeaderboardModel>();
			
			//делаем выборку данных по нужной Активности с группировкой по Пользователю
			var usersDataSet = from a in db.Activities
								where 
								a.Activity == ActivityLeaderboardCurrent.CurrentActivity
								group a by a.Username into g
								select new { Username = g.Key, Sum = g.Sum(g => g.Activity_duration) };

			//форматируем выборку в List<>
			foreach (var e in usersDataSet)
			{
				usersDataList.Add(new LeaderboardModel { Username = e.Username, TimeSpent = e.Sum });
			}			

			//сортируем по убыванию по количеству потраченного времени (суммы в минутах)
			usersDataList.Sort((x,  y) =>
			{
				if (x.TimeSpent > y.TimeSpent ) 
					return -1;
				else
					return 1;					
			});

			//проставляем порядковый номер и переводим минуты в часы
			for(int i = 0; i < usersDataList.Count; i++)
			{
				usersDataList[i].Position = i + 1;

				double whole = (double)((int)usersDataList[i].TimeSpent / 60);
				double partial = ((usersDataList[i].TimeSpent - (60 * whole)) / 100) * 1.67;
				usersDataList[i].TimeSpent = Math.Round(whole + partial, 1);				
			}

			return usersDataList;
		}
	}
}