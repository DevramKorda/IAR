using IAR.Models;
using Microsoft.AspNetCore.Mvc;
using IAR.Services;


namespace IAR.Controllers
{
	public class LoginController : Controller
	{
		UserLoginNRegisterService userLoginAndReg = new UserLoginNRegisterService();


		public IActionResult Index()
		{
			return View();
		}


		public IActionResult Registration()
		{
			return View();
		}


		public IActionResult ProcessLogin(UserModel userModel)
		{
			if (userLoginAndReg.IsLoginAndPasswordConfirmed(userModel))
			//успешная попытка залогиниться
			{
				//return RedirectToAction("OtherMethod", "OtherController");
				UserCurrent.Username = userModel.UserName;
				return RedirectToAction("Index", "Activities");
			}
			else
			//провальная попытка залогиниться
			{
				return View("LoginFailure", userModel);
			}
		}


		public IActionResult ProcessRegistration(UserRegistrationModel userModel)
		{
			RegistrationFailureMessageModel msg = new RegistrationFailureMessageModel();

			string s1 = "This Username is occupied. Choose another one.";
			string s2 = "Username or Passwords are empty. Fill in all.";
			string s3 = "Passwords don't match. Enter equal Passwords.";

			if (userLoginAndReg.IsNewLoginAvailable(userModel))
			{
				if (userLoginAndReg.IsNewLoginAndPasswordNotEmpty(userModel))
				{
					if(userModel.Password == userModel.Password2)
					{//успешная попытка регистрации
						userLoginAndReg.AddNewUser(userModel);
						UserCurrent.Username = userModel.UserName;
						return RedirectToAction("Index", "Activities");
					}
					else
					{//провальная попытка регистрации
						msg.Message = s3;
						return View("RegistrationFailure", msg);
					}
				}
				else
				{//провальная попытка регистрации
					msg.Message = s2;
					return View("RegistrationFailure", msg);
				}
			}
			else
			{//провальная попытка регистрации
				msg.Message = s1;
				return View("RegistrationFailure", msg);
			}
		}
	}
}