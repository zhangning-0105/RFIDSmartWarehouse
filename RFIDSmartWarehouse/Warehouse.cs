using Impinj.OctaneSdk;
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
    public partial class Warehouse : Form
    {
        public Warehouse()
        {
            InitializeComponent();
        }

        public static ImpinjReader reader = new ImpinjReader();
        static string reader_ip = "";//读写器ip

        public List<string> tids = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            reader.Disconnect();
            this.Close();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                reader.Connect("192.168.0.211");
                Settings settings = reader.QueryDefaultSettings();
                FeatureSet features = reader.QueryFeatureSet();

                settings.Report.IncludeAntennaPortNumber = true;

                //settings.Report.Mode = ReportMode.WaitForQuery;
                settings.Report.Mode = ReportMode.Individual;
                //settings.Report.Mode = ReportMode.BatchAfterStop;

                settings.ReaderMode = ReaderMode.MaxThroughput;
                settings.SearchMode = SearchMode.DualTarget;
                settings.Session = 1;
                settings.TagPopulationEstimate = 32;//设置预读数量

                //设置标签过滤器，只有符合过滤器的标签才能读取
                //settings.Filters.Mode = TagFilterMode.OnlyFilter1;
                //settings.Filters.TagFilter1.MemoryBank = MemoryBank.Epc;
                //settings.Filters.TagFilter1.BitPointer = 0x20;
                //settings.Filters.TagFilter1.TagMask = TagData.FromHexString("3008");


                //设置发送功率（分贝毫瓦）
                settings.Antennas.GetAntenna(1).TxPowerInDbm = 15;
                settings.Antennas.GetAntenna(2).TxPowerInDbm = 15;
                settings.Antennas.GetAntenna(3).TxPowerInDbm = 15;
                settings.Antennas.GetAntenna(4).TxPowerInDbm = 15;
                //设置接收功率（分贝毫瓦）
                //settings.Antennas.GetAntenna(1).RxSensitivityInDbm = 15;
                //settings.Antennas.GetAntenna(2).RxSensitivityInDbm = 15;
                //settings.Antennas.GetAntenna(3).RxSensitivityInDbm = 15;
                //settings.Antennas.GetAntenna(4).RxSensitivityInDbm = 15;

                //设置低负荷周期
                //LowDutyCycleSettings ldc = new LowDutyCycleSettings();
                //ldc.EmptyFieldTimeoutInMs = 500;
                //ldc.FieldPingIntervalInMs = 200;
                //ldc.IsEnabled = true;
                //settings.LowDutyCycle = ldc;

                //设置读取TID
                settings.Report.IncludeFastId = true;
                //设置读取标签信号
                settings.Report.IncludePeakRssi = true;

                //设置发送频率
                /*List<double> freqList = new List<double>();
                freqList.Add(865.7);
                freqList.Add(866.3);
                freqList.Add(866.9);
                freqList.Add(867.5);
                settings.TxFrequenciesInMhz = freqList;*/
                reader.ApplySettings(settings);//应用设置
                reader.TagsReported += OnTagsReported;

                reader.Start();
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("通道门读取产品信息失败", ex);
            }
        }

        public void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            reader_ip = sender.Address;

            foreach (Tag tag in report)
            {


                //Console.WriteLine("RSSI:" + String.Format("{0:0.00}", tag.PeakRssiInDbm));
                if (tag.IsFastIdPresent)
                {
                    this.SetEpc(tag.Tid.ToString().Replace(" ", "").Substring(0, 16), tag.Epc.ToString().Replace(" ", ""), tag.AntennaPortNumber + "", String.Format("{0:0.00}", tag.PeakRssiInDbm));

                }
                else
                {
                    this.SetEpc("未获取", tag.Epc.ToString().Replace(" ", ""), tag.AntennaPortNumber + "", String.Format("{0:0.00}", tag.PeakRssiInDbm));

                }
            }
        }

        delegate void SetTextCallback(string text);//委托回调

        delegate void SetListCallback(string tid, string epc, string number, string rssi);//委托回调

        public void SetEpc(string tid, string epc, string number, string rssi)
        {
            if (InvokeRequired)
            {
                SetListCallback d = new SetListCallback(SetEpc);
                this.Invoke(d, new object[] { tid, epc, number, rssi });
            }
            else
            {
                if(!tids.Contains(tid))
                {
                    tids.Add(tid);
                    label4.Text = "已读取产品数量:" + tids.Count;
                    textBox1.Text += tid + "\r\n";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var strcout = label3.Text.Split(new char[1] { ':' })[1];
                if (tids.Count == Convert.ToInt32(strcout))
                {
                    var ordernum = label1.Text.Split(new char[1] { ':' })[1];
                    var productname = label2.Text.Split(new char[1] { ':' })[1];
                    if ( DatabaseHelper.InsertIntoProdcutsAndUpdateWarehouseOrderstaus(tids,productname,ordernum) )
                    {
             
                        MessageBox.Show("入库成功");
                        button3.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("入库失败，读取的产品tid中有已入库的产品或者读取数据库验证失败");
                    }

                }
                else
                {
                    MessageBox.Show("已读取产品数量与入库订单数量不符合，请重新读取后再入库");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("入库失败");
                LogHelper.WriteLog("", ex);
            }
            finally
            {
                label4.Text = "已读取产品数量:";
                tids.Clear();
                textBox1.Text = "";
            }
        }
    }
}
