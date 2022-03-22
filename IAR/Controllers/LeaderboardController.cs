using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IAR.Models;
using IAR.Services;


namespace IAR.Controllers
{
	public class LeaderboardController : Controller
	{
		public IActionResult Index()
		{
			//формирование модели для передачи в Представление
			LeaderboardAgregateModel leaderboardAgregateModel = new LeaderboardAgregateModel();

			if (ActivityLeaderboardCurrent.IsChanged)
			//если пользователь выбрал все необходимые данные из выпадающего списка в Представлении
			{	
				//получаем выгрузку суммарного времени по всем пользователям
				ActivityService activityService = new ActivityService();
				leaderboardAgregateModel.LeaderboardItems = activityService.GetUsersDataForLeaderboard();

				//получаем данные текущего пользователя
				LeaderboardModel leaderboardModel = 
					leaderboardAgregateModel.LeaderboardItems.Find( x => x.Username == UserCurrent.Username);
				leaderboardAgregateModel.CurrentUserPosition = leaderboardModel.Position;
				leaderboardAgregateModel.CurrentUserName = leaderboardModel.Username;
				leaderboardAgregateModel.CurrentUserHours = leaderboardModel.TimeSpent;
			}
			else
			//если пользователь НЕ выбрал данные из выпадающего списка в Представлении (страница открыта впервые)
			{
				leaderboardAgregateModel.LeaderboardItems = new List<LeaderboardModel>();
				leaderboardAgregateModel.LeaderboardItems.Add(new LeaderboardModel 
					{ 
						Position = 0, 
						Username = "Select some Activity to show data", 
						TimeSpent = 0 
					}
				);

				leaderboardAgregateModel.CurrentUserPosition = 0;
				leaderboardAgregateModel.CurrentUserName = UserCurrent.Username;
				leaderboardAgregateModel.CurrentUserHours = 0;
			}

			//получение дынных из таблицы фактических исторических записей по конкретному(текущему) юзеру
			//для формирования выпадающего списка опций выбора Активностей для лидерборда.
			ChartService chartService = new ChartService();
			ViewBag.TableActivities = chartService.GetHistoricalActivities();

			//для передачи в представление (View) конкретного варианта для отображения в выпадающем списке,
			//этот вариант должен обязательно присутствовать в сформированном ViewBag'е
			//в противном случае этот вариант отображаться не будет
			leaderboardAgregateModel.Activity = ActivityLeaderboardCurrent.CurrentActivity;

			return View(leaderboardAgregateModel);
		}


		public IActionResult UpdateLeaderboard(LeaderboardAgregateModel leaderboardAgregateModel)
		{
			ActivityLeaderboardCurrent.CurrentActivity = leaderboardAgregateModel.Activity;

			if(!ActivityLeaderboardCurrent.IsChanged) 
				ActivityLeaderboardCurrent.IsChanged = true;

			return RedirectToAction("Index");
		}
	}
}