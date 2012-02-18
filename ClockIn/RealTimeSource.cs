using System;

namespace ClockIn
{
	public class RealTimeSource : TimeSource
	{
		public DateTime CurrentTime
		{
			get { return DateTime.Now; }
		}
	}
}