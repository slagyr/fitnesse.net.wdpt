using System.Collections;
	
namespace ClockIn
{
	public class ClockInContext : LoginListener
	{
		private IList users = new ArrayList();
		private TimeSource timeSource = new RealTimeSource();
		public ClockInView view;

		public ClockInContext(ClockInView view)
		{
			this.view = view;
		}

		public IList Users
		{
			get { return users; }
		}

		public bool Login(string username, string password)
		{
			view.Clear();
			bool validLogin = true;
			User user = GetUser(username);
			if(user == null)
				validLogin = false;
			else if(!PasswordMatches(user, password))
				validLogin = false;

			view.ValidLogin = validLogin;
			if(validLogin)
				PerformLogin(user);

			return validLogin;
		}

		private void PerformLogin(User user)
		{
			if(!user.IsClockedIn)
				ClockIn(user);
			else
				ClockOut(user);
		}

		private static bool PasswordMatches(User user, string password)
		{
			return password != null && password.Equals(user.Password);
		}

		public void AddUser(string username, string password)
		{
			users.Add(new User(username, password));
		}

		public TimeSource TimeSource
		{
			set { timeSource = value; }
		}

		public User GetUser(string username)
		{
			if(username == null)
				return null;
			foreach (User user in users)
			{
				if(username.Equals(user.Username))
					return user;
			}
			return null;
		}

		private void ClockIn(User user)
		{
			user.ClockIn(timeSource.CurrentTime);
			view.Username = user.Username;
			view.ClockedIn = true;
			view.ClockInTime = user.ClockInTime;
		}

		private void ClockOut(User user)
		{
			user.ClockOut(timeSource.CurrentTime);
			view.Username = user.Username;
			view.ClockedIn = false;
			view.ClockInTime = user.ClockInTime;
			view.ClockOutTime = user.ClockOutTime;
			view.HoursWorked = user.HoursWorked;
		}

		public void LoginAttempted(string username, string password)
		{
			Login(username, password);
		}
	}
}