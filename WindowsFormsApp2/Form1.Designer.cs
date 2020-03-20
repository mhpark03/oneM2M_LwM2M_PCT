namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cBoxCOMPORT = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbActionState = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cBoxATCMD = new System.Windows.Forms.ComboBox();
            this.btnATCMD = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeregister = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBootstrap = new System.Windows.Forms.Button();
            this.tBoxDataOut = new System.Windows.Forms.TextBox();
            this.btnSendData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbIccid = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbIMSI = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbModemVer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbMaker = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.lbModelName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnModuleInfo = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxDeviceVer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxDeviceSN = new System.Windows.Forms.TextBox();
            this.tBoxSVCCD = new System.Windows.Forms.TextBox();
            this.tBoxDeviceModel = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tBoxDataIN = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Location = new System.Drawing.Point(50, 19);
            this.cBoxCOMPORT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxCOMPORT.Name = "cBoxCOMPORT";
            this.cBoxCOMPORT.Size = new System.Drawing.Size(73, 20);
            this.cBoxCOMPORT.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(146, 21);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(22, 18);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("돋움체", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1235, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.testToolStripMenuItem.Text = "테스트";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1235, 627);
            this.panel1.TabIndex = 10;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox5);
            this.groupBox7.Controls.Add(this.groupBox2);
            this.groupBox7.Controls.Add(this.groupBox1);
            this.groupBox7.Location = new System.Drawing.Point(28, 125);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(594, 499);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "DEVICE 동작";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbActionState);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.cBoxCOMPORT);
            this.groupBox5.Controls.Add(this.cBoxATCMD);
            this.groupBox5.Controls.Add(this.btnATCMD);
            this.groupBox5.Controls.Add(this.progressBar1);
            this.groupBox5.Location = new System.Drawing.Point(33, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(534, 75);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "COM 포트";
            // 
            // lbActionState
            // 
            this.lbActionState.AutoSize = true;
            this.lbActionState.Location = new System.Drawing.Point(300, 22);
            this.lbActionState.Name = "lbActionState";
            this.lbActionState.Size = new System.Drawing.Size(43, 12);
            this.lbActionState.TabIndex = 26;
            this.lbActionState.Text = "closed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "동작상태 :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cBoxATCMD
            // 
            this.cBoxATCMD.FormattingEnabled = true;
            this.cBoxATCMD.Location = new System.Drawing.Point(17, 43);
            this.cBoxATCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxATCMD.Name = "cBoxATCMD";
            this.cBoxATCMD.Size = new System.Drawing.Size(378, 20);
            this.cBoxATCMD.TabIndex = 18;
            this.cBoxATCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBoxATCMD_KeyDown);
            // 
            // btnATCMD
            // 
            this.btnATCMD.Location = new System.Drawing.Point(401, 41);
            this.btnATCMD.Name = "btnATCMD";
            this.btnATCMD.Size = new System.Drawing.Size(75, 20);
            this.btnATCMD.TabIndex = 17;
            this.btnATCMD.Text = "AT명령";
            this.btnATCMD.UseVisualStyleBackColor = true;
            this.btnATCMD.Click += new System.EventHandler(this.btnATCMD_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeregister);
            this.groupBox2.Controls.Add(this.btnRegister);
            this.groupBox2.Controls.Add(this.btnBootstrap);
            this.groupBox2.Controls.Add(this.tBoxDataOut);
            this.groupBox2.Controls.Add(this.btnSendData);
            this.groupBox2.Location = new System.Drawing.Point(33, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 191);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LwM2M";
            // 
            // btnDeregister
            // 
            this.btnDeregister.Location = new System.Drawing.Point(13, 116);
            this.btnDeregister.Name = "btnDeregister";
            this.btnDeregister.Size = new System.Drawing.Size(176, 20);
            this.btnDeregister.TabIndex = 23;
            this.btnDeregister.Text = "DEREGISTER";
            this.btnDeregister.UseVisualStyleBackColor = true;
            this.btnDeregister.Click += new System.EventHandler(this.btnDeregister_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(13, 51);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(176, 20);
            this.btnRegister.TabIndex = 22;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnBootstrap
            // 
            this.btnBootstrap.Location = new System.Drawing.Point(13, 25);
            this.btnBootstrap.Name = "btnBootstrap";
            this.btnBootstrap.Size = new System.Drawing.Size(176, 20);
            this.btnBootstrap.TabIndex = 21;
            this.btnBootstrap.Text = "BOOTSTRAP";
            this.btnBootstrap.UseVisualStyleBackColor = true;
            this.btnBootstrap.Click += new System.EventHandler(this.btnBootstrap_Click);
            // 
            // tBoxDataOut
            // 
            this.tBoxDataOut.Location = new System.Drawing.Point(8, 80);
            this.tBoxDataOut.Name = "tBoxDataOut";
            this.tBoxDataOut.Size = new System.Drawing.Size(378, 21);
            this.tBoxDataOut.TabIndex = 20;
            this.tBoxDataOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBoxDataOut_KeyDown);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(392, 79);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(75, 20);
            this.btnSendData.TabIndex = 19;
            this.btnSendData.Text = "서버전송";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbIccid);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lbIMSI);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbModemVer);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbMaker);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbModel);
            this.groupBox1.Controls.Add(this.lbModelName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnModuleInfo);
            this.groupBox1.Location = new System.Drawing.Point(33, 100);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(534, 121);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "모듈 정보";
            // 
            // lbIccid
            // 
            this.lbIccid.AutoSize = true;
            this.lbIccid.Location = new System.Drawing.Point(321, 67);
            this.lbIccid.Name = "lbIccid";
            this.lbIccid.Size = new System.Drawing.Size(9, 12);
            this.lbIccid.TabIndex = 33;
            this.lbIccid.Text = ".";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(273, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 12);
            this.label11.TabIndex = 32;
            this.label11.Text = "ICCID :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbIMSI
            // 
            this.lbIMSI.AutoSize = true;
            this.lbIMSI.Location = new System.Drawing.Point(161, 67);
            this.lbIMSI.Name = "lbIMSI";
            this.lbIMSI.Size = new System.Drawing.Size(9, 12);
            this.lbIMSI.TabIndex = 31;
            this.lbIMSI.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(119, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "CTN :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbModemVer
            // 
            this.lbModemVer.AutoSize = true;
            this.lbModemVer.Location = new System.Drawing.Point(321, 44);
            this.lbModemVer.Name = "lbModemVer";
            this.lbModemVer.Size = new System.Drawing.Size(9, 12);
            this.lbModemVer.TabIndex = 29;
            this.lbModemVer.Text = ".";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(257, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "모듈버전 :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbMaker
            // 
            this.lbMaker.AutoSize = true;
            this.lbMaker.Location = new System.Drawing.Point(171, 23);
            this.lbMaker.Name = "lbMaker";
            this.lbMaker.Size = new System.Drawing.Size(9, 12);
            this.lbMaker.TabIndex = 27;
            this.lbMaker.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "제조사 :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Location = new System.Drawing.Point(171, 42);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(9, 12);
            this.lbModel.TabIndex = 25;
            this.lbModel.Text = ".";
            // 
            // lbModelName
            // 
            this.lbModelName.AutoSize = true;
            this.lbModelName.Location = new System.Drawing.Point(176, 25);
            this.lbModelName.Name = "lbModelName";
            this.lbModelName.Size = new System.Drawing.Size(0, 12);
            this.lbModelName.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "모델명 :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnModuleInfo
            // 
            this.btnModuleInfo.Location = new System.Drawing.Point(17, 26);
            this.btnModuleInfo.Name = "btnModuleInfo";
            this.btnModuleInfo.Size = new System.Drawing.Size(75, 49);
            this.btnModuleInfo.TabIndex = 16;
            this.btnModuleInfo.Text = "조회";
            this.btnModuleInfo.UseVisualStyleBackColor = true;
            this.btnModuleInfo.Click += new System.EventHandler(this.btnModuleInfo_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.tBoxDeviceVer);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.tBoxDeviceSN);
            this.groupBox6.Controls.Add(this.tBoxSVCCD);
            this.groupBox6.Controls.Add(this.tBoxDeviceModel);
            this.groupBox6.Location = new System.Drawing.Point(28, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1149, 100);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "프로젝트";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(771, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "디바이스 버전 :";
            // 
            // tBoxDeviceVer
            // 
            this.tBoxDeviceVer.Location = new System.Drawing.Point(890, 22);
            this.tBoxDeviceVer.Name = "tBoxDeviceVer";
            this.tBoxDeviceVer.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceVer.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "디바이스 일련번호 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "디바이스 모델명 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "서비스 코드 :";
            // 
            // tBoxDeviceSN
            // 
            this.tBoxDeviceSN.Location = new System.Drawing.Point(634, 22);
            this.tBoxDeviceSN.Name = "tBoxDeviceSN";
            this.tBoxDeviceSN.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceSN.TabIndex = 23;
            this.tBoxDeviceSN.Text = "123456";
            // 
            // tBoxSVCCD
            // 
            this.tBoxSVCCD.Location = new System.Drawing.Point(96, 20);
            this.tBoxSVCCD.Name = "tBoxSVCCD";
            this.tBoxSVCCD.Size = new System.Drawing.Size(126, 21);
            this.tBoxSVCCD.TabIndex = 17;
            this.tBoxSVCCD.Text = "FOTA";
            // 
            // tBoxDeviceModel
            // 
            this.tBoxDeviceModel.Location = new System.Drawing.Point(375, 20);
            this.tBoxDeviceModel.Name = "tBoxDeviceModel";
            this.tBoxDeviceModel.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceModel.TabIndex = 21;
            this.tBoxDeviceModel.Text = "LWEMG";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tBoxDataIN);
            this.groupBox4.Location = new System.Drawing.Point(628, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 488);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Device Message";
            // 
            // tBoxDataIN
            // 
            this.tBoxDataIN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tBoxDataIN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBoxDataIN.Location = new System.Drawing.Point(3, 19);
            this.tBoxDataIN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tBoxDataIN.Multiline = true;
            this.tBoxDataIN.Name = "tBoxDataIN";
            this.tBoxDataIN.ReadOnly = true;
            this.tBoxDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBoxDataIN.Size = new System.Drawing.Size(466, 466);
            this.tBoxDataIN.TabIndex = 22;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 651);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1076);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(748, 452);
            this.Name = "Form1";
            this.Text = "LGU+ ATcommand TEST";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cBoxCOMPORT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tBoxSVCCD;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tBoxDeviceSN;
        private System.Windows.Forms.TextBox tBoxDeviceVer;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxDeviceModel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnModuleInfo;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label lbModelName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbMaker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbModemVer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbIccid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbIMSI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbActionState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnATCMD;
        private System.Windows.Forms.ComboBox cBoxATCMD;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox tBoxDataOut;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnBootstrap;
        private System.Windows.Forms.TextBox tBoxDataIN;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnDeregister;
    }
}

