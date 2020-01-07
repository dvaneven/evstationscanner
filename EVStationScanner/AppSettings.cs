using System;
using System.Configuration;
using EVStationScanner.Infrastructure;

namespace EVStationScanner
{
    public class AppSettings
    {
        public Uri NewMotionLocationBaseUri { get; private set; }
        public string NewMotionLocationId { get; private set; }
        public int ProbingInterval { get; private set; }

        public static AppSettings Load()
        {
            var appSettings = ConfigurationManager.AppSettings;

            return new AppSettings
            {
                NewMotionLocationBaseUri = appSettings.GetUri("NewMotionLocationBaseUri", UriKind.Absolute, true),
                NewMotionLocationId = appSettings.GetString("NewMotionLocationId", true),
                ProbingInterval = appSettings.GetInt("ProbingInterval", true) ?? 60
            };
        }
    }
}