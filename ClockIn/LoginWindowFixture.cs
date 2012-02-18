using fit;

namespace ClockIn
{
	public class LoginWindowFixture : ActionFixture
	{
		public string username;
		public string password;
		public bool loggedIn;

		public LoginWindowFixture()
		{
			actor = this;
		}

		public void Login()
		{
			loggedIn = SetupFixture.appContext.Login(username, password);
		}

		public string LogInTime
		{
			get { return SetupFixture.view.clockedInTime.ToString("H:mm"); }
		}

		public string LogOutTime
		{
			get { return SetupFixture.view.clockedOutTime.ToString("H:mm"); }
		}

		public double HoursWorked
		{
			get { return SetupFixture.view.hoursWorked; }
		}
	}
}