using IAR.Context;
using IAR.Models;


namespace IAR.Services
{
	public class UserLoginNRegisterService
	{
		private AppDbContext db = new AppDbContext(OptionsBuilder.optionsBuilder.Options);


		public bool IsLoginAndPasswordConfirmed(UserModel user)
		{			
			var users = db.Users;
				
			foreach(UserModel u in users)
			{
				if (u.UserName == user.UserName && u.Password == user.Password)
					return true;
			}

			return false;			
		}
		

		public bool IsNewLoginAvailable(UserRegistrationModel user)
		{			
			var users = db.Users;

			foreach (UserModel u in users)
			{
				if (u.UserName == user.UserName)
					return false;
			}

			return true;			
		}


		public bool IsNewLoginAndPasswordNotEmpty(UserRegistrationModel user)
		{
			if (user.UserName == null || user.Password == null || user.Password2 == null)
				return false;
			else 
				return true;
		}


		public void AddNewUser(UserRegistrationModel user)
		{
			UserModel newUser = new UserModel() { Id = user.Id, UserName = user.UserName, Password = user.Password };
			db.Users.Add(newUser);
			db.SaveChanges();			
		}
	}
}