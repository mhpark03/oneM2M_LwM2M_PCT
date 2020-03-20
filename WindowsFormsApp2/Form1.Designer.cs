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
            this.tBoxDataIN = new System.Windows.Forms.TextBox();
            this.btnSendData = new System.Windows.Forms.Button();
            this.tBoxDataOut = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deregisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cBoxATCMD = new System.Windows.Forms.ComboBox();
            this.btnATCMD = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tBoxDeviceVer = new System.Windows.Forms.TextBox();
            this.tBoxDeviceSN = new System.Windows.Forms.TextBox();
            this.tBoxSVCCD = new System.Windows.Forms.TextBox();
            this.tBoxIccid = new System.Windows.Forms.TextBox();
            this.btnICCID = new System.Windows.Forms.Button();
            this.tBoxActionState = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tBoxIMEI = new System.Windows.Forms.TextBox();
            this.btnIMEI = new System.Windows.Forms.Button();
            this.tBoxIMSI = new System.Windows.Forms.TextBox();
            this.btnIMSI = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxDeviceModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnModuleInfo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbModelName = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.lbMaker = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbModemVer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.cBoxCOMPORT.TextChanged += new System.EventHandler(this.CBoxCOMPORT_TextChanged);
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
            // tBoxDataIN
            // 
            this.tBoxDataIN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tBoxDataIN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBoxDataIN.Location = new System.Drawing.Point(3, 48);
            this.tBoxDataIN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tBoxDataIN.Multiline = true;
            this.tBoxDataIN.Name = "tBoxDataIN";
            this.tBoxDataIN.ReadOnly = true;
            this.tBoxDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBoxDataIN.Size = new System.Drawing.Size(460, 233);
            this.tBoxDataIN.TabIndex = 6;
            this.tBoxDataIN.TextChanged += new System.EventHandler(this.TBoxDataIN_TextChanged);
            // 
            // btnSendData
            // 
            this.btnSendData.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSendData.Location = new System.Drawing.Point(378, 0);
            this.btnSendData.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(82, 22);
            this.btnSendData.TabIndex = 2;
            this.btnSendData.Text = "서버전송";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.BtnSendData_Click);
            // 
            // tBoxDataOut
            // 
            this.tBoxDataOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.tBoxDataOut.Location = new System.Drawing.Point(0, 0);
            this.tBoxDataOut.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tBoxDataOut.Name = "tBoxDataOut";
            this.tBoxDataOut.Size = new System.Drawing.Size(378, 21);
            this.tBoxDataOut.TabIndex = 3;
            this.tBoxDataOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBoxDataOut_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("돋움체", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1235, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.provisionToolStripMenuItem,
            this.registerToolStripMenuItem,
            this.deregisterToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.testToolStripMenuItem.Text = "테스트";
            // 
            // provisionToolStripMenuItem
            // 
            this.provisionToolStripMenuItem.Name = "provisionToolStripMenuItem";
            this.provisionToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.provisionToolStripMenuItem.Text = "서버설정(BOOTSTRAP)";
            this.provisionToolStripMenuItem.Click += new System.EventHandler(this.ProvisionToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.registerToolStripMenuItem.Text = "서버등록(REGISTER)";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.RegisterToolStripMenuItem_Click);
            // 
            // deregisterToolStripMenuItem
            // 
            this.deregisterToolStripMenuItem.Name = "deregisterToolStripMenuItem";
            this.deregisterToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.deregisterToolStripMenuItem.Text = "서버해제(DEREGISTER)";
            this.deregisterToolStripMenuItem.Click += new System.EventHandler(this.DeregisterToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.resetToolStripMenuItem.Text = "서버정보초기화";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "도움말";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.tBoxDataIN);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 40);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(466, 283);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSendData);
            this.panel3.Controls.Add(this.tBoxDataOut);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 22);
            this.panel3.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1235, 613);
            this.panel1.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(756, 202);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 326);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cBoxATCMD);
            this.panel4.Controls.Add(this.btnATCMD);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 17);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(466, 22);
            this.panel4.TabIndex = 12;
            // 
            // cBoxATCMD
            // 
            this.cBoxATCMD.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxATCMD.FormattingEnabled = true;
            this.cBoxATCMD.Items.AddRange(new object[] {
            "AT"});
            this.cBoxATCMD.Location = new System.Drawing.Point(0, 0);
            this.cBoxATCMD.Name = "cBoxATCMD";
            this.cBoxATCMD.Size = new System.Drawing.Size(381, 20);
            this.cBoxATCMD.Sorted = true;
            this.cBoxATCMD.TabIndex = 3;
            this.cBoxATCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBoxATCMD_KeyDown);
            // 
            // btnATCMD
            // 
            this.btnATCMD.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnATCMD.Location = new System.Drawing.Point(381, 0);
            this.btnATCMD.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnATCMD.Name = "btnATCMD";
            this.btnATCMD.Size = new System.Drawing.Size(85, 22);
            this.btnATCMD.TabIndex = 2;
            this.btnATCMD.Text = "AT명령";
            this.btnATCMD.UseVisualStyleBackColor = true;
            this.btnATCMD.Click += new System.EventHandler(this.BtnATCMD_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbModemVer);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbMaker);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbModel);
            this.groupBox1.Controls.Add(this.lbModelName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnModuleInfo);
            this.groupBox1.Controls.Add(this.tBoxIccid);
            this.groupBox1.Controls.Add(this.btnICCID);
            this.groupBox1.Controls.Add(this.tBoxActionState);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.tBoxIMEI);
            this.groupBox1.Controls.Add(this.btnIMEI);
            this.groupBox1.Controls.Add(this.tBoxIMSI);
            this.groupBox1.Controls.Add(this.btnIMSI);
            this.groupBox1.Location = new System.Drawing.Point(28, 219);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(722, 199);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "모듈 정보";
            // 
            // tBoxDeviceVer
            // 
            this.tBoxDeviceVer.Location = new System.Drawing.Point(890, 22);
            this.tBoxDeviceVer.Name = "tBoxDeviceVer";
            this.tBoxDeviceVer.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceVer.TabIndex = 25;
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
            // tBoxIccid
            // 
            this.tBoxIccid.Location = new System.Drawing.Point(575, 108);
            this.tBoxIccid.Name = "tBoxIccid";
            this.tBoxIccid.ReadOnly = true;
            this.tBoxIccid.Size = new System.Drawing.Size(126, 21);
            this.tBoxIccid.TabIndex = 15;
            this.tBoxIccid.Text = "알 수 없음";
            // 
            // btnICCID
            // 
            this.btnICCID.Location = new System.Drawing.Point(504, 106);
            this.btnICCID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnICCID.Name = "btnICCID";
            this.btnICCID.Size = new System.Drawing.Size(66, 24);
            this.btnICCID.TabIndex = 14;
            this.btnICCID.Text = "ICCID";
            this.btnICCID.UseVisualStyleBackColor = true;
            this.btnICCID.Click += new System.EventHandler(this.btnICCID_Click);
            // 
            // tBoxActionState
            // 
            this.tBoxActionState.Location = new System.Drawing.Point(575, 164);
            this.tBoxActionState.Name = "tBoxActionState";
            this.tBoxActionState.ReadOnly = true;
            this.tBoxActionState.Size = new System.Drawing.Size(126, 21);
            this.tBoxActionState.TabIndex = 13;
            this.tBoxActionState.Text = "idle";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(504, 164);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 24);
            this.button4.TabIndex = 12;
            this.button4.Text = "동작상태";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tBoxIMEI
            // 
            this.tBoxIMEI.Location = new System.Drawing.Point(575, 137);
            this.tBoxIMEI.Name = "tBoxIMEI";
            this.tBoxIMEI.ReadOnly = true;
            this.tBoxIMEI.Size = new System.Drawing.Size(126, 21);
            this.tBoxIMEI.TabIndex = 11;
            this.tBoxIMEI.Text = "알 수 없음";
            // 
            // btnIMEI
            // 
            this.btnIMEI.Location = new System.Drawing.Point(504, 134);
            this.btnIMEI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMEI.Name = "btnIMEI";
            this.btnIMEI.Size = new System.Drawing.Size(66, 24);
            this.btnIMEI.TabIndex = 10;
            this.btnIMEI.Text = "IMEI";
            this.btnIMEI.UseVisualStyleBackColor = true;
            this.btnIMEI.Click += new System.EventHandler(this.btnIMEI_Click);
            // 
            // tBoxIMSI
            // 
            this.tBoxIMSI.Location = new System.Drawing.Point(575, 82);
            this.tBoxIMSI.Name = "tBoxIMSI";
            this.tBoxIMSI.ReadOnly = true;
            this.tBoxIMSI.Size = new System.Drawing.Size(126, 21);
            this.tBoxIMSI.TabIndex = 9;
            this.tBoxIMSI.Text = "알 수 없음";
            // 
            // btnIMSI
            // 
            this.btnIMSI.Location = new System.Drawing.Point(504, 80);
            this.btnIMSI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMSI.Name = "btnIMSI";
            this.btnIMSI.Size = new System.Drawing.Size(66, 24);
            this.btnIMSI.TabIndex = 8;
            this.btnIMSI.Text = "IMSI";
            this.btnIMSI.UseVisualStyleBackColor = true;
            this.btnIMSI.Click += new System.EventHandler(this.btnIMSI_Click);
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cBoxCOMPORT);
            this.groupBox5.Controls.Add(this.progressBar1);
            this.groupBox5.Location = new System.Drawing.Point(28, 139);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(330, 53);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "COM PORT";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "서비스 코드 :";
            // 
            // tBoxDeviceModel
            // 
            this.tBoxDeviceModel.Location = new System.Drawing.Point(375, 20);
            this.tBoxDeviceModel.Name = "tBoxDeviceModel";
            this.tBoxDeviceModel.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceModel.TabIndex = 21;
            this.tBoxDeviceModel.Text = "LWEMG";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "디바이스 일련번호 :";
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
            // btnModuleInfo
            // 
            this.btnModuleInfo.Location = new System.Drawing.Point(17, 20);
            this.btnModuleInfo.Name = "btnModuleInfo";
            this.btnModuleInfo.Size = new System.Drawing.Size(75, 23);
            this.btnModuleInfo.TabIndex = 16;
            this.btnModuleInfo.Text = "조회";
            this.btnModuleInfo.UseVisualStyleBackColor = true;
            this.btnModuleInfo.Click += new System.EventHandler(this.btnModuleInfo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "모델명 :";
            // 
            // lbModelName
            // 
            this.lbModelName.AutoSize = true;
            this.lbModelName.Location = new System.Drawing.Point(176, 25);
            this.lbModelName.Name = "lbModelName";
            this.lbModelName.Size = new System.Drawing.Size(0, 12);
            this.lbModelName.TabIndex = 24;
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Location = new System.Drawing.Point(173, 23);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(9, 12);
            this.lbModel.TabIndex = 25;
            this.lbModel.Text = ".";
            // 
            // lbMaker
            // 
            this.lbMaker.AutoSize = true;
            this.lbMaker.Location = new System.Drawing.Point(173, 42);
            this.lbMaker.Name = "lbMaker";
            this.lbMaker.Size = new System.Drawing.Size(9, 12);
            this.lbMaker.TabIndex = 27;
            this.lbMaker.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "제조사 :";
            // 
            // lbModemVer
            // 
            this.lbModemVer.AutoSize = true;
            this.lbModemVer.Location = new System.Drawing.Point(173, 69);
            this.lbModemVer.Name = "lbModemVer";
            this.lbModemVer.Size = new System.Drawing.Size(9, 12);
            this.lbModemVer.TabIndex = 29;
            this.lbModemVer.Text = ".";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "모듈버전 :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 637);
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
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cBoxCOMPORT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tBoxDataIN;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.TextBox tBoxDataOut;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tBoxActionState;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tBoxIMEI;
        private System.Windows.Forms.Button btnIMEI;
        private System.Windows.Forms.TextBox tBoxIMSI;
        private System.Windows.Forms.Button btnIMSI;
        private System.Windows.Forms.TextBox tBoxIccid;
        private System.Windows.Forms.Button btnICCID;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provisionToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tBoxSVCCD;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deregisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnATCMD;
        private System.Windows.Forms.ComboBox cBoxATCMD;
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
    }
}

