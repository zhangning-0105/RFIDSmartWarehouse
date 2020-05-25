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
    public partial class CreateInventoryInfo : Form
    {
        public CreateInventoryInfo()
        {
            InitializeComponent();
        }

        public static List<ShelfCodeProductInfo> shelfCodeProductInfos = new List<ShelfCodeProductInfo>();


        private void CreateInventoryInfo_Load(object sender, EventArgs e)
        {
            GetShelfCodeProductInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DatabaseHelper.InsertIntoInventoryInfo(comboBox1.SelectedItem.ToString(), comboBox3.SelectedItem.ToString()))
            {
                MessageBox.Show("创建盘点订单成功");
            }
            else
            {
                MessageBox.Show("创建盘点订单失败");
            }
            comboBox1.SelectedItem = "";
            comboBox3.SelectedItem = "";
        }

        public void GetShelfCodeProductInfo()
        {
            comboBox1.Items.Clear();
            shelfCodeProductInfos = DatabaseHelper.GetShelfCodeProductInfos();
            foreach (var item in shelfCodeProductInfos)
            {
                comboBox1.Items.Add(item.productname);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            foreach (var item in shelfCodeProductInfos[comboBox1.SelectedIndex].shelflocation)
            {
                comboBox3.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
