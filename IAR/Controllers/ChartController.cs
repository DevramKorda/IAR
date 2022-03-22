using ChartJSCore.Helpers;
using ChartJSCore.Models;
using IAR.Models;
using IAR.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace IAR.Controllers
{
	public class ChartController : Controller
	{
		public IActionResult Index()
		{
			//получение дынных из таблицы фактических исторических записей по конкретному(текущему) юзеру
			//для формирования выпадающих списков опций выбора данных для графиков.
			ChartService chartService = new ChartService();	
			ViewBag.ChartActivities = chartService.GetHistoricalActivities(); //уникальные активности
			ViewBag.ChartPeriods = new List<string> { "Week", "Month" };	  //периоды (хардкод)
			ViewBag.ChartYears = chartService.GetYears();                     //уникальные годы

			//передача в поля выбора выбранных ранее вариантов, чтобы не сбрасывались при обновлении страницы
			ChartModel chartModel = new ChartModel();

			List<string> weeksLabels = new List<string>();
			List<double?> weeksData = new List<double?>();
			List<double?> monthsData = new List<double?>();

			if (ActivityChartCurrent.IsChanged)
			{
				weeksLabels = chartService.GetWeekLabels();
				weeksData = chartService.GetWeeksData(weeksLabels);
				monthsData = chartService.GeGetMonthsData();

				if (ActivityChartCurrent.Period == "Week")
				{
					MakeChart(weeksLabels, weeksData); //график по неделям
				}
				else if(ActivityChartCurrent.Period == "Month")
				{
					MakeChart(monthsData); //график по месяцам
				}

				//передача в поля выбора выбранных ранее вариантов, чтобы не сбрасывались при обновлении страницы
				chartModel.Activity = ActivityChartCurrent.Activity;
				chartModel.Period = ActivityChartCurrent.Period;
				chartModel.Year = ActivityChartCurrent.Year;
			}
			else
			{
				MakeChart(); //график по умолчанию (пустой)
			}
			
			return View(chartModel);
		}


		public IActionResult UpdateChart(ChartModel chartModel)
		{			
			ActivityChartCurrent.Activity = chartModel.Activity;
			ActivityChartCurrent.Period = chartModel.Period;
			ActivityChartCurrent.Year = chartModel.Year;
			ActivityChartCurrent.IsChanged = true;			

			return RedirectToAction("Index");
		}


		//перегрузка для графика по месяцам
		public void MakeChart(List<double?> dataList)
		{
			Chart chart = new Chart();

			chart.Type = Enums.ChartType.Bar;

			ChartJSCore.Models.Data data = new ChartJSCore.Models.Data();

			data.Labels = new List<string>() { "January", "February", "March", "April", 
				"May", "June", "July", "August", "September", "October", "November", "December" };
			
			BarDataset dataset = new BarDataset()
			{
				Label = "Hours by Period",
				Data = dataList,
				BackgroundColor = new List<ChartColor> { ChartColor.FromRgba(75, 192, 192, 0.4) },
				BorderColor = new List<ChartColor> { ChartColor.FromRgb(75, 192, 192) },
				BorderWidth = new List<int> { 1 },
				HoverBackgroundColor = new List<ChartColor> { ChartColor.FromHexString("#ffffff") },
				HoverBorderColor = new List<ChartColor> { ChartColor.FromRgb(220, 220, 220) },
				HoverBorderWidth = new List<int> { 2 }

			};

			data.Datasets = new List<Dataset>();
			data.Datasets.Add(dataset);

			chart.Data = data;

			ViewData["chart"] = chart;
		}


		//перегрузка для графика по неделям
		public void MakeChart(List<string> weeksList, List<double?> dataList)
		{
            Chart chart = new Chart();

            chart.Type = Enums.ChartType.Bar;

            ChartJSCore.Models.Data data = new ChartJSCore.Models.Data();

			//data.Labels = new List<string>() { "January", "February", "March" };
			data.Labels = weeksList;

			BarDataset dataset = new BarDataset()
            {
                Label = "Hours by Period",
				//Data = new List<double?> { 65, 59, 80 },
				Data = dataList,
				BackgroundColor = new List<ChartColor> { ChartColor.FromRgba(75, 192, 192, 0.4) },
                BorderColor = new List<ChartColor> { ChartColor.FromRgb(75, 192, 192) },
                BorderWidth = new List<int> { 1 },
                HoverBackgroundColor = new List<ChartColor> { ChartColor.FromHexString("#ffffff") },
                HoverBorderColor = new List<ChartColor> { ChartColor.FromRgb(220, 220, 220) },
                HoverBorderWidth = new List<int> { 2 }

            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            ViewData["chart"] = chart;
        }


		//перегрузка для графика по умолчанию (пустой)
		public void MakeChart()
		{
			Chart chart = new Chart();

			chart.Type = Enums.ChartType.Bar;

			ChartJSCore.Models.Data data = new ChartJSCore.Models.Data();
			
			data.Labels = new List<string>() {  };			

			BarDataset dataset = new BarDataset()
			{
				Label = "Hours by Period",
				Data = new List<double?> { },
				BackgroundColor = new List<ChartColor> { ChartColor.FromRgba(75, 192, 192, 0.4) },
				BorderColor = new List<ChartColor> { ChartColor.FromRgb(75, 192, 192) },
				BorderWidth = new List<int> { 1 },
				HoverBackgroundColor = new List<ChartColor> { ChartColor.FromHexString("#ffffff") },
				HoverBorderColor = new List<ChartColor> { ChartColor.FromRgb(220, 220, 220) },
				HoverBorderWidth = new List<int> { 2 }

			};

			data.Datasets = new List<Dataset>();
			data.Datasets.Add(dataset);

			chart.Data = data;

			ViewData["chart"] = chart;
		}
	}
}