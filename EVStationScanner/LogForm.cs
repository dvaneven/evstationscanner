using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using EVStationScanner.Model;

namespace EVStationScanner
{
	public partial class LogForm : Form
	{
		private readonly IDictionary<DateTime, EvseInfo> _logEntries;

		public LogForm(IDictionary<DateTime, EvseInfo> logEntries)
		{
			_logEntries = logEntries ?? throw new ArgumentNullException(nameof(logEntries));
			InitializeComponent();
		}

		private void LogForm_Shown(object sender, EventArgs e)
		{
			dataGridView.AutoGenerateColumns = false;
			dataGridView.DataSource = _logEntries
				.OrderByDescending(entry => entry.Key)
				.Select(entry => new DataGridViewEntry
					{
						Timestamp = entry.Key.ToString("HH:mm:ss"),
						Available = $"{entry.Value.Evses.Count(evse => evse.Status == "Available")} of {entry.Value.Evses.Count}",
						RawData = JsonConvert.SerializeObject(entry.Value, Formatting.Indented)
					})
				.ToList();
		}

		private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
            if (e.ColumnIndex == 2)
            {
                var entries = dataGridView.DataSource as List<DataGridViewEntry>;
                var rawData = entries[e.RowIndex].RawData;
				var rawDataForm = new RawDataForm(rawData);
                rawDataForm.ShowDialog();
            }
		}

        public class DataGridViewEntry
        {
            public string Timestamp { get; set; }
            public string Available { get; set; }
            public string RawData { get; set; }
        }
	}
}
