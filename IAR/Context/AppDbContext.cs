using IAR.Models;
using Microsoft.EntityFrameworkCore;


namespace IAR.Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<UserModel> Users { get; set; }
		public DbSet<ActivityModel> Activities { get; set; }
		public DbSet<ActivityTypeModel> ActivityTypes { get; set; }
		public DbSet<GoalModel> Goals { get; set; }


		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			//Database.EnsureDeleted();
			Database.EnsureCreated(); //создание БД при её отсутствии
		}
	}
}