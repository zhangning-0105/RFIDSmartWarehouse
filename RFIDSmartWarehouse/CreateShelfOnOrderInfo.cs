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
    public partial class CreateShelfOnOrderInfo : Form
    {
        public CreateShelfOnOrderInfo()
        {
            InitializeComponent();
        }

        public static ShelfOnInfo shelfOnInfo = new ShelfOnInfo();

        private void CreateShelfOnOrderInfo_Load(object sender, EventArgs e)
        {
            GetShelfOnOrder();
        }

        public void GetShelfOnOrder()
        {
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            shelfOnInfo = DatabaseHelper.GetShelfOnInfo();
            foreach (var item in shelfOnInfo.productinfos)
            {
                comboBox1.Items.Add(item.ProductName);
            }

            foreach (var item in shelfOnInfo.ShelfCodes)
            {
                comboBox3.Items.Add(item.shelflocation);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string productname = comboBox1.SelectedItem.ToString();
                var tids = shelfOnInfo.productinfos[comboBox1.SelectedIndex].tids.Take(2).ToList();
                string shelflocation = comboBox3.SelectedItem.ToString();
                string shelfcode = shelfOnInfo.ShelfCodes[comboBox3.SelectedIndex].shelfcode;
                if (DatabaseHelper.CreateShelfOnOrderInfoAndUpdateShelfState(Guid.NewGuid().ToString("N"), tids, shelflocation, shelfcode,productname, tids.Count.ToString()))
                {
                    GetShelfOnOrder();
                    MessageBox.Show("创建上架订单成功！");
                 
                }
                else
                {
                    MessageBox.Show("创建上架订单失败！");
                }
                comboBox1.SelectedItem = "";
                comboBox3.SelectedItem = "";
                GetShelfOnOrder();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("创建上架订单失败", ex);
            }
        }
    }
}
