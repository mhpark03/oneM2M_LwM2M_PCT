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
            this.chBoxRTSEnable = new System.Windows.Forms.CheckBox();
            this.chBoxDtrEnable = new System.Windows.Forms.CheckBox();
            this.cBoxParityBits = new System.Windows.Forms.ComboBox();
            this.cBoxStopBits = new System.Windows.Forms.ComboBox();
            this.cBoxDataBits = new System.Windows.Forms.ComboBox();
            this.cBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.cBoxCOMPORT = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblDataInLength = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tBoxDataIN = new System.Windows.Forms.TextBox();
            this.btnSendData = new System.Windows.Forms.Button();
            this.tBoxDataOut = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COMCTRLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comportTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tSCBoxComPort = new System.Windows.Forms.ToolStripComboBox();
            this.bAUDRATEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate24 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate48 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate96 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate384 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate768 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate1152 = new System.Windows.Forms.ToolStripMenuItem();
            this.dATABITSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenu6bits = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenu7bits = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenu8bits = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOPBITSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuStopOne = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuStopTwo = new System.Windows.Forms.ToolStripMenuItem();
            this.pARITYBitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuParityNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuParityOdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuParityEven = new System.Windows.Forms.ToolStripMenuItem();
            this.dTREnableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuDTRDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuDTREnable = new System.Windows.Forms.ToolStripMenuItem();
            this.rTPControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuRTSDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuRTSEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.송신ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuEndLineNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuEndLineBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuEndLineLF = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuEndLineCR = new System.Windows.Forms.ToolStripMenuItem();
            this.수ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearRXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.표시방법ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuRxUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuRxAll = new System.Windows.Forms.ToolStripMenuItem();
            this.CursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuDown = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initinfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deregisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autobsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.devserverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cvsserverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opserverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDataOutLength = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnATCMD = new System.Windows.Forms.Button();
            this.tBoxATCMD = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBoxLogSave = new System.Windows.Forms.CheckBox();
            this.cBoxSendHex = new System.Windows.Forms.CheckBox();
            this.tBoxDeviceModel = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cBoxSERVER = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tBoxSVCCD = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tBoxIccid = new System.Windows.Forms.TextBox();
            this.btnICCID = new System.Windows.Forms.Button();
            this.tBoxActionState = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tBoxIMEI = new System.Windows.Forms.TextBox();
            this.btnIMEI = new System.Windows.Forms.Button();
            this.tBoxIMSI = new System.Windows.Forms.TextBox();
            this.btnIMSI = new System.Windows.Forms.Button();
            this.tBoxManu = new System.Windows.Forms.TextBox();
            this.btnManufac = new System.Windows.Forms.Button();
            this.tBoxModel = new System.Windows.Forms.TextBox();
            this.btnModel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cBoxAutoBS = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chBoxRTSEnable
            // 
            this.chBoxRTSEnable.AutoSize = true;
            this.chBoxRTSEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxRTSEnable.Location = new System.Drawing.Point(410, 12);
            this.chBoxRTSEnable.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.chBoxRTSEnable.Name = "chBoxRTSEnable";
            this.chBoxRTSEnable.Size = new System.Drawing.Size(45, 17);
            this.chBoxRTSEnable.TabIndex = 13;
            this.chBoxRTSEnable.Text = "RTS";
            this.chBoxRTSEnable.UseVisualStyleBackColor = true;
            this.chBoxRTSEnable.CheckedChanged += new System.EventHandler(this.ChBoxRTSEnable_CheckedChanged);
            // 
            // chBoxDtrEnable
            // 
            this.chBoxDtrEnable.AutoSize = true;
            this.chBoxDtrEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxDtrEnable.Location = new System.Drawing.Point(362, 12);
            this.chBoxDtrEnable.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.chBoxDtrEnable.Name = "chBoxDtrEnable";
            this.chBoxDtrEnable.Size = new System.Drawing.Size(46, 17);
            this.chBoxDtrEnable.TabIndex = 12;
            this.chBoxDtrEnable.Text = "DTR";
            this.chBoxDtrEnable.UseVisualStyleBackColor = true;
            this.chBoxDtrEnable.CheckedChanged += new System.EventHandler(this.ChBoxDtrEnable_CheckedChanged);
            // 
            // cBoxParityBits
            // 
            this.cBoxParityBits.FormattingEnabled = true;
            this.cBoxParityBits.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cBoxParityBits.Location = new System.Drawing.Point(299, 10);
            this.cBoxParityBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxParityBits.Name = "cBoxParityBits";
            this.cBoxParityBits.Size = new System.Drawing.Size(57, 20);
            this.cBoxParityBits.TabIndex = 5;
            this.cBoxParityBits.Text = "None";
            // 
            // cBoxStopBits
            // 
            this.cBoxStopBits.FormattingEnabled = true;
            this.cBoxStopBits.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.cBoxStopBits.Location = new System.Drawing.Point(235, 10);
            this.cBoxStopBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxStopBits.Name = "cBoxStopBits";
            this.cBoxStopBits.Size = new System.Drawing.Size(57, 20);
            this.cBoxStopBits.TabIndex = 4;
            this.cBoxStopBits.Text = "One";
            // 
            // cBoxDataBits
            // 
            this.cBoxDataBits.FormattingEnabled = true;
            this.cBoxDataBits.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.cBoxDataBits.Location = new System.Drawing.Point(195, 9);
            this.cBoxDataBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxDataBits.Name = "cBoxDataBits";
            this.cBoxDataBits.Size = new System.Drawing.Size(33, 20);
            this.cBoxDataBits.TabIndex = 3;
            this.cBoxDataBits.Text = "8";
            // 
            // cBoxBaudRate
            // 
            this.cBoxBaudRate.FormattingEnabled = true;
            this.cBoxBaudRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "38400",
            "76800",
            "115200"});
            this.cBoxBaudRate.Location = new System.Drawing.Point(118, 10);
            this.cBoxBaudRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxBaudRate.Name = "cBoxBaudRate";
            this.cBoxBaudRate.Size = new System.Drawing.Size(70, 20);
            this.cBoxBaudRate.TabIndex = 2;
            this.cBoxBaudRate.Text = "115200";
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Location = new System.Drawing.Point(39, 10);
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
            this.progressBar1.Location = new System.Drawing.Point(10, 10);
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
            // lblDataInLength
            // 
            this.lblDataInLength.AutoSize = true;
            this.lblDataInLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInLength.Location = new System.Drawing.Point(112, 12);
            this.lblDataInLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataInLength.Name = "lblDataInLength";
            this.lblDataInLength.Size = new System.Drawing.Size(35, 15);
            this.lblDataInLength.TabIndex = 6;
            this.lblDataInLength.Text = "0000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(76, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "RX : ";
            // 
            // tBoxDataIN
            // 
            this.tBoxDataIN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tBoxDataIN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBoxDataIN.Location = new System.Drawing.Point(3, 41);
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
            this.fileToolStripMenuItem,
            this.COMCTRLToolStripMenuItem,
            this.송신ToolStripMenuItem,
            this.수ToolStripMenuItem,
            this.testToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(733, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.fileToolStripMenuItem.Text = "파일";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ExitToolStripMenuItem.Text = "끝내기";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // COMCTRLToolStripMenuItem
            // 
            this.COMCTRLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.CloseToolStripMenuItem,
            this.comportTSMenu,
            this.bAUDRATEToolStripMenuItem,
            this.dATABITSToolStripMenuItem,
            this.sTOPBITSToolStripMenuItem,
            this.pARITYBitsToolStripMenuItem,
            this.dTREnableToolStripMenuItem,
            this.rTPControlToolStripMenuItem});
            this.COMCTRLToolStripMenuItem.Name = "COMCTRLToolStripMenuItem";
            this.COMCTRLToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.COMCTRLToolStripMenuItem.Text = "설정";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.OpenToolStripMenuItem.Text = "COM 연결";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.CloseToolStripMenuItem.Text = "COM 해제";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // comportTSMenu
            // 
            this.comportTSMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSCBoxComPort});
            this.comportTSMenu.Name = "comportTSMenu";
            this.comportTSMenu.Size = new System.Drawing.Size(158, 22);
            this.comportTSMenu.Text = "COM PORT";
            // 
            // tSCBoxComPort
            // 
            this.tSCBoxComPort.Name = "tSCBoxComPort";
            this.tSCBoxComPort.Size = new System.Drawing.Size(121, 23);
            this.tSCBoxComPort.TextChanged += new System.EventHandler(this.TSCBoxComPort_TextChanged);
            // 
            // bAUDRATEToolStripMenuItem
            // 
            this.bAUDRATEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuBaudRate24,
            this.tSMenuBaudRate48,
            this.tSMenuBaudRate96,
            this.tSMenuBaudRate384,
            this.tSMenuBaudRate768,
            this.tSMenuBaudRate1152});
            this.bAUDRATEToolStripMenuItem.Name = "bAUDRATEToolStripMenuItem";
            this.bAUDRATEToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.bAUDRATEToolStripMenuItem.Text = "BAUD RATE";
            // 
            // tSMenuBaudRate24
            // 
            this.tSMenuBaudRate24.Name = "tSMenuBaudRate24";
            this.tSMenuBaudRate24.Size = new System.Drawing.Size(144, 22);
            this.tSMenuBaudRate24.Text = "2400bps";
            this.tSMenuBaudRate24.Click += new System.EventHandler(this.TSMenuBaudRate24_Click);
            // 
            // tSMenuBaudRate48
            // 
            this.tSMenuBaudRate48.Name = "tSMenuBaudRate48";
            this.tSMenuBaudRate48.Size = new System.Drawing.Size(144, 22);
            this.tSMenuBaudRate48.Text = "4800bps";
            this.tSMenuBaudRate48.Click += new System.EventHandler(this.TSMenuBaudRate48_Click);
            // 
            // tSMenuBaudRate96
            // 
            this.tSMenuBaudRate96.Name = "tSMenuBaudRate96";
            this.tSMenuBaudRate96.Size = new System.Drawing.Size(144, 22);
            this.tSMenuBaudRate96.Text = "9600bps";
            this.tSMenuBaudRate96.Click += new System.EventHandler(this.TSMenuBaudRate96_Click);
            // 
            // tSMenuBaudRate384
            // 
            this.tSMenuBaudRate384.Name = "tSMenuBaudRate384";
            this.tSMenuBaudRate384.Size = new System.Drawing.Size(144, 22);
            this.tSMenuBaudRate384.Text = "38400bps";
            this.tSMenuBaudRate384.Click += new System.EventHandler(this.TSMenuBaudRate384_Click);
            // 
            // tSMenuBaudRate768
            // 
            this.tSMenuBaudRate768.Name = "tSMenuBaudRate768";
            this.tSMenuBaudRate768.Size = new System.Drawing.Size(144, 22);
            this.tSMenuBaudRate768.Text = "76800bps";
            this.tSMenuBaudRate768.Click += new System.EventHandler(this.TSMenuBaudRate768_Click);
            // 
            // tSMenuBaudRate1152
            // 
            this.tSMenuBaudRate1152.Name = "tSMenuBaudRate1152";
            this.tSMenuBaudRate1152.Size = new System.Drawing.Size(144, 22);
            this.tSMenuBaudRate1152.Text = "115200bps";
            this.tSMenuBaudRate1152.Click += new System.EventHandler(this.TSMenuBaudRate1152_Click);
            // 
            // dATABITSToolStripMenuItem
            // 
            this.dATABITSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenu6bits,
            this.tSMenu7bits,
            this.tSMenu8bits});
            this.dATABITSToolStripMenuItem.Name = "dATABITSToolStripMenuItem";
            this.dATABITSToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.dATABITSToolStripMenuItem.Text = "DATA bits";
            // 
            // tSMenu6bits
            // 
            this.tSMenu6bits.Name = "tSMenu6bits";
            this.tSMenu6bits.Size = new System.Drawing.Size(123, 22);
            this.tSMenu6bits.Text = "6 bits";
            this.tSMenu6bits.Click += new System.EventHandler(this.TSMenu6bits_Click);
            // 
            // tSMenu7bits
            // 
            this.tSMenu7bits.Name = "tSMenu7bits";
            this.tSMenu7bits.Size = new System.Drawing.Size(123, 22);
            this.tSMenu7bits.Text = "7 bits";
            this.tSMenu7bits.Click += new System.EventHandler(this.TSMenu7bits_Click);
            // 
            // tSMenu8bits
            // 
            this.tSMenu8bits.Name = "tSMenu8bits";
            this.tSMenu8bits.Size = new System.Drawing.Size(123, 22);
            this.tSMenu8bits.Text = "8 bits";
            this.tSMenu8bits.Click += new System.EventHandler(this.TSMenu8bits_Click);
            // 
            // sTOPBITSToolStripMenuItem
            // 
            this.sTOPBITSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuStopOne,
            this.tSMenuStopTwo});
            this.sTOPBITSToolStripMenuItem.Name = "sTOPBITSToolStripMenuItem";
            this.sTOPBITSToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.sTOPBITSToolStripMenuItem.Text = "STOP bits";
            // 
            // tSMenuStopOne
            // 
            this.tSMenuStopOne.Name = "tSMenuStopOne";
            this.tSMenuStopOne.Size = new System.Drawing.Size(102, 22);
            this.tSMenuStopOne.Text = "One";
            this.tSMenuStopOne.Click += new System.EventHandler(this.TSMenuStopOne_Click);
            // 
            // tSMenuStopTwo
            // 
            this.tSMenuStopTwo.Name = "tSMenuStopTwo";
            this.tSMenuStopTwo.Size = new System.Drawing.Size(102, 22);
            this.tSMenuStopTwo.Text = "Two";
            this.tSMenuStopTwo.Click += new System.EventHandler(this.TSMenuStopTwo_Click);
            // 
            // pARITYBitsToolStripMenuItem
            // 
            this.pARITYBitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuParityNone,
            this.tSMenuParityOdd,
            this.tSMenuParityEven});
            this.pARITYBitsToolStripMenuItem.Name = "pARITYBitsToolStripMenuItem";
            this.pARITYBitsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.pARITYBitsToolStripMenuItem.Text = "PARITY bits";
            // 
            // tSMenuParityNone
            // 
            this.tSMenuParityNone.Name = "tSMenuParityNone";
            this.tSMenuParityNone.Size = new System.Drawing.Size(109, 22);
            this.tSMenuParityNone.Text = "None";
            this.tSMenuParityNone.Click += new System.EventHandler(this.TSMenuParityNone_Click);
            // 
            // tSMenuParityOdd
            // 
            this.tSMenuParityOdd.Name = "tSMenuParityOdd";
            this.tSMenuParityOdd.Size = new System.Drawing.Size(109, 22);
            this.tSMenuParityOdd.Text = "Odd";
            this.tSMenuParityOdd.Click += new System.EventHandler(this.TSMenuParityOdd_Click);
            // 
            // tSMenuParityEven
            // 
            this.tSMenuParityEven.Name = "tSMenuParityEven";
            this.tSMenuParityEven.Size = new System.Drawing.Size(109, 22);
            this.tSMenuParityEven.Text = "Even";
            this.tSMenuParityEven.Click += new System.EventHandler(this.TSMenuParityEven_Click);
            // 
            // dTREnableToolStripMenuItem
            // 
            this.dTREnableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuDTRDisable,
            this.tSMenuDTREnable});
            this.dTREnableToolStripMenuItem.Name = "dTREnableToolStripMenuItem";
            this.dTREnableToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.dTREnableToolStripMenuItem.Text = "DTR control";
            // 
            // tSMenuDTRDisable
            // 
            this.tSMenuDTRDisable.Name = "tSMenuDTRDisable";
            this.tSMenuDTRDisable.Size = new System.Drawing.Size(130, 22);
            this.tSMenuDTRDisable.Text = "Disable";
            this.tSMenuDTRDisable.Click += new System.EventHandler(this.TSMenuDTRDisable_Click);
            // 
            // tSMenuDTREnable
            // 
            this.tSMenuDTREnable.Name = "tSMenuDTREnable";
            this.tSMenuDTREnable.Size = new System.Drawing.Size(130, 22);
            this.tSMenuDTREnable.Text = "Enable";
            this.tSMenuDTREnable.Click += new System.EventHandler(this.TSMenuDTREnable_Click);
            // 
            // rTPControlToolStripMenuItem
            // 
            this.rTPControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuRTSDisable,
            this.tSMenuRTSEnable});
            this.rTPControlToolStripMenuItem.Name = "rTPControlToolStripMenuItem";
            this.rTPControlToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.rTPControlToolStripMenuItem.Text = "RTS control";
            // 
            // tSMenuRTSDisable
            // 
            this.tSMenuRTSDisable.Name = "tSMenuRTSDisable";
            this.tSMenuRTSDisable.Size = new System.Drawing.Size(130, 22);
            this.tSMenuRTSDisable.Text = "Disable";
            this.tSMenuRTSDisable.Click += new System.EventHandler(this.TSMenuRTSDisable_Click);
            // 
            // tSMenuRTSEnable
            // 
            this.tSMenuRTSEnable.Name = "tSMenuRTSEnable";
            this.tSMenuRTSEnable.Size = new System.Drawing.Size(130, 22);
            this.tSMenuRTSEnable.Text = "Enable";
            this.tSMenuRTSEnable.Click += new System.EventHandler(this.TSMenuRTSEnable_Click);
            // 
            // 송신ToolStripMenuItem
            // 
            this.송신ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearToolStripMenuItem,
            this.writeToolStripMenuItem});
            this.송신ToolStripMenuItem.Name = "송신ToolStripMenuItem";
            this.송신ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.송신ToolStripMenuItem.Text = "송신";
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ClearToolStripMenuItem.Text = "내용 지우기";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // writeToolStripMenuItem
            // 
            this.writeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuEndLineNone,
            this.tSMenuEndLineBoth,
            this.tSMenuEndLineLF,
            this.tSMenuEndLineCR});
            this.writeToolStripMenuItem.Name = "writeToolStripMenuItem";
            this.writeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.writeToolStripMenuItem.Text = "End Line";
            // 
            // tSMenuEndLineNone
            // 
            this.tSMenuEndLineNone.Name = "tSMenuEndLineNone";
            this.tSMenuEndLineNone.Size = new System.Drawing.Size(158, 22);
            this.tSMenuEndLineNone.Text = "없음";
            this.tSMenuEndLineNone.Click += new System.EventHandler(this.TSMenuEndLineNone_Click);
            // 
            // tSMenuEndLineBoth
            // 
            this.tSMenuEndLineBoth.Name = "tSMenuEndLineBoth";
            this.tSMenuEndLineBoth.Size = new System.Drawing.Size(158, 22);
            this.tSMenuEndLineBoth.Text = "모두(LF+CR)";
            this.tSMenuEndLineBoth.Click += new System.EventHandler(this.TSMenuEndLineBoth_Click);
            // 
            // tSMenuEndLineLF
            // 
            this.tSMenuEndLineLF.Name = "tSMenuEndLineLF";
            this.tSMenuEndLineLF.Size = new System.Drawing.Size(158, 22);
            this.tSMenuEndLineLF.Text = "줄바꿈(LF)";
            this.tSMenuEndLineLF.Click += new System.EventHandler(this.TSMenuEndLineLF_Click);
            // 
            // tSMenuEndLineCR
            // 
            this.tSMenuEndLineCR.Name = "tSMenuEndLineCR";
            this.tSMenuEndLineCR.Size = new System.Drawing.Size(158, 22);
            this.tSMenuEndLineCR.Text = "맨앞줄(CR)";
            this.tSMenuEndLineCR.Click += new System.EventHandler(this.TSMenuEndLineCR_Click);
            // 
            // 수ToolStripMenuItem
            // 
            this.수ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearRXToolStripMenuItem,
            this.표시방법ToolStripMenuItem,
            this.CursorToolStripMenuItem});
            this.수ToolStripMenuItem.Name = "수ToolStripMenuItem";
            this.수ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.수ToolStripMenuItem.Text = "수신";
            // 
            // ClearRXToolStripMenuItem
            // 
            this.ClearRXToolStripMenuItem.Name = "ClearRXToolStripMenuItem";
            this.ClearRXToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ClearRXToolStripMenuItem.Text = "내용 지우기";
            this.ClearRXToolStripMenuItem.Click += new System.EventHandler(this.ClearRXToolStripMenuItem_Click);
            // 
            // 표시방법ToolStripMenuItem
            // 
            this.표시방법ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuRxUpdate,
            this.tSMenuRxAll});
            this.표시방법ToolStripMenuItem.Name = "표시방법ToolStripMenuItem";
            this.표시방법ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.표시방법ToolStripMenuItem.Text = "표시방법";
            // 
            // tSMenuRxUpdate
            // 
            this.tSMenuRxUpdate.Name = "tSMenuRxUpdate";
            this.tSMenuRxUpdate.Size = new System.Drawing.Size(235, 22);
            this.tSMenuRxUpdate.Text = "수신 정보 표시(UPDATE)";
            this.tSMenuRxUpdate.Click += new System.EventHandler(this.TSMenuRxUpdate_Click);
            // 
            // tSMenuRxAll
            // 
            this.tSMenuRxAll.Name = "tSMenuRxAll";
            this.tSMenuRxAll.Size = new System.Drawing.Size(235, 22);
            this.tSMenuRxAll.Text = "모두 표시 (ADD)";
            this.tSMenuRxAll.Click += new System.EventHandler(this.TSMenuRxAll_Click);
            // 
            // CursorToolStripMenuItem
            // 
            this.CursorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuTop,
            this.tSMenuDown});
            this.CursorToolStripMenuItem.Name = "CursorToolStripMenuItem";
            this.CursorToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.CursorToolStripMenuItem.Text = "표시위치";
            // 
            // tSMenuTop
            // 
            this.tSMenuTop.Name = "tSMenuTop";
            this.tSMenuTop.Size = new System.Drawing.Size(123, 22);
            this.tSMenuTop.Text = "위로";
            this.tSMenuTop.Click += new System.EventHandler(this.TSMenuTop_Click);
            // 
            // tSMenuDown
            // 
            this.tSMenuDown.Name = "tSMenuDown";
            this.tSMenuDown.Size = new System.Drawing.Size(123, 22);
            this.tSMenuDown.Text = "아래로";
            this.tSMenuDown.Click += new System.EventHandler(this.TSMenuDown_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initinfoToolStripMenuItem,
            this.provisionToolStripMenuItem,
            this.registerToolStripMenuItem,
            this.deregisterToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.autobsToolStripMenuItem,
            this.serverTSMenu});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.testToolStripMenuItem.Text = "테스트";
            // 
            // initinfoToolStripMenuItem
            // 
            this.initinfoToolStripMenuItem.Name = "initinfoToolStripMenuItem";
            this.initinfoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.initinfoToolStripMenuItem.Text = "단말정보 ";
            this.initinfoToolStripMenuItem.Click += new System.EventHandler(this.InitinfoToolStripMenuItem_Click);
            // 
            // provisionToolStripMenuItem
            // 
            this.provisionToolStripMenuItem.Name = "provisionToolStripMenuItem";
            this.provisionToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.provisionToolStripMenuItem.Text = "서버설정(BOOTSTRAP)";
            this.provisionToolStripMenuItem.Click += new System.EventHandler(this.ProvisionToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.registerToolStripMenuItem.Text = "서버등록(REGISTER)";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.RegisterToolStripMenuItem_Click);
            // 
            // deregisterToolStripMenuItem
            // 
            this.deregisterToolStripMenuItem.Name = "deregisterToolStripMenuItem";
            this.deregisterToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.deregisterToolStripMenuItem.Text = "서버해제(DEREGISTER)";
            this.deregisterToolStripMenuItem.Click += new System.EventHandler(this.DeregisterToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.resetToolStripMenuItem.Text = "서버정보초기화";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItem_Click);
            // 
            // autobsToolStripMenuItem
            // 
            this.autobsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem});
            this.autobsToolStripMenuItem.Name = "autobsToolStripMenuItem";
            this.autobsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.autobsToolStripMenuItem.Text = "자동 실행 설정(AutoBS)";
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.enableToolStripMenuItem.Text = "Enable";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.EnableToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.DisableToolStripMenuItem_Click);
            // 
            // serverTSMenu
            // 
            this.serverTSMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devserverToolStripMenuItem,
            this.cvsserverToolStripMenuItem,
            this.opserverToolStripMenuItem});
            this.serverTSMenu.Name = "serverTSMenu";
            this.serverTSMenu.Size = new System.Drawing.Size(235, 22);
            this.serverTSMenu.Text = "대상서버설정";
            // 
            // devserverToolStripMenuItem
            // 
            this.devserverToolStripMenuItem.Name = "devserverToolStripMenuItem";
            this.devserverToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.devserverToolStripMenuItem.Text = "개발 서버";
            this.devserverToolStripMenuItem.Click += new System.EventHandler(this.DevserverToolStripMenuItem_Click);
            // 
            // cvsserverToolStripMenuItem
            // 
            this.cvsserverToolStripMenuItem.Name = "cvsserverToolStripMenuItem";
            this.cvsserverToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cvsserverToolStripMenuItem.Text = "검증 서버";
            this.cvsserverToolStripMenuItem.Click += new System.EventHandler(this.CvsserverToolStripMenuItem_Click);
            // 
            // opserverToolStripMenuItem
            // 
            this.opserverToolStripMenuItem.Name = "opserverToolStripMenuItem";
            this.opserverToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.opserverToolStripMenuItem.Text = "상용서버";
            this.opserverToolStripMenuItem.Click += new System.EventHandler(this.OpserverToolStripMenuItem_Click);
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
            this.groupBox3.Location = new System.Drawing.Point(3, 36);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(466, 276);
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
            // lblDataOutLength
            // 
            this.lblDataOutLength.AutoSize = true;
            this.lblDataOutLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataOutLength.Location = new System.Drawing.Point(44, 12);
            this.lblDataOutLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataOutLength.Name = "lblDataOutLength";
            this.lblDataOutLength.Size = new System.Drawing.Size(35, 15);
            this.lblDataOutLength.TabIndex = 6;
            this.lblDataOutLength.Text = "0000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "TX : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 371);
            this.panel1.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(225, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 315);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnATCMD);
            this.panel4.Controls.Add(this.tBoxATCMD);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 17);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(466, 22);
            this.panel4.TabIndex = 12;
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
            // tBoxATCMD
            // 
            this.tBoxATCMD.Dock = System.Windows.Forms.DockStyle.Left;
            this.tBoxATCMD.Location = new System.Drawing.Point(0, 0);
            this.tBoxATCMD.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tBoxATCMD.Name = "tBoxATCMD";
            this.tBoxATCMD.Size = new System.Drawing.Size(381, 21);
            this.tBoxATCMD.TabIndex = 3;
            this.tBoxATCMD.TextChanged += new System.EventHandler(this.TBoxATCMD_TextChanged);
            this.tBoxATCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBoxATCMD_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxLogSave);
            this.groupBox1.Controls.Add(this.cBoxSendHex);
            this.groupBox1.Controls.Add(this.tBoxDeviceModel);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.cBoxSERVER);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tBoxSVCCD);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tBoxIccid);
            this.groupBox1.Controls.Add(this.btnICCID);
            this.groupBox1.Controls.Add(this.tBoxActionState);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.tBoxIMEI);
            this.groupBox1.Controls.Add(this.btnIMEI);
            this.groupBox1.Controls.Add(this.tBoxIMSI);
            this.groupBox1.Controls.Add(this.btnIMSI);
            this.groupBox1.Controls.Add(this.tBoxManu);
            this.groupBox1.Controls.Add(this.btnManufac);
            this.groupBox1.Controls.Add(this.tBoxModel);
            this.groupBox1.Controls.Add(this.btnModel);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(209, 311);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // cBoxLogSave
            // 
            this.cBoxLogSave.AutoSize = true;
            this.cBoxLogSave.Checked = true;
            this.cBoxLogSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxLogSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxLogSave.Location = new System.Drawing.Point(77, 282);
            this.cBoxLogSave.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cBoxLogSave.Name = "cBoxLogSave";
            this.cBoxLogSave.Size = new System.Drawing.Size(86, 17);
            this.cBoxLogSave.TabIndex = 22;
            this.cBoxLogSave.Text = "Log file save";
            this.cBoxLogSave.UseVisualStyleBackColor = true;
            // 
            // cBoxSendHex
            // 
            this.cBoxSendHex.AutoSize = true;
            this.cBoxSendHex.Checked = true;
            this.cBoxSendHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxSendHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxSendHex.Location = new System.Drawing.Point(7, 282);
            this.cBoxSendHex.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cBoxSendHex.Name = "cBoxSendHex";
            this.cBoxSendHex.Size = new System.Drawing.Size(47, 17);
            this.cBoxSendHex.TabIndex = 15;
            this.cBoxSendHex.Text = "HEX";
            this.cBoxSendHex.UseVisualStyleBackColor = true;
            // 
            // tBoxDeviceModel
            // 
            this.tBoxDeviceModel.Location = new System.Drawing.Point(77, 214);
            this.tBoxDeviceModel.Name = "tBoxDeviceModel";
            this.tBoxDeviceModel.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceModel.TabIndex = 21;
            this.tBoxDeviceModel.Text = "LWENG";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 214);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 24);
            this.button3.TabIndex = 20;
            this.button3.Text = "단말모델";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // cBoxSERVER
            // 
            this.cBoxSERVER.FormattingEnabled = true;
            this.cBoxSERVER.Items.AddRange(new object[] {
            "개발",
            "검증",
            "상용"});
            this.cBoxSERVER.Location = new System.Drawing.Point(77, 242);
            this.cBoxSERVER.Name = "cBoxSERVER";
            this.cBoxSERVER.Size = new System.Drawing.Size(126, 20);
            this.cBoxSERVER.TabIndex = 19;
            this.cBoxSERVER.Text = "개발";
            this.cBoxSERVER.TextChanged += new System.EventHandler(this.CBoxSERVER_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 241);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 24);
            this.button2.TabIndex = 18;
            this.button2.Text = "서버";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tBoxSVCCD
            // 
            this.tBoxSVCCD.Location = new System.Drawing.Point(77, 185);
            this.tBoxSVCCD.Name = "tBoxSVCCD";
            this.tBoxSVCCD.Size = new System.Drawing.Size(126, 21);
            this.tBoxSVCCD.TabIndex = 17;
            this.tBoxSVCCD.Text = "FOTA";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 185);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 24);
            this.button1.TabIndex = 16;
            this.button1.Text = "SVCCD";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tBoxIccid
            // 
            this.tBoxIccid.Location = new System.Drawing.Point(77, 97);
            this.tBoxIccid.Name = "tBoxIccid";
            this.tBoxIccid.ReadOnly = true;
            this.tBoxIccid.Size = new System.Drawing.Size(126, 21);
            this.tBoxIccid.TabIndex = 15;
            this.tBoxIccid.Text = "알 수 없음";
            // 
            // btnICCID
            // 
            this.btnICCID.Location = new System.Drawing.Point(6, 95);
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
            this.tBoxActionState.Location = new System.Drawing.Point(77, 153);
            this.tBoxActionState.Name = "tBoxActionState";
            this.tBoxActionState.ReadOnly = true;
            this.tBoxActionState.Size = new System.Drawing.Size(126, 21);
            this.tBoxActionState.TabIndex = 13;
            this.tBoxActionState.Text = "idle";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(6, 153);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 24);
            this.button4.TabIndex = 12;
            this.button4.Text = "동작상태";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tBoxIMEI
            // 
            this.tBoxIMEI.Location = new System.Drawing.Point(77, 126);
            this.tBoxIMEI.Name = "tBoxIMEI";
            this.tBoxIMEI.ReadOnly = true;
            this.tBoxIMEI.Size = new System.Drawing.Size(126, 21);
            this.tBoxIMEI.TabIndex = 11;
            this.tBoxIMEI.Text = "알 수 없음";
            // 
            // btnIMEI
            // 
            this.btnIMEI.Location = new System.Drawing.Point(6, 123);
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
            this.tBoxIMSI.Location = new System.Drawing.Point(77, 71);
            this.tBoxIMSI.Name = "tBoxIMSI";
            this.tBoxIMSI.ReadOnly = true;
            this.tBoxIMSI.Size = new System.Drawing.Size(126, 21);
            this.tBoxIMSI.TabIndex = 9;
            this.tBoxIMSI.Text = "알 수 없음";
            // 
            // btnIMSI
            // 
            this.btnIMSI.Location = new System.Drawing.Point(6, 69);
            this.btnIMSI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMSI.Name = "btnIMSI";
            this.btnIMSI.Size = new System.Drawing.Size(66, 24);
            this.btnIMSI.TabIndex = 8;
            this.btnIMSI.Text = "IMSI";
            this.btnIMSI.UseVisualStyleBackColor = true;
            this.btnIMSI.Click += new System.EventHandler(this.btnIMSI_Click);
            // 
            // tBoxManu
            // 
            this.tBoxManu.Location = new System.Drawing.Point(77, 42);
            this.tBoxManu.Name = "tBoxManu";
            this.tBoxManu.ReadOnly = true;
            this.tBoxManu.Size = new System.Drawing.Size(126, 21);
            this.tBoxManu.TabIndex = 7;
            this.tBoxManu.Text = "알 수 없음";
            // 
            // btnManufac
            // 
            this.btnManufac.Location = new System.Drawing.Point(6, 40);
            this.btnManufac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManufac.Name = "btnManufac";
            this.btnManufac.Size = new System.Drawing.Size(66, 24);
            this.btnManufac.TabIndex = 6;
            this.btnManufac.Text = "제조사";
            this.btnManufac.UseVisualStyleBackColor = true;
            this.btnManufac.Click += new System.EventHandler(this.btnManufac_Click);
            // 
            // tBoxModel
            // 
            this.tBoxModel.Location = new System.Drawing.Point(77, 12);
            this.tBoxModel.Name = "tBoxModel";
            this.tBoxModel.ReadOnly = true;
            this.tBoxModel.Size = new System.Drawing.Size(126, 21);
            this.tBoxModel.TabIndex = 2;
            this.tBoxModel.Text = "알 수 없음";
            // 
            // btnModel
            // 
            this.btnModel.Location = new System.Drawing.Point(6, 12);
            this.btnModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(66, 24);
            this.btnModel.TabIndex = 0;
            this.btnModel.Text = "모듈모델";
            this.btnModel.UseVisualStyleBackColor = true;
            this.btnModel.Click += new System.EventHandler(this.BtnModel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cBoxAutoBS);
            this.panel2.Controls.Add(this.chBoxRTSEnable);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.chBoxDtrEnable);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.cBoxCOMPORT);
            this.panel2.Controls.Add(this.cBoxBaudRate);
            this.panel2.Controls.Add(this.cBoxDataBits);
            this.panel2.Controls.Add(this.cBoxParityBits);
            this.panel2.Controls.Add(this.cBoxStopBits);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 333);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.panel2.Size = new System.Drawing.Size(733, 38);
            this.panel2.TabIndex = 10;
            // 
            // cBoxAutoBS
            // 
            this.cBoxAutoBS.AutoSize = true;
            this.cBoxAutoBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxAutoBS.Location = new System.Drawing.Point(457, 11);
            this.cBoxAutoBS.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cBoxAutoBS.Name = "cBoxAutoBS";
            this.cBoxAutoBS.Size = new System.Drawing.Size(70, 17);
            this.cBoxAutoBS.TabIndex = 14;
            this.cBoxAutoBS.Text = "AUTO BS";
            this.cBoxAutoBS.UseVisualStyleBackColor = true;
            this.cBoxAutoBS.CheckedChanged += new System.EventHandler(this.CBoxAutoBS_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDataInLength);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblDataOutLength);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(576, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(157, 36);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 395);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1078);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(749, 433);
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
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cBoxParityBits;
        private System.Windows.Forms.ComboBox cBoxStopBits;
        private System.Windows.Forms.ComboBox cBoxDataBits;
        private System.Windows.Forms.ComboBox cBoxBaudRate;
        private System.Windows.Forms.ComboBox cBoxCOMPORT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblDataInLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBoxDataIN;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.TextBox tBoxDataOut;
        private System.Windows.Forms.CheckBox chBoxRTSEnable;
        private System.Windows.Forms.CheckBox chBoxDtrEnable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COMCTRLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 송신ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 수ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearRXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 표시방법ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblDataOutLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem CursorToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem dATABITSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTOPBITSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pARITYBitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dTREnableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTPControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tSMenu6bits;
        private System.Windows.Forms.ToolStripMenuItem tSMenu7bits;
        private System.Windows.Forms.ToolStripMenuItem tSMenu8bits;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.ToolStripMenuItem tSMenuStopOne;
        private System.Windows.Forms.ToolStripMenuItem tSMenuStopTwo;
        private System.Windows.Forms.ToolStripMenuItem tSMenuParityNone;
        private System.Windows.Forms.ToolStripMenuItem tSMenuParityOdd;
        private System.Windows.Forms.ToolStripMenuItem tSMenuParityEven;
        private System.Windows.Forms.ToolStripMenuItem bAUDRATEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate24;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate48;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate96;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate384;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate768;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate1152;
        private System.Windows.Forms.ToolStripMenuItem tSMenuDTRDisable;
        private System.Windows.Forms.ToolStripMenuItem tSMenuDTREnable;
        private System.Windows.Forms.ToolStripMenuItem tSMenuRTSDisable;
        private System.Windows.Forms.ToolStripMenuItem tSMenuRTSEnable;
        private System.Windows.Forms.ToolStripMenuItem comportTSMenu;
        private System.Windows.Forms.ToolStripComboBox tSCBoxComPort;
        private System.Windows.Forms.ToolStripMenuItem tSMenuEndLineNone;
        private System.Windows.Forms.ToolStripMenuItem tSMenuEndLineBoth;
        private System.Windows.Forms.ToolStripMenuItem tSMenuEndLineLF;
        private System.Windows.Forms.ToolStripMenuItem tSMenuEndLineCR;
        private System.Windows.Forms.ToolStripMenuItem tSMenuRxUpdate;
        private System.Windows.Forms.ToolStripMenuItem tSMenuRxAll;
        private System.Windows.Forms.ToolStripMenuItem tSMenuTop;
        private System.Windows.Forms.ToolStripMenuItem tSMenuDown;
        private System.Windows.Forms.TextBox tBoxActionState;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tBoxIMEI;
        private System.Windows.Forms.Button btnIMEI;
        private System.Windows.Forms.TextBox tBoxIMSI;
        private System.Windows.Forms.Button btnIMSI;
        private System.Windows.Forms.TextBox tBoxManu;
        private System.Windows.Forms.Button btnManufac;
        private System.Windows.Forms.TextBox tBoxModel;
        private System.Windows.Forms.TextBox tBoxIccid;
        private System.Windows.Forms.Button btnICCID;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initinfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provisionToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tBoxSVCCD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cBoxAutoBS;
        private System.Windows.Forms.ComboBox cBoxSERVER;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autobsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deregisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverTSMenu;
        private System.Windows.Forms.ToolStripMenuItem devserverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cvsserverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opserverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.TextBox tBoxDeviceModel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnATCMD;
        private System.Windows.Forms.TextBox tBoxATCMD;
        private System.Windows.Forms.CheckBox cBoxSendHex;
        private System.Windows.Forms.CheckBox cBoxLogSave;
    }
}

