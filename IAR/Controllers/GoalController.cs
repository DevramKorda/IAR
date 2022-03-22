using ChartJSCore.Helpers;
using ChartJSCore.Models;
using IAR.Models;
using IAR.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace IAR.Controllers
{
	public class GoalController : Controller
	{
		public IActionResult Index()
		{
            //модель для передачи в представление
            GoalModel goalModel = new GoalModel();

            //получение доступа к методам
            GoalService goalService = new GoalService(); 
            
            //инициализация модели в зависимости от того, выбрал пользователь активность или нет
            if (GoalCurrent.IsChanged)
            //активность выбрана
			{
                //сразу выгружаем данные по всем полям кроме CurrentUserHours
                //проверка на корректность возвращаемых данных
                if(goalService.GetGoal() == null)
                //если не ок
				{
                    return Index();
				}
				else
                //если ок
				{
                    goalModel = goalService.GetGoal();
                }
                

                //получаем данные по CurrentUserHours
                goalModel.CurrentUserHours = goalService.GetCurrentTotalHoursForActivity();

                //формируем заголовок и данные для графика
                //2 подписи данных - на текущее кол-во часов и оставшееся до цели
                List<string> label = new List<string> { goalModel.Activity, "Hours left" };

                //в графике используются не доли, а абсолютные значения, поэтому чтобы картина была корректной
                //в датасет помещаем текущее количество часов и разницу между целью и текущим кол-вом часов
                //т.е. есть целое - это целевое кол-во часов, которое разбито на 2 части: факт и остаток
                List<double?> dataSet = new List<double?>();

                if (goalModel.Goal - goalModel.CurrentUserHours >= 0)
                {
                    dataSet.Add(goalModel.CurrentUserHours);
                    dataSet.Add(goalModel.Goal - goalModel.CurrentUserHours);
                }
                else
                {
                    dataSet.Add(goalModel.CurrentUserHours);
                    dataSet.Add(0);
                }            

                //строим график; первый перегруженный метод из 2
                MakeChart(label, dataSet);
            }
			else
            //активность не выбрана
			{
                goalModel.CurrentUserHours = 0;
                goalModel.Goal = 0;

                List<string> label = new List<string> { "Activity not selected" };

                //строим график; второй перегруженный метод из 2
                MakeChart(label);
            }

            //получаем список текущих активностей, по которым есть цели
            ViewBag.GoalActivities = goalService.GetCurrentGoalActivities(); 

            return View(goalModel);
		}


        public IActionResult SelectActivity(GoalModel goalModel)
		{
            GoalCurrent.Activity = goalModel.Activity;
            GoalCurrent.IsChanged = true;

            return RedirectToAction("Index");
        }


        //перегрузка для построение графика, если активность выбрана
        public void MakeChart(List<string> label, List<double?> dataSet)
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Doughnut;

            Data data = new Data();
            data.Labels = label;

            PieDataset outerDataset = new PieDataset()
            {
                BackgroundColor = new List<ChartColor>() {                    
                    ChartColor.FromHexString("#109618"),
                    ChartColor.FromHexString("#FF9900")
                },
                HoverBackgroundColor = new List<ChartColor>() {
                    ChartColor.FromHexString("#109618"),
                    ChartColor.FromHexString("#FF9900")
                },
                Data = dataSet                
            };

            //делаем пустой, чтобы график был с пустотой в центре - для этого в Data записываем 0
            PieDataset innerDataset = new PieDataset()
            {
                BackgroundColor = new List<ChartColor>() {
					ChartColor.FromHexString("#FF9900")
                },
                HoverBackgroundColor = new List<ChartColor>() {
					ChartColor.FromHexString("#FF9900")
                },
                Data = new List<double?>() {
                    0
                }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(outerDataset);
            data.Datasets.Add(innerDataset);

            chart.Data = data;

            ViewData["goal"] = chart;
        }


        //перегрузка для построение графика, если активность НЕ выбрана
        public void MakeChart(List<string> label)
		{
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Doughnut;

            Data data = new Data();
			data.Labels = label;

			//data.Labels = new List<string>() {
			//	"resource-group-1",
			//	"resource-group-2",
			//	"Data Services - Basic Database Days",
			//	"Data Services - Basic Database Days",
			//	"Azure App Service - Basic Small App Service Hours",
			//	"resource-group-2 - Other"
			//};

			PieDataset outerDataset = new PieDataset()
            {
                BackgroundColor = new List<ChartColor>() {
					//ChartColor.FromHexString("#3366CC"),
					//ChartColor.FromHexString("#DC3912"),
					ChartColor.FromHexString("#FF9900"),
					//ChartColor.FromHexString("#109618"),
					//ChartColor.FromHexString("#990099"),
					//ChartColor.FromHexString("#3B3EAC")
                },
                HoverBackgroundColor = new List<ChartColor>() {
					//ChartColor.FromHexString("#3366CC"),
					//ChartColor.FromHexString("#DC3912"),
					ChartColor.FromHexString("#FF9900"),
					//ChartColor.FromHexString("#109618"),
					//ChartColor.FromHexString("#990099"),
					//ChartColor.FromHexString("#3B3EAC")
                },
                Data = new List<double?>() {
					//0.0,
					//0.0,
					//8.31,
					//10.43,
					//84.69,
					//0.84
                    1
				}
            };

			PieDataset innerDataset = new PieDataset()
			{
				BackgroundColor = new List<ChartColor>() {
					//ChartColor.FromHexString("#3366CC"),
					//ChartColor.FromHexString("#DC3912"),
					ChartColor.FromHexString("#FF9900"),
					//ChartColor.FromHexString("#109618"),
					//ChartColor.FromHexString("#990099"),
					//ChartColor.FromHexString("#3B3EAC")
				},
				HoverBackgroundColor = new List<ChartColor>() {
					//ChartColor.FromHexString("#3366CC"),
					//ChartColor.FromHexString("#DC3912"),
					ChartColor.FromHexString("#FF9900"),
					//ChartColor.FromHexString("#109618"),
					//ChartColor.FromHexString("#990099"),
					//ChartColor.FromHexString("#3B3EAC")
				},
				Data = new List<double?>() {
					//8.31,
					//95.96
                    0
				}
			};

			data.Datasets = new List<Dataset>();
            data.Datasets.Add(outerDataset);
            data.Datasets.Add(innerDataset);

            chart.Data = data;            

            ViewData["goal"] = chart;
		}
	}
}
