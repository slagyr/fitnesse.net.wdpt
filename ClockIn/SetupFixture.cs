using fit;

namespace ClockIn
{
	public class SetupFixture : Fixture
	{
		
		public static ClockInContext appContext;
		public static MockView view;

		public override void DoTable(Parse table)
		{
			view = new MockView();
			appContext = new ClockInContext(view);
		}
	}
}