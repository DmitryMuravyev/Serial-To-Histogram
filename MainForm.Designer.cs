namespace SerialToHistogram
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.VerticalLineAnnotation verticalLineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.VerticalLineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.histogramChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ptpLabel = new System.Windows.Forms.Label();
            this.portsComboBox = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.speedComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.avgLabel = new System.Windows.Forms.Label();
            this.vRefLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.millivoltsRadioButton = new System.Windows.Forms.RadioButton();
            this.voltsRadioButton = new System.Windows.Forms.RadioButton();
            this.valuesRadioButton = new System.Windows.Forms.RadioButton();
            this.exportImageButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.maximumLabel = new System.Windows.Forms.Label();
            this.minimumLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clearDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.histogramChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // histogramChart
            // 
            this.histogramChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            verticalLineAnnotation1.AllowMoving = true;
            verticalLineAnnotation1.AxisXName = "ChartArea1\\rX";
            verticalLineAnnotation1.ClipToChartArea = "ChartArea1";
            verticalLineAnnotation1.IsInfinitive = true;
            verticalLineAnnotation1.LineColor = System.Drawing.Color.Red;
            verticalLineAnnotation1.LineWidth = 2;
            verticalLineAnnotation1.Name = "averageLine";
            verticalLineAnnotation1.ToolTip = "123";
            verticalLineAnnotation1.Visible = false;
            verticalLineAnnotation1.X = 5D;
            this.histogramChart.Annotations.Add(verticalLineAnnotation1);
            chartArea1.Name = "ChartArea1";
            this.histogramChart.ChartAreas.Add(chartArea1);
            this.histogramChart.Location = new System.Drawing.Point(12, 12);
            this.histogramChart.Name = "histogramChart";
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "PointWidth=1";
            series1.Name = "Series1";
            this.histogramChart.Series.Add(series1);
            this.histogramChart.Size = new System.Drawing.Size(1504, 582);
            this.histogramChart.TabIndex = 0;
            this.histogramChart.Text = "Histogram";
            this.histogramChart.Paint += new System.Windows.Forms.PaintEventHandler(this.histogramChart_Paint);
            // 
            // ptpLabel
            // 
            this.ptpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ptpLabel.AutoSize = true;
            this.ptpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ptpLabel.Location = new System.Drawing.Point(691, 22);
            this.ptpLabel.Name = "ptpLabel";
            this.ptpLabel.Size = new System.Drawing.Size(26, 29);
            this.ptpLabel.TabIndex = 1;
            this.ptpLabel.Text = "?";
            this.ptpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // portsComboBox
            // 
            this.portsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.portsComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.portsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portsComboBox.FormattingEnabled = true;
            this.portsComboBox.Location = new System.Drawing.Point(1326, 610);
            this.portsComboBox.Name = "portsComboBox";
            this.portsComboBox.Size = new System.Drawing.Size(190, 28);
            this.portsComboBox.TabIndex = 2;
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.Location = new System.Drawing.Point(1326, 692);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(190, 48);
            this.connectButton.TabIndex = 3;
            this.connectButton.Tag = "0";
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // speedComboBox
            // 
            this.speedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.speedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedComboBox.FormattingEnabled = true;
            this.speedComboBox.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200"});
            this.speedComboBox.Location = new System.Drawing.Point(1326, 644);
            this.speedComboBox.Name = "speedComboBox";
            this.speedComboBox.Size = new System.Drawing.Size(190, 28);
            this.speedComboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(509, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Peak-to-peak:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(31, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Calibrated Average:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(31, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Reference (V):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // avgLabel
            // 
            this.avgLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.avgLabel.AutoSize = true;
            this.avgLabel.BackColor = System.Drawing.SystemColors.Control;
            this.avgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.avgLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.avgLabel.Location = new System.Drawing.Point(278, 60);
            this.avgLabel.Name = "avgLabel";
            this.avgLabel.Size = new System.Drawing.Size(25, 29);
            this.avgLabel.TabIndex = 8;
            this.avgLabel.Text = "?";
            this.avgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vRefLabel
            // 
            this.vRefLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vRefLabel.AutoSize = true;
            this.vRefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vRefLabel.Location = new System.Drawing.Point(278, 99);
            this.vRefLabel.Name = "vRefLabel";
            this.vRefLabel.Size = new System.Drawing.Size(25, 29);
            this.vRefLabel.TabIndex = 9;
            this.vRefLabel.Text = "?";
            this.vRefLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.millivoltsRadioButton);
            this.groupBox1.Controls.Add(this.voltsRadioButton);
            this.groupBox1.Controls.Add(this.valuesRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(1148, 600);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 140);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display as";
            // 
            // millivoltsRadioButton
            // 
            this.millivoltsRadioButton.AutoSize = true;
            this.millivoltsRadioButton.Enabled = false;
            this.millivoltsRadioButton.Location = new System.Drawing.Point(18, 95);
            this.millivoltsRadioButton.Name = "millivoltsRadioButton";
            this.millivoltsRadioButton.Size = new System.Drawing.Size(91, 24);
            this.millivoltsRadioButton.TabIndex = 2;
            this.millivoltsRadioButton.TabStop = true;
            this.millivoltsRadioButton.Text = "Millivolts";
            this.millivoltsRadioButton.UseVisualStyleBackColor = true;
            this.millivoltsRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // voltsRadioButton
            // 
            this.voltsRadioButton.AutoSize = true;
            this.voltsRadioButton.Enabled = false;
            this.voltsRadioButton.Location = new System.Drawing.Point(18, 64);
            this.voltsRadioButton.Name = "voltsRadioButton";
            this.voltsRadioButton.Size = new System.Drawing.Size(70, 24);
            this.voltsRadioButton.TabIndex = 1;
            this.voltsRadioButton.Text = "Volts";
            this.voltsRadioButton.UseVisualStyleBackColor = true;
            this.voltsRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // valuesRadioButton
            // 
            this.valuesRadioButton.AutoSize = true;
            this.valuesRadioButton.Checked = true;
            this.valuesRadioButton.Location = new System.Drawing.Point(18, 34);
            this.valuesRadioButton.Name = "valuesRadioButton";
            this.valuesRadioButton.Size = new System.Drawing.Size(121, 24);
            this.valuesRadioButton.TabIndex = 0;
            this.valuesRadioButton.TabStop = true;
            this.valuesRadioButton.Text = "ADC Values";
            this.valuesRadioButton.UseVisualStyleBackColor = true;
            this.valuesRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // exportImageButton
            // 
            this.exportImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportImageButton.Enabled = false;
            this.exportImageButton.Location = new System.Drawing.Point(958, 609);
            this.exportImageButton.Name = "exportImageButton";
            this.exportImageButton.Size = new System.Drawing.Size(168, 64);
            this.exportImageButton.TabIndex = 11;
            this.exportImageButton.Text = "Save PNG";
            this.exportImageButton.UseVisualStyleBackColor = true;
            this.exportImageButton.Click += new System.EventHandler(this.exportImageButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.resolutionLabel);
            this.groupBox2.Controls.Add(this.maximumLabel);
            this.groupBox2.Controls.Add(this.minimumLabel);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ptpLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.vRefLabel);
            this.groupBox2.Controls.Add(this.avgLabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 600);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(921, 140);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resolutionLabel.Location = new System.Drawing.Point(278, 22);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(25, 29);
            this.resolutionLabel.TabIndex = 18;
            this.resolutionLabel.Text = "?";
            this.resolutionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maximumLabel
            // 
            this.maximumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.maximumLabel.AutoSize = true;
            this.maximumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maximumLabel.Location = new System.Drawing.Point(691, 99);
            this.maximumLabel.Name = "maximumLabel";
            this.maximumLabel.Size = new System.Drawing.Size(26, 29);
            this.maximumLabel.TabIndex = 17;
            this.maximumLabel.Text = "?";
            this.maximumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minimumLabel
            // 
            this.minimumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.minimumLabel.AutoSize = true;
            this.minimumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minimumLabel.Location = new System.Drawing.Point(691, 60);
            this.minimumLabel.Name = "minimumLabel";
            this.minimumLabel.Size = new System.Drawing.Size(26, 29);
            this.minimumLabel.TabIndex = 16;
            this.minimumLabel.Text = "?";
            this.minimumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DodgerBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(484, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 29);
            this.label8.TabIndex = 15;
            this.label8.Text = " ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Red;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 29);
            this.label7.TabIndex = 14;
            this.label7.Text = " ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(31, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "Resolution (bits):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(509, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Maximum:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(509, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Minimum:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clearDataButton
            // 
            this.clearDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearDataButton.Enabled = false;
            this.clearDataButton.Location = new System.Drawing.Point(958, 692);
            this.clearDataButton.Name = "clearDataButton";
            this.clearDataButton.Size = new System.Drawing.Size(168, 48);
            this.clearDataButton.TabIndex = 13;
            this.clearDataButton.Text = "Clear Data";
            this.clearDataButton.UseVisualStyleBackColor = true;
            this.clearDataButton.Click += new System.EventHandler(this.clearDataButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 752);
            this.Controls.Add(this.clearDataButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.exportImageButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.speedComboBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.portsComboBox);
            this.Controls.Add(this.histogramChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1550, 800);
            this.Name = "MainForm";
            this.Text = "SerialToHistogram";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.histogramChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart histogramChart;
        private System.Windows.Forms.Label ptpLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox portsComboBox;
        private System.Windows.Forms.ComboBox speedComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label avgLabel;
        private System.Windows.Forms.Label vRefLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton voltsRadioButton;
        private System.Windows.Forms.RadioButton valuesRadioButton;
        private System.Windows.Forms.Button exportImageButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.Label maximumLabel;
        private System.Windows.Forms.Label minimumLabel;
        private System.Windows.Forms.RadioButton millivoltsRadioButton;
        private System.Windows.Forms.Button clearDataButton;
    }
}

