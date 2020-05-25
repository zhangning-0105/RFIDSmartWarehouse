using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RFIDSmartWarehouse
{
    public partial class EnvironmentalMonito : Form
    {
        public EnvironmentalMonito()
        {
            InitializeComponent();
            InitChart();
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += Timer1_Tick;
        }

        public Queue<wdsd> wdsdqueue = new Queue<wdsd>(10);


        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateQueueValue();
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            for (int i = 0; i < wdsdqueue.Count; i++)
            {
                var datetime = DateTime.Parse(wdsdqueue.ElementAt(i).thinfo.upTime);
                this.chart1.Series[0].Points.AddXY(datetime.ToLongTimeString().ToString(), wdsdqueue.ElementAt(i).thinfo.tempetature);
                this.chart1.Series[1].Points.AddXY(datetime.ToLongTimeString().ToString(), wdsdqueue.ElementAt(i).thinfo.humidity);

            }
    
        }

        private void UpdateQueueValue()
        {
            try
            {
                while (wdsdqueue.Count > 10)
                {
                    wdsdqueue.Dequeue();
                }

                HttpHelper httpHelper = new HttpHelper();
                var wdsdstr = httpHelper.HTTPJsonGet("http://47.102.195.242:9090/gttest/wdsd/2CF43277BDEF");
                var wdsddata = JsonConvert.DeserializeObject<wdsd>(wdsdstr);
                if (wdsddata.success.Equals("T"))
                {
                    wdsdqueue.Enqueue(wdsddata);
                    this.ucMeter1.Value = Convert.ToDecimal(wdsddata.thinfo.tempetature);
                    this.ucMeter2.Value = Convert.ToDecimal(wdsddata.thinfo.humidity);
                    this.label1.Text = "当前时间:" + wdsddata.thinfo.upTime;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("获取温湿度数据失败", ex);
            }
        }

        private void InitChart()
        {
            //定义图表区域
            this.chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            this.chart1.ChartAreas.Add(chartArea1);
            //定义存储和显示点的容器
            this.chart1.Series.Clear();
            Series series1 = new Series("温度");
            series1.ChartArea = "C1";
            this.chart1.Series.Add(series1);
            Series series2 = new Series("湿度");
            series2.ChartArea = "C1";
            this.chart1.Series.Add(series2);
            //设置图表显示样式
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;
            this.chart1.ChartAreas[0].AxisY.Maximum = 80;
            this.chart1.ChartAreas[0].AxisX.Interval = 1;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //设置标题
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("S01");
            this.chart1.Titles[0].Text = "XXX显示";
            this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //设置图表显示样式
            this.chart1.Series[0].Color = Color.Red;
            this.chart1.Titles[0].Text = "温湿度实时监控";
            this.chart1.Series[0].ChartType = SeriesChartType.Line;
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[0].Label = "#VAL";
            this.chart1.Series[1].Color = Color.Blue;
            this.chart1.Series[1].Label = "#VAL";
            this.chart1.Series[1].ChartType = SeriesChartType.Line;
            this.chart1.Series[1].Points.Clear();
        }
    }

    public class wdsd
    {
        public string success { get; set; }

        public thinfo thinfo { get; set; }
    }
    public class thinfo
    {
        public string id { get; set; }

        public string isNewRecord { get; set; }

        public string remarks { get; set; }

        public string createDate { get; set; }

        public string updateDate { get; set; }

        public string deviceNo { get; set; }

        public string tempetature { get; set; }

        public string humidity { get; set; }

        public string upTime { get; set; }
    }

}
