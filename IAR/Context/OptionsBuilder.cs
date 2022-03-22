using Microsoft.EntityFrameworkCore;


namespace IAR.Context
{
	public class OptionsBuilder
	{
		public static DbContextOptionsBuilder<AppDbContext> optionsBuilder;


		public OptionsBuilder()	{}
		static OptionsBuilder()
		{
			//string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IARdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			string connectionString = @"Server=(localdb)\mssqllocaldb;Database=IARdb2;Trusted_Connection=True;MultipleActiveResultSets=true";

			optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseSqlServer(connectionString);
		}
	}
}