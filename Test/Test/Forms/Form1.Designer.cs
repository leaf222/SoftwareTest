namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TestName = new System.Windows.Forms.ComboBox();
            this.TestMethod = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StartButton = new System.Windows.Forms.Button();
            this.TestVersion = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // TestName
            // 
            this.TestName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TestName.FormattingEnabled = true;
            this.TestName.Location = new System.Drawing.Point(555, 81);
            this.TestName.Name = "TestName";
            this.TestName.Size = new System.Drawing.Size(155, 23);
            this.TestName.TabIndex = 0;
            this.TestName.SelectedIndexChanged += new System.EventHandler(this.TestName_SelectedIndexChanged);
            // 
            // TestMethod
            // 
            this.TestMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TestMethod.FormattingEnabled = true;
            this.TestMethod.Location = new System.Drawing.Point(555, 183);
            this.TestMethod.Name = "TestMethod";
            this.TestMethod.Size = new System.Drawing.Size(155, 23);
            this.TestMethod.TabIndex = 1;
            this.TestMethod.SelectedIndexChanged += new System.EventHandler(this.TestMethod_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 40);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(537, 345);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(555, 230);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(112, 23);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "StartTest";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // TestVersion
            // 
            this.TestVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TestVersion.FormattingEnabled = true;
            this.TestVersion.Location = new System.Drawing.Point(555, 130);
            this.TestVersion.Name = "TestVersion";
            this.TestVersion.Size = new System.Drawing.Size(155, 23);
            this.TestVersion.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TestVersion);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.TestMethod);
            this.Controls.Add(this.TestName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox TestName;
        private System.Windows.Forms.ComboBox TestMethod;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ComboBox TestVersion;
    }
}

