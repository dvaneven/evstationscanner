using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using EVStationScanner.Infrastructure;
using EVStationScanner.Model;
using Timer = System.Threading.Timer;

namespace EVStationScanner
{
	public class Application : ApplicationContext
    {
        private static readonly AppSettings Settings = AppSettings.Load();

        private bool _chargingStationsAvailable;
		private readonly IDictionary<DateTime, EvseInfo> _logEntries;
		private readonly NotifyIcon _trayIcon;
		private readonly Timer _timer;

		public Application()
		{
            _chargingStationsAvailable = false;
			_logEntries = new Dictionary<DateTime, EvseInfo>();
			_trayIcon = CreateTrayIcon();
			_timer = CreateAndStartTimer();
        }

		private NotifyIcon CreateTrayIcon()
		{
			return new NotifyIcon
			{
				Icon = Resources.AppIcon,
				ContextMenu = new ContextMenu(new[] {
					new MenuItem("Check availability now...", (sender, args) => CheckAvailability()),
					new MenuItem("Show activity..", (sender, args) => ShowLog()),
                    new MenuItem("-"),
					new MenuItem("Last update on 00:00:00") { Name = "InfoMenuItem", Enabled = false, Visible = false}, 
					new MenuItem("-"), 
					new MenuItem("Exit", (sender, args) => Exit())
				}),
				Visible = true,
			};
		}

		private Timer CreateAndStartTimer()
		{
			return new Timer(state => CheckAvailability(), null, 0, Settings.ProbingInterval * 1000);
		}

		private void CheckAvailability()
		{
			// retrieve ev station data
			var client = new NewMotionClient(Settings.NewMotionLocationBaseUri);
			var evseInfo = TaskRunner.RunSync(() => client.GetEvseInfo(Settings.NewMotionLocationId));
			_logEntries.Add(DateTime.Now, evseInfo);
			var availableEvseCount = evseInfo.Evses.Count(evse => evse.Status == "Available");

			UpdateTrayIcon(availableEvseCount);
			DisplayBalloonTipWhenChargingStationBecomesAvailable(availableEvseCount);
			UpdateShowLogMenuItem();
		}

		private void UpdateTrayIcon(int availableEvseCount)
		{
			_trayIcon.Icon = availableEvseCount > 0 ? Resources.AppIconGreen : Resources.AppIconRed;
		}

		private void DisplayBalloonTipWhenChargingStationBecomesAvailable(int availableEvseCount)
		{
			if (!_chargingStationsAvailable && availableEvseCount > 0)
			{
				_trayIcon.ShowBalloonTip(0, "EV station info",
					$"{availableEvseCount} EV station(s) available", ToolTipIcon.Info);

				_chargingStationsAvailable = true;
			}
			else if (_chargingStationsAvailable && availableEvseCount == 0)
			{
				_chargingStationsAvailable = false;
			}
		}

		private void UpdateShowLogMenuItem()
		{
			var menuItem = _trayIcon.ContextMenu.MenuItems.Find("InfoMenuItem", false).Single();
			menuItem.Text = $@"Last update on {DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)}";
			menuItem.Visible = true;
        }

		private void ShowLog()
		{
			var logForm = new LogForm(_logEntries);
			logForm.Show();
		}

		private void Exit()
		{
            _trayIcon.Dispose();
			_timer.Dispose();
			System.Windows.Forms.Application.Exit();
		}
	}
}