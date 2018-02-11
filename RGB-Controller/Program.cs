using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_Controller
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!SettingsMan.GetSetting("hue_ip").Equals("null"))
            {
                Application.Run(new Main());
            }
            else
            {
                Application.Run(new Setup());
            }
        }
    }
}
