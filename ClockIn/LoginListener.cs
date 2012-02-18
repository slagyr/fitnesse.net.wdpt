namespace ClockIn
{
	public interface LoginListener
	{
		void LoginAttempted(string username, string password);
	}
}