using System;

namespace EVStationScanner.Model
{
	public class Connector
	{
		public string ConnectorType { get; set; }
		public ElectricalProperties ElectricalProperties { get; set; }
		public string ExternalId { get; set; }
		public bool FixedCable { get; set; }
		public Tariff Tariff { get; set; }
		public int Uid { get; set; }
		public DateTime Updated { get; set; }
		public string UpdatedBy { get; set; }
	}
}