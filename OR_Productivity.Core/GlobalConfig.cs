using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OR_Productivity.Core
{
    public class GlobalConfig
    {
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string AppString(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
