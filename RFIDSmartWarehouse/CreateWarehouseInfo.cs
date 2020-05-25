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
    public partial class CreateWarehouseInfo : Form
    {
        public CreateWarehouseInfo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请添加商品名称");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("请添加商品数量");
                return;
            }
            if (DatabaseHelper.CreateWarehoueOrder(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("创建入库订单成功！");
            }
            else
            {
                MessageBox.Show("创建入库订单失败！");
            }

        }
    }
}
