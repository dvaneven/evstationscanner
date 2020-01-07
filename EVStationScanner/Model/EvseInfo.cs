using System;
using System.Collections.Generic;

namespace EVStationScanner.Model
{
	public class EvseInfo
	{
		public Accessibility Accessibility { get; set; }
		public Address Address { get; set; }
		public Coordinates Coordinates { get; set; }
		public List<Evse> Evses { get; set; }
		public string ExternalId { get; set; }
		public List<OpeningHour> OpeningHours { get; set; }
		public string OperatorName { get; set; }
		public int Uid { get; set; }
		public DateTime Updated { get; set; }
	}
}