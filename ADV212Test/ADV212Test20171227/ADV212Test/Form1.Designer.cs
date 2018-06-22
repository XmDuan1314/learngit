namespace ADV212Test
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_light = new System.Windows.Forms.Label();
            this.BtnOpenSerialPort = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbCOMPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_light = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.sp = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbPercent = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.openfiletextBox = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tBRcv = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.tBParameters = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tBIndirectRegisterValue = new System.Windows.Forms.TextBox();
            this.lb_light.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_light
            // 
            this.label_light.AutoSize = true;
            this.label_light.ForeColor = System.Drawing.Color.Red;
            this.label_light.Location = new System.Drawing.Point(178, 29);
            this.label_light.Name = "label_light";
            this.label_light.Size = new System.Drawing.Size(17, 12);
            this.label_light.TabIndex = 11;
            this.label_light.Text = "●";
            // 
            // BtnOpenSerialPort
            // 
            this.BtnOpenSerialPort.Location = new System.Drawing.Point(218, 21);
            this.BtnOpenSerialPort.Name = "BtnOpenSerialPort";
            this.BtnOpenSerialPort.Size = new System.Drawing.Size(71, 26);
            this.BtnOpenSerialPort.TabIndex = 10;
            this.BtnOpenSerialPort.Text = "打开串口";
            this.BtnOpenSerialPort.UseVisualStyleBackColor = true;
            this.BtnOpenSerialPort.Click += new System.EventHandler(this.BtnOpenSerialPort_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "校验位:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "停止位:";
            // 
            // cbStopBits
            // 
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.cbStopBits.Location = new System.Drawing.Point(218, 55);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(71, 20);
            this.cbStopBits.TabIndex = 3;
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "无校验",
            "奇校验",
            "偶校验"});
            this.cbParity.Location = new System.Drawing.Point(218, 84);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(71, 20);
            this.cbParity.TabIndex = 2;
            // 
            // cbCOMPort
            // 
            this.cbCOMPort.FormattingEnabled = true;
            this.cbCOMPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15"});
            this.cbCOMPort.Location = new System.Drawing.Point(70, 26);
            this.cbCOMPort.Name = "cbCOMPort";
            this.cbCOMPort.Size = new System.Drawing.Size(76, 20);
            this.cbCOMPort.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "数据位:";
            // 
            // lb_light
            // 
            this.lb_light.Controls.Add(this.label_light);
            this.lb_light.Controls.Add(this.label5);
            this.lb_light.Controls.Add(this.label4);
            this.lb_light.Controls.Add(this.BtnOpenSerialPort);
            this.lb_light.Controls.Add(this.label3);
            this.lb_light.Controls.Add(this.label2);
            this.lb_light.Controls.Add(this.label1);
            this.lb_light.Controls.Add(this.cbDataBits);
            this.lb_light.Controls.Add(this.cbStopBits);
            this.lb_light.Controls.Add(this.cbParity);
            this.lb_light.Controls.Add(this.cbBaudRate);
            this.lb_light.Controls.Add(this.cbCOMPort);
            this.lb_light.Location = new System.Drawing.Point(12, 12);
            this.lb_light.Name = "lb_light";
            this.lb_light.Size = new System.Drawing.Size(322, 116);
            this.lb_light.TabIndex = 3;
            this.lb_light.TabStop = false;
            this.lb_light.Text = "串口设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 6;
            this.label2.Tag = "";
            this.label2.Text = "波特率:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "串口号:";
            // 
            // cbDataBits
            // 
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(70, 83);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(76, 20);
            this.cbDataBits.TabIndex = 4;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "115200",
            "128000",
            "256000"});
            this.cbBaudRate.Location = new System.Drawing.Point(70, 55);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(76, 20);
            this.cbBaudRate.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 103);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbPercent);
            this.groupBox2.Controls.Add(this.btnOpenFile);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.openfiletextBox);
            this.groupBox2.Controls.Add(this.btnLoad);
            this.groupBox2.Location = new System.Drawing.Point(9, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 76);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "固件下载";
            // 
            // lbPercent
            // 
            this.lbPercent.AutoSize = true;
            this.lbPercent.Location = new System.Drawing.Point(261, 55);
            this.lbPercent.Name = "lbPercent";
            this.lbPercent.Size = new System.Drawing.Size(17, 12);
            this.lbPercent.TabIndex = 4;
            this.lbPercent.Text = "0%";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(14, 20);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(62, 26);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "打开文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 52);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(234, 17);
            this.progressBar1.TabIndex = 3;
            // 
            // openfiletextBox
            // 
            this.openfiletextBox.Location = new System.Drawing.Point(81, 22);
            this.openfiletextBox.Name = "openfiletextBox";
            this.openfiletextBox.Size = new System.Drawing.Size(172, 21);
            this.openfiletextBox.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(259, 20);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(37, 26);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "加载";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tBRcv);
            this.groupBox3.Location = new System.Drawing.Point(340, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 328);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收显示";
            // 
            // tBRcv
            // 
            this.tBRcv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBRcv.Location = new System.Drawing.Point(3, 17);
            this.tBRcv.Multiline = true;
            this.tBRcv.Name = "tBRcv";
            this.tBRcv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBRcv.Size = new System.Drawing.Size(317, 308);
            this.tBRcv.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(464, 346);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tBParameters
            // 
            this.tBParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBParameters.Location = new System.Drawing.Point(3, 17);
            this.tBParameters.Multiline = true;
            this.tBParameters.Name = "tBParameters";
            this.tBParameters.Size = new System.Drawing.Size(315, 35);
            this.tBParameters.TabIndex = 12;
            this.tBParameters.Text = "0400 0503 0100 0000 0200 0600 000f 0001";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tBParameters);
            this.groupBox4.Location = new System.Drawing.Point(13, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(321, 55);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "参数信息";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tBIndirectRegisterValue);
            this.groupBox5.Location = new System.Drawing.Point(13, 193);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(321, 55);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "间接寄存器值";
            // 
            // tBIndirectRegisterValue
            // 
            this.tBIndirectRegisterValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBIndirectRegisterValue.Location = new System.Drawing.Point(3, 17);
            this.tBIndirectRegisterValue.Multiline = true;
            this.tBIndirectRegisterValue.Name = "tBIndirectRegisterValue";
            this.tBIndirectRegisterValue.Size = new System.Drawing.Size(315, 35);
            this.tBIndirectRegisterValue.TabIndex = 12;
            this.tBIndirectRegisterValue.Text = "0004 0280 01e0 0000 0000 0001 0000 01e0 0000 0001 0280 003f 0022";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 372);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_light);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ADV212固件下载";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.lb_light.ResumeLayout(false);
            this.lb_light.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_light;
        private System.Windows.Forms.Button BtnOpenSerialPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbCOMPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox lb_light;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.IO.Ports.SerialPort sp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox openfiletextBox;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tBRcv;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbPercent;
        private System.Windows.Forms.TextBox tBParameters;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tBIndirectRegisterValue;
    }
}

