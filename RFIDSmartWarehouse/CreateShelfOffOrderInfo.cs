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
    public partial class CreateShelfOffOrderInfo : Form
    {
        public CreateShelfOffOrderInfo()
        {
            InitializeComponent();
        }

        public static List<Productinfo> productinfos = new List<Productinfo>();

        public static List<ShelfCode> shelfCodes = new List<ShelfCode>();
 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string productname = comboBox1.SelectedItem.ToString();
                var tids = shelfCodes[comboBox3.SelectedIndex].tids.Take(2).ToList();
                string shelflocation = comboBox3.SelectedItem.ToString();
                string shelfcode = shelfCodes[comboBox3.SelectedIndex].shelfcode;
                if (DatabaseHelper.CreateShelfOffOrderInfoAndUpdateShelfState(Guid.NewGuid().ToString("N"), tids, shelflocation, shelfcode, productname, "2"))
                {
                    GetShelfOffOrder();
                    MessageBox.Show("创建下架订单成功！");
                }
                else
                {
                    MessageBox.Show("创建下架订单失败！");
                }
                comboBox1.SelectedItem = "";
                comboBox3.SelectedItem = "";
                GetShelfOffOrder();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("创建下架订单失败", ex);
            }
        }

        private void CreateShelfOffOrderInfo_Load(object sender, EventArgs e)
        {
            GetShelfOffOrder();
        }

        public void GetShelfOffOrder()
        {
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            productinfos = DatabaseHelper.GetShelfOffInfo();
            foreach (var item in productinfos)
            {
                comboBox1.Items.Add(item.ProductName);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            shelfCodes = DatabaseHelper.GetShelfCodes(comboBox1.SelectedItem.ToString());
            foreach (var item in shelfCodes)
            {
                comboBox3.Items.Add(item.shelflocation);
            }
        }
    }
}
