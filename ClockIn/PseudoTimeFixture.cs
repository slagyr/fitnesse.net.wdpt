using System;
using fit;

namespace ClockIn
{
	public class PseudoTimeFixture : ActionFixture
	{
		public PseudoTimeFixture()
		{
			actor = this;
		}

		public string Time
		{
			set
			{
				string[ ] timeParts = value.Split(':');
				int hour = Int32.Parse(timeParts[0]);
				int minute = Int32.Parse(timeParts[1]);
				DateTime today = DateTime.Today;
				DateTime pseudoTime = new DateTime(today.Year,  today.Month, today.Day, hour, minute, 0);

				SetupFixture.appContext.TimeSource = new PseudoTimeSource(pseudoTime);
			}
		}
	}
}