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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbTCResult = new System.Windows.Forms.GroupBox();
            this.tbTCResult = new System.Windows.Forms.TextBox();
            this.gbServerLog = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnMEFAuthS = new System.Windows.Forms.Button();
            this.lbEnrmtKey = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbToken = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbEntityId = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.gbLwM2MServer = new System.Windows.Forms.GroupBox();
            this.lbSvrLwM2MData = new System.Windows.Forms.Label();
            this.lbLwM2MRxData = new System.Windows.Forms.Label();
            this.btnDeviceStatusCheck = new System.Windows.Forms.Button();
            this.btnLwM2MData = new System.Windows.Forms.Button();
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.tbSeverPort = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbSeverIP = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnDelRemoteCSE = new System.Windows.Forms.Button();
            this.btnGetCSEBase = new System.Windows.Forms.Button();
            this.btnSetRemoteCSE = new System.Windows.Forms.Button();
            this.btnGetRemoteCSE = new System.Windows.Forms.Button();
            this.gbOneM2MServer = new System.Windows.Forms.GroupBox();
            this.lbdevicepoa = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbmodemfwrver = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbdevicever = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnDeviceCheck = new System.Windows.Forms.Button();
            this.lbSvroneM2MData = new System.Windows.Forms.Label();
            this.lboneM2MRxData = new System.Windows.Forms.Label();
            this.btnDataRetrive = new System.Windows.Forms.Button();
            this.btnSendtoDeviceoneM2M = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.gbOneM2MDevice = new System.Windows.Forms.GroupBox();
            this.btnDelSubscript = new System.Windows.Forms.Button();
            this.lbSendedData = new System.Windows.Forms.Label();
            this.btnDelRxContainer = new System.Windows.Forms.Button();
            this.btnSetRxContainer = new System.Windows.Forms.Button();
            this.btnoneM2MDeviceVer = new System.Windows.Forms.Button();
            this.btnSetSubscript = new System.Windows.Forms.Button();
            this.btnMEFAuthD = new System.Windows.Forms.Button();
            this.btnDeviceUpdateCSR = new System.Windows.Forms.Button();
            this.lboneM2MRcvData = new System.Windows.Forms.Label();
            this.btnRcvDataOneM2M = new System.Windows.Forms.Button();
            this.btnDelContainer = new System.Windows.Forms.Button();
            this.btnSetContainer = new System.Windows.Forms.Button();
            this.btnDelDeviceCSR = new System.Windows.Forms.Button();
            this.btnCreateDeviceCSR = new System.Windows.Forms.Button();
            this.btnModemFOTA = new System.Windows.Forms.Button();
            this.btnDeviceFOTA = new System.Windows.Forms.Button();
            this.btnGetDeviceCSR = new System.Windows.Forms.Button();
            this.btnGetCSED = new System.Windows.Forms.Button();
            this.btnSendDataOneM2M = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lbActionState = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cBoxATCMD = new System.Windows.Forms.ComboBox();
            this.btnATCMD = new System.Windows.Forms.Button();
            this.gbLwM2MDevice = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lbLwM2MRcvData = new System.Windows.Forms.Label();
            this.lbDevLwM2MData = new System.Windows.Forms.Label();
            this.btnLwM2MDisable = new System.Windows.Forms.Button();
            this.btnDeviceVerLwM2M = new System.Windows.Forms.Button();
            this.btnDeregister = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBootstrap = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.gbModule = new System.Windows.Forms.GroupBox();
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
            this.tbSvcCd = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tBoxDeviceModel = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbSvcSvrNum = new System.Windows.Forms.TextBox();
            this.tbSvcSvrCd = new System.Windows.Forms.TextBox();
            this.gbDeviceLog = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.tBoxDataIN = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.gbTCResult.SuspendLayout();
            this.gbServerLog.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.gbLwM2MServer.SuspendLayout();
            this.gbServer.SuspendLayout();
            this.gbOneM2MServer.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gbOneM2MDevice.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbLwM2MDevice.SuspendLayout();
            this.gbModule.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbDeviceLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Location = new System.Drawing.Point(19, 19);
            this.cBoxCOMPORT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxCOMPORT.Name = "cBoxCOMPORT";
            this.cBoxCOMPORT.Size = new System.Drawing.Size(73, 20);
            this.cBoxCOMPORT.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(98, 21);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(36, 18);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbTCResult);
            this.panel1.Controls.Add(this.gbServerLog);
            this.panel1.Controls.Add(this.groupBox11);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.gbDeviceLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1395, 678);
            this.panel1.TabIndex = 10;
            // 
            // gbTCResult
            // 
            this.gbTCResult.Controls.Add(this.tbTCResult);
            this.gbTCResult.Location = new System.Drawing.Point(475, 488);
            this.gbTCResult.Name = "gbTCResult";
            this.gbTCResult.Size = new System.Drawing.Size(472, 182);
            this.gbTCResult.TabIndex = 37;
            this.gbTCResult.TabStop = false;
            this.gbTCResult.Text = "TestCase Message";
            // 
            // tbTCResult
            // 
            this.tbTCResult.Location = new System.Drawing.Point(0, 25);
            this.tbTCResult.Multiline = true;
            this.tbTCResult.Name = "tbTCResult";
            this.tbTCResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTCResult.Size = new System.Drawing.Size(466, 146);
            this.tbTCResult.TabIndex = 35;
            // 
            // gbServerLog
            // 
            this.gbServerLog.Controls.Add(this.tbLog);
            this.gbServerLog.Location = new System.Drawing.Point(475, 300);
            this.gbServerLog.Name = "gbServerLog";
            this.gbServerLog.Size = new System.Drawing.Size(472, 182);
            this.gbServerLog.TabIndex = 36;
            this.gbServerLog.TabStop = false;
            this.gbServerLog.Text = "Server Message";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(0, 25);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(466, 146);
            this.tbLog.TabIndex = 35;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.groupBox9);
            this.groupBox11.Controls.Add(this.gbLwM2MServer);
            this.groupBox11.Controls.Add(this.gbServer);
            this.groupBox11.Controls.Add(this.gbOneM2MServer);
            this.groupBox11.Location = new System.Drawing.Point(953, 103);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(435, 567);
            this.groupBox11.TabIndex = 34;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "SERVER 동작";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnMEFAuthS);
            this.groupBox9.Controls.Add(this.lbEnrmtKey);
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Controls.Add(this.lbToken);
            this.groupBox9.Controls.Add(this.label25);
            this.groupBox9.Controls.Add(this.lbEntityId);
            this.groupBox9.Controls.Add(this.label27);
            this.groupBox9.Location = new System.Drawing.Point(15, 20);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(403, 94);
            this.groupBox9.TabIndex = 30;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "MEF";
            // 
            // btnMEFAuthS
            // 
            this.btnMEFAuthS.Location = new System.Drawing.Point(9, 25);
            this.btnMEFAuthS.Name = "btnMEFAuthS";
            this.btnMEFAuthS.Size = new System.Drawing.Size(112, 48);
            this.btnMEFAuthS.TabIndex = 0;
            this.btnMEFAuthS.Text = "MEF 인증";
            this.btnMEFAuthS.UseVisualStyleBackColor = true;
            this.btnMEFAuthS.Click += new System.EventHandler(this.btnMEFAuthS_Click);
            // 
            // lbEnrmtKey
            // 
            this.lbEnrmtKey.Location = new System.Drawing.Point(208, 25);
            this.lbEnrmtKey.Name = "lbEnrmtKey";
            this.lbEnrmtKey.Size = new System.Drawing.Size(189, 16);
            this.lbEnrmtKey.TabIndex = 6;
            this.lbEnrmtKey.Text = "svr.enrmtKey";
            this.lbEnrmtKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(125, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 16);
            this.label22.TabIndex = 6;
            this.label22.Text = "enrmtKey =";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbToken
            // 
            this.lbToken.Location = new System.Drawing.Point(208, 60);
            this.lbToken.Name = "lbToken";
            this.lbToken.Size = new System.Drawing.Size(189, 16);
            this.lbToken.TabIndex = 6;
            this.lbToken.Text = "svr.token";
            this.lbToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(125, 60);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 16);
            this.label25.TabIndex = 6;
            this.label25.Text = "token =";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbEntityId
            // 
            this.lbEntityId.Location = new System.Drawing.Point(208, 41);
            this.lbEntityId.Name = "lbEntityId";
            this.lbEntityId.Size = new System.Drawing.Size(189, 16);
            this.lbEntityId.TabIndex = 6;
            this.lbEntityId.Text = "svr.entityId";
            this.lbEntityId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(125, 41);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(78, 16);
            this.label27.TabIndex = 6;
            this.label27.Text = "entityId =";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbLwM2MServer
            // 
            this.gbLwM2MServer.Controls.Add(this.lbSvrLwM2MData);
            this.gbLwM2MServer.Controls.Add(this.lbLwM2MRxData);
            this.gbLwM2MServer.Controls.Add(this.btnDeviceStatusCheck);
            this.gbLwM2MServer.Controls.Add(this.btnLwM2MData);
            this.gbLwM2MServer.Enabled = false;
            this.gbLwM2MServer.Location = new System.Drawing.Point(15, 420);
            this.gbLwM2MServer.Name = "gbLwM2MServer";
            this.gbLwM2MServer.Size = new System.Drawing.Size(403, 108);
            this.gbLwM2MServer.TabIndex = 33;
            this.gbLwM2MServer.TabStop = false;
            this.gbLwM2MServer.Text = "LwM2M Device DATA";
            // 
            // lbSvrLwM2MData
            // 
            this.lbSvrLwM2MData.AutoSize = true;
            this.lbSvrLwM2MData.Location = new System.Drawing.Point(163, 81);
            this.lbSvrLwM2MData.Name = "lbSvrLwM2MData";
            this.lbSvrLwM2MData.Size = new System.Drawing.Size(49, 12);
            this.lbSvrLwM2MData.TabIndex = 40;
            this.lbSvrLwM2MData.Text = "No data";
            this.lbSvrLwM2MData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLwM2MRxData
            // 
            this.lbLwM2MRxData.Location = new System.Drawing.Point(163, 35);
            this.lbLwM2MRxData.Name = "lbLwM2MRxData";
            this.lbLwM2MRxData.Size = new System.Drawing.Size(224, 22);
            this.lbLwM2MRxData.TabIndex = 19;
            this.lbLwM2MRxData.Text = "No received data";
            this.lbLwM2MRxData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDeviceStatusCheck
            // 
            this.btnDeviceStatusCheck.Location = new System.Drawing.Point(9, 27);
            this.btnDeviceStatusCheck.Name = "btnDeviceStatusCheck";
            this.btnDeviceStatusCheck.Size = new System.Drawing.Size(112, 23);
            this.btnDeviceStatusCheck.TabIndex = 18;
            this.btnDeviceStatusCheck.Text = "상태조회(단말)";
            this.btnDeviceStatusCheck.UseVisualStyleBackColor = true;
            this.btnDeviceStatusCheck.Click += new System.EventHandler(this.btnDeviceStatusCheck_Click);
            // 
            // btnLwM2MData
            // 
            this.btnLwM2MData.Location = new System.Drawing.Point(9, 67);
            this.btnLwM2MData.Name = "btnLwM2MData";
            this.btnLwM2MData.Size = new System.Drawing.Size(112, 23);
            this.btnLwM2MData.TabIndex = 11;
            this.btnLwM2MData.Text = "데이터 보내기";
            this.btnLwM2MData.UseVisualStyleBackColor = true;
            this.btnLwM2MData.Click += new System.EventHandler(this.btnLwM2MData_Click);
            // 
            // gbServer
            // 
            this.gbServer.Controls.Add(this.tbSeverPort);
            this.gbServer.Controls.Add(this.label19);
            this.gbServer.Controls.Add(this.tbSeverIP);
            this.gbServer.Controls.Add(this.label20);
            this.gbServer.Controls.Add(this.btnDelRemoteCSE);
            this.gbServer.Controls.Add(this.btnGetCSEBase);
            this.gbServer.Controls.Add(this.btnSetRemoteCSE);
            this.gbServer.Controls.Add(this.btnGetRemoteCSE);
            this.gbServer.Enabled = false;
            this.gbServer.Location = new System.Drawing.Point(15, 120);
            this.gbServer.Name = "gbServer";
            this.gbServer.Size = new System.Drawing.Size(403, 122);
            this.gbServer.TabIndex = 31;
            this.gbServer.TabStop = false;
            this.gbServer.Text = "CSE";
            // 
            // tbSeverPort
            // 
            this.tbSeverPort.Location = new System.Drawing.Point(114, 87);
            this.tbSeverPort.Name = "tbSeverPort";
            this.tbSeverPort.Size = new System.Drawing.Size(140, 21);
            this.tbSeverPort.TabIndex = 14;
            this.tbSeverPort.Text = "8180";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(13, 82);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 22);
            this.label19.TabIndex = 13;
            this.label19.Text = "서비스서버 port";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSeverIP
            // 
            this.tbSeverIP.Location = new System.Drawing.Point(113, 62);
            this.tbSeverIP.Name = "tbSeverIP";
            this.tbSeverIP.Size = new System.Drawing.Size(141, 21);
            this.tbSeverIP.TabIndex = 12;
            this.tbSeverIP.Text = "http://172.17.224.57";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(7, 60);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 22);
            this.label20.TabIndex = 11;
            this.label20.Text = "서비스서버 IP";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDelRemoteCSE
            // 
            this.btnDelRemoteCSE.Location = new System.Drawing.Point(273, 27);
            this.btnDelRemoteCSE.Name = "btnDelRemoteCSE";
            this.btnDelRemoteCSE.Size = new System.Drawing.Size(118, 23);
            this.btnDelRemoteCSE.TabIndex = 2;
            this.btnDelRemoteCSE.Text = "CSR 삭제";
            this.btnDelRemoteCSE.UseVisualStyleBackColor = true;
            this.btnDelRemoteCSE.Click += new System.EventHandler(this.btnDelRemoteCSE_Click);
            // 
            // btnGetCSEBase
            // 
            this.btnGetCSEBase.Location = new System.Drawing.Point(9, 23);
            this.btnGetCSEBase.Name = "btnGetCSEBase";
            this.btnGetCSEBase.Size = new System.Drawing.Size(112, 23);
            this.btnGetCSEBase.TabIndex = 0;
            this.btnGetCSEBase.Text = "CSEBase 조회";
            this.btnGetCSEBase.UseVisualStyleBackColor = true;
            this.btnGetCSEBase.Click += new System.EventHandler(this.btnGetCSEBase_Click);
            // 
            // btnSetRemoteCSE
            // 
            this.btnSetRemoteCSE.Location = new System.Drawing.Point(273, 58);
            this.btnSetRemoteCSE.Name = "btnSetRemoteCSE";
            this.btnSetRemoteCSE.Size = new System.Drawing.Size(118, 50);
            this.btnSetRemoteCSE.TabIndex = 0;
            this.btnSetRemoteCSE.Text = "CSR 생성";
            this.btnSetRemoteCSE.UseVisualStyleBackColor = true;
            this.btnSetRemoteCSE.Click += new System.EventHandler(this.btnSetRemoteCSE_Click);
            // 
            // btnGetRemoteCSE
            // 
            this.btnGetRemoteCSE.Location = new System.Drawing.Point(143, 27);
            this.btnGetRemoteCSE.Name = "btnGetRemoteCSE";
            this.btnGetRemoteCSE.Size = new System.Drawing.Size(119, 23);
            this.btnGetRemoteCSE.TabIndex = 0;
            this.btnGetRemoteCSE.Text = "CSR 조회";
            this.btnGetRemoteCSE.UseVisualStyleBackColor = true;
            this.btnGetRemoteCSE.Click += new System.EventHandler(this.btnGetRemoteCSE_Click);
            // 
            // gbOneM2MServer
            // 
            this.gbOneM2MServer.Controls.Add(this.lbdevicepoa);
            this.gbOneM2MServer.Controls.Add(this.label12);
            this.gbOneM2MServer.Controls.Add(this.lbmodemfwrver);
            this.gbOneM2MServer.Controls.Add(this.label14);
            this.gbOneM2MServer.Controls.Add(this.lbdevicever);
            this.gbOneM2MServer.Controls.Add(this.label16);
            this.gbOneM2MServer.Controls.Add(this.btnDeviceCheck);
            this.gbOneM2MServer.Controls.Add(this.lbSvroneM2MData);
            this.gbOneM2MServer.Controls.Add(this.lboneM2MRxData);
            this.gbOneM2MServer.Controls.Add(this.btnDataRetrive);
            this.gbOneM2MServer.Controls.Add(this.btnSendtoDeviceoneM2M);
            this.gbOneM2MServer.Enabled = false;
            this.gbOneM2MServer.Location = new System.Drawing.Point(15, 265);
            this.gbOneM2MServer.Name = "gbOneM2MServer";
            this.gbOneM2MServer.Size = new System.Drawing.Size(403, 140);
            this.gbOneM2MServer.TabIndex = 32;
            this.gbOneM2MServer.TabStop = false;
            this.gbOneM2MServer.Text = "oneM2M Device DATA";
            // 
            // lbdevicepoa
            // 
            this.lbdevicepoa.Location = new System.Drawing.Point(221, 17);
            this.lbdevicepoa.Name = "lbdevicepoa";
            this.lbdevicepoa.Size = new System.Drawing.Size(164, 16);
            this.lbdevicepoa.TabIndex = 41;
            this.lbdevicepoa.Text = "Device IP";
            this.lbdevicepoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(134, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 16);
            this.label12.TabIndex = 42;
            this.label12.Text = "poa =";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbmodemfwrver
            // 
            this.lbmodemfwrver.Location = new System.Drawing.Point(221, 52);
            this.lbmodemfwrver.Name = "lbmodemfwrver";
            this.lbmodemfwrver.Size = new System.Drawing.Size(164, 16);
            this.lbmodemfwrver.TabIndex = 43;
            this.lbmodemfwrver.Text = ".";
            this.lbmodemfwrver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(129, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 17);
            this.label14.TabIndex = 44;
            this.label14.Text = "modem ver =";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbdevicever
            // 
            this.lbdevicever.Location = new System.Drawing.Point(221, 33);
            this.lbdevicever.Name = "lbdevicever";
            this.lbdevicever.Size = new System.Drawing.Size(164, 16);
            this.lbdevicever.TabIndex = 45;
            this.lbdevicever.Text = ".";
            this.lbdevicever.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(134, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 16);
            this.label16.TabIndex = 46;
            this.label16.Text = "device ver =";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDeviceCheck
            // 
            this.btnDeviceCheck.Location = new System.Drawing.Point(9, 16);
            this.btnDeviceCheck.Name = "btnDeviceCheck";
            this.btnDeviceCheck.Size = new System.Drawing.Size(112, 50);
            this.btnDeviceCheck.TabIndex = 40;
            this.btnDeviceCheck.Text = "디바이스 리소스";
            this.btnDeviceCheck.UseVisualStyleBackColor = true;
            this.btnDeviceCheck.Click += new System.EventHandler(this.btnDeviceCheck_Click);
            // 
            // lbSvroneM2MData
            // 
            this.lbSvroneM2MData.AutoSize = true;
            this.lbSvroneM2MData.Location = new System.Drawing.Point(149, 110);
            this.lbSvroneM2MData.Name = "lbSvroneM2MData";
            this.lbSvroneM2MData.Size = new System.Drawing.Size(49, 12);
            this.lbSvroneM2MData.TabIndex = 39;
            this.lbSvroneM2MData.Text = "No data";
            this.lbSvroneM2MData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lboneM2MRxData
            // 
            this.lboneM2MRxData.Location = new System.Drawing.Point(149, 73);
            this.lboneM2MRxData.Name = "lboneM2MRxData";
            this.lboneM2MRxData.Size = new System.Drawing.Size(242, 22);
            this.lboneM2MRxData.TabIndex = 16;
            this.lboneM2MRxData.Text = "No received data";
            this.lboneM2MRxData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDataRetrive
            // 
            this.btnDataRetrive.Location = new System.Drawing.Point(9, 72);
            this.btnDataRetrive.Name = "btnDataRetrive";
            this.btnDataRetrive.Size = new System.Drawing.Size(112, 23);
            this.btnDataRetrive.TabIndex = 14;
            this.btnDataRetrive.Text = "데이터 확인 (DB)";
            this.btnDataRetrive.UseVisualStyleBackColor = true;
            this.btnDataRetrive.Click += new System.EventHandler(this.btnDataRetrive_Click);
            // 
            // btnSendtoDeviceoneM2M
            // 
            this.btnSendtoDeviceoneM2M.Location = new System.Drawing.Point(9, 104);
            this.btnSendtoDeviceoneM2M.Name = "btnSendtoDeviceoneM2M";
            this.btnSendtoDeviceoneM2M.Size = new System.Drawing.Size(112, 23);
            this.btnSendtoDeviceoneM2M.TabIndex = 3;
            this.btnSendtoDeviceoneM2M.Text = "데이터 보내기";
            this.btnSendtoDeviceoneM2M.UseVisualStyleBackColor = true;
            this.btnSendtoDeviceoneM2M.Click += new System.EventHandler(this.btnSendtoDeviceoneM2M_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.gbOneM2MDevice);
            this.groupBox7.Controls.Add(this.groupBox5);
            this.groupBox7.Controls.Add(this.gbLwM2MDevice);
            this.groupBox7.Controls.Add(this.gbModule);
            this.groupBox7.Location = new System.Drawing.Point(28, 94);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(438, 576);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "DEVICE 동작";
            // 
            // gbOneM2MDevice
            // 
            this.gbOneM2MDevice.Controls.Add(this.btnDelSubscript);
            this.gbOneM2MDevice.Controls.Add(this.lbSendedData);
            this.gbOneM2MDevice.Controls.Add(this.btnDelRxContainer);
            this.gbOneM2MDevice.Controls.Add(this.btnSetRxContainer);
            this.gbOneM2MDevice.Controls.Add(this.btnoneM2MDeviceVer);
            this.gbOneM2MDevice.Controls.Add(this.btnSetSubscript);
            this.gbOneM2MDevice.Controls.Add(this.btnMEFAuthD);
            this.gbOneM2MDevice.Controls.Add(this.btnDeviceUpdateCSR);
            this.gbOneM2MDevice.Controls.Add(this.lboneM2MRcvData);
            this.gbOneM2MDevice.Controls.Add(this.btnRcvDataOneM2M);
            this.gbOneM2MDevice.Controls.Add(this.btnDelContainer);
            this.gbOneM2MDevice.Controls.Add(this.btnSetContainer);
            this.gbOneM2MDevice.Controls.Add(this.btnDelDeviceCSR);
            this.gbOneM2MDevice.Controls.Add(this.btnCreateDeviceCSR);
            this.gbOneM2MDevice.Controls.Add(this.btnModemFOTA);
            this.gbOneM2MDevice.Controls.Add(this.btnDeviceFOTA);
            this.gbOneM2MDevice.Controls.Add(this.btnGetDeviceCSR);
            this.gbOneM2MDevice.Controls.Add(this.btnGetCSED);
            this.gbOneM2MDevice.Controls.Add(this.btnSendDataOneM2M);
            this.gbOneM2MDevice.Enabled = false;
            this.gbOneM2MDevice.Location = new System.Drawing.Point(14, 205);
            this.gbOneM2MDevice.Name = "gbOneM2MDevice";
            this.gbOneM2MDevice.Size = new System.Drawing.Size(413, 218);
            this.gbOneM2MDevice.TabIndex = 25;
            this.gbOneM2MDevice.TabStop = false;
            this.gbOneM2MDevice.Text = "oneM2M";
            // 
            // btnDelSubscript
            // 
            this.btnDelSubscript.Location = new System.Drawing.Point(323, 77);
            this.btnDelSubscript.Name = "btnDelSubscript";
            this.btnDelSubscript.Size = new System.Drawing.Size(75, 20);
            this.btnDelSubscript.TabIndex = 39;
            this.btnDelSubscript.Text = "구독삭제";
            this.btnDelSubscript.UseVisualStyleBackColor = true;
            this.btnDelSubscript.Click += new System.EventHandler(this.btnDelSubscript_Click);
            // 
            // lbSendedData
            // 
            this.lbSendedData.AutoSize = true;
            this.lbSendedData.Location = new System.Drawing.Point(150, 167);
            this.lbSendedData.Name = "lbSendedData";
            this.lbSendedData.Size = new System.Drawing.Size(49, 12);
            this.lbSendedData.TabIndex = 38;
            this.lbSendedData.Text = "No data";
            this.lbSendedData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelRxContainer
            // 
            this.btnDelRxContainer.Location = new System.Drawing.Point(120, 77);
            this.btnDelRxContainer.Name = "btnDelRxContainer";
            this.btnDelRxContainer.Size = new System.Drawing.Size(88, 20);
            this.btnDelRxContainer.TabIndex = 37;
            this.btnDelRxContainer.Text = "수신폴더삭제";
            this.btnDelRxContainer.UseVisualStyleBackColor = true;
            this.btnDelRxContainer.Click += new System.EventHandler(this.btnDelRxContainer_Click);
            // 
            // btnSetRxContainer
            // 
            this.btnSetRxContainer.Location = new System.Drawing.Point(13, 77);
            this.btnSetRxContainer.Name = "btnSetRxContainer";
            this.btnSetRxContainer.Size = new System.Drawing.Size(92, 20);
            this.btnSetRxContainer.TabIndex = 36;
            this.btnSetRxContainer.Text = "수신폴더생성";
            this.btnSetRxContainer.UseVisualStyleBackColor = true;
            this.btnSetRxContainer.Click += new System.EventHandler(this.btnSetRxContainer_Click);
            // 
            // btnoneM2MDeviceVer
            // 
            this.btnoneM2MDeviceVer.Location = new System.Drawing.Point(13, 189);
            this.btnoneM2MDeviceVer.Name = "btnoneM2MDeviceVer";
            this.btnoneM2MDeviceVer.Size = new System.Drawing.Size(121, 20);
            this.btnoneM2MDeviceVer.TabIndex = 35;
            this.btnoneM2MDeviceVer.Text = "디바이스 버전 보고";
            this.btnoneM2MDeviceVer.UseVisualStyleBackColor = true;
            this.btnoneM2MDeviceVer.Click += new System.EventHandler(this.btnoneM2MDeviceVer_Click);
            // 
            // btnSetSubscript
            // 
            this.btnSetSubscript.Location = new System.Drawing.Point(231, 77);
            this.btnSetSubscript.Name = "btnSetSubscript";
            this.btnSetSubscript.Size = new System.Drawing.Size(75, 20);
            this.btnSetSubscript.TabIndex = 34;
            this.btnSetSubscript.Text = "구독신청";
            this.btnSetSubscript.UseVisualStyleBackColor = true;
            this.btnSetSubscript.Click += new System.EventHandler(this.btnSetSubscript_Click);
            // 
            // btnMEFAuthD
            // 
            this.btnMEFAuthD.Location = new System.Drawing.Point(13, 25);
            this.btnMEFAuthD.Name = "btnMEFAuthD";
            this.btnMEFAuthD.Size = new System.Drawing.Size(121, 20);
            this.btnMEFAuthD.TabIndex = 33;
            this.btnMEFAuthD.Text = "MEF 인증";
            this.btnMEFAuthD.UseVisualStyleBackColor = true;
            this.btnMEFAuthD.Click += new System.EventHandler(this.btnMEFAuthD_Click);
            // 
            // btnDeviceUpdateCSR
            // 
            this.btnDeviceUpdateCSR.Location = new System.Drawing.Point(281, 25);
            this.btnDeviceUpdateCSR.Name = "btnDeviceUpdateCSR";
            this.btnDeviceUpdateCSR.Size = new System.Drawing.Size(119, 20);
            this.btnDeviceUpdateCSR.TabIndex = 32;
            this.btnDeviceUpdateCSR.Text = "CSR 수정";
            this.btnDeviceUpdateCSR.UseVisualStyleBackColor = true;
            this.btnDeviceUpdateCSR.Click += new System.EventHandler(this.btnDeviceUpdateCSR_Click);
            // 
            // lboneM2MRcvData
            // 
            this.lboneM2MRcvData.AutoSize = true;
            this.lboneM2MRcvData.Location = new System.Drawing.Point(146, 111);
            this.lboneM2MRcvData.Name = "lboneM2MRcvData";
            this.lboneM2MRcvData.Size = new System.Drawing.Size(101, 12);
            this.lboneM2MRcvData.TabIndex = 31;
            this.lboneM2MRcvData.Text = "No received data";
            this.lboneM2MRcvData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRcvDataOneM2M
            // 
            this.btnRcvDataOneM2M.Location = new System.Drawing.Point(13, 107);
            this.btnRcvDataOneM2M.Name = "btnRcvDataOneM2M";
            this.btnRcvDataOneM2M.Size = new System.Drawing.Size(121, 20);
            this.btnRcvDataOneM2M.TabIndex = 30;
            this.btnRcvDataOneM2M.Text = "데이터 수신";
            this.btnRcvDataOneM2M.UseVisualStyleBackColor = true;
            this.btnRcvDataOneM2M.Click += new System.EventHandler(this.btnRcvDataOneM2M_Click);
            // 
            // btnDelContainer
            // 
            this.btnDelContainer.Location = new System.Drawing.Point(138, 137);
            this.btnDelContainer.Name = "btnDelContainer";
            this.btnDelContainer.Size = new System.Drawing.Size(137, 20);
            this.btnDelContainer.TabIndex = 29;
            this.btnDelContainer.Text = "송신폴더삭제";
            this.btnDelContainer.UseVisualStyleBackColor = true;
            this.btnDelContainer.Click += new System.EventHandler(this.btnDelContainer_Click);
            // 
            // btnSetContainer
            // 
            this.btnSetContainer.Location = new System.Drawing.Point(13, 137);
            this.btnSetContainer.Name = "btnSetContainer";
            this.btnSetContainer.Size = new System.Drawing.Size(121, 20);
            this.btnSetContainer.TabIndex = 27;
            this.btnSetContainer.Text = "송신폴더생성";
            this.btnSetContainer.UseVisualStyleBackColor = true;
            this.btnSetContainer.Click += new System.EventHandler(this.btnSetContainer_Click);
            // 
            // btnDelDeviceCSR
            // 
            this.btnDelDeviceCSR.Location = new System.Drawing.Point(281, 50);
            this.btnDelDeviceCSR.Name = "btnDelDeviceCSR";
            this.btnDelDeviceCSR.Size = new System.Drawing.Size(119, 20);
            this.btnDelDeviceCSR.TabIndex = 26;
            this.btnDelDeviceCSR.Text = "CSR 삭제";
            this.btnDelDeviceCSR.UseVisualStyleBackColor = true;
            this.btnDelDeviceCSR.Click += new System.EventHandler(this.btnDelDeviceCSR_Click);
            // 
            // btnCreateDeviceCSR
            // 
            this.btnCreateDeviceCSR.Location = new System.Drawing.Point(140, 51);
            this.btnCreateDeviceCSR.Name = "btnCreateDeviceCSR";
            this.btnCreateDeviceCSR.Size = new System.Drawing.Size(135, 20);
            this.btnCreateDeviceCSR.TabIndex = 25;
            this.btnCreateDeviceCSR.Text = "CSR 생성";
            this.btnCreateDeviceCSR.UseVisualStyleBackColor = true;
            this.btnCreateDeviceCSR.Click += new System.EventHandler(this.btnCreateDeviceCSR_Click);
            // 
            // btnModemFOTA
            // 
            this.btnModemFOTA.Location = new System.Drawing.Point(281, 189);
            this.btnModemFOTA.Name = "btnModemFOTA";
            this.btnModemFOTA.Size = new System.Drawing.Size(119, 20);
            this.btnModemFOTA.TabIndex = 24;
            this.btnModemFOTA.Text = "모듈 FOTA 조회";
            this.btnModemFOTA.UseVisualStyleBackColor = true;
            this.btnModemFOTA.Click += new System.EventHandler(this.btnModemFOTA_Click);
            // 
            // btnDeviceFOTA
            // 
            this.btnDeviceFOTA.Location = new System.Drawing.Point(140, 189);
            this.btnDeviceFOTA.Name = "btnDeviceFOTA";
            this.btnDeviceFOTA.Size = new System.Drawing.Size(135, 20);
            this.btnDeviceFOTA.TabIndex = 23;
            this.btnDeviceFOTA.Text = "디바이스 FOTA 조회";
            this.btnDeviceFOTA.UseVisualStyleBackColor = true;
            this.btnDeviceFOTA.Click += new System.EventHandler(this.btnDeviceFOTA_Click);
            // 
            // btnGetDeviceCSR
            // 
            this.btnGetDeviceCSR.Location = new System.Drawing.Point(13, 51);
            this.btnGetDeviceCSR.Name = "btnGetDeviceCSR";
            this.btnGetDeviceCSR.Size = new System.Drawing.Size(121, 20);
            this.btnGetDeviceCSR.TabIndex = 22;
            this.btnGetDeviceCSR.Text = "CSR 조회";
            this.btnGetDeviceCSR.UseVisualStyleBackColor = true;
            this.btnGetDeviceCSR.Click += new System.EventHandler(this.btnGetDeviceCSR_Click);
            // 
            // btnGetCSED
            // 
            this.btnGetCSED.Location = new System.Drawing.Point(140, 25);
            this.btnGetCSED.Name = "btnGetCSED";
            this.btnGetCSED.Size = new System.Drawing.Size(135, 20);
            this.btnGetCSED.TabIndex = 21;
            this.btnGetCSED.Text = "CSEBase 조회";
            this.btnGetCSED.UseVisualStyleBackColor = true;
            this.btnGetCSED.Click += new System.EventHandler(this.btnGetCSED_Click);
            // 
            // btnSendDataOneM2M
            // 
            this.btnSendDataOneM2M.Location = new System.Drawing.Point(13, 163);
            this.btnSendDataOneM2M.Name = "btnSendDataOneM2M";
            this.btnSendDataOneM2M.Size = new System.Drawing.Size(121, 20);
            this.btnSendDataOneM2M.TabIndex = 19;
            this.btnSendDataOneM2M.Text = "데이터전송";
            this.btnSendDataOneM2M.UseVisualStyleBackColor = true;
            this.btnSendDataOneM2M.Click += new System.EventHandler(this.btnSendDataOneM2M_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox10);
            this.groupBox5.Controls.Add(this.lbActionState);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.cBoxCOMPORT);
            this.groupBox5.Controls.Add(this.cBoxATCMD);
            this.groupBox5.Controls.Add(this.btnATCMD);
            this.groupBox5.Controls.Add(this.progressBar1);
            this.groupBox5.Location = new System.Drawing.Point(14, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(413, 75);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "COM 포트";
            // 
            // groupBox10
            // 
            this.groupBox10.Location = new System.Drawing.Point(237, 75);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(786, 588);
            this.groupBox10.TabIndex = 34;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "groupBox10";
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
            this.cBoxATCMD.Size = new System.Drawing.Size(245, 20);
            this.cBoxATCMD.TabIndex = 18;
            this.cBoxATCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBoxATCMD_KeyDown);
            // 
            // btnATCMD
            // 
            this.btnATCMD.Location = new System.Drawing.Point(268, 42);
            this.btnATCMD.Name = "btnATCMD";
            this.btnATCMD.Size = new System.Drawing.Size(75, 20);
            this.btnATCMD.TabIndex = 17;
            this.btnATCMD.Text = "AT명령";
            this.btnATCMD.UseVisualStyleBackColor = true;
            this.btnATCMD.Click += new System.EventHandler(this.btnATCMD_Click);
            // 
            // gbLwM2MDevice
            // 
            this.gbLwM2MDevice.Controls.Add(this.label17);
            this.gbLwM2MDevice.Controls.Add(this.lbLwM2MRcvData);
            this.gbLwM2MDevice.Controls.Add(this.lbDevLwM2MData);
            this.gbLwM2MDevice.Controls.Add(this.btnLwM2MDisable);
            this.gbLwM2MDevice.Controls.Add(this.btnDeviceVerLwM2M);
            this.gbLwM2MDevice.Controls.Add(this.btnDeregister);
            this.gbLwM2MDevice.Controls.Add(this.btnRegister);
            this.gbLwM2MDevice.Controls.Add(this.btnBootstrap);
            this.gbLwM2MDevice.Controls.Add(this.btnSendData);
            this.gbLwM2MDevice.Enabled = false;
            this.gbLwM2MDevice.Location = new System.Drawing.Point(14, 429);
            this.gbLwM2MDevice.Name = "gbLwM2MDevice";
            this.gbLwM2MDevice.Size = new System.Drawing.Size(413, 135);
            this.gbLwM2MDevice.TabIndex = 15;
            this.gbLwM2MDevice.TabStop = false;
            this.gbLwM2MDevice.Text = "LwM2M";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(39, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 12);
            this.label17.TabIndex = 41;
            this.label17.Text = "데이터 수신 : ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLwM2MRcvData
            // 
            this.lbLwM2MRcvData.AutoSize = true;
            this.lbLwM2MRcvData.Location = new System.Drawing.Point(146, 61);
            this.lbLwM2MRcvData.Name = "lbLwM2MRcvData";
            this.lbLwM2MRcvData.Size = new System.Drawing.Size(101, 12);
            this.lbLwM2MRcvData.TabIndex = 40;
            this.lbLwM2MRcvData.Text = "No received data";
            this.lbLwM2MRcvData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDevLwM2MData
            // 
            this.lbDevLwM2MData.AutoSize = true;
            this.lbDevLwM2MData.Location = new System.Drawing.Point(150, 83);
            this.lbDevLwM2MData.Name = "lbDevLwM2MData";
            this.lbDevLwM2MData.Size = new System.Drawing.Size(49, 12);
            this.lbDevLwM2MData.TabIndex = 39;
            this.lbDevLwM2MData.Text = "No data";
            this.lbDevLwM2MData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLwM2MDisable
            // 
            this.btnLwM2MDisable.Location = new System.Drawing.Point(148, 103);
            this.btnLwM2MDisable.Name = "btnLwM2MDisable";
            this.btnLwM2MDisable.Size = new System.Drawing.Size(127, 20);
            this.btnLwM2MDisable.TabIndex = 25;
            this.btnLwM2MDisable.Text = "LwM2M해제";
            this.btnLwM2MDisable.UseVisualStyleBackColor = true;
            this.btnLwM2MDisable.Click += new System.EventHandler(this.btnLwM2MDisable_Click);
            // 
            // btnDeviceVerLwM2M
            // 
            this.btnDeviceVerLwM2M.Location = new System.Drawing.Point(281, 30);
            this.btnDeviceVerLwM2M.Name = "btnDeviceVerLwM2M";
            this.btnDeviceVerLwM2M.Size = new System.Drawing.Size(119, 20);
            this.btnDeviceVerLwM2M.TabIndex = 24;
            this.btnDeviceVerLwM2M.Text = "DEVICE 버전 보고";
            this.btnDeviceVerLwM2M.UseVisualStyleBackColor = true;
            this.btnDeviceVerLwM2M.Click += new System.EventHandler(this.btnDeviceVerLwM2M_Click);
            // 
            // btnDeregister
            // 
            this.btnDeregister.Location = new System.Drawing.Point(13, 103);
            this.btnDeregister.Name = "btnDeregister";
            this.btnDeregister.Size = new System.Drawing.Size(127, 20);
            this.btnDeregister.TabIndex = 23;
            this.btnDeregister.Text = "DEREGISTER";
            this.btnDeregister.UseVisualStyleBackColor = true;
            this.btnDeregister.Click += new System.EventHandler(this.btnDeregister_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(148, 30);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(127, 20);
            this.btnRegister.TabIndex = 22;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnBootstrap
            // 
            this.btnBootstrap.Location = new System.Drawing.Point(13, 30);
            this.btnBootstrap.Name = "btnBootstrap";
            this.btnBootstrap.Size = new System.Drawing.Size(127, 20);
            this.btnBootstrap.TabIndex = 21;
            this.btnBootstrap.Text = "BOOTSTRAP";
            this.btnBootstrap.UseVisualStyleBackColor = true;
            this.btnBootstrap.Click += new System.EventHandler(this.btnBootstrap_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(13, 77);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(127, 20);
            this.btnSendData.TabIndex = 19;
            this.btnSendData.Text = "데이터전송";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // gbModule
            // 
            this.gbModule.Controls.Add(this.lbIccid);
            this.gbModule.Controls.Add(this.label11);
            this.gbModule.Controls.Add(this.lbIMSI);
            this.gbModule.Controls.Add(this.label9);
            this.gbModule.Controls.Add(this.lbModemVer);
            this.gbModule.Controls.Add(this.label8);
            this.gbModule.Controls.Add(this.lbMaker);
            this.gbModule.Controls.Add(this.label7);
            this.gbModule.Controls.Add(this.lbModel);
            this.gbModule.Controls.Add(this.lbModelName);
            this.gbModule.Controls.Add(this.label5);
            this.gbModule.Controls.Add(this.btnModuleInfo);
            this.gbModule.Enabled = false;
            this.gbModule.Location = new System.Drawing.Point(14, 100);
            this.gbModule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbModule.Name = "gbModule";
            this.gbModule.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbModule.Size = new System.Drawing.Size(413, 100);
            this.gbModule.TabIndex = 11;
            this.gbModule.TabStop = false;
            this.gbModule.Text = "모듈 정보";
            // 
            // lbIccid
            // 
            this.lbIccid.AutoSize = true;
            this.lbIccid.Location = new System.Drawing.Point(267, 67);
            this.lbIccid.Name = "lbIccid";
            this.lbIccid.Size = new System.Drawing.Size(9, 12);
            this.lbIccid.TabIndex = 33;
            this.lbIccid.Text = ".";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(219, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 12);
            this.label11.TabIndex = 32;
            this.label11.Text = "ICCID :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbIMSI
            // 
            this.lbIMSI.AutoSize = true;
            this.lbIMSI.Location = new System.Drawing.Point(114, 67);
            this.lbIMSI.Name = "lbIMSI";
            this.lbIMSI.Size = new System.Drawing.Size(9, 12);
            this.lbIMSI.TabIndex = 31;
            this.lbIMSI.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "CTN :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbModemVer
            // 
            this.lbModemVer.AutoSize = true;
            this.lbModemVer.Location = new System.Drawing.Point(267, 44);
            this.lbModemVer.Name = "lbModemVer";
            this.lbModemVer.Size = new System.Drawing.Size(9, 12);
            this.lbModemVer.TabIndex = 29;
            this.lbModemVer.Text = ".";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(203, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "모듈버전 :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbMaker
            // 
            this.lbMaker.AutoSize = true;
            this.lbMaker.Location = new System.Drawing.Point(124, 23);
            this.lbMaker.Name = "lbMaker";
            this.lbMaker.Size = new System.Drawing.Size(9, 12);
            this.lbMaker.TabIndex = 27;
            this.lbMaker.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "제조사 :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Location = new System.Drawing.Point(124, 42);
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
            this.label5.Location = new System.Drawing.Point(72, 44);
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
            this.btnModuleInfo.Size = new System.Drawing.Size(49, 49);
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
            this.groupBox6.Controls.Add(this.tbSvcCd);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.tBoxDeviceModel);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.tbSvcSvrNum);
            this.groupBox6.Controls.Add(this.tbSvcSvrCd);
            this.groupBox6.Location = new System.Drawing.Point(28, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1360, 64);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "프로젝트";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(747, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "디바이스 버전 :";
            // 
            // tBoxDeviceVer
            // 
            this.tBoxDeviceVer.Location = new System.Drawing.Point(842, 19);
            this.tBoxDeviceVer.Name = "tBoxDeviceVer";
            this.tBoxDeviceVer.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceVer.TabIndex = 25;
            this.tBoxDeviceVer.Text = "1.0.0";
            this.tBoxDeviceVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(494, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "디바이스 일련번호 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 23);
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
            this.tBoxDeviceSN.Location = new System.Drawing.Point(610, 20);
            this.tBoxDeviceSN.Name = "tBoxDeviceSN";
            this.tBoxDeviceSN.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceSN.TabIndex = 23;
            this.tBoxDeviceSN.Text = "123456";
            this.tBoxDeviceSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSvcCd
            // 
            this.tbSvcCd.Location = new System.Drawing.Point(96, 20);
            this.tbSvcCd.Name = "tbSvcCd";
            this.tbSvcCd.Size = new System.Drawing.Size(126, 21);
            this.tbSvcCd.TabIndex = 17;
            this.tbSvcCd.Text = "CATM";
            this.tbSvcCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(979, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(86, 16);
            this.label23.TabIndex = 6;
            this.label23.Text = "서버 SEQ :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBoxDeviceModel
            // 
            this.tBoxDeviceModel.Location = new System.Drawing.Point(351, 18);
            this.tBoxDeviceModel.Name = "tBoxDeviceModel";
            this.tBoxDeviceModel.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceModel.TabIndex = 21;
            this.tBoxDeviceModel.Text = "LWEMG";
            this.tBoxDeviceModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(1177, 22);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(86, 16);
            this.label28.TabIndex = 6;
            this.label28.Text = "서버 NUM :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSvcSvrNum
            // 
            this.tbSvcSvrNum.Location = new System.Drawing.Point(1275, 20);
            this.tbSvcSvrNum.Name = "tbSvcSvrNum";
            this.tbSvcSvrNum.Size = new System.Drawing.Size(68, 21);
            this.tbSvcSvrNum.TabIndex = 7;
            this.tbSvcSvrNum.Text = "1";
            this.tbSvcSvrNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSvcSvrCd
            // 
            this.tbSvcSvrCd.Location = new System.Drawing.Point(1071, 20);
            this.tbSvcSvrCd.Name = "tbSvcSvrCd";
            this.tbSvcSvrCd.Size = new System.Drawing.Size(100, 21);
            this.tbSvcSvrCd.TabIndex = 7;
            this.tbSvcSvrCd.Text = "300";
            this.tbSvcSvrCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbDeviceLog
            // 
            this.gbDeviceLog.Controls.Add(this.groupBox12);
            this.gbDeviceLog.Controls.Add(this.tBoxDataIN);
            this.gbDeviceLog.Location = new System.Drawing.Point(472, 103);
            this.gbDeviceLog.Name = "gbDeviceLog";
            this.gbDeviceLog.Size = new System.Drawing.Size(475, 191);
            this.gbDeviceLog.TabIndex = 12;
            this.gbDeviceLog.TabStop = false;
            this.gbDeviceLog.Text = "Device Message";
            // 
            // groupBox12
            // 
            this.groupBox12.Location = new System.Drawing.Point(51, 241);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(200, 100);
            this.groupBox12.TabIndex = 36;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "groupBox12";
            // 
            // tBoxDataIN
            // 
            this.tBoxDataIN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tBoxDataIN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBoxDataIN.Location = new System.Drawing.Point(3, 26);
            this.tBoxDataIN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tBoxDataIN.Multiline = true;
            this.tBoxDataIN.Name = "tBoxDataIN";
            this.tBoxDataIN.ReadOnly = true;
            this.tBoxDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBoxDataIN.Size = new System.Drawing.Size(469, 162);
            this.tBoxDataIN.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 678);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1076);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(748, 452);
            this.Name = "Form1";
            this.Text = "oneM2M/LwM2M Device PCT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.gbTCResult.ResumeLayout(false);
            this.gbTCResult.PerformLayout();
            this.gbServerLog.ResumeLayout(false);
            this.gbServerLog.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.gbLwM2MServer.ResumeLayout(false);
            this.gbLwM2MServer.PerformLayout();
            this.gbServer.ResumeLayout(false);
            this.gbServer.PerformLayout();
            this.gbOneM2MServer.ResumeLayout(false);
            this.gbOneM2MServer.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.gbOneM2MDevice.ResumeLayout(false);
            this.gbOneM2MDevice.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbLwM2MDevice.ResumeLayout(false);
            this.gbLwM2MDevice.PerformLayout();
            this.gbModule.ResumeLayout(false);
            this.gbModule.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gbDeviceLog.ResumeLayout(false);
            this.gbDeviceLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cBoxCOMPORT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbModule;
        private System.Windows.Forms.TextBox tbSvcCd;
        private System.Windows.Forms.GroupBox gbDeviceLog;
        private System.Windows.Forms.TextBox tBoxDeviceSN;
        private System.Windows.Forms.TextBox tBoxDeviceVer;
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
        private System.Windows.Forms.GroupBox gbLwM2MDevice;
        private System.Windows.Forms.Button btnATCMD;
        private System.Windows.Forms.ComboBox cBoxATCMD;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnBootstrap;
        private System.Windows.Forms.TextBox tBoxDataIN;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnDeregister;
        private System.Windows.Forms.Button btnDeviceVerLwM2M;
        private System.Windows.Forms.GroupBox gbOneM2MDevice;
        private System.Windows.Forms.Button btnModemFOTA;
        private System.Windows.Forms.Button btnDeviceFOTA;
        private System.Windows.Forms.Button btnGetDeviceCSR;
        private System.Windows.Forms.Button btnGetCSED;
        private System.Windows.Forms.Button btnSendDataOneM2M;
        private System.Windows.Forms.Button btnRcvDataOneM2M;
        private System.Windows.Forms.Button btnDelContainer;
        private System.Windows.Forms.Button btnSetContainer;
        private System.Windows.Forms.Button btnDelDeviceCSR;
        private System.Windows.Forms.Button btnCreateDeviceCSR;
        private System.Windows.Forms.Label lboneM2MRcvData;
        private System.Windows.Forms.Button btnDeviceUpdateCSR;
        private System.Windows.Forms.GroupBox gbLwM2MServer;
        private System.Windows.Forms.Label lbLwM2MRxData;
        private System.Windows.Forms.Button btnDeviceStatusCheck;
        private System.Windows.Forms.Button btnLwM2MData;
        private System.Windows.Forms.GroupBox gbOneM2MServer;
        private System.Windows.Forms.Label lboneM2MRxData;
        private System.Windows.Forms.Button btnDataRetrive;
        private System.Windows.Forms.Button btnSendtoDeviceoneM2M;
        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.TextBox tbSeverPort;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbSeverIP;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnDelRemoteCSE;
        private System.Windows.Forms.Button btnGetCSEBase;
        private System.Windows.Forms.Button btnSetRemoteCSE;
        private System.Windows.Forms.Button btnGetRemoteCSE;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnMEFAuthS;
        private System.Windows.Forms.Label lbEnrmtKey;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbToken;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lbEntityId;
        private System.Windows.Forms.TextBox tbSvcSvrCd;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbSvcSvrNum;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox gbServerLog;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnMEFAuthD;
        private System.Windows.Forms.Button btnSetSubscript;
        private System.Windows.Forms.Button btnoneM2MDeviceVer;
        private System.Windows.Forms.Button btnLwM2MDisable;
        private System.Windows.Forms.GroupBox gbTCResult;
        private System.Windows.Forms.TextBox tbTCResult;
        private System.Windows.Forms.Button btnDelRxContainer;
        private System.Windows.Forms.Button btnSetRxContainer;
        private System.Windows.Forms.Button btnDelSubscript;
        private System.Windows.Forms.Label lbSendedData;
        private System.Windows.Forms.Label lbSvroneM2MData;
        private System.Windows.Forms.Label lbSvrLwM2MData;
        private System.Windows.Forms.Label lbDevLwM2MData;
        private System.Windows.Forms.Label lbdevicepoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbmodemfwrver;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbdevicever;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnDeviceCheck;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbLwM2MRcvData;
    }
}

