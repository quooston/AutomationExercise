using System;
using System.Configuration;

namespace SampleWebApp.Automation.Helpers.Configuration
{
    public static class ConfigurationHelpers
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["SampleWebApp"].ConnectionString;
        public static Uri SiteUrl => new Uri(ConfigurationManager.AppSettings["SiteUrl"]);

        public static string WebBrowser => ConfigurationManager.AppSettings["WebBrowser"];

        public static TimeSpan PageTimeout
            => new TimeSpan(0, 0, Convert.ToInt32(ConfigurationManager.AppSettings["PageTimeOut"]));
    }
}