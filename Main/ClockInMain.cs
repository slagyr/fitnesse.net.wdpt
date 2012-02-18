using System.Windows.Forms;
using ClockIn;

namespace Main
{
	public class ClockInMain
	{
		public static void Main(string[] args)
		{
			ClockInWindow window = new ClockInWindow();
			ClockInContext context = new ClockInContext(window);
			window.LoginListener = context;

			context.AddUser("wallace", "cheese");
			context.AddUser("grommit", "nomorepenguins");

			Application.Run(window);
		}
	}
}