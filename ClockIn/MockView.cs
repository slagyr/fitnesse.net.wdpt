using System;

namespace ClockIn
{
	public class MockView : ClockInView
	{
		public string username;
		public bool clockedIn;
		public DateTime clockedInTime;
		public DateTime clockedOutTime;
		public double hoursWorked;
		public bool validLogin;
		public bool wasCleared;

		public void Clear()
		{
			wasCleared = true;
		}

		public string Username
		{
			set { username = value; }
		}

		public bool ClockedIn
		{
			set { clockedIn = value; }
		}

		public DateTime ClockInTime
		{
			set { clockedInTime = value; }
		}

		public DateTime ClockOutTime
		{
			set { clockedOutTime = value; }
		}

		public double HoursWorked
		{
			set { hoursWorked = value; }
		}

		public bool ValidLogin
		{
			set { validLogin = value; }
		}

	}
}