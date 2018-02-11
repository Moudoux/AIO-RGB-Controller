using System;
using System.Windows.Forms;
using RGB_SDK_Wrapper;

namespace RGB_Controller
{
    public partial class Main : Form { 

        private RGBSDKWrapper _controller;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _controller = new RGBSDKWrapper();
            Setup();
        }

        private async void Setup()
        {
            string appKey = await _controller.SetupHue(SettingsMan.GetSetting("hue_ip"), SettingsMan.GetSetting("hue_app_key"));
            SettingsMan.SaveSetting("hue_app_key", appKey);
        }

        private void selectColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            panel1.BackColor = colorDialog1.Color;
        }

        private void apply_Click(object sender, EventArgs e)
        {
            _controller.SetColor(new RgbColor(colorDialog1.Color));
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.Shutdown();
        }
    }
}
