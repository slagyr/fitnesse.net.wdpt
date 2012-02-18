using System;
using NUnit.Framework;

namespace ClockIn
{
	[TestFixture]
	public class UserTest
	{
		private User user;

		[SetUp]
		public void SetUp()
		{
			user = new User("joe", "sparrow");
		}

		[Test]
		public void ConsrtructorArgs()
		{
			Assert.AreEqual("joe", user.Username);
			Assert.AreEqual("sparrow", user.Password);
		}

		[Test]
		public void ClockIn()
		{
			Assert.IsFalse(user.IsClockedIn);

			DateTime now = DateTime.Now;
			user.ClockIn(now);

			Assert.IsTrue(user.IsClockedIn);
			Assert.AreEqual(now, user.ClockInTime);
		}

		[Test]
		public void ClockOut()
		{
			DateTime now = DateTime.Now;
			user.ClockIn(now);

			DateTime then = now.AddHours(5).AddMinutes(15);
			user.ClockOut(then);

			Assert.IsFalse(user.IsClockedIn);
			Assert.AreEqual(5.25, user.HoursWorked);
		}
	}
}