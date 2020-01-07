using System;

namespace EVStationScanner.Model
{
	public class Tariff
	{
		public string Currency { get; set; }
		public double PerKWh { get; set; }
		public string Structure { get; set; }
		public DateTime Updated { get; set; }
		public string UpdatedBy { get; set; }
	}
}