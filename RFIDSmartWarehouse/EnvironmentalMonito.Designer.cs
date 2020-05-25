namespace RFIDSmartWarehouse
{
    partial class EnvironmentalMonito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ucMeter1 = new HZH_Controls.Controls.UCMeter();
            this.label1 = new System.Windows.Forms.Label();
            this.ucMeter2 = new HZH_Controls.Controls.UCMeter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(26, 39);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(688, 643);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // ucMeter1
            // 
            this.ucMeter1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucMeter1.BoundaryLineColor = System.Drawing.Color.Black;
            this.ucMeter1.ExternalRoundColor = System.Drawing.Color.Black;
            this.ucMeter1.FixedText = "温度";
            this.ucMeter1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter1.InsideRoundColor = System.Drawing.Color.Black;
            this.ucMeter1.Location = new System.Drawing.Point(70, 168);
            this.ucMeter1.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ucMeter1.MeterDegrees = 180;
            this.ucMeter1.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucMeter1.Name = "ucMeter1";
            this.ucMeter1.PointerColor = System.Drawing.Color.Black;
            this.ucMeter1.ScaleColor = System.Drawing.Color.Black;
            this.ucMeter1.ScaleValueColor = System.Drawing.Color.Black;
            this.ucMeter1.Size = new System.Drawing.Size(219, 117);
            this.ucMeter1.SplitCount = 10;
            this.ucMeter1.TabIndex = 1;
            this.ucMeter1.TextColor = System.Drawing.Color.Black;
            this.ucMeter1.TextFont = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter1.TextLocation = HZH_Controls.Controls.MeterTextLocation.Top;
            this.ucMeter1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "显示最新上报的时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucMeter2
            // 
            this.ucMeter2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucMeter2.BoundaryLineColor = System.Drawing.Color.Black;
            this.ucMeter2.ExternalRoundColor = System.Drawing.Color.Black;
            this.ucMeter2.FixedText = "湿度";
            this.ucMeter2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter2.InsideRoundColor = System.Drawing.Color.Black;
            this.ucMeter2.Location = new System.Drawing.Point(70, 373);
            this.ucMeter2.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ucMeter2.MeterDegrees = 180;
            this.ucMeter2.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucMeter2.Name = "ucMeter2";
            this.ucMeter2.PointerColor = System.Drawing.Color.Black;
            this.ucMeter2.ScaleColor = System.Drawing.Color.Black;
            this.ucMeter2.ScaleValueColor = System.Drawing.Color.Black;
            this.ucMeter2.Size = new System.Drawing.Size(219, 123);
            this.ucMeter2.SplitCount = 10;
            this.ucMeter2.TabIndex = 2;
            this.ucMeter2.TextColor = System.Drawing.Color.Black;
            this.ucMeter2.TextFont = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter2.TextLocation = HZH_Controls.Controls.MeterTextLocation.Top;
            this.ucMeter2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ucMeter2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ucMeter1);
            this.panel1.Location = new System.Drawing.Point(854, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 643);
            this.panel1.TabIndex = 4;
            // 
            // EnvironmentalMonito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 721);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnvironmentalMonito";
            this.Text = "EnvironmentalMonito";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private HZH_Controls.Controls.UCMeter ucMeter1;
        private System.Windows.Forms.Label label1;
        private HZH_Controls.Controls.UCMeter ucMeter2;
        private System.Windows.Forms.Panel panel1;
    }
}