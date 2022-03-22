using System;


namespace IAR.Models
{
	public class PagerModel
	{
		public int TotalItems { get; set; }  //общее количество строк для отображения
		public int CurrentPage { get; set; } //номер текущей страницы
		public int PageSize { get; set; }    //количество строк на странице
		public int TotalPages { get; set; }  //количество страниц
		public int StartPage { get; set; }   //номер страницы слева в отображаемом на странице диапазоне
		public int EndPage { get; set; }     //номер страницы справа в отображаемом на странице диапазоне


		//пустой конструктор
		public PagerModel() { }

		//рабочий конструктор
		public PagerModel(int totalItems, int page, int pageSize = 100)
		{
			//сколько всего должно быть страниц
			int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

			//номер текущей страницы
			int currentPage = page;

			//рассчёт диапазона страниц, которые должны быть визуально представлены на странице
			int startPage = currentPage - 5; //крайняя левая страница
			int endPage = currentPage + 4;   //крайняя правая страница

			//корректировака отображения диапазона страниц
			////чтобы номер левой страницы не ушёл в минусовое значение
			if (startPage <= 0)
			{
				endPage = endPage - (startPage - 1);
				startPage = 1;
			}

			////чтобы номер правой страницы не превысил общее количество страниц
			if (endPage > totalPages)
			{
				endPage = totalPages;
				if(endPage > 10)
				{
					startPage = endPage - 9;
				}
			}

			//инициализация свойств
			TotalItems = totalItems;
			CurrentPage = currentPage;
			PageSize = pageSize;
			TotalPages = totalPages;
			StartPage = startPage;
			EndPage = endPage;
		}
	}
}
