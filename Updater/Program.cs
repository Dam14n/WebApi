namespace Updater
{
	public class Program
	{
		private static void Main(string[] args)
		{
			UpdaterDates upDates = new UpdaterDates();
			upDates.startUpdate();
			UpdaterPositions upPositions = new UpdaterPositions();
			upPositions.startUpdate();
		}
	}
}
