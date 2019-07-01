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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDataOutLength = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnLteState = new System.Windows.Forms.Button();
            this.lblLteState = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnIMEI = new System.Windows.Forms.Button();
            this.lblIMEI = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnIMSI = new System.Windows.Forms.Button();
            this.lblIMSI = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnManu = new System.Windows.Forms.Button();
            this.lblManu = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnModel = new System.Windows.Forms.Button();
            this.lblModel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tSMenuTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuDown = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chBoxRTSEnable
            // 
            this.chBoxRTSEnable.AutoSize = true;
            this.chBoxRTSEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxRTSEnable.Location = new System.Drawing.Point(477, 15);
            this.chBoxRTSEnable.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.chBoxRTSEnable.Name = "chBoxRTSEnable";
            this.chBoxRTSEnable.Size = new System.Drawing.Size(53, 19);
            this.chBoxRTSEnable.TabIndex = 13;
            this.chBoxRTSEnable.Text = "RTS";
            this.chBoxRTSEnable.UseVisualStyleBackColor = true;
            this.chBoxRTSEnable.CheckedChanged += new System.EventHandler(this.ChBoxRTSEnable_CheckedChanged);
            // 
            // chBoxDtrEnable
            // 
            this.chBoxDtrEnable.AutoSize = true;
            this.chBoxDtrEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxDtrEnable.Location = new System.Drawing.Point(421, 15);
            this.chBoxDtrEnable.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.chBoxDtrEnable.Name = "chBoxDtrEnable";
            this.chBoxDtrEnable.Size = new System.Drawing.Size(54, 19);
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
            this.cBoxParityBits.Location = new System.Drawing.Point(347, 12);
            this.cBoxParityBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxParityBits.Name = "cBoxParityBits";
            this.cBoxParityBits.Size = new System.Drawing.Size(65, 23);
            this.cBoxParityBits.TabIndex = 5;
            this.cBoxParityBits.Text = "None";
            // 
            // cBoxStopBits
            // 
            this.cBoxStopBits.FormattingEnabled = true;
            this.cBoxStopBits.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.cBoxStopBits.Location = new System.Drawing.Point(273, 12);
            this.cBoxStopBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxStopBits.Name = "cBoxStopBits";
            this.cBoxStopBits.Size = new System.Drawing.Size(65, 23);
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
            this.cBoxDataBits.Location = new System.Drawing.Point(213, 11);
            this.cBoxDataBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxDataBits.Name = "cBoxDataBits";
            this.cBoxDataBits.Size = new System.Drawing.Size(52, 23);
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
            this.cBoxBaudRate.Location = new System.Drawing.Point(128, 12);
            this.cBoxBaudRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxBaudRate.Name = "cBoxBaudRate";
            this.cBoxBaudRate.Size = new System.Drawing.Size(79, 23);
            this.cBoxBaudRate.TabIndex = 2;
            this.cBoxBaudRate.Text = "115200";
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Location = new System.Drawing.Point(53, 12);
            this.cBoxCOMPORT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxCOMPORT.Name = "cBoxCOMPORT";
            this.cBoxCOMPORT.Size = new System.Drawing.Size(69, 23);
            this.cBoxCOMPORT.TabIndex = 1;
            this.cBoxCOMPORT.TextChanged += new System.EventHandler(this.CBoxCOMPORT_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 12);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(25, 22);
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
            this.lblDataInLength.Location = new System.Drawing.Point(128, 15);
            this.lblDataInLength.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataInLength.Name = "lblDataInLength";
            this.lblDataInLength.Size = new System.Drawing.Size(24, 18);
            this.lblDataInLength.TabIndex = 6;
            this.lblDataInLength.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(87, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 18);
            this.label8.TabIndex = 5;
            this.label8.Text = "RX : ";
            // 
            // tBoxDataIN
            // 
            this.tBoxDataIN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBoxDataIN.Location = new System.Drawing.Point(3, 52);
            this.tBoxDataIN.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tBoxDataIN.Multiline = true;
            this.tBoxDataIN.Name = "tBoxDataIN";
            this.tBoxDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBoxDataIN.Size = new System.Drawing.Size(446, 212);
            this.tBoxDataIN.TabIndex = 6;
            // 
            // btnSendData
            // 
            this.btnSendData.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSendData.Location = new System.Drawing.Point(372, 0);
            this.btnSendData.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(74, 28);
            this.btnSendData.TabIndex = 2;
            this.btnSendData.Text = "전송";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.BtnSendData_Click);
            // 
            // tBoxDataOut
            // 
            this.tBoxDataOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxDataOut.Location = new System.Drawing.Point(0, 0);
            this.tBoxDataOut.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tBoxDataOut.Name = "tBoxDataOut";
            this.tBoxDataOut.Size = new System.Drawing.Size(446, 25);
            this.tBoxDataOut.TabIndex = 3;
            this.tBoxDataOut.TextChanged += new System.EventHandler(this.TBoxDataOut_TextChanged);
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
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.fileToolStripMenuItem.Text = "파일";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
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
            this.COMCTRLToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.COMCTRLToolStripMenuItem.Text = "설정";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.OpenToolStripMenuItem.Text = "COM 연결";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.CloseToolStripMenuItem.Text = "COM 해제";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // comportTSMenu
            // 
            this.comportTSMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSCBoxComPort});
            this.comportTSMenu.Name = "comportTSMenu";
            this.comportTSMenu.Size = new System.Drawing.Size(198, 26);
            this.comportTSMenu.Text = "COM PORT";
            // 
            // tSCBoxComPort
            // 
            this.tSCBoxComPort.Name = "tSCBoxComPort";
            this.tSCBoxComPort.Size = new System.Drawing.Size(121, 28);
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
            this.bAUDRATEToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.bAUDRATEToolStripMenuItem.Text = "BAUD RATE";
            // 
            // tSMenuBaudRate24
            // 
            this.tSMenuBaudRate24.Name = "tSMenuBaudRate24";
            this.tSMenuBaudRate24.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate24.Text = "2400bps";
            this.tSMenuBaudRate24.Click += new System.EventHandler(this.TSMenuBaudRate24_Click);
            // 
            // tSMenuBaudRate48
            // 
            this.tSMenuBaudRate48.Name = "tSMenuBaudRate48";
            this.tSMenuBaudRate48.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate48.Text = "4800bps";
            this.tSMenuBaudRate48.Click += new System.EventHandler(this.TSMenuBaudRate48_Click);
            // 
            // tSMenuBaudRate96
            // 
            this.tSMenuBaudRate96.Name = "tSMenuBaudRate96";
            this.tSMenuBaudRate96.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate96.Text = "9600bps";
            this.tSMenuBaudRate96.Click += new System.EventHandler(this.TSMenuBaudRate96_Click);
            // 
            // tSMenuBaudRate384
            // 
            this.tSMenuBaudRate384.Name = "tSMenuBaudRate384";
            this.tSMenuBaudRate384.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate384.Text = "38400bps";
            this.tSMenuBaudRate384.Click += new System.EventHandler(this.TSMenuBaudRate384_Click);
            // 
            // tSMenuBaudRate768
            // 
            this.tSMenuBaudRate768.Name = "tSMenuBaudRate768";
            this.tSMenuBaudRate768.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate768.Text = "76800bps";
            this.tSMenuBaudRate768.Click += new System.EventHandler(this.TSMenuBaudRate768_Click);
            // 
            // tSMenuBaudRate1152
            // 
            this.tSMenuBaudRate1152.Name = "tSMenuBaudRate1152";
            this.tSMenuBaudRate1152.Size = new System.Drawing.Size(180, 26);
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
            this.dATABITSToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.dATABITSToolStripMenuItem.Text = "DATA bits";
            // 
            // tSMenu6bits
            // 
            this.tSMenu6bits.Name = "tSMenu6bits";
            this.tSMenu6bits.Size = new System.Drawing.Size(153, 26);
            this.tSMenu6bits.Text = "6 bits";
            this.tSMenu6bits.Click += new System.EventHandler(this.TSMenu6bits_Click);
            // 
            // tSMenu7bits
            // 
            this.tSMenu7bits.Name = "tSMenu7bits";
            this.tSMenu7bits.Size = new System.Drawing.Size(153, 26);
            this.tSMenu7bits.Text = "7 bits";
            this.tSMenu7bits.Click += new System.EventHandler(this.TSMenu7bits_Click);
            // 
            // tSMenu8bits
            // 
            this.tSMenu8bits.Name = "tSMenu8bits";
            this.tSMenu8bits.Size = new System.Drawing.Size(153, 26);
            this.tSMenu8bits.Text = "8 bits";
            this.tSMenu8bits.Click += new System.EventHandler(this.TSMenu8bits_Click);
            // 
            // sTOPBITSToolStripMenuItem
            // 
            this.sTOPBITSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuStopOne,
            this.tSMenuStopTwo});
            this.sTOPBITSToolStripMenuItem.Name = "sTOPBITSToolStripMenuItem";
            this.sTOPBITSToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.sTOPBITSToolStripMenuItem.Text = "STOP bits";
            // 
            // tSMenuStopOne
            // 
            this.tSMenuStopOne.Name = "tSMenuStopOne";
            this.tSMenuStopOne.Size = new System.Drawing.Size(126, 26);
            this.tSMenuStopOne.Text = "One";
            this.tSMenuStopOne.Click += new System.EventHandler(this.TSMenuStopOne_Click);
            // 
            // tSMenuStopTwo
            // 
            this.tSMenuStopTwo.Name = "tSMenuStopTwo";
            this.tSMenuStopTwo.Size = new System.Drawing.Size(126, 26);
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
            this.pARITYBitsToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.pARITYBitsToolStripMenuItem.Text = "PARITY bits";
            // 
            // tSMenuParityNone
            // 
            this.tSMenuParityNone.Name = "tSMenuParityNone";
            this.tSMenuParityNone.Size = new System.Drawing.Size(135, 26);
            this.tSMenuParityNone.Text = "None";
            this.tSMenuParityNone.Click += new System.EventHandler(this.TSMenuParityNone_Click);
            // 
            // tSMenuParityOdd
            // 
            this.tSMenuParityOdd.Name = "tSMenuParityOdd";
            this.tSMenuParityOdd.Size = new System.Drawing.Size(135, 26);
            this.tSMenuParityOdd.Text = "Odd";
            this.tSMenuParityOdd.Click += new System.EventHandler(this.TSMenuParityOdd_Click);
            // 
            // tSMenuParityEven
            // 
            this.tSMenuParityEven.Name = "tSMenuParityEven";
            this.tSMenuParityEven.Size = new System.Drawing.Size(135, 26);
            this.tSMenuParityEven.Text = "Even";
            this.tSMenuParityEven.Click += new System.EventHandler(this.TSMenuParityEven_Click);
            // 
            // dTREnableToolStripMenuItem
            // 
            this.dTREnableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuDTRDisable,
            this.tSMenuDTREnable});
            this.dTREnableToolStripMenuItem.Name = "dTREnableToolStripMenuItem";
            this.dTREnableToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.dTREnableToolStripMenuItem.Text = "DTR control";
            // 
            // tSMenuDTRDisable
            // 
            this.tSMenuDTRDisable.Name = "tSMenuDTRDisable";
            this.tSMenuDTRDisable.Size = new System.Drawing.Size(162, 26);
            this.tSMenuDTRDisable.Text = "Disable";
            this.tSMenuDTRDisable.Click += new System.EventHandler(this.TSMenuDTRDisable_Click);
            // 
            // tSMenuDTREnable
            // 
            this.tSMenuDTREnable.Name = "tSMenuDTREnable";
            this.tSMenuDTREnable.Size = new System.Drawing.Size(162, 26);
            this.tSMenuDTREnable.Text = "Enable";
            this.tSMenuDTREnable.Click += new System.EventHandler(this.TSMenuDTREnable_Click);
            // 
            // rTPControlToolStripMenuItem
            // 
            this.rTPControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuRTSDisable,
            this.tSMenuRTSEnable});
            this.rTPControlToolStripMenuItem.Name = "rTPControlToolStripMenuItem";
            this.rTPControlToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.rTPControlToolStripMenuItem.Text = "RTS control";
            // 
            // tSMenuRTSDisable
            // 
            this.tSMenuRTSDisable.Name = "tSMenuRTSDisable";
            this.tSMenuRTSDisable.Size = new System.Drawing.Size(162, 26);
            this.tSMenuRTSDisable.Text = "Disable";
            this.tSMenuRTSDisable.Click += new System.EventHandler(this.TSMenuRTSDisable_Click);
            // 
            // tSMenuRTSEnable
            // 
            this.tSMenuRTSEnable.Name = "tSMenuRTSEnable";
            this.tSMenuRTSEnable.Size = new System.Drawing.Size(162, 26);
            this.tSMenuRTSEnable.Text = "Enable";
            this.tSMenuRTSEnable.Click += new System.EventHandler(this.TSMenuRTSEnable_Click);
            // 
            // 송신ToolStripMenuItem
            // 
            this.송신ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearToolStripMenuItem,
            this.writeToolStripMenuItem});
            this.송신ToolStripMenuItem.Name = "송신ToolStripMenuItem";
            this.송신ToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.송신ToolStripMenuItem.Text = "송신";
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
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
            this.writeToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.writeToolStripMenuItem.Text = "End Line";
            // 
            // tSMenuEndLineNone
            // 
            this.tSMenuEndLineNone.Name = "tSMenuEndLineNone";
            this.tSMenuEndLineNone.Size = new System.Drawing.Size(198, 26);
            this.tSMenuEndLineNone.Text = "없음";
            this.tSMenuEndLineNone.Click += new System.EventHandler(this.TSMenuEndLineNone_Click);
            // 
            // tSMenuEndLineBoth
            // 
            this.tSMenuEndLineBoth.Name = "tSMenuEndLineBoth";
            this.tSMenuEndLineBoth.Size = new System.Drawing.Size(198, 26);
            this.tSMenuEndLineBoth.Text = "모두(LF+CR)";
            this.tSMenuEndLineBoth.Click += new System.EventHandler(this.TSMenuEndLineBoth_Click);
            // 
            // tSMenuEndLineLF
            // 
            this.tSMenuEndLineLF.Name = "tSMenuEndLineLF";
            this.tSMenuEndLineLF.Size = new System.Drawing.Size(198, 26);
            this.tSMenuEndLineLF.Text = "줄바꿈(LF)";
            this.tSMenuEndLineLF.Click += new System.EventHandler(this.TSMenuEndLineLF_Click);
            // 
            // tSMenuEndLineCR
            // 
            this.tSMenuEndLineCR.Name = "tSMenuEndLineCR";
            this.tSMenuEndLineCR.Size = new System.Drawing.Size(198, 26);
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
            this.수ToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.수ToolStripMenuItem.Text = "수신";
            // 
            // ClearRXToolStripMenuItem
            // 
            this.ClearRXToolStripMenuItem.Name = "ClearRXToolStripMenuItem";
            this.ClearRXToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ClearRXToolStripMenuItem.Text = "내용 지우기";
            this.ClearRXToolStripMenuItem.Click += new System.EventHandler(this.ClearRXToolStripMenuItem_Click);
            // 
            // 표시방법ToolStripMenuItem
            // 
            this.표시방법ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuRxUpdate,
            this.tSMenuRxAll});
            this.표시방법ToolStripMenuItem.Name = "표시방법ToolStripMenuItem";
            this.표시방법ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.표시방법ToolStripMenuItem.Text = "표시방법";
            // 
            // tSMenuRxUpdate
            // 
            this.tSMenuRxUpdate.Name = "tSMenuRxUpdate";
            this.tSMenuRxUpdate.Size = new System.Drawing.Size(297, 26);
            this.tSMenuRxUpdate.Text = "수신 정보 표시(UPDATE)";
            this.tSMenuRxUpdate.Click += new System.EventHandler(this.TSMenuRxUpdate_Click);
            // 
            // tSMenuRxAll
            // 
            this.tSMenuRxAll.Name = "tSMenuRxAll";
            this.tSMenuRxAll.Size = new System.Drawing.Size(297, 26);
            this.tSMenuRxAll.Text = "모두 표시 (ADD)";
            this.tSMenuRxAll.Click += new System.EventHandler(this.TSMenuRxAll_Click);
            // 
            // CursorToolStripMenuItem
            // 
            this.CursorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuTop,
            this.tSMenuDown});
            this.CursorToolStripMenuItem.Name = "CursorToolStripMenuItem";
            this.CursorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.CursorToolStripMenuItem.Text = "표시위치";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.aboutToolStripMenuItem.Text = "도움말";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.tBoxDataIN);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(257, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(452, 266);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSendData);
            this.panel3.Controls.Add(this.tBoxDataOut);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 20);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(446, 28);
            this.panel3.TabIndex = 11;
            // 
            // lblDataOutLength
            // 
            this.lblDataOutLength.AutoSize = true;
            this.lblDataOutLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataOutLength.Location = new System.Drawing.Point(50, 15);
            this.lblDataOutLength.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataOutLength.Name = "lblDataOutLength";
            this.lblDataOutLength.Size = new System.Drawing.Size(24, 18);
            this.lblDataOutLength.TabIndex = 6;
            this.lblDataOutLength.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "TX : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 332);
            this.panel1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 264);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnLteState);
            this.groupBox8.Controls.Add(this.lblLteState);
            this.groupBox8.Location = new System.Drawing.Point(11, 217);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(222, 46);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            // 
            // btnLteState
            // 
            this.btnLteState.Location = new System.Drawing.Point(9, 14);
            this.btnLteState.Name = "btnLteState";
            this.btnLteState.Size = new System.Drawing.Size(75, 30);
            this.btnLteState.TabIndex = 0;
            this.btnLteState.Text = "LTE상태";
            this.btnLteState.UseVisualStyleBackColor = true;
            // 
            // lblLteState
            // 
            this.lblLteState.AutoSize = true;
            this.lblLteState.Location = new System.Drawing.Point(91, 18);
            this.lblLteState.Name = "lblLteState";
            this.lblLteState.Size = new System.Drawing.Size(68, 15);
            this.lblLteState.TabIndex = 1;
            this.lblLteState.Text = "ldle State";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnIMEI);
            this.groupBox7.Controls.Add(this.lblIMEI);
            this.groupBox7.Location = new System.Drawing.Point(11, 165);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(222, 46);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            // 
            // btnIMEI
            // 
            this.btnIMEI.Location = new System.Drawing.Point(9, 14);
            this.btnIMEI.Name = "btnIMEI";
            this.btnIMEI.Size = new System.Drawing.Size(75, 30);
            this.btnIMEI.TabIndex = 0;
            this.btnIMEI.Text = "IMEI";
            this.btnIMEI.UseVisualStyleBackColor = true;
            // 
            // lblIMEI
            // 
            this.lblIMEI.AutoSize = true;
            this.lblIMEI.Location = new System.Drawing.Point(91, 18);
            this.lblIMEI.Name = "lblIMEI";
            this.lblIMEI.Size = new System.Drawing.Size(52, 15);
            this.lblIMEI.TabIndex = 1;
            this.lblIMEI.Text = "미확인";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnIMSI);
            this.groupBox6.Controls.Add(this.lblIMSI);
            this.groupBox6.Location = new System.Drawing.Point(11, 120);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(222, 46);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            // 
            // btnIMSI
            // 
            this.btnIMSI.Location = new System.Drawing.Point(9, 14);
            this.btnIMSI.Name = "btnIMSI";
            this.btnIMSI.Size = new System.Drawing.Size(75, 30);
            this.btnIMSI.TabIndex = 0;
            this.btnIMSI.Text = "IMSI";
            this.btnIMSI.UseVisualStyleBackColor = true;
            // 
            // lblIMSI
            // 
            this.lblIMSI.AutoSize = true;
            this.lblIMSI.Location = new System.Drawing.Point(91, 18);
            this.lblIMSI.Name = "lblIMSI";
            this.lblIMSI.Size = new System.Drawing.Size(52, 15);
            this.lblIMSI.TabIndex = 1;
            this.lblIMSI.Text = "미확인";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnManu);
            this.groupBox5.Controls.Add(this.lblManu);
            this.groupBox5.Location = new System.Drawing.Point(11, 68);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(222, 46);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // btnManu
            // 
            this.btnManu.Location = new System.Drawing.Point(9, 14);
            this.btnManu.Name = "btnManu";
            this.btnManu.Size = new System.Drawing.Size(75, 30);
            this.btnManu.TabIndex = 0;
            this.btnManu.Text = "제조사";
            this.btnManu.UseVisualStyleBackColor = true;
            // 
            // lblManu
            // 
            this.lblManu.AutoSize = true;
            this.lblManu.Location = new System.Drawing.Point(91, 18);
            this.lblManu.Name = "lblManu";
            this.lblManu.Size = new System.Drawing.Size(52, 15);
            this.lblManu.TabIndex = 1;
            this.lblManu.Text = "미확인";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnModel);
            this.groupBox4.Controls.Add(this.lblModel);
            this.groupBox4.Location = new System.Drawing.Point(11, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(222, 46);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // btnModel
            // 
            this.btnModel.Location = new System.Drawing.Point(9, 14);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(75, 30);
            this.btnModel.TabIndex = 0;
            this.btnModel.Text = "모델명";
            this.btnModel.UseVisualStyleBackColor = true;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(91, 18);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(52, 15);
            this.lblModel.TabIndex = 1;
            this.lblModel.Text = "미확인";
            // 
            // panel2
            // 
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
            this.panel2.Location = new System.Drawing.Point(0, 284);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.panel2.Size = new System.Drawing.Size(715, 48);
            this.panel2.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDataInLength);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblDataOutLength);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(536, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(179, 46);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // tSMenuTop
            // 
            this.tSMenuTop.Name = "tSMenuTop";
            this.tSMenuTop.Size = new System.Drawing.Size(224, 26);
            this.tSMenuTop.Text = "위로";
            this.tSMenuTop.Click += new System.EventHandler(this.TSMenuTop_Click);
            // 
            // tSMenuDown
            // 
            this.tSMenuDown.Name = "tSMenuDown";
            this.tSMenuDown.Size = new System.Drawing.Size(224, 26);
            this.tSMenuDown.Text = "아래로";
            this.tSMenuDown.Click += new System.EventHandler(this.TSMenuDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 360);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1124, 709);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 407);
            this.Name = "Form1";
            this.Text = "LGU+ ATcommand TEST";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnLteState;
        private System.Windows.Forms.Label lblLteState;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnIMEI;
        private System.Windows.Forms.Label lblIMEI;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnIMSI;
        private System.Windows.Forms.Label lblIMSI;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnManu;
        private System.Windows.Forms.Label lblManu;
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
    }
}

