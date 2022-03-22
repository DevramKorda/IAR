using IAR.Context;
using IAR.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace IAR.Services
{
	class Week
	{
		public int WeekNum { get; set; }
		public int Duration { get; set; }
	}


	class Month
	{
		public int MonthNum { get; set; }
		public int Duration { get; set; }
	}


	public class ChartService
	{
		private AppDbContext db = new AppDbContext(OptionsBuilder.optionsBuilder.Options);


		public List<int> GetYears()
		{			
			var yearsSet = from a in db.Activities
							where a.Username == UserCurrent.Username
							select a.Date_value.Year;

			List<int> yearsList = yearsSet.Distinct<int>().ToList<int>();
			yearsList.Sort();
				
			return yearsList;			
		}


		public List<string> GetHistoricalActivities()
		{			
			var activitiesSet = from a in db.Activities
								where a.Username == UserCurrent.Username
								select a.Activity;

			List<string> activitiesList = activitiesSet.Distinct<string>().ToList<string>();
			activitiesList.Sort();

			return activitiesList;			
		}


		public List<string> GetWeekLabels()
		{
			int weeks = ISOWeek.GetWeeksInYear(ActivityChartCurrent.Year);

			List<string> weeksList = new List<string>();

			for(int i = 1; i <= weeks; i++)
			{
				weeksList.Add(Convert.ToString(i));
			}
			
			return weeksList;			
		}
		

		public List<double?> GetWeeksData(List<string> weeks)
		{			
			//получение данных из БД
			var dbSet = from a in db.Activities
						where
							a.Username == UserCurrent.Username &&
							a.Activity == ActivityChartCurrent.Activity &&
							a.Date_value.Year == ActivityChartCurrent.Year
						select a;

			//переформат данных из БД - получаем разбивку по неделям
			List<Week> dbSetWithWeeks = new List<Week>();

			foreach(var e in dbSet)
			{
				dbSetWithWeeks.Add(new Week { WeekNum = ISOWeek.GetWeekOfYear(e.Date_value), Duration = e.Activity_duration });
			}

			//суммируем по неделям
			var sumByWeeks = from a in dbSetWithWeeks
								group a by a.WeekNum into g
								select new { Week = g.Key, Sum = g.Sum(g => g.Duration) };

			////меняем для удобства формат sumByWeeks с var на List<Week>
			List<Week> sumByWeeksList = new List<Week>();
			foreach(var a in sumByWeeks)
			{
				sumByWeeksList.Add(new Week { WeekNum = a.Week, Duration = a.Sum});
			}

			//получаем массив суммарных значений для абсолютно всех недель в году
			List<double?> weeksData = new List<double?>();

			for (int i = 0; i < weeks.Count; i++)
			{
				double n = 0;
				foreach (Week w in sumByWeeksList)
				{
					if(w.WeekNum == i + 1)
					{
						double whole = (double)((int)w.Duration / 60);
						double partial = ((w.Duration - (60 * whole)) / 100) * 1.67;
						n = whole + partial;
					}
				}
				weeksData.Add(n);
			}

			return weeksData;			
		}


		public List<double?> GeGetMonthsData()
		{			
			//получение данных из БД
			var dbSet = from a in db.Activities
						where
							a.Username == UserCurrent.Username &&
							a.Activity == ActivityChartCurrent.Activity &&
							a.Date_value.Year == ActivityChartCurrent.Year
						select a;

			//переформат данных из БД - получаем разбивку по месяцам
			List<Month> dbSetWithMonths = new List<Month>();
			foreach (var e in dbSet)
			{
				dbSetWithMonths.Add(new Month { MonthNum = e.Date_value.Month, Duration = e.Activity_duration });
			}

			//суммируем по месяцам
			var sumByMonths = from a in dbSetWithMonths
								group a by a.MonthNum into g
								select new { Month = g.Key, Sum = g.Sum(g => g.Duration) };

			////меняем для удобства формат sumByMonths с var на List<Month>
			List<Month> sumByMonthsList = new List<Month>();
			foreach (var a in sumByMonths)
			{
				sumByMonthsList.Add(new Month { MonthNum = a.Month, Duration = a.Sum });
			}

			//получаем массив суммарных значений для абсолютно всех месяцев в году
			List<double?> monthsData = new List<double?>();

			for (int i = 0; i < 12; i++)
			{
				double n = 0;
				foreach (Month w in sumByMonthsList)
				{
					if (w.MonthNum == i + 1)
					{
						double whole = (double)((int)w.Duration / 60);
						double partial = ((w.Duration - (60 * whole)) / 100) * 1.67;
						n = whole + partial;
					}
				}
				monthsData.Add(n);
			}

			return monthsData;			
		}
	}
}