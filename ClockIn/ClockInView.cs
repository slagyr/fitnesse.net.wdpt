using System;

namespace ClockIn
{
	public interface ClockInView
	{
		void Clear();
		string Username { set; }
		bool ClockedIn { set; }
		DateTime ClockInTime { set; }
		DateTime ClockOutTime { set; }
		double HoursWorked { set; }
		bool ValidLogin { set; }
	}
}