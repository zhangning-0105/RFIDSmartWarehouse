namespace RFIDSmartWarehouse
{
    partial class InventoryManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.盘点订单编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.盘点产品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.盘点操作人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.盘点产品数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.盘点时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.盘点创建时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.货架位置 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.盘点订单状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.盘点结果 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.dateTimePicker2);
            this.groupBox3.Location = new System.Drawing.Point(36, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1277, 100);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(140, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 49);
            this.button5.TabIndex = 9;
            this.button5.Text = "创建盘点订单";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "是",
            "否"});
            this.comboBox1.Location = new System.Drawing.Point(998, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(57, 20);
            this.comboBox1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(911, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "是否盘点";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(606, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 49);
            this.label2.TabIndex = 6;
            this.label2.Text = "结束时间";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1090, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 49);
            this.button2.TabIndex = 2;
            this.button2.Text = "查询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(260, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 49);
            this.label1.TabIndex = 5;
            this.label1.Text = "开始时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(366, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(705, 47);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.盘点订单编号,
            this.盘点产品名称,
            this.盘点操作人,
            this.盘点产品数量,
            this.盘点时间,
            this.盘点创建时间,
            this.货架位置,
            this.盘点订单状态,
            this.盘点结果});
            this.dataGridView1.Location = new System.Drawing.Point(36, 130);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1277, 674);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // 盘点订单编号
            // 
            this.盘点订单编号.DataPropertyName = "盘点订单编号";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.盘点订单编号.DefaultCellStyle = dataGridViewCellStyle1;
            this.盘点订单编号.HeaderText = "订单编号";
            this.盘点订单编号.Name = "盘点订单编号";
            this.盘点订单编号.ReadOnly = true;
            this.盘点订单编号.Width = 78;
            // 
            // 盘点产品名称
            // 
            this.盘点产品名称.DataPropertyName = "盘点产品名称";
            this.盘点产品名称.HeaderText = "产品名称";
            this.盘点产品名称.Name = "盘点产品名称";
            this.盘点产品名称.ReadOnly = true;
            this.盘点产品名称.Width = 78;
            // 
            // 盘点操作人
            // 
            this.盘点操作人.DataPropertyName = "盘点操作人";
            this.盘点操作人.HeaderText = "操作人";
            this.盘点操作人.Name = "盘点操作人";
            this.盘点操作人.ReadOnly = true;
            this.盘点操作人.Width = 66;
            // 
            // 盘点产品数量
            // 
            this.盘点产品数量.DataPropertyName = "盘点产品数量";
            this.盘点产品数量.HeaderText = "产品数量";
            this.盘点产品数量.Name = "盘点产品数量";
            this.盘点产品数量.ReadOnly = true;
            this.盘点产品数量.Width = 78;
            // 
            // 盘点时间
            // 
            this.盘点时间.DataPropertyName = "盘点时间";
            this.盘点时间.HeaderText = "盘点时间";
            this.盘点时间.Name = "盘点时间";
            this.盘点时间.ReadOnly = true;
            this.盘点时间.Width = 78;
            // 
            // 盘点创建时间
            // 
            this.盘点创建时间.DataPropertyName = "盘点创建时间";
            this.盘点创建时间.HeaderText = "创建时间";
            this.盘点创建时间.Name = "盘点创建时间";
            this.盘点创建时间.ReadOnly = true;
            this.盘点创建时间.Width = 78;
            // 
            // 货架位置
            // 
            this.货架位置.DataPropertyName = "货架位置";
            this.货架位置.HeaderText = "货架位置";
            this.货架位置.Name = "货架位置";
            this.货架位置.ReadOnly = true;
            this.货架位置.Width = 78;
            // 
            // 盘点订单状态
            // 
            this.盘点订单状态.DataPropertyName = "盘点状态";
            this.盘点订单状态.HeaderText = "盘点状态";
            this.盘点订单状态.Name = "盘点订单状态";
            this.盘点订单状态.ReadOnly = true;
            this.盘点订单状态.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.盘点订单状态.Width = 78;
            // 
            // 盘点结果
            // 
            this.盘点结果.HeaderText = "盘点结果";
            this.盘点结果.Name = "盘点结果";
            this.盘点结果.ReadOnly = true;
            this.盘点结果.Width = 78;
            // 
            // InventoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 835);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InventoryManagement";
            this.Text = "InventoryManagement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 盘点订单编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 盘点产品名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 盘点操作人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 盘点产品数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 盘点时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 盘点创建时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 货架位置;
        private System.Windows.Forms.DataGridViewTextBoxColumn 盘点订单状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 盘点结果;
    }
}