using System;
using System.Drawing;
using NUnit.Framework;

namespace ClockIn
{
	[TestFixture]
	public class ClockInWindowTest : LoginListener
	{
		private ClockInWindow window;

		[SetUp]
		public void SetUp()
		{
			window = new ClockInWindow();
			window.Show();
		}

		[TearDown]
		public void TearDown()
		{
			window.Dispose();	
		}

		[Test]
		public void Clear()
		{
			window.currentUserLabel.Text = "blah";
			window.clockedInAnswerLabel.Text = "blah";
			window.clockedInTimeAnswerLabel.Text = "blah";
			window.clockedOutTimeAnswerLabel.Text = "blah";
			window.hoursWorkedAnswerLabel.Text = "blah";

			window.Clear();

			Assert.AreEqual("", window.currentUserLabel.Text);
			Assert.AreEqual("", window.clockedInAnswerLabel.Text);
			Assert.AreEqual("", window.clockedInTimeAnswerLabel.Text);
			Assert.AreEqual("", window.clockedOutTimeAnswerLabel.Text);
			Assert.AreEqual("", window.hoursWorkedAnswerLabel.Text);
		}

		[Test]
		public void UserName()
		{
			window.Username = "Bub";
			Assert.AreEqual("Bub", window.currentUserLabel.Text);
		}

		[Test]
		public void ValidLogin()
		{
			window.ValidLogin = true;
			Assert.AreEqual("Valid Login", window.loginMessageTextBox.Text);
			Assert.AreEqual(Color.Green, window.loginMessageTextBox.ForeColor);

			window.ValidLogin = false;
			Assert.AreEqual("Invalid Login", window.loginMessageTextBox.Text);
			Assert.AreEqual(Color.Red, window.loginMessageTextBox.ForeColor);
		}

		[Test]
		public void ClockedIn()
		{
			window.ClockedIn = true;
			Assert.AreEqual("Yes", window.clockedInAnswerLabel.Text);

			window.ClockedIn = false;
			Assert.AreEqual("No", window.clockedInAnswerLabel.Text);
		}

		[Test]
		public void ClockedInTime()
		{
			window.ClockInTime = new DateTime(2006, 4, 26, 8, 2, 0);
			Assert.AreEqual("8:02", window.clockedInTimeAnswerLabel.Text);
			
			window.ClockInTime = new DateTime(2006, 4, 26, 20, 58, 0);
			Assert.AreEqual("20:58", window.clockedInTimeAnswerLabel.Text);
		}

		[Test]
		public void ClockedOutTime()
		{
			window.ClockOutTime = new DateTime(2006, 4, 26, 8, 2, 0);
			Assert.AreEqual("8:02", window.clockedOutTimeAnswerLabel.Text);
			
			window.ClockOutTime = new DateTime(2006, 4, 26, 20, 58, 0);
			Assert.AreEqual("20:58", window.clockedOutTimeAnswerLabel.Text);
		}

		[Test]
		public void HoursWorked()
		{
			window.HoursWorked = 5;
			Assert.AreEqual("5.0", window.hoursWorkedAnswerLabel.Text);
			
			window.HoursWorked = 1.321;
			Assert.AreEqual("1.3", window.hoursWorkedAnswerLabel.Text);
			
			window.HoursWorked = 2.25;
			Assert.AreEqual("2.3", window.hoursWorkedAnswerLabel.Text);
		}

		[Test]
		public void LoginButtonCalledListener()
		{
			window.LoginListener = this;
			window.usernameTextBox.Text = "joe";
			window.passwordTextBox.Text = "cool";
			window.loginButton.PerformClick();

			Assert.AreEqual("joe", loginUsername);
			Assert.AreEqual("cool", loginPassword);
		}

		private string loginPassword;
		private string loginUsername;
		public void LoginAttempted(string username, string password)
		{
			loginUsername = username;
			loginPassword = password;
		}

		[Test]
		public void LoginButtonClearsTextBoxes()
		{
			window.usernameTextBox.Text = "blah";
			window.passwordTextBox.Text = "blah";
			window.loginButton.PerformClick();

			Assert.AreEqual("", window.usernameTextBox.Text);
			Assert.AreEqual("", window.passwordTextBox.Text);
		}
	}
}