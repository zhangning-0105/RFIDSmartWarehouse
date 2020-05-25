using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDSmartWarehouse
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.label4.Hide();
        }

        public static FunctionalModules FunctionalModules;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox1.Text == "admin" && textBox2.Text == "123")
                {
                    this.timer1.Enabled = true;
                    this.timer1.Interval = 2000;
                    this.timer1.Tick += Timer1_Tick;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("登录出错", ex);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.label4.Show();
            this.Hide();
            if (FunctionalModules == null || FunctionalModules.IsDisposed == true)
            {
                FunctionalModules = new FunctionalModules();
                FunctionalModules.Show();
            }
        }
    }
}
