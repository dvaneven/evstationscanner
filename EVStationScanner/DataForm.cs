using System;
using System.Windows.Forms;

namespace EVStationScanner
{
    public partial class RawDataForm : Form
    {
        private readonly string _rawData;

        public RawDataForm(string rawData)
        {
            _rawData = rawData ?? throw new ArgumentNullException(nameof(rawData));
            InitializeComponent();
        }

        private void RawDataForm_Load(object sender, EventArgs e)
        {
            rawDataTextBox.Text = (string)_rawData.Clone();
            rawDataTextBox.Select(0, 0);
        }
    }
}
