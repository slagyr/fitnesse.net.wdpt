using System;
using fit;

namespace ClockIn	
{
	public class UsersFixture : ColumnFixture
	{
		public string username;
		public string password;

		public override void Execute()
		{
			SetupFixture.appContext.AddUser(username, password);
		}
	}

}