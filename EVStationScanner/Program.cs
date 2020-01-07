using System;

namespace EVStationScanner
{
	public static class Program
	{
		[STAThread]
		public static void Main()
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			System.Windows.Forms.Application.Run(new Application());
		}
	}
}
