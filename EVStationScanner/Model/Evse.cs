using System;
using System.Collections.Generic;

namespace EVStationScanner.Model
{
	public class Evse
	{
		public List<string> AuthorizationMethods { get; set; }
		public List<Connector> Connectors { get; set; }
		public string EVSEId { get; set; }
		public string ExternalId { get; set; }
		public string Status { get; set; }
		public int Uid { get; set; }
		public DateTime Updated { get; set; }
	}
}