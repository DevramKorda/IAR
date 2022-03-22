using IAR.Context;
using IAR.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace IAR.Services
{
	public class GoalService
	{
		private AppDbContext db = new AppDbContext(OptionsBuilder.optionsBuilder.Options);


		//у пользователя может быть несколько активностей с целями, но только с 1 целью на активность
		//метод должен возвращать одну единственную цель
		public GoalModel GetGoal()
		{
			GoalModel goal;

			try
			{
				goal = db.Goals.First<GoalModel>(
					x =>
					x.Username == UserCurrent.Username &&
					x.Activity == GoalCurrent.Activity
				);
			}
			catch
			//если выгрузка пустая, например, когда у пользователя на странице с графиком по цели уже выбрана цель,
			//потом он удаляет её на странице с таблицей, а потом снова переходит на страницу с графиком.
			{
				GoalCurrent.IsChanged = false;
				return null;
			}
			
			return goal;			
		}


		//получаем текущее суммарное количество часов по пользователю и активности
		public double GetCurrentTotalHoursForActivity()
		{
			//выгрузка
			var activitySet = from a in db.Activities
							  where
							  a.Username == UserCurrent.Username &&
							  a.Activity == GoalCurrent.Activity
							  group a by new { a.Username, a.Activity } into g
							  select new { Username = g.Key, Activity = g.Key, Sum = g.Sum(g => g.Activity_duration) };

			double totalHours;

			if (activitySet.Count() != 0) //если выгрузка не пустая
			{
				//перевод из int в адаптированный под часы double
				double whole = (double)(activitySet.FirstOrDefault().Sum / 60);
				double partial = ((activitySet.FirstOrDefault().Sum - (60 * whole)) / 100) * 1.67;
				totalHours = Math.Round(whole + partial, 1);
			}
			else //если выгрузка пустая, т.е. по данной активности есть цель, но нет исторических данных
			{
				totalHours = 0;
			}
			
			return totalHours;
		}


		public List<string> GetCurrentGoalActivities()
		{
			var activitiesSet = from a in db.Goals
								where a.Username == UserCurrent.Username
								select a.Activity;

			List<string> activitiesList = activitiesSet.ToList<string>();
			activitiesList.Sort();

			return activitiesList;
		}


		//проверка на существование цели по передаваемой активности по текущему пользователю
		public bool GoalExists(string activity)
		{
			var dataSet = from a in db.Goals
						  where
						  a.Username == UserCurrent.Username &&
						  a.Activity == activity
						  select a;

			//если цель по переданной активности по текущему пользователю уже ЕСТЬ
			if (dataSet.Count() != 0) return true;

			//если цели по переданной активности по текущему пользователю НЕТ
			return false;
		}


		//добавление цели по новой активности в таблицу Goals
		public void AddNewGoal(string activity, int goal)
		{
			GoalModel goalModel = new GoalModel();

			goalModel.Username = UserCurrent.Username;
			goalModel.Activity = activity;
			goalModel.Goal = goal;
			goalModel.CurrentUserHours = 0;

			db.Goals.Add(goalModel);
			db.SaveChanges();
		}


		//удаление цели по уктивности
		//сюда прилетает объект GoalModel с одним заполненным полем - Id строки, которую надо удалить
		public void DeleteGoalData(GoalModel goalModel)
		{
			//в метод Remove не обязательно передавать объект со всеми заполненными полями - достаточно одного,
			//которое Primary Key (короче, которое, по идее, уникально идентифицирует строку)
			db.Goals.Remove(goalModel);
			db.SaveChanges();
		}


		//обновление цели в БД
		public void UpdateGoal(GoalModel goalModel)
		{
			GoalModel goal = db.Goals.First<GoalModel>(x => x.Id == GoalCurrent.IdForEdit);
			
			if (goal != null)
			{
				goal.Goal = goalModel.Goal;
				db.SaveChanges();
			}
		}


		//получение списка заведённых пользователем целей для таблицы на странице Goals
		public List<GoalModel> GetAllUserGoals()
		{
			var dataSet = from a in db.Goals
						  where a.Username == UserCurrent.Username
						  select a;

			List<GoalModel> dataList = dataSet.ToList<GoalModel>();

			return dataList;
		}
	}
}
