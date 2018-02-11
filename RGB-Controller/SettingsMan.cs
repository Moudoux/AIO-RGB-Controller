using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGB_Controller
{
    class SettingsMan
    {

        public static string GetSetting(string key)
        {
            return Properties.Settings.Default[key].ToString();
        }

        public static bool HasSetting(string key)
        {
            return Properties.Settings.Default.Properties.Cast<SettingsProperty>().Any(prop => prop.Name == key);
        }

        public static void SaveSetting(string key, string value)
        {
            Properties.Settings.Default[key] = value;
            Properties.Settings.Default.Save();
        }

    }
}
