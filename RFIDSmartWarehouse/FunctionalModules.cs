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
    public partial class FunctionalModules : Form
    {
        public FunctionalModules()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            if (environmentalMonito == null || environmentalMonito.IsDisposed)
            {
                environmentalMonito = new EnvironmentalMonito();

            }
            if (videoSurveillance == null || videoSurveillance.IsDisposed)
            {
                videoSurveillance = new VideoSurveillance();
            }
            if (intelligentStorage == null || intelligentStorage.IsDisposed)
            {
                intelligentStorage = new IntelligentStorage();
            }
            if (inventoryManagement == null || inventoryManagement.IsDisposed)
            {
                inventoryManagement = new InventoryManagement();
            }
            if (shelfOnAndOff == null || shelfOnAndOff.IsDisposed)
            {
                shelfOnAndOff = new ShelfOnAndOff();
            }
            if (stockManagement == null || stockManagement.IsDisposed)
            {
                stockManagement = new StockManagement();
            }

        }

        public static EnvironmentalMonito environmentalMonito;
        public static VideoSurveillance videoSurveillance;
        public static IntelligentStorage intelligentStorage;
        public static InventoryManagement inventoryManagement;
        public static ShelfOnAndOff shelfOnAndOff;
        public static StockManagement stockManagement;


        private void button1_Click(object sender, EventArgs e)
        {
            videoSurveillance.MdiParent = this;
            videoSurveillance.Parent = this.panel1;
            videoSurveillance.Dock = DockStyle.Fill;
            videoSurveillance.Size = this.panel1.Size;
            videoSurveillance.Show();
            environmentalMonito.Hide();
            intelligentStorage.Hide();
            inventoryManagement.Hide();
            stockManagement.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            environmentalMonito.MdiParent = this;
            environmentalMonito.Parent = this.panel1;
            environmentalMonito.Dock = DockStyle.Fill;
            environmentalMonito.Size = this.panel1.Size;
            environmentalMonito.Show();
            environmentalMonito.WindowState = FormWindowState.Maximized;
            videoSurveillance.Hide();
            intelligentStorage.Hide();
            inventoryManagement.Hide();
            shelfOnAndOff.Hide();
            stockManagement.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            intelligentStorage.MdiParent = this;
            intelligentStorage.Parent = this.panel1;
            intelligentStorage.Dock = DockStyle.Fill;
            intelligentStorage.Size = this.panel1.Size;
            intelligentStorage.Show();
            environmentalMonito.Hide();
            videoSurveillance.Hide();
            inventoryManagement.Hide();
            shelfOnAndOff.Hide();
            stockManagement.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stockManagement.MdiParent = this;
            stockManagement.Parent = this.panel1;
            stockManagement.Dock = DockStyle.Fill;
            stockManagement.Size = this.panel1.Size;
            inventoryManagement.Hide();
            intelligentStorage.Hide();
            environmentalMonito.Hide();
            videoSurveillance.Hide();
            shelfOnAndOff.Hide();
            stockManagement.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shelfOnAndOff.MdiParent = this;
            shelfOnAndOff.Parent = this.panel1;
            shelfOnAndOff.Dock = DockStyle.Fill;
            shelfOnAndOff.Size = this.panel1.Size;
            shelfOnAndOff.Show();
            intelligentStorage.Hide();
            environmentalMonito.Hide();
            videoSurveillance.Hide();
            inventoryManagement.Hide();
            stockManagement.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inventoryManagement.MdiParent = this;
            inventoryManagement.Parent = this.panel1;
            inventoryManagement.Dock = DockStyle.Fill;
            inventoryManagement.Size = this.panel1.Size;
            inventoryManagement.Show();
            intelligentStorage.Hide();
            environmentalMonito.Hide();
            videoSurveillance.Hide();
            shelfOnAndOff.Hide();
            stockManagement.Hide();
        }
    }
}
