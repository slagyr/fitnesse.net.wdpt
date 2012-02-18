using System;

namespace ClockIn
{
	public interface TimeSource
	{
		DateTime CurrentTime { get; }
	}
}