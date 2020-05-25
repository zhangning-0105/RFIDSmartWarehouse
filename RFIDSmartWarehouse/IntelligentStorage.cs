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
    public partial class IntelligentStorage : Form
    {
        public IntelligentStorage()
        {
            InitializeComponent();

            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("黑体", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            //列Header的背景色
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.AutoGenerateColumns = false;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("黑体", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            //列Header的背景色
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView2.ColumnHeadersHeight = 30;
            dataGridView2.RowTemplate.Height = 30;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GetProductinfos();

        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        /// <summary>
        /// 入库刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            GetProductinfos();
        }
        public void GetProductinfos()
        {
            dataGridView1.Rows.Clear();
            var orderlist1 = DatabaseHelper.GetInHouseOrders();
            foreach (var item in orderlist1)
            {
                dataGridView1.Rows.Add(item);
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["入库订单状态"].Value.ToString() == "未入库")
                {
                    dataGridView1.Rows[i].Cells["入库订单状态"].Style.ForeColor = Color.Red;
                }
            }
            dataGridView2.Rows.Clear();
          
            var orderlist2 = DatabaseHelper.GetOutHouseOrders();
            foreach (var item in orderlist2)
            {
                dataGridView2.Rows.Add(item);
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells["出库订单状态"].Value.ToString() == "未出库")
                {
                    dataGridView2.Rows[i].Cells["出库订单状态"].Style.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// 入库查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 出库刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            GetProductinfos();

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0) // 绘制 自动序号
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle vRect = e.CellBounds;
                vRect.Inflate(-2, 2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, vRect, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                e.Handled = true;
            }
            e.CellStyle.SelectionBackColor = Color.Gray; // 选中单元格时，背景色
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //单位格内数据对齐方式
          
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0) // 绘制 自动序号
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle vRect = e.CellBounds;
                vRect.Inflate(-2, 2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, vRect, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                e.Handled = true;
            }
            e.CellStyle.SelectionBackColor = Color.Gray; // 选中单元格时，背景色
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //单位格内数据对齐方式
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["入库订单状态"].Index)
            {
                Warehouse warehouse = new Warehouse();

                warehouse.label1.Text = "订单编号:" + dataGridView1.Rows[e.RowIndex].Cells["入库订单编号"].Value.ToString();
                warehouse.label2.Text = "产品名称:" + dataGridView1.Rows[e.RowIndex].Cells["入库产品名称"].Value.ToString();
                warehouse.label3.Text = "需入库数量:" + dataGridView1.Rows[e.RowIndex].Cells["入库产品数量"].Value.ToString();
                //订单入库状态下，详情页面入库按钮不可点击
                if (dataGridView1.Rows[e.RowIndex].Cells["入库订单状态"].Value.ToString() == "已入库")
                {
                    warehouse.button2.Enabled = false;
                    warehouse.button3.Enabled = false;
                }
                warehouse.ShowDialog();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dataGridView2.Columns["出库订单状态"].Index)
                {
                    Outhouse warehouse = new Outhouse();

                    warehouse.label1.Text = "订单编号:" + dataGridView2.Rows[e.RowIndex].Cells["出库订单编号"].Value.ToString();
                    warehouse.label2.Text = "产品名称:" + dataGridView2.Rows[e.RowIndex].Cells["出库产品名称"].Value.ToString();
                    warehouse.label3.Text = "需出库数量:" + dataGridView2.Rows[e.RowIndex].Cells["出库产品数量"].Value.ToString();

                    warehouse.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Rectangle rectangle = tabControl1.GetTabRect(i);
               // e.Graphics.DrawString(tabControl1.TabPages[i].Text,new Font("黑体",10),black,rectangle,StringFormat)
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateWarehouseInfo createWarehouseInfo = new CreateWarehouseInfo();
            createWarehouseInfo.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CreateOuthouseInfo createOuthouseInfo = new CreateOuthouseInfo();
            createOuthouseInfo.ShowDialog();
        }
    }
}
