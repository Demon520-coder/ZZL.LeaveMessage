using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZL.LeaveMessage.Common
{
    public class ConfigHelper
    {
        public static string GetAppSettingsByKey(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? string.Empty;
        }

        public static string GetConString(string conString)
        {
            return ConfigurationManager.ConnectionStrings[conString].ConnectionString ?? string.Empty;
        }

    }
}
