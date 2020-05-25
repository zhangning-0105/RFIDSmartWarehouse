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
    public partial class CreateOuthouseInfo : Form
    {
        public CreateOuthouseInfo()
        {
            InitializeComponent();
        }

        List<Productinfo> productinfos = new List<Productinfo>();

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) > int.Parse(productinfos[comboBox1.SelectedIndex].Count))
            {
                MessageBox.Show(string.Format("该商品最多可以出库{0}个", productinfos[comboBox1.SelectedIndex].Count));
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请添加商品数量");
                return;
            }
            var productname = comboBox1.SelectedItem.ToString();
            var count = textBox1.Text;
            var tids = productinfos[comboBox1.SelectedIndex].tids.Take(int.Parse(count)).ToList();
            if (DatabaseHelper.CreateOuthoueOrder(productname, count))
            {
                MessageBox.Show("创建出库订单成功");
                Getproductinfos();
            }
            comboBox1.SelectedItem = "";
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateOuthouseInfo_Load(object sender, EventArgs e)
        {

            Getproductinfos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        public void Getproductinfos()
        {
            productinfos = DatabaseHelper.GetProductinfos();
            foreach (var item in productinfos)
            {
                comboBox1.Items.Add(item.ProductName);
            }
        }
    
    }
}
