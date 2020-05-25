namespace RFIDSmartWarehouse
{
    partial class VideoSurveillance
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            this.vlcControl2 = new Vlc.DotNet.Forms.VlcControl();
            this.vlcControl3 = new Vlc.DotNet.Forms.VlcControl();
            this.vlcControl4 = new Vlc.DotNet.Forms.VlcControl();
            this.vlcControl5 = new Vlc.DotNet.Forms.VlcControl();
            this.vlcControl6 = new Vlc.DotNet.Forms.VlcControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl6)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.67025F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.32975F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 486F));
            this.tableLayoutPanel1.Controls.Add(this.vlcControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.vlcControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.vlcControl3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.vlcControl5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.vlcControl6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.vlcControl4, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1294, 750);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // vlcControl1
            // 
            this.vlcControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Location = new System.Drawing.Point(3, 3);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(379, 369);
            this.vlcControl1.Spu = -1;
            this.vlcControl1.TabIndex = 0;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.VlcLibDirectory = null;
            this.vlcControl1.VlcMediaplayerOptions = null;
            this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // vlcControl2
            // 
            this.vlcControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcControl2.BackColor = System.Drawing.Color.Black;
            this.vlcControl2.Location = new System.Drawing.Point(388, 3);
            this.vlcControl2.Name = "vlcControl2";
            this.vlcControl2.Size = new System.Drawing.Size(416, 369);
            this.vlcControl2.Spu = -1;
            this.vlcControl2.TabIndex = 1;
            this.vlcControl2.Text = "vlcControl2";
            this.vlcControl2.VlcLibDirectory = null;
            this.vlcControl2.VlcMediaplayerOptions = null;
            this.vlcControl2.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl2_VlcLibDirectoryNeeded);
            // 
            // vlcControl3
            // 
            this.vlcControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcControl3.BackColor = System.Drawing.Color.Black;
            this.vlcControl3.Location = new System.Drawing.Point(810, 3);
            this.vlcControl3.Name = "vlcControl3";
            this.vlcControl3.Size = new System.Drawing.Size(481, 369);
            this.vlcControl3.Spu = -1;
            this.vlcControl3.TabIndex = 2;
            this.vlcControl3.Text = "vlcControl3";
            this.vlcControl3.VlcLibDirectory = null;
            this.vlcControl3.VlcMediaplayerOptions = null;
            this.vlcControl3.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl3_VlcLibDirectoryNeeded);
            // 
            // vlcControl4
            // 
            this.vlcControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcControl4.BackColor = System.Drawing.Color.Black;
            this.vlcControl4.Location = new System.Drawing.Point(3, 378);
            this.vlcControl4.Name = "vlcControl4";
            this.vlcControl4.Size = new System.Drawing.Size(379, 369);
            this.vlcControl4.Spu = -1;
            this.vlcControl4.TabIndex = 3;
            this.vlcControl4.Text = "vlcControl4";
            this.vlcControl4.VlcLibDirectory = null;
            this.vlcControl4.VlcMediaplayerOptions = null;
            this.vlcControl4.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl4_VlcLibDirectoryNeeded);
            // 
            // vlcControl5
            // 
            this.vlcControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcControl5.BackColor = System.Drawing.Color.Black;
            this.vlcControl5.Location = new System.Drawing.Point(388, 378);
            this.vlcControl5.Name = "vlcControl5";
            this.vlcControl5.Size = new System.Drawing.Size(416, 369);
            this.vlcControl5.Spu = -1;
            this.vlcControl5.TabIndex = 4;
            this.vlcControl5.Text = "vlcControl5";
            this.vlcControl5.VlcLibDirectory = null;
            this.vlcControl5.VlcMediaplayerOptions = null;
            this.vlcControl5.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl5_VlcLibDirectoryNeeded);
            // 
            // vlcControl6
            // 
            this.vlcControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcControl6.BackColor = System.Drawing.Color.Black;
            this.vlcControl6.Location = new System.Drawing.Point(810, 378);
            this.vlcControl6.Name = "vlcControl6";
            this.vlcControl6.Size = new System.Drawing.Size(481, 369);
            this.vlcControl6.Spu = -1;
            this.vlcControl6.TabIndex = 5;
            this.vlcControl6.Text = "vlcControl6";
            this.vlcControl6.VlcLibDirectory = null;
            this.vlcControl6.VlcMediaplayerOptions = null;
            this.vlcControl6.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl6_VlcLibDirectoryNeeded);
            // 
            // VideoSurveillance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 774);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VideoSurveillance";
            this.Text = "VideoSurveillance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Vlc.DotNet.Forms.VlcControl vlcControl1;
        private Vlc.DotNet.Forms.VlcControl vlcControl2;
        private Vlc.DotNet.Forms.VlcControl vlcControl3;
        private Vlc.DotNet.Forms.VlcControl vlcControl4;
        private Vlc.DotNet.Forms.VlcControl vlcControl5;
        private Vlc.DotNet.Forms.VlcControl vlcControl6;
    }
}