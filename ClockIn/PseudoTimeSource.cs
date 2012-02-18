using System;
using ClockIn;

namespace ClockIn
{
	public class PseudoTimeSource : TimeSource
	{
		private DateTime currentTime;

		public PseudoTimeSource(DateTime time)
		{
			currentTime = time;
		}

		public DateTime CurrentTime
		{
			get { return currentTime; }
		}

		public void SetTime(DateTime time)
		{
			currentTime = time;
		}
	}
}