using System;
using NUnit.Framework;

namespace ClockIn
{
	[TestFixture]
	public class ClockInContextTest
	{
		private ClockInContext context;
		private MockView view;
		private DateTime now;
		private PseudoTimeSource timeSource;

		[SetUp]
		public void SetUp()
		{
			now = DateTime.Now;
			view = new MockView();
			context = new ClockInContext(view);
			timeSource = new PseudoTimeSource(now);
			context.TimeSource = timeSource;
			context.AddUser("neo", "whiterabbit");
		}

		[Test]
		public void ValidLogin()
		{
			Assert.IsTrue(context.Login("neo", "whiterabbit"));
		}

		[Test]
		public void LoginWithInvalidUsername()
		{
			Assert.IsFalse(context.Login("john", "whiterabbit"));
			Assert.IsFalse(context.Login("nathan", "whiterabbit"));
			Assert.IsFalse(context.Login("", "whiterabbit"));
			Assert.IsFalse(context.Login(null, "whiterabbit"));
		}

		[Test]
		public void LoginWithWrongPassword()
		{
			Assert.IsFalse(context.Login("neo", "whiteelephant"));
			Assert.IsFalse(context.Login("neo", "sugar"));
			Assert.IsFalse(context.Login("neo", ""));
			Assert.IsFalse(context.Login("neo", null));
		}

		[Test]
		public void LoginClocksUserIn()
		{
			context.Login("neo", "whiterabbit");

			User user = context.GetUser("neo");

			Assert.IsTrue(user.IsClockedIn);
			Assert.IsTrue(DateTime.Now - user.ClockInTime < new TimeSpan(1000));
		}

		[Test]
		public void ViewLoginStatusIsUpdated()
		{
			context.Login("neo", "whiterabbit");
			Assert.IsTrue(view.validLogin);

			context.Login("blah", "blah");
			Assert.IsFalse(view.validLogin);
		}

		[Test]
		public void LoginClearsView()
		{
			context.Login("blah", "blah");
			Assert.IsTrue(view.wasCleared);
		}

		[Test]
		public void ViewInforUpdateForClockIn()
		{
			context.Login("neo", "whiterabbit");

			Assert.AreEqual("neo", view.username);
			Assert.IsTrue(view.clockedIn);
			Assert.AreEqual(now, view.clockedInTime);
			Assert.IsTrue(view.clockedIn);
		}

		[Test]
		public void ViewInfoUpdatedForClockOut()
		{
			context.Login("neo", "whiterabbit");
			DateTime then = DateTime.Now.AddHours(5);
			timeSource.SetTime(then);
			context.Login("neo", "whiterabbit");

			Assert.AreEqual("neo", view.username);
			Assert.IsFalse(view.clockedIn);
			Assert.AreEqual(now, view.clockedInTime);
			Assert.AreEqual(then, view.clockedOutTime);
			Assert.AreEqual(5.0, view.hoursWorked, 0.001);
			Assert.IsFalse(view.clockedIn);
		}
	}
}