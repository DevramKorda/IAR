using IAR.Models;
using IAR.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace IAR.Controllers
{
	public class ActivitiesController : Controller
	{
		const int pageSize = 100; //для пагинации (количество строк на странице)

		private ActivityService activityService = new ActivityService();
		private ActivityTypeService activityListService = new ActivityTypeService();		


		public IActionResult Index(int pg = 1)
		{
			//для пагинации и вывода всех активностей на экран
			List<ActivityModel> activityData = activityService.GetAllActivities();

			//Пагинация - НАЧАЛО
			////подсчёт общего количества строк
			int recsCount = activityData.Count;

			////инициализация объекта пагинации
			PagerModel pager = new PagerModel(recsCount, pg, pageSize);

			////рассчёт - сколько строк надо проигнорировать в начале и конце
			int recSkipBegin = (pg - 1) * pageSize;
			int recSkipEnd = recsCount - recSkipBegin - pageSize;
			if (recSkipEnd < 0)
			{
				recSkipEnd = 0;
			}			

			////удаление ненужных строк из общей выборки, чтобы остались только те, 
			////которые соответствую выбранной пользователем странице
			activityData.RemoveRange(0, recSkipBegin);
			if(recSkipEnd != 0)
			{
				activityData.RemoveRange(pageSize, recSkipEnd);
			}			

			////сохранение объекта пагинации в общую переменную для использования в представлении
			ViewBag.Pager = pager;
			//Пагинация - КОНЕЦ

			return View(activityData);
		}


		public IActionResult Addition()
		{
			ActivityModel activityModel = new ActivityModel();

			//передача сегодняшней даны в поле выбора даты
			activityModel.Date_value = DateTime.Now;

			//формирование выпадающего списка активностей
			ViewBag.ListOfActivities = activityListService.GetActivitiesList();

			return View(activityModel);
		}


		public IActionResult AddNewDataToActivities(ActivityModel activityModel)
		{	
			activityService.AddNewActivity(activityModel);

			return RedirectToAction("Index", "Activities");
		}


		public IActionResult DeleteDataFromActivities(ActivityModel activityModel)
		{
			activityService.DeleteActivity(activityModel);

			return RedirectToAction("Index", "Activities");
		}
	}
}