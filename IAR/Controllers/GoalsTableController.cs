using IAR.Models;
using IAR.Services;
using Microsoft.AspNetCore.Mvc;


namespace IAR.Controllers
{
	public class GoalsTableController : Controller
	{
		private GoalService goalService = new GoalService();
		private ActivityTypeService ActivityListService = new ActivityTypeService();


		public IActionResult Index()
		{
			return View(goalService.GetAllUserGoals());
		}


		//переход на страницу добавления новой цели
		public IActionResult AddNewGoal()
		{
			//получаем список доступных активностей
			ViewBag.ListOfActivities = ActivityListService.GetActivitiesList();

			return View();
		}

		
		//добавление новой цели
		public IActionResult ProcessNewGoal(GoalModel goalModel)
		{
			bool isExist = goalService.GoalExists(goalModel.Activity);

			if (isExist) //если цель по переданной в goalModel активности уже ЕСТЬ
			{
				//предупреждение о существовании цели по активности (по одной активности не может быть нескольких целей)
				return View("GoalIsExist");
			}
			else //если цели по переданной в goalModel активности НЕТ
			{
				//добавление новой цели в базу
				goalService.AddNewGoal(goalModel.Activity, goalModel.Goal);

				return RedirectToAction("Index");
			}
		}


		//удаление цели
		//сюда из представления прилетает анонимный объект с одним полем Id, в котором айдишник строки, которую надо удалить
		//этот АО переформатируется в объект типа GoalModel со всеми пустыми полями, кроме Id - там айдишник нужной строки
		public IActionResult DeleteGoal(GoalModel goalModel)
		{
			//удаление цели
			goalService.DeleteGoalData(goalModel);

			//возврат на окно со списком всех целей
			return RedirectToAction("Index");
		}


		//переход на страницу редактирования цели
		public IActionResult EditGoal(GoalModel goalModel)
		{
			//сохранение айдишника в глобальную переменную, чтобы в методе UpdateGoal
			//найти по нему нужную строку для редактирования
			GoalCurrent.IdForEdit = goalModel.Id;

			//переход на страницу редактирования цели
			return View(goalModel);
		}


		public IActionResult ConfirmEditChanges(GoalModel goalModel)
		{
			//редактирование цели
			goalService.UpdateGoal(goalModel);

			//возврат на окно со списком всех целей
			return RedirectToAction("Index");
		}
	}
}