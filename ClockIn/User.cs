using System;

namespace ClockIn
{
	public class User
	{
		private readonly string username;
		private readonly string password;
		private bool clockedIn;
		private DateTime clockInTime;
		private DateTime clockOutTime;

		public User(string username, string password)
		{
			this.username = username;
			this.password = password;
		}

		public string Username
		{
			get { return username; }
		}

		public string Password
		{
			get { return password; }
		}

		public bool IsClockedIn
		{
			get { return clockedIn; }
		}

		public DateTime ClockInTime
		{
			get { return clockInTime; }
		}

		public void ClockIn(DateTime time)
		{
			clockInTime = time;
			clockedIn = true;
		}

		public DateTime ClockOutTime
		{
			get { return clockOutTime; }
		}

		public double HoursWorked
		{
			get 
			{
				TimeSpan span = clockOutTime - clockInTime;
				double hours = span.Hours;
				hours += ((double)span.Minutes) / 60.0;
				return hours; 
			}
		}

		public void ClockOut(DateTime time)
		{
			clockOutTime = time;
			clockedIn = false;
		}
	}
}