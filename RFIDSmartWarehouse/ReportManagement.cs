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
    public partial class ReportManagement : Form
    {
        public ReportManagement()
        {
            InitializeComponent();
            chart1.Hide();
        }

        public void GetProductinfos()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {


            chart1.Show();
        }
    }
}
