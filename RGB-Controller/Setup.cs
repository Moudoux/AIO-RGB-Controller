using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_Controller
{
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsMan.SaveSetting("hue_ip", textBox1.Text);
            new Main().Show();
            this.Close();
        }
    }
}
