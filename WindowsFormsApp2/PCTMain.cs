using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private enum states
        {
            booting,
            idle,
            getmodel,
            getmanufac,
            getimsi,
            geticcid,
            autogetmodel,
            autogetmodelgmm,
            autogetmanufac,
            autogetimsi,
            autogeticcid,
            bootstrap,
            setserverinfo,
            setserverinfotpb23,
            setmefserverinfo,
            sethttpserverinfo,
            setncdp,
            setservertype,
            setepns,
            setmbsps,
            setAutoBS,
            register,
            deregister,
            sendLWM2Mdata,
            receiveLWM2Mdata,
            downloadMDLFOTA,
            updateMDLFOTA,
            lwm2mreset,
            sendmsgstr,
            sendmsghex,
            sendmsgver,

            disable_bg96,
            enable_bg96,
            setcdp_bg96,

            sendonemsgstr,

            getonem2mmode,
            setonem2mmode,
            setmefauthnt,
            fotamefauthnt,
            getCSEbase,
            getremoteCSE,
            setremoteCSE,
            updateremoteCSE,
            setcontainer,
            setsubscript,
            getonem2mdata,

            setcereg,
            setceregtpb23,
            getcereg,
            reset,

            geticcidtpb23,
            autogeticcidtpb23,
            resettpb23,
            bootstrapmodetpb23,
            setepnstpb23,
            setmbspstpb23,
            bootstraptpb23,
            registertpb23,
            deregistertpb23,
            sendLWM2Mdatatpb23,
            receiveLWM2Mdatatpb23,
            downloadMDLFOTAtpb23,
            updateMDLFOTAtpb23,
            lwm2mresettpb23,
            sendmsgstrtpb23,
            sendmsghextpb23,
            sendmsgvertpb23,

            geticcidamtel,
            autogeticcidamtel,

            geticcidlg,
            autogeticcidlg,

            getmodemSvrVer,
            modemFWUPfinish,
            modemFWUPfinishLTE,
            modemFWUPstart,

            getdeviceSvrVer,
            setdeviceSvrVer,
            deviceFWUPfinish,
            deviceFWUPstart,

            catm1check,
            catm1set,
            catm1apn1,
            catm1apn2,
            catm1psmode,
            rfoff,
            rfon,
            rfreset,

            catm1imscheck,
            catm1imsset,
            catm1imsapn1,
            catm1imsapn2,
            catm1imsmode,
            catm1imspco,

            nbcheck,
            nbset,
            nbapn1,
            nbapn2,
            nbpsmode,

            getmodemver,
            autogetmodemver,
            getmodemvertpb23,
            autogetmodemvertpb23,
            getmodemvernt,
            autogetmodemvernt,
            getNWmode,
            autogetNWmode,
        }

        string sendWith;
        string dataIN;
        string RxDispOrder;
        string serverip = "\"106.103.233.155\"";
        string serverport = "5783";
        int network_chkcnt = 3;
        string nextcommand = "";    //OK를 받은 후 전송할 명령어가 존재하는 경우
                                    //예를들어 +CEREG와 같이 OK를 포함한 응답 값을 받은 경우 OK처리 후에 명령어를 전송해야 한다
                                    // states 값을 바꾸고 명령어를 전송하면 명령의 응답을 받기전 이전에 받았던 OK에 동작할 수 있다.

        string device_fota_state = "1";
        string device_fota_reseult = "0";
        string device_fota_index = "0";
        string device_total_index = "0";
        string device_fota_checksum = "";
        UInt32 oneM2Mtotalsize = 0;
        UInt32 oneM2Mrcvsize = 0;

        string oneM2MMEFIP = "106.103.230.209";
        string oneM2MMEFPort = "80";
        string oneM2MBRKIP = "106.103.230.207";
        string oneM2MBRKPort = "8080";
        int oneM2Mmode = 0;

        Dictionary<string, string> commands = new Dictionary<string, string>();
        Dictionary<char, int> bcdvalues = new Dictionary<char, int>();

        HttpWebRequest wReq;
        HttpWebResponse wRes;

        string brkUrl = "https://testbrk.onem2m.uplus.co.kr:443"; // BRK(oneM2M 개발기)       
        string brkUrlL = "https://testbrks.onem2m.uplus.co.kr:8443"; // BRK(LwM2M 개발기)       
        string mefUrl = "https://testmef.onem2m.uplus.co.kr:443"; // MEF(개발기)

        ServiceServer svr = new ServiceServer();
        Device dev = new Device();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            if(ports.Length == 0)
            {
                logPrintInTextBox("연결 가능한 COM PORT가 없습니다.", "");
            }
            else
            {
                cBoxCOMPORT.Items.AddRange(ports);
                cBoxCOMPORT.SelectedIndex = 0;
            }

            sendWith = "Both";
            RxDispOrder = "BOTTOM";

            groupBox1.Enabled = false;
            groupBox4.Enabled = false;

            bcdvalues.Add('0', 0);
            bcdvalues.Add('1', 1);
            bcdvalues.Add('2', 2);
            bcdvalues.Add('3', 3);
            bcdvalues.Add('4', 4);
            bcdvalues.Add('5', 5);
            bcdvalues.Add('6', 6);
            bcdvalues.Add('7', 7);
            bcdvalues.Add('8', 8);
            bcdvalues.Add('9', 9);
            bcdvalues.Add('A', 10);
            bcdvalues.Add('B', 11);
            bcdvalues.Add('C', 12);
            bcdvalues.Add('D', 13);
            bcdvalues.Add('E', 14);
            bcdvalues.Add('F', 15);
            bcdvalues.Add('a', 10);
            bcdvalues.Add('b', 11);
            bcdvalues.Add('c', 12);
            bcdvalues.Add('d', 13);
            bcdvalues.Add('e', 14);
            bcdvalues.Add('f', 15);

            commands.Add("getimsi", "AT+CIMI");
            commands.Add("geticcid", "AT+ICCID");
            commands.Add("geticcidtpb23", "AT+MUICCID");
            commands.Add("geticcidlg", "AT+MUICCID=?");
            commands.Add("geticcidamtel", "AT@ICCID?");
            commands.Add("getmodel", "AT+CGMM");
            commands.Add("getmanufac", "AT+CGMI");
            commands.Add("setcereg", "AT+CEREG=1");
            commands.Add("setceregtpb23", "AT+CEREG=3");
            commands.Add("getcereg", "AT+CEREG?");
            commands.Add("reset", "AT+CFUN=3,3");

            commands.Add("resettpb23", "AT+NRB");

            commands.Add("autogetimsi", "AT+CIMI");
            commands.Add("autogeticcid", "AT+ICCID");
            commands.Add("autogeticcidtpb23", "AT+MUICCID");
            commands.Add("autogeticcidamtel", "AT@ICCID?");
            commands.Add("autogeticcidlg", "AT+MUICCID=?");
            commands.Add("autogetmodel", "AT+CGMM");
            commands.Add("autogetmodelgmm", "AT+GMM");
            commands.Add("autogetmanufac", "AT+CGMI");

            commands.Add("bootstrap", "AT+QLWM2M=\"bootstrap\",1");
            commands.Add("setserverinfo", "AT+QLWM2M=\"cdp\",");
            commands.Add("setservertype", "AT+QLWM2M=\"select\",2");
            //commands.Add("setepns", "AT+QLWM2M=\"epns\",1,\"");
            commands.Add("setepns", "AT+QLWM2M=\"epns\",0,\"");
            commands.Add("setmbsps", "AT+QLWM2M=\"mbsps\",\"");
            commands.Add("setAutoBS", "AT+QLWM2M=\"enable\",");
            commands.Add("register", "AT+QLWM2M=\"register\"");
            commands.Add("deregister", "AT+QLWM2M=\"deregister\"");
            commands.Add("lwm2mreset", "AT+QLWM2M=\"reset\"");
            commands.Add("sendmsgstr", "AT+QLWM2M=\"uldata\",10250,");
            commands.Add("sendmsghex", "AT+QLWM2M=\"ulhex\",10250,");
            commands.Add("sendmsgver", "AT+QLWM2M=\"uldata\",26241,");

            commands.Add("disable_bg96", "AT+QLWM2M=\"enable\",0");
            commands.Add("enable_bg96", "AT+QLWM2M=\"enable\",1");
            commands.Add("setcdp_bg96", "AT+QLWM2M=\"cdp\",");

            commands.Add("sendonemsgstr", "AT$OM_C_INS_REQ=");

            commands.Add("getonem2mmode", "AT$LGTMPF?");
            commands.Add("setonem2mmode", "AT$LGTMPF=5");
            commands.Add("setmefauthnt", "AT$OM_AUTH_REQ=");
            commands.Add("fotamefauthnt", "AT$OM_AUTH_REQ=");
            commands.Add("getCSEbase", "AT$OM_B_CSE_REQ");
            commands.Add("getremoteCSE", "AT$OM_R_CSE_REQ");
            commands.Add("setremoteCSE", "AT$OM_C_CSE_REQ");
            commands.Add("updateremoteCSE", "AT$OM_U_CSE_REQ");
            commands.Add("setcontainer", "AT$OM_C_CON_REQ=");
            commands.Add("setsubscript", "AT$OM_C_SUB_REQ=");
            commands.Add("getonem2mdata", "AT$OM_R_INS_REQ=");

            commands.Add("setserverinfotpb23", "AT+NCDP=");
            commands.Add("setncdp", "AT+NCDP=");
            commands.Add("bootstrapmodetpb23", "AT+MBOOTSTRAPMODE=1");
            commands.Add("setepnstpb23", "AT+MLWEPNS=ASN_CSE-D-");
            commands.Add("setmbspstpb23", "AT+MLWMBSPS=serviceCode=");
            commands.Add("bootstraptpb23", "AT+MLWGOBOOTSTRAP=1");
            commands.Add("registertpb23", "AT+MLWSREGIND=0");
            commands.Add("deregistertpb23", "AT+MLWSREGIND=1");
            commands.Add("lwm2mresettpb23", "AT+FATORYRESET=0");
            commands.Add("sendmsgstrtpb23", "AT+MLWULDATA=");
            commands.Add("sendmsgvertpb23", "AT+MLWULDATA=1,");

            commands.Add("setmefserverinfo", "AT$OM_SVR_INFO=1,");
            commands.Add("sethttpserverinfo", "AT$OM_SVR_INFO=2,");

            commands.Add("getmodemSvrVer", "AT$OM_MODEM_FWUP_REQ");
            commands.Add("setmodemver", "AT$OM_C_MODEM_FWUP_REQ");
            commands.Add("modemFWUPfinish", "AT$OM_MODEM_FWUP_FINISH");
            commands.Add("modemFWUPfinishLTE", "AT$OM_MOD_FWUP_FINISH");
            commands.Add("modemFWUPstart", "AT$OM_MODEM_FWUP_START");

            commands.Add("getdeviceSvrVer", "AT$OM_DEV_FWUP_REQ");
            commands.Add("setdeviceSrvver", "AT$OM_C_DEV_FWUP_REQ");
            commands.Add("deviceFWUPfinish", "AT$OM_DEV_FWUP_FINISH");
            commands.Add("deviceFWUPstart", "AT$OM_DEV_FWUP_START");

            commands.Add("catm1check", "AT+QCFG=\"iotopmode\"");
            commands.Add("catm1set", "AT+QCFG=\"iotopmode\",0");
            commands.Add("catm1apn1", "AT+CGDCONT=1,\"IPV4V6\",\"m2m-catm1.default.lguplus.co.kr\"");
            commands.Add("catm1apn2", "AT+CGDCONT=2");
            commands.Add("catm1psmode", "AT+QCFG=\"servicedomain\",1");
            commands.Add("rfoff", "AT+CFUN=0");
            commands.Add("rfon", "AT+CFUN=1");
            commands.Add("rfreset", "AT+CFUN=1,1");

            commands.Add("catm1imsset", "AT+QCFG=\"iotopmode\",0");
            commands.Add("catm1imsapn1", "AT+CGDCONT=1,\"IPV4V6\",\"m2m-catm1.default.lguplus.co.kr\"");
            commands.Add("catm1imsapn2", "AT+CGDCONT=2,\"IPV4V6\",\"imsv6-m2m.lguplus.co.kr\"");
            commands.Add("catm1imsmode", "AT+QCFG=\"servicedomain\",2");
            commands.Add("catm1imspco", "AT$QCPDPIMSCFGE=2,1,0,1");

            commands.Add("getNWmode", "AT+QCFG=\"iotopmode\"");
            commands.Add("autogetNWmode", "AT+QCFG=\"iotopmode\"");

            commands.Add("nbset", "AT+QCFG=\"iotopmode\",1");
            commands.Add("nbapn1", "AT+CGDCONT=1,\"IPV4V6\",\"\",\"0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0\",0,0,0,0");
            commands.Add("nbapn2", "AT+CGDCONT=2");
            commands.Add("nbpsmode", "AT+QCFG=\"servicedomain\",1");

            commands.Add("getmodemver", "AT+GMR");
            commands.Add("autogetmodemver", "AT+GMR");
            commands.Add("getmodemvertpb23", "AT+CGMR");
            commands.Add("autogetmodemvertpb23", "AT+CGMR");
            commands.Add("getmodemvernt", "AT*ST*INFO?");
            commands.Add("autogetmodemvernt", "AT*ST*INFO?");

            /////   서버 초기값 설정
            svr.enrmtKeyId = string.Empty;
        }

        // COMM PORT 연결
        private void ProgressBar1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                this.doCloseComPort();
            }
            else
            {
                this.doOpenComPort();
            }
        }

        // 모듈 정보 읽기
        private void btnModuleInfo_Click(object sender, EventArgs e)
        {
            getDeviveInfo();
        }

        // AT command 보내기
        private void btnATCMD_Click(object sender, EventArgs e)
        {
            if (cBoxATCMD.Text.Length != 0)
            {
                DataOutandstore(cBoxATCMD.Text);
            }
        }

        // oneM2M 플랫폼서버로 단말 인증 요청
        private void btnMEFAuth_Click(object sender, EventArgs e)
        {
            Provision();
        }

        private void btnGetDeviceCSR_Click(object sender, EventArgs e)
        {

        }

        private void TSMenuModemVer_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getmodemSvrVer"]);
            lbActionState.Text = states.getmodemSvrVer.ToString();

            timer1.Start();
        }

        private void TSMenuDeviceVer_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getdeviceSvrVer"]);
            lbActionState.Text = states.getdeviceSvrVer.ToString();

            timer1.Start();
        }

        private void tSMenuTxVersion_Click(object sender, EventArgs e)
        {
            DeviceFWVerSendOne(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
        }

        private void btnCreateDeviceCSR_Click(object sender, EventArgs e)
        {

        }

        private void btnDelDeviceCSR_Click(object sender, EventArgs e)
        {

        }

        private void btnSetContainer_Click(object sender, EventArgs e)
        {

        }

        private void btnDelContainer_Click(object sender, EventArgs e)
        {

        }

        private void btnSendDataOneM2M_Click(object sender, EventArgs e)
        {

        }

        private void btnRcvDataOneM2M_Click(object sender, EventArgs e)
        {

        }

        private void btnDeviceVerOneM2M_Click(object sender, EventArgs e)
        {

        }

        // MEF Auth
        private void btnMEFAuthS_Click(object sender, EventArgs e)
        {
            svr.svcSvrCd = tbSvcSvrCd.Text; // 서비스 서버의 시퀀스
            //LogWrite("svr.svcSvrCd = " + svr.svcSvrCd);
            svr.svcCd = tbSvcCd.Text; // 서비스 서버의 서비스코드
            //LogWrite("svr.svcCd = " + svr.svcCd);
            svr.svcSvrNum = tbSvcSvrNum.Text; // 서비스 서버의 Number
            //LogWrite("svr.svcSvrNum = " + svr.svcSvrNum);

            if (svr.svcCd != string.Empty && svr.svcSvrCd != string.Empty && svr.svcSvrNum != string.Empty)
                RequestMEF();
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        // CSE Base Get
        private void btnGetCSEBase_Click(object sender, EventArgs e)
        {
            LogWrite("----------CSEBase GET----------");
            if (svr.enrmtKeyId != string.Empty)
                ReqCSEBaseGET();
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        // RemoteCSE-GET
        private void btnGetRemoteCSE_Click(object sender, EventArgs e)
        {
            LogWrite("----------remoteCSE GET----------");
            if (svr.enrmtKeyId != string.Empty)
                ReqRemoteCSEGet();
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        // RemoteCSE-Create
        private void btnSetRemoteCSE_Click(object sender, EventArgs e)
        {
            LogWrite("----------remoteCSE SET----------");
            if (svr.enrmtKeyId != string.Empty)
                ReqRemoteCSECreate();
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        // RemoteCSE-Update
        private void btnUpdateRemoteCSE_Click(object sender, EventArgs e)
        {
            // 서비스서버에 대해서는 미지원함
            LogWrite("----------remoteCSE UPDATE----------");
            if (svr.enrmtKeyId != string.Empty)
                ReqRemoteCSEUpdate();
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        // RemoteCSE-Delete
        private void btnDelRemoteCSE_Click(object sender, EventArgs e)
        {
            LogWrite("----------remoteCSE DEL----------");
            if (svr.enrmtKeyId != string.Empty)
                ReqRemoteCSEDEL();
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        // 데이터 수신 (oneM2M 플랫폼 DB)
        private void btnDataRetrive_Click(object sender, EventArgs e)
        {
            LogWrite("----------DATA RECIEVE----------");
            if (svr.enrmtKeyId != string.Empty)
                RetriveDataToPlatform();
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        // 데이터 송신

        private void btnSendtoDeviceoneM2M_Click(object sender, EventArgs e)
        {
            LogWrite("----------DATA SEND----------");
            if (svr.enrmtKeyId != string.Empty)
            {
                string target_comm = "oneM2M";
                SendDataToPlatform(target_comm);
            }
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        // 데이터 송신
        private void btnLwM2MData_Click(object sender, EventArgs e)
        {
            LogWrite("----------DATA SEND----------");
            if (svr.enrmtKeyId != string.Empty)
            {
                string target_comm = "LwM2M";
                SendDataToPlatform(target_comm);
            }
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        // LwM2M Device Status Check
        private void btnDeviceStatusCheck_Click(object sender, EventArgs e)
        {
            LogWrite("----------DEVICE STATUS CHECK----------");
            if (svr.enrmtKeyId != string.Empty)
            {
                DeviceCheckToPlatform();
            }
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        // LwM2M 플랫폼서버로 BOOTSTRAP 요청
        private void btnBootstrap_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                // LWM2M bootstrap 자동 요청 순서
                // (servertype) - endpointpame - mbsps - bootstrap
                // 플랫폼 서버 타입 설정
                //AT+QLWM2M="select",2
                this.sendDataOut(commands["setservertype"]);
                lbActionState.Text = states.setservertype.ToString();

                timer1.Start();
            }
        }

        // LwM2M 플랫폼서버로 REGISTER 요청
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                if (oneM2Mmode == 0)   //oneM2M : remoteCSE 요청
                {
                    // 플랫폼 서버 remoteCSE, container 등록 요청
                    // getCSEbase - getremoteCSE - setremoteCSE - setcontainer - setsubscript,

                    //this.sendDataOut(commands["getCSEbase"]);
                    //lbActionState.Text = states.getCSEbase.ToString();
                    this.sendDataOut(commands["getremoteCSE"]);
                    lbActionState.Text = states.getremoteCSE.ToString();
                }
                else if (lbModel.Text == "BG96")
                {
                    // 플랫폼 등록 요청
                    //AT+QLWM2M="register"
                    this.sendDataOut(commands["register"]);
                    lbActionState.Text = states.register.ToString();
                }
                else
                {
                    // 플랫폼 등록 요청
                    //AT+MLWSREGIND=0
                    this.sendDataOut(commands["registertpb23"]);
                    lbActionState.Text = states.registertpb23.ToString();
                }
            }
        }

        // LwM2M 플랫폼서버로 DATA 보내기
        private void btnSendData_Click_1(object sender, EventArgs e)
        {
            //입력 Text값을 플랫폼 서버로 전송
            sendDataToServer(tBoxDataOut.Text);
        }

        // LwM2M 플랫폼서버로 DEREGISTER 요청
        private void btnDeregister_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {

                if (lbModel.Text == "BG96")
                {
                    // 플랫폼 등록해제 요청
                    //AT+QLWM2M="deregister"
                    this.sendDataOut(commands["deregister"]);
                    lbActionState.Text = states.deregister.ToString();
                }
                else
                {
                    // 플랫폼 등록 요청
                    //AT+MLWSREGIND=1
                    this.sendDataOut(commands["deregistertpb23"]);
                    lbActionState.Text = states.deregistertpb23.ToString();
                }
            }
        }

        // LwM2M 플랫폼서버로 DEVICE VERSION REPORT
        private void btnDeviceVerLwM2M_Click(object sender, EventArgs e)
        {
            if (oneM2Mmode == 0)      // oneM2M : MEF Auth인증 요청
                DeviceFWVerSendOne(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
            else
                DeviceFWVerSend(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
        }

        // serial port에서 data 수신이 될 때, 발생하는 이벤트 함수
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN += serialPort1.ReadExisting();    // 수신한 버퍼에 있는 데이터 모두 받음
            this.Invoke(new EventHandler(ShowData));
        }

        /// <summary>
        /// 이하 처리 함수 들
        /// </summary>

        // SERIAL COM PORT 제어 함수
        private void doOpenComPort()
        {
            try
            {
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = (int)115200;
                serialPort1.DataBits = (int)8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.ReadTimeout = (int)500;
                serialPort1.WriteTimeout = (int)500;
                serialPort1.DtrEnable = false;
                serialPort1.RtsEnable = false;

                serialPort1.Open();
                progressBar1.Value = 100;
                groupBox1.Enabled = true;
                groupBox4.Enabled = true;
                logPrintInTextBox("COM PORT가 연결 되었습니다.", "");

                this.sendDataOut(commands["getcereg"]);
                lbActionState.Text = states.getcereg.ToString();

                timer1.Start();
            }
            catch (Exception err)
            {
                //groupBox1.Enabled = false;
                //groupBox4.Enabled = false;
                logPrintInTextBox(err.Message, "");

            }
        }

        private void doCloseComPort()
        {
            serialPort1.Close();
            progressBar1.Value = 0;
            groupBox1.Enabled = false;
            groupBox4.Enabled = false;
            logPrintInTextBox("COM PORT가 해제 되었습니다.","");

        }


        private void DataOutandstore(string text)
        {
            this.sendDataOut(text);

            // 타이핑한 명령어가 이미 등록되지 않았으면, 목록에 저장하고 가나다 순으로 sorting 함.
            if (!cBoxATCMD.Items.Contains(text))
            {
                cBoxATCMD.Items.Add(text);      // 명령어를 재사용하는 경우를 대비하여 명령 목록에 추가
            }
        }

        private void CBoxATCMD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataOutandstore(cBoxATCMD.Text);    //textbox에 명령어 입력 중 Enter를 누른 경우 명령어 호출  
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void sendDataOut(string dataOUT)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string sendmsg = dataOUT;
                    if (sendWith == "Both")     // LF + CR
                    {
                        sendmsg = dataOUT + "\r\n";
                    }
                    else if (sendWith == "LF")
                    {
                        sendmsg = dataOUT + "\r";
                    }
                    else if (sendWith == "CR")
                    {
                        sendmsg = dataOUT + "\n";
                    }

                    serialPort1.Write(sendmsg);
                    logPrintInTextBox(sendmsg, "tx");

                    //textbox에서 명령어를 직접 입력한 경우에도 응답 값을 받았을떄 정보를 저장하고 화면에 표시할 수 있게하기 위함.
                    if (lbActionState.Text == "idle")
                    {
                        string command = dataOUT.ToUpper();
                        if (command == "AT+CIMI")
                        {
                            lbActionState.Text = states.getimsi.ToString();
                        }
                        else if (command == "AT+ICCID")
                        {
                            lbActionState.Text = states.geticcid.ToString();
                        }
                        else if (command == "AT@ICCID?")
                        {
                            lbActionState.Text = states.geticcidamtel.ToString();
                        }
                        else if (command == "AT+MUICCID")
                        {
                            lbActionState.Text = states.geticcid.ToString();
                        }
                        else if (command == "AT+MUICCID=?")
                        {
                            lbActionState.Text = states.geticcid.ToString();
                        }
                        else if (command == "AT+CGMM" || command == "AT+GMM")
                        {
                            lbActionState.Text = states.getmodel.ToString();
                        }
                        else if (command == "AT+CGMI")
                        {
                            lbActionState.Text = states.getmanufac.ToString();
                        }
                        timer1.Start();
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 송수신 명령/응답 값과 동작 설명을 textbox에 삽입하고 앱 종료시 로그파일로 저장한다.
        public void logPrintInTextBox(string message, string kind)
        {
            string displayMsg = makeLogPrintLine(message,kind);

            if (RxDispOrder == "TOP")
            {
                tBoxDataIN.Text = tBoxDataIN.Text.Insert(0, displayMsg);
            }
            else
            {
                tBoxDataIN.Text += displayMsg;
            }

        }

        // 명령어에 대해 동작시각과 방향을 포함하여 저장한다.
        private string makeLogPrintLine(string msg, string kind)
        {
            string msg_form;
            DateTime currenttime = DateTime.Now;
            msg_form = currenttime.ToString("hh:mm:ss.fff") + " : ";
            if(kind == "tx")
            {
                msg_form += "==> : ";
            }
            else if (kind == "rx")
            {
                msg_form += "<== : ";
            }
            else
            {
                msg_form += "     : ";
            }
            msg_form = msg_form  + msg + "\r\n";
            return msg_form;
        }

        // 수신 데이터 처리 thread 시작
        private void ShowData(object sender, EventArgs e)
        {
            char[] charValues = dataIN.ToCharArray();

            /* Debug를 위해 Hex로 문자열 표시*/
            
            string hexOutput = "";
            foreach (char _eachChar in charValues)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(_eachChar);
                // Convert the decimal value to a hexadecimal value in string form.
                if (value < 16)
                    hexOutput += "0";
                hexOutput += String.Format("{0:X}", value);
            }
            logPrintInTextBox(hexOutput, "");
            

            if (charValues.Length >= 2)
            {
                if (charValues[charValues.Length - 1] == '\n' || charValues[charValues.Length - 2] == '\n' || charValues[charValues.Length - 2] == '>')
                {
                    rxDataProcess(dataIN);
                    if (charValues[charValues.Length - 1] != '\n')
                    {
                        dataIN = charValues[charValues.Length - 1].ToString();    // \r\n를 제외하고 나머지 한글자 저장
                    }
                    else
                    {
                        dataIN = "";
                    }
                }
            }
        }

        private void rxDataProcess(string rxdataIN)
        {
            string[] words = rxdataIN.Split('\n');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

            foreach (var word in words)
            {
                string str1;

                int lflength = word.IndexOf("\r");
                if (lflength > 1)
                {
                    str1 = word.Substring(0, lflength);    // \r\n를 제외하고 명령어만 처리하기 위함
                }
                else
                {
                    str1 = word;
                }

                if (str1 != "")             // 빈 줄은 제외하기 위함
                {
                    this.parseRXData(str1);
                }
            }
        }

        // 수신한 데이터 한 줄에 대해 후처리가 필요한 응답 값을 찾아서 설정함 
        private void parseRXData(string rxMsg)
        {
            string[] sentences =
            {
                "OK",           // 모든 응답이 완료한 경우, 다음 동작이 필요한지 확인 (nextcommand)
                "ERROR",        // 오류 응답을 받은 경우, 동작을 중지한다.
                "+ICCID:",      // ICCID 값을 저장한다.
                "ICCID:",      // ICCID 값을 저장한다.
                "+MUICCID:",    // ICCID (NB) 값을 저장한다.
                "@ICCID:",    // ICCID (AMTEL) 값을 저장한다.
                "+CGSN:",       // IMEI (NB TPB23모델) 값을 저장한다.
                "AT+MLWDLDATA=",    // LWM2M서버에서 data 수신이벤트
                "AT+MLWEVTIND=",    // LWM2M서버와 연동 상태 이벤트
                "AT+CGMI",
                "AT",           // AT는 Device가 modem으로 요청하는 명령어로 무시하기 위함
                "+CEREG:",      // LTE network 상태를 확인하고 연결이 되어 있지 않으면 재접속 시도
                "+QLWEVENT:",    // 모듈 부팅시, LWM2M 등록 상태 이벤트, 진행 상태를 status bar에 진행율 표시
                "+QLWDLDATA:",
                "+QLWOBSERVE:",

                "$OM_B_CSE_RSP=",
                "$OM_R_CSE_RSP=",
                "$OM_C_CSE_RSP=",
                "$OM_C_CON_RSP=",
                "$OM_C_SUB_RSP=",
                "$OM_NOTI_IND=",
                "$OM_R_INS_RSP=",
                "$OM_C_MODEM_FWUP_RSP=",
                "$OM_MODEM_FWUP_RSP=",
                "$OM_PUSH_MODEM_FWUP_RSP=",
                "$OM_MODEM_UPDATE_FINISH",
                "$OM_DEV_FWUP_RSP=",
                "$OM_PUSH_DEV_FWUP_RSP=",
                "$OM_DEV_FWDL_FINISH",
                "$LGTMPF=",

                "*ST*INFO:",
                "@NOTI:",
                "@NETSTI:",
                "$OM_AUTH_RSP=",
                "$OM_U_CSE_RSP=",

                "$OM_DEV_FWDL_START=",
                "$BIN_DATA=",

                "+QCFG: ",
                "FW_VER: ",
            };

            /* Debug를 위해 Hex로 문자열 표시*/
            /*
            char[] charValues = rxMsg.ToCharArray();
            string hexOutput = "";
            foreach (char _eachChar in charValues)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(_eachChar);
                // Convert the decimal value to a hexadecimal value in string form.
                hexOutput += String.Format("{0:X}", value);
            }
            logPrintInTextBox(hexOutput,"");
            */

            logPrintInTextBox(rxMsg,"rx");          // 수신한 데이터 한줄을 표시
            bool find_msg = false;

            // 후처리가 필요한 명령어 목록에서 하나씩 순서대로 읽어서 비교한다.
            foreach (string s in sentences)
            {
                //logPrintInTextBox(s,"");

                // 수신한 데이터에 대해 후처리가 필요한 명령어가 포함되어 있는지 체크한다.
                //if (System.Text.RegularExpressions.Regex.IsMatch(rxMsg, s, System.Text.RegularExpressions.RegexOptions.IgnoreCase))

                // 수신한 데이터에 대해 후처리가 필요한 명령어로 시작하는지 체크한다.
                if (rxMsg.StartsWith(s, System.StringComparison.CurrentCultureIgnoreCase))
                {
                   //logPrintInTextBox(s + " : There is matching data.","");

                    // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                    int first = rxMsg.IndexOf(s) + s.Length;
                    string str2 = "";
                    str2 = rxMsg.Substring(first, rxMsg.Length - first);
                    //logPrintInTextBox("남은 문자열 : " + str2,"");

                    this.parseReceiveData(s, str2);

                    find_msg = true;
                    break;
                }
            }

            // 후처리가 필요한 명령어인데 고정 값이 없고 data만 있는 경우
            //예를들어 IMSI, IMEI 요청에 대한 응답 값 등
            if ((find_msg == false)&&(rxMsg!="\r") && (rxMsg != "\n"))
            {
                //logPrintInTextBox("No Matching Data!!!","");

                this.parseNoPrefixData(rxMsg);
            }

        }

        // 수신한 응답 값과 특정 값과 일치하는 경우
        // 응답을 받고 후 작업이 필요한지 확인한다. 
        void parseReceiveData(string s, string str2)
        {
            switch (s)
            {
                case "OK":
                    OKReceived();
                    break;
                case "ERROR":
                    lbActionState.Text = states.idle.ToString();
                    nextcommand = "";
                    timer1.Stop();

                    if (lbModel.Text == ".")
                    {
                        isDeviceInfo();     // 모류 발생시 모듈 정보 확인(모델 정보 오류로 인해 전문 오류 발생할 수 있음)
                    }
                    timer2.Stop();
                    break;
                case "+ICCID:":
                    // AT+ICCID의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    if (str2.Length > 19)
                        lbIccid.Text = str2.Substring(str2.Length - 20, 19);
                    else
                        lbIccid.Text = str2;
                    logPrintInTextBox("ICCID값이 저장되었습니다.", "");

                    if (lbActionState.Text == states.autogeticcid.ToString())
                    {
                        if (lbModel.Text == "BG96" || lbMaker.Text == "LIME-I Co., Ltd")
                        {
                            nextcommand = states.autogetmodemver.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                        }
                        else if (lbModel.Text == "TPB23")
                        {
                            nextcommand = states.autogetmodemvertpb23.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                        }
                        else
                        {
                            nextcommand = states.getcereg.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                        }
                    }
                    break;
                case "ICCID:":
                    // AT+ICCID의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    if (str2.Length > 19)
                        lbIccid.Text = str2.Substring(str2.Length - 20, 19);
                    else
                        lbIccid.Text = str2;
                    logPrintInTextBox("ICCID값이 저장되었습니다.", "");

                    if (lbActionState.Text == states.autogeticcid.ToString())
                    {
                        if (lbMaker.Text == "QUALCOMM INCORPORATED" || lbMaker.Text == "LIME-I Co., Ltd")
                        {
                            nextcommand = states.autogetmodemver.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                        }
                        else
                        {
                            nextcommand = states.autogetmodemvernt.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                        }
                    }
                    break;
                case "+MUICCID:":
                    // AT+MUICCID (NB TPB23모델)의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    if (str2.Length > 19)
                        lbIccid.Text = str2.Substring(str2.Length - 20, 19);
                    else
                        lbIccid.Text = str2;
                    logPrintInTextBox("ICCID값이 저장되었습니다.", "");

                    if (lbActionState.Text == states.autogeticcidtpb23.ToString())
                    {
                        nextcommand = states.autogetmodemvertpb23.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                    }
                    else if (lbActionState.Text == states.autogeticcidlg.ToString())
                    {
                        this.sendDataOut(commands["autogetmodemver"]);
                        lbActionState.Text = states.autogetmodemver.ToString();

                        timer1.Start();
                    }
                    break;
                case "@ICCID:":
                    // AT@ICCID?의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    if (str2.Length > 19)
                        lbIccid.Text = str2.Substring(str2.Length - 20, 19);
                    else
                        lbIccid.Text = str2;
                    logPrintInTextBox("ICCID값이 저장되었습니다.", "");

                    if (lbActionState.Text == states.autogeticcidamtel.ToString())
                    {
                        nextcommand = states.autogetmodemver.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                    }
                    break;
                case "+CEREG:":
                    // AT+CEREG의 응답으로 LTE attach 상태 확인하고 disable되어 있어면 attach 요청, 
                    // attach가 완료되지 않았으면 1초 후에 재확인, (timer2 사용)
                    // OK 응답이 따라온다
                    timer2.Stop();

                    // 수신한 데이터에 대해 space로 시작하는지 확인한다.
                    if (str2.StartsWith(" "))
                    {
                        str2 = str2.Substring(1, str2.Length - 1);
                    }

                    string ltestatus = str2.Substring(0, 1);
                    if (ltestatus == "0")
                    {
                        network_chkcnt = 3;             // LTE attach disable일 경우 enable하고 getcereg 3회 확인
                        if (lbModel.Text == "TPB23")
                        {
                            nextcommand = states.setceregtpb23.ToString();
                        }
                        else
                        {
                            nextcommand = states.setcereg.ToString();
                        }
                        logPrintInTextBox("LTE 연결을 요청이 필요합니다.", "");
                    }
                    else if ((ltestatus == "1") || (ltestatus == "3"))
                    {
                        if (str2.Length > 1)
                        {
                            string lteregi = str2.Substring(2, 1);

                            if (lteregi == "0")
                            {
                                /*
                                network_chkcnt = 3;             // LTE attach disable일 경우 enable하고 getcereg 3회 확인
                                if (lbModel.Text == "TPB23")
                                {
                                    nextcommand = states.setceregtpb23.ToString();
                                }
                                else
                                {
                                    nextcommand = states.setcereg.ToString();
                                }
                                */
                                logPrintInTextBox("LTE 상태 확인이 필요합니다.", "");
                            }
                            else if ((lteregi == "1") || (lteregi == "5"))
                            {
                                timer2.Stop();
                                logPrintInTextBox("LTE망에 연결 되었습니다.", "");
                            }
                            else
                            {
                                // LTE attach 시도 중
                                timer2.Start();     // 1초 후에 AT+CEREG 호출
                            }
                        }
                        else
                        {
                            if ((str2 == "1") || (str2 == "5"))
                            {
                                timer2.Stop();
                                logPrintInTextBox("LTE망에 연결 되었습니다.", "");
                            }
                            else
                            {
                                // LTE attach 시도 중

                                timer2.Start();     // 1초 후에 AT+CEREG 호출
                            }
                        }
                    }
                    else
                    {
                        timer2.Stop();
                    }

                    lbActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    break;
                case "$OM_AUTH_RSP=":
                    // oneM2M 인증 결과
                    if (str2 == "2000")
                    {
                        logPrintInTextBox("oneM2M서버 인증 성공하였습니다.", "");

                        if (lbModel.Text == "알 수 없음")
                        {
                            getDeviveInfo();
                        }
                        else if (lbActionState.Text == "fotamefauthnt")
                        {
                            this.sendDataOut(commands["deviceFWUPfinish"]);
                            lbActionState.Text = states.deviceFWUPfinish.ToString();
                        }
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 인증 정보 확인이 필요합니다.", "");
                    }

                    timer1.Stop();
                    timer2.Stop();
                    nextcommand = "";
                    break;
                case "$OM_B_CSE_RSP=":
                    // oneM2M CSEBase 조회 결과
                    if (str2 == "2000")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // (getCSEbase) - (getremoteCSE) - setremoteCSE - setcontainer - setsubscript,

                        this.sendDataOut(commands["getremoteCSE"]);
                        lbActionState.Text = states.getremoteCSE.ToString();
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 인증 정보 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_R_CSE_RSP=":
                    // oneM2M remoteCSE 조회 결과, 4004이면 생성/2000 또는 2004이면 container 확인
                    if (str2 == "2004" || str2 == "2000")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - (getremoteCSE) - setremoteCSE - (setcontainer) - setsubscript,

                        //this.sendDataOut(commands["setcontainer"]+tBoxDeviceSN.Text);
                        //lbActionState.Text = states.setcontainer.ToString();

                        // getCSEbase - (getremoteCSE) - (updateremoteCSE) - setcontainer - setsubscript,

                        this.sendDataOut(commands["updateremoteCSE"]);
                        lbActionState.Text = states.updateremoteCSE.ToString();
                    }
                    else
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - (getremoteCSE) - (setremoteCSE) - setcontainer - setsubscript,

                        this.sendDataOut(commands["setremoteCSE"]);
                        lbActionState.Text = states.setremoteCSE.ToString();
                    }
                    break;
                case "$OM_C_CSE_RSP=":
                    // oneM2M remoteCSE 생성 결과, 2001이면 container 생성 요청
                    if (str2 == "2001" || str2 == "2000" || str2 == "4105")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - getremoteCSE - (setremoteCSE) - (setcontainer) - setsubscript,

                        this.sendDataOut(commands["setcontainer"] + tBoxDeviceSN.Text);
                        lbActionState.Text = states.setcontainer.ToString();
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_U_CSE_RSP=":
                    // oneM2M remoteCSE 업데이트 결과, 2004이면 container 생성 요청
                    if (str2 == "2004" || str2 == "2000")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - getremoteCSE - (updateremoteCSE) - (setcontainer) - setsubscript,

                        this.sendDataOut(commands["setcontainer"] + tBoxDeviceSN.Text);
                        lbActionState.Text = states.setcontainer.ToString();
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_C_CON_RSP=":
                    // oneM2M container 생성 결과, 2001이면 subscript 신청
                    if (str2 == "2001" || str2 == "2000" || str2 == "4105")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - getremoteCSE - setremoteCSE - (setcontainer) - (setsubscript),

                        this.sendDataOut(commands["setsubscript"] + tBoxDeviceSN.Text);
                        lbActionState.Text = states.setsubscript.ToString();
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_C_SUB_RSP=":
                    // oneM2M subscription 신청 결과
                    if (str2 == "2001" || str2 == "2000" || str2 == "4105")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - getremoteCSE - setremoteCSE - setcontainer - (setsubscript),

                        logPrintInTextBox("oneM2M서버 정상 등록을 완료하였습니다.", "");
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_NOTI_IND=":
                    // oneM2M subscription 설정에 의한 data 변경 이벤트
                    // 플랫폼 서버에 data 수신 요청
                    this.sendDataOut(commands["getonem2mdata"] + str2);
                    lbActionState.Text = states.getonem2mdata.ToString();
                    break;
                case "$OM_R_INS_RSP=":
                    // 플랫폼 서버에 data 수신

                    string[] rxwords = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rxwords[0] == "2000")
                    {
                        // 수신한 데이터 사이즈 확이
                        int rxsize = Convert.ToInt32(rxwords[1]);
                        if (rxsize == rxwords[2].Length)
                        {
                            logPrintInTextBox(rxwords[2] + "를 수신하였습니다.", "");
                        }
                        else
                        {
                            logPrintInTextBox("수신한 데이터 사이즈를 확인하세요", "");
                        }
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "*ST*INFO:":
                    string[] modeminfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    lbModemVer.Text = modeminfos[1];
                    logPrintInTextBox("MODEM의 버전을 저장하였습니다.", "");
                    break;
                case "$OM_DEV_FWDL_START=":
                    oneM2Mtotalsize = Convert.ToUInt32(str2);
                    logPrintInTextBox("FOTA 이미지 크기는 " + str2 + "입니다.", "");
                    break;
                case "$BIN_DATA=":
                    if (lbMaker.Text == "AM Telecom")        //AMTEL 모듈은 OK가 오지 않음
                    {
                        string[] oneM2Minfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                        oneM2Mrcvsize += Convert.ToUInt32(oneM2Minfos[0]);
                    }
                    else
                    {
                        oneM2Mrcvsize += (UInt32)str2.Length / 2;
                    }
                    logPrintInTextBox("index= " + oneM2Mrcvsize + "/" + oneM2Mtotalsize + "를 수신하였습니다.", "");
                    break;
                case "$OM_C_MODEM_FWUP_RSP=":
                    break;
                case "$OM_MODEM_FWUP_RSP=":
                case "$OM_PUSH_MODEM_FWUP_RSP=":
                    string[] modemverinfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (modemverinfos[0] == "2000")
                    {
                        logPrintInTextBox("수신한 MODEM의 버전은 " + modemverinfos[1] + "입니다. 업데이트를 시도합니다.", "");

                        this.sendDataOut(commands["modemFWUPstart"]);
                        lbActionState.Text = states.modemFWUPstart.ToString();
                    }
                    else if (modemverinfos[0] == "9001")
                    {
                        logPrintInTextBox("현재 MODEM 버전이 최신버전입니다.", "");
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_MODEM_UPDATE_FINISH":
                    if (lbModel.Text == "NTLM3410Y")
                    {
                        this.sendDataOut(commands["modemFWUPfinishLTE"]);
                        lbActionState.Text = states.modemFWUPfinishLTE.ToString();
                    }
                    else
                    {
                        this.sendDataOut(commands["modemFWUPfinish"]);
                        lbActionState.Text = states.modemFWUPfinish.ToString();
                    }
                    break;
                case "$OM_DEV_FWUP_RSP=":
                case "$OM_PUSH_DEV_FWUP_RSP=":
                    string[] deviceverinfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (deviceverinfos[0] == "2000")
                    {
                        logPrintInTextBox("수신한 DEVICE의 버전은 " + deviceverinfos[1] + "입니다. 업데이트를 시도합니다.", "");

                        this.sendDataOut(commands["deviceFWUPstart"]);
                        lbActionState.Text = states.deviceFWUPstart.ToString();

                        oneM2Mrcvsize = 0;
                        oneM2Mtotalsize = 0;
                    }
                    else if (deviceverinfos[0] == "9001")
                    {
                        logPrintInTextBox("현재 DEVICE 버전이 최신버전입니다.", "");
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_DEV_FWDL_FINISH":
                    this.sendDataOut(commands["deviceFWUPfinish"]);
                    lbActionState.Text = states.deviceFWUPfinish.ToString();
                    break;
                case "+QLWEVENT:":
                    // 모듈이 LWM2M서버에 접속/등록하는 단계에서 발생하는 이벤트,
                    // OK 응답 발생하지 않음
                    char[] lwm2mstep = str2.ToCharArray();
                    int value = Convert.ToInt32(lwm2mstep[1]) - 48;
                    if (value < 5)
                    {

                    }
                    else
                    {
                        if (lbModel.Text == ".")
                        {
                            getDeviveInfo();
                        }
                    }

                    int first = str2.IndexOf("\"");
                    int last = str2.LastIndexOf("\"");
                    string lwm2mstate = str2.Substring(first + 1, last - first - 2);

                    if (nextcommand == states.getcereg.ToString())
                        nextcommand = "";
                    timer2.Stop();
                    break;
                case "AT+MLWEVTIND=":
                    // 모듈이 LWM2M서버 연동 상태 이벤트,
                    // OK 응답 발생하지 않음
                    // AT+MLWEVTIND=<type>
                    int type = Convert.ToInt32(str2);
                    switch (str2)
                    {
                        case "0":
                            logPrintInTextBox("registration completed", " ");
                            break;
                        case "1":
                            logPrintInTextBox("deregistration completed", " ");
                            break;
                        case "2":
                            logPrintInTextBox("registration update completed", " ");
                            break;
                        case "3":
                            logPrintInTextBox("10250 object subscription completed", " ");
                            break;
                        case "4":
                            logPrintInTextBox("Bootstrap finished", " ");
                            break;
                        case "5":
                            logPrintInTextBox("5/0/3 object subscription completed", " ");
                            break;
                        case "6":
                            logPrintInTextBox("fota downloading request", " ");
                            break;
                        case "7":
                            logPrintInTextBox("fota update request", " ");
                            break;
                        case "8":
                            logPrintInTextBox("26241 object subscription completed", " ");
                            break;
                    }
                    break;
                case "AT+MLWDLDATA=":
                    // 모듈이 LWM2M서버에서 받은 데이터를 전달하는 이벤트,
                    // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                    // AT+MLWDLDATA=(<type>),<length>,<hex data>
                    string[] rxdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rxdatas.Length < 3)
                    {
                        // 10250 DATA object RECEIVED!!!
                        if (Convert.ToInt32(rxdatas[0]) == rxdatas[1].Length / 2)    // data size 비교
                        {
                            //received hex data make to ascii code
                            string receiveDataIN = BcdToString(rxdatas[1].ToCharArray());
                            logPrintInTextBox("\"" + receiveDataIN + "\"를 수신하였습니다.", "");
                        }
                        else
                        {
                            logPrintInTextBox("data size가 맞지 않습니다.", "");
                        }
                    }
                    else if (rxdatas[0] == "1")
                    {
                        // 26241 FOTA DATA object RECEIVED!!!
                        receiveFotaData(rxdatas[1], rxdatas[2]);
                    }
                    else if (rxdatas[0] == "2")
                    {
                        // 26241 FOTA DATA object RECEIVED!!!  (GCT 모듈)
                        receiveFotaData(rxdatas[1], rxdatas[2]);
                    }
                    else
                    {
                        logPrintInTextBox("data format이 맞지 않습니다.", "");
                    }
                    break;

                case "+QLWDLDATA:":
                    // 모듈이 LWM2M서버에서 받은 데이터를 전달하는 이벤트,
                    // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                    string[] words = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (words[0] == " \"/10250/0/1\"")       // data object인지 확인
                    {
                        if (words[1] == "4")     // string data received
                        {
                            if (Convert.ToInt32(words[2]) == (words[3].Length - 2))    // data size 비교 (양쪽 끝의 " 크기 빼고)
                            {
                                logPrintInTextBox(words[3] + "를 수신하였습니다.", "");
                            }
                            else
                            {
                                logPrintInTextBox("data size가 맞지 않습니다.", "");
                            }
                        }
                        else if (words[1] == "5")     // hex data received
                        {
                            if (Convert.ToInt32(words[2]) == (words[3].Length - 2) / 2)    // data size 비교 (양쪽 끝의 " 크기 빼고 2bytes가 1글자임)
                            {
                                //received hex data make to ascii code
                                string hexInPut = words[3].Substring(1, words[3].Length - 2);
                                string receiveDataIN = BcdToString(hexInPut.ToCharArray());
                                logPrintInTextBox("\"" + receiveDataIN + "\"를 수신하였습니다.", "");
                            }
                            else
                            {
                                logPrintInTextBox("data size가 맞지 않습니다.", "");
                            }
                        }
                        else
                        {
                            logPrintInTextBox("지원하지 않는 data object입니다.", "");
                        }
                    }
                    else if (words[0] == " \"/26241/0/1\"")       // device firmware object인지 확인
                    {
                        if (words[1] == "5")     // hex data received
                        {
                            // 26241 FOTA DATA object RECEIVED!!!
                            receiveFotaData(words[2], words[3].Substring(1, words[3].Length - 2));
                        }
                        else
                        {
                            logPrintInTextBox("지원하지 않는 data object입니다.", "");
                        }
                    }
                    else
                    {
                        logPrintInTextBox("지원하지 않는 data object입니다.", "");
                    }

                    if (nextcommand == states.getcereg.ToString())
                        nextcommand = "";
                    timer2.Stop();
                    break;
                case "+QLWOBSERVE:":
                    // 모듈이 LWM2M서버와 초기 접속시 받은 데이터를 전달하는 이벤트,
                    // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                    string[] observes = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (observes[1] == "\"/10250/0/0\"")       // data object인지 확인
                    {
                    }
                    else if (observes[1] == "\"/26241/0/0\"")       // device firmware object인지 확인
                    {
                        // 서버에서 모듈 펌웨어 처리 후에 디바이스 펌웨어 체크 가능, 일정 시간 후에 동작해야 함.
                        // DeviceFWVerSend(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
                    }
                    else
                    {
                        logPrintInTextBox("지원하지 않는 data object입니다.", "");
                    }

                    if (nextcommand == states.getcereg.ToString())
                        nextcommand = "";
                    timer2.Stop();
                    break;
                case "@NETSTI:":
                    // AMTEL booting end, device info rerequest
                    getDeviveInfo();
                    timer2.Interval = 10000;        // 10초 타이머로 동작
                    break;
                case "AT+CGMI":
                    // AMTEL booting 시 제조사명 재요청인 경우인지 확인
                    if (lbActionState.Text == "idle" )
                    {
                        lbActionState.Text = states.autogetmanufac.ToString();
                    }
                    break;
                case "$LGTMPF=":
                    if (str2 == "5")
                    {
                        // 플랫폼 서버 MEF AUTH 요청
                        this.sendDataOut(commands["setmefauthnt"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + ",D-" + lbIMSI.Text);
                        lbActionState.Text = states.setmefauthnt.ToString();
                        nextcommand = "skip";
                    }
                    else
                    {
                        // 모듈 oneM2M 플랫폼 모드 요청
                        nextcommand = "setonem2mmode";
                    }
                    break;
                case "+QCFG: ":
                    string[] qcfgs = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (qcfgs[0] == "\"iotopmode\"")       // 현재 접속한 LTE망 확인
                    {
                        if (qcfgs[1] == "0")
                        {
                            logPrintInTextBox("LTE Cat M1망에 접속되어 있습니다.", "");
                        }
                        else
                        {
                            logPrintInTextBox("NB_IOT망에 접속되어 있습니다.", "");
                        }

                        if (lbActionState.Text == "autogetNWmode")
                        {
                            nextcommand = "autogetimsi";
                        }
                    }
                    break;
                case "FW_VER: ":
                    lbModemVer.Text = str2;
                    logPrintInTextBox("모뎀 버전이 저장되었습니다.", "");
                    break;
                default:
                    break;
            }
        }

        private void receiveFotaData(string size, string rcvData)
        {
            int dataSize = rcvData.Length / 2;
            if (Convert.ToInt32(size) == dataSize)    // data size 비교
            {
                // Firmware File Information Block Checking
                if ((device_total_index == "0") && (dataSize == 8))
                {
                    if (rcvData.Substring(0, 4) == "0000")
                    {
                        device_total_index = rcvData.Substring(4, 4);
                        device_fota_checksum = rcvData.Substring(8, 8);
                        device_fota_state = "2";
                        logPrintInTextBox("total Index= " + device_total_index + ", checksum = " + device_fota_checksum + "를 수신하였습니다.", "");
                    }
                }
                // Firmware File Data Block Checking
                else
                {
                    device_fota_index = rcvData.Substring(0, 4);
                    //tBoxFOTAIndex.Text = device_fota_index;
                    string checksum = rcvData.Substring(4, 8);
                    logPrintInTextBox("index= " + device_fota_index + "/" + device_total_index + ", checksum= " + checksum + "를 수신하였습니다.", "");

                    if (device_total_index == device_fota_index)
                    {
                        device_total_index = "0";
                        device_fota_index = "0";
                        device_fota_state = "1";        // fota receive sucess
                        //tBoxFOTAIndex.Text = device_fota_index;

                        // 메뉴에서 선택시 버전 정보 보고하도록 함
                        // DeviceFWVerSend(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
                    }
                }
            }
            else
            {
                logPrintInTextBox("data size가 맞지 않습니다.", "");
            }
        }

        private void OKReceived()
        {
            states state = (states)Enum.Parse(typeof(states), lbActionState.Text);
            switch (state)
            {
                case states.setmefserverinfo:
                    //AT$OM_SVR_INFO=<svr>,<ip>,<port>
                    this.sendDataOut(commands["sethttpserverinfo"] + oneM2MBRKIP + "," + oneM2MBRKPort);
                    lbActionState.Text = states.sethttpserverinfo.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.sethttpserverinfo:
                    nextcommand = "";           // 서버 설정 완료
                    break;
                case states.setserverinfo:
                    if (lbModel.Text == "BG96")
                    {
                        nextcommand = "rfreset";           // 서버 변경후 망 재연결
                    }
                    break;
                case states.disable_bg96:
                    // 쿼텔 LWM2M bootstrap 자동 요청 순서
                    // (disable) - (setcdp) - servertype - endpointpame - mbsps - enable
                    // 플랫폼 서버 타입 설정
                    //AT+QLWM2M="cdp",<ip>,<port>
                    this.sendDataOut(commands["setcdp_bg96"] + "\"" + serverip + "\"," + serverport);
                    lbActionState.Text = states.setcdp_bg96.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.setcdp_bg96:
                    // 쿼텔 LWM2M bootstrap 자동 요청 순서
                    // disable - (setcdp) - (servertype) - endpointpame - mbsps - enable
                    // 플랫폼 서버 타입 설정
                    //AT+QLWM2M="select",2
                    this.sendDataOut(commands["setservertype"]);
                    lbActionState.Text = states.setservertype.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.setservertype:
                    // 쿼텔 LWM2M bootstrap 자동 요청 순서
                    // disable - setcdp - (servertype) - (endpointpame) - mbsps - enable
                    // EndPointName 플랫폼 device ID 설정
                    //AT+QLWM2M="enps",0,<service code>
                    //this.sendDataOut(commands["setepns"] + "ASN-CSE-D-6399301537-FOTA" + "\"");
                    this.sendDataOut(commands["setepns"] + tbSvcCd.Text + "\"");
                    lbActionState.Text = states.setepns.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.setepns:
                    // 쿼텔 LWM2M bootstrap 자동 요청 순서
                    // disable - setcdp - servertype - (endpointpame) - (mbsps) - enable
                    // PLMN 정보 확인 후 진행
                    string ctn = lbIMSI.Text;
                    if (ctn != "알 수 없음")
                    {
                        // Bootstrap Parameter 설정
                        //AT+QLWM2M="mbsps",<service code>,<sn>,<ctn>,<iccid>,<device model>
                        string epncmd = commands["setmbsps"] + tbSvcCd.Text + "\",\"";
                        epncmd = epncmd + tBoxDeviceSN.Text + "\",\"";
                        epncmd = epncmd + ctn + "\",\"";

                        string epniccid = lbIccid.Text;
                        epncmd = epncmd + epniccid.Substring(epniccid.Length - 6, 6) + "\",\"";
                        epncmd = epncmd + tBoxDeviceModel.Text + "\"";
                        this.sendDataOut(epncmd);
                        lbActionState.Text = states.setmbsps.ToString();

                        timer1.Start();
                        nextcommand = "skip";
                    }
                    else
                    {
                        MessageBox.Show("USIM이 정상인지 확인해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nextcommand = "";
                        timer1.Stop();
                    }
                    break;
                case states.setmbsps:
                    if (lbModel.Text == "BG96")
                    {
                        // 쿼텔 LWM2M bootstrap 자동 요청 순서
                        // disable - setcdp - servertype - endpointpame - (mbsps) - (enable)
                        // enable 요청
                        //AT+QLWM2M="enable",1
                        nextcommand = states.enable_bg96.ToString();
                    }
                    else
                    {
                        // LWM2M bootstrap 자동 요청 순서
                        // servertype - endpointpame - (mbsps) - (bootstrap) 마지막
                        // Bootstrap 요청
                        //AT+QLWM2M="bootstrap",1
                        nextcommand = states.bootstrap.ToString();
                    }
                    break;
                case states.autogetmodemver:
                case states.autogetmodemvertpb23:
                case states.autogetmodemvernt:
                    // 모듈 정보 자동 확인 후 , LTE network attach 요청하면 정상적으로 attach 성공했는지 확인
                    nextcommand = states.getcereg.ToString();
                    break;
                case states.setcereg:
                    // LTE network attach 요청하면 정상적으로 attach 성공했는지 확인 필요
                    nextcommand = states.getcereg.ToString();
                    break;
                case states.setceregtpb23:
                    // LTE network attach 요청하면 정상적으로 attach 성공했는지 확인 필요
                    nextcommand = states.getcereg.ToString();
                    break;
                case states.setncdp:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // (setncdp) - (setepnstpb23) - setmbspstpb23 - bootstrapmodetpb23 - bootstraptpb23
                    // End Point Name Parameter 설정
                    //AT+MLWEPNS="LWM2M 서버 entityID"
                    String md5value = getMd5Hash(lbIMSI.Text + lbIccid.Text);
                    logPrintInTextBox(md5value, "");

                    string epn = md5value.Substring(0, 5) + md5value.Substring(md5value.Length - 5, 5);

                    this.sendDataOut(commands["setepnstpb23"] + epn + "-" + tbSvcCd.Text);
                    lbActionState.Text = states.setepnstpb23.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.setepnstpb23:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - (setepnstpb23) - (setmbspstpb23) - bootstrapmodetpb23 - bootstraptpb23
                    // Bootstarp Parameter 설정
                    //AT+MLWMBSPS="serviceCode=GAMR|deviceSerialNo=1234567|ctn=01022335078 | iccId = 127313 | deviceModel = Summer | mac = "

                    string command = tbSvcCd.Text + "|deviceSerialNo=";
                    command += tBoxDeviceSN.Text + "|ctn=";
                    command += lbIMSI.Text + "|iccId=";

                    string iccid = lbIccid.Text;
                    command += iccid.Substring(iccid.Length - 6, 6) + "|deviceModel=";
                    command += tBoxDeviceModel.Text + "|mac=";

                    this.sendDataOut(commands["setmbspstpb23"] + command);
                    lbActionState.Text = states.setmbspstpb23.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.setmbspstpb23:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - setepnstpb23 - (setmbspstpb23) - (bootstrapmodetpb23) - bootstraptpb23
                    // LWM2M 서버 설정
                    // BOOTSTARP MODE 설정
                    //AT+MBOOTSTRAPMODE=1
                    nextcommand = states.bootstrapmodetpb23.ToString();
                    break;
                case states.bootstrapmodetpb23:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - setepnstpb23 - setmbspstpb23 - (bootstrapmodetpb23) - (bootstraptpb23)
                    // LWM2M서버에 Bootstarp 요청
                    //  AT+MLWGOBOOTSTRAP=1
                    nextcommand = states.bootstraptpb23.ToString();
                    break;
                case states.setonem2mmode:
                    nextcommand = states.getonem2mmode.ToString();
                    break;
                case states.catm1set:
                    nextcommand = states.catm1apn1.ToString();
                    break;
                case states.catm1apn1:
                    nextcommand = states.catm1apn2.ToString();
                    break;
                case states.catm1apn2:
                    nextcommand = states.catm1psmode.ToString();
                    break;
                case states.catm1psmode:
                    nextcommand = states.rfoff.ToString();
                    break;
                case states.rfoff:
                    nextcommand = states.rfon.ToString();
                    break;
                case states.rfon:
                    nextcommand = states.getcereg.ToString();
                    break;
                case states.catm1imsset:
                    nextcommand = states.catm1imsapn1.ToString();
                    break;
                case states.catm1imsapn1:
                    nextcommand = states.catm1imsapn2.ToString();
                    break;
                case states.catm1imsapn2:
                    nextcommand = states.catm1imsmode.ToString();
                    break;
                case states.catm1imsmode:
                    nextcommand = states.catm1imspco.ToString();
                    break;
                case states.catm1imspco:
                    nextcommand = states.rfoff.ToString();
                    break;
                case states.nbset:
                    nextcommand = states.nbapn1.ToString();
                    break;
                case states.nbapn1:
                    nextcommand = states.nbapn2.ToString();
                    break;
                case states.nbapn2:
                    nextcommand = states.nbpsmode.ToString();
                    break;
                case states.nbpsmode:
                    nextcommand = states.rfoff.ToString();
                    break;
                default:
                    break;
            }

            // 마지막 응답(OK)을 받은 후에 후속 작업이 필요한지 확인한다.
            if (nextcommand != "skip")
            {
                if (nextcommand != "")
                {
                    this.sendDataOut(commands[nextcommand]);
                    lbActionState.Text = nextcommand;
                    nextcommand = "";

                    timer1.Start();
                }
                else
                {
                    lbActionState.Text = states.idle.ToString();
                    timer1.Stop();
                }
            }
        }

        private void parseNoPrefixData(string str1)
        {
            states state = (states)Enum.Parse(typeof(states), lbActionState.Text);
            switch (state)
            {
                // 단말 정보 자동 갱신 순서
                // (autogetmanufac) - (autogetmodel) - autogetimsi - geticcid
                case states.autogetmanufac:
                    lbMaker.Text = str1;
                    this.logPrintInTextBox("제조사값이 저장되었습니다.", "");
                    if (str1 == "AM Telecom" || str1 == "QUALCOMM INCORPORATED"
                        || str1 == "LIME-I Co., Ltd")        //AMTEL 모듈은 OK가 오지 않음
                    {
                        this.sendDataOut(commands["autogetmodelgmm"]);
                        lbActionState.Text = states.autogetmodel.ToString();

                        timer1.Start();
                        nextcommand = "skip";
                    }
                    else
                    {
                        lbActionState.Text = states.idle.ToString();
                        nextcommand = states.autogetmodel.ToString();
                    }
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmanufac - (autogetmodel) - (autogetimsi) - geticcid
                case states.autogetmodel:
                    lbModel.Text = str1;
                    this.logPrintInTextBox("모델값이 저장되었습니다.", "");

                    setModelConfig(str1);

                    lbActionState.Text = states.idle.ToString();
                    if (str1 == "BG96")
                    {
                        nextcommand = "autogetNWmode";
                    }
                    else
                    {
                        nextcommand = states.autogetimsi.ToString();
                    }
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmanufac - autogetmodel - (autogetimsi) - (geticcid)
                case states.autogetimsi:
                    if (str1.StartsWith("45006"))
                    {
                        string ctn = "0" + str1.Substring(5, str1.Length - 5);

                        lbIMSI.Text = ctn;

                        if (lbMaker.Text == "AM Telecom")        //AMTEL 모듈은 OK가 오지 않음
                        {
                            lbActionState.Text = states.autogeticcidamtel.ToString();
                            nextcommand = states.autogeticcidamtel.ToString();
                        }
                        else
                        {
                            lbActionState.Text = states.autogeticcid.ToString();
                            nextcommand = states.autogeticcid.ToString();
                        }
                    }
                    else
                        this.logPrintInTextBox("USIM 상태 확인이 필요합니다.", "");
                    break;
                case states.setservertype:
                    // EndPointName 플랫폼 device ID 설정
                    //AT+QLWM2M="enps",0,<service code>
                    //this.sendDataOut(commands["setepns"] + "ASN-CSE-D-6399301537-FOTA" + "\"");
                    this.sendDataOut(commands["setepns"] + tbSvcCd.Text + "\"");
                    lbActionState.Text = states.setepns.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.setepns:
                    if (lbIMSI.Text != "알 수 없음")
                    {
                        // Bootstrap Parameter 설정
                        //AT+QLWM2M="mbsps",<service code>,<sn>,<ctn>,<iccid>,<device model>
                        string command = commands["setmbsps"] + tbSvcCd.Text + "\",\"";
                        command = command + tBoxDeviceSN.Text + "\",\"";
                        command = command + lbIMSI.Text + "\",\"";

                        string iccid = lbIccid.Text;
                        command = command + iccid.Substring(iccid.Length - 6, 6) + "\",\"";
                        command = command + tBoxDeviceModel.Text + "\"";
                        this.sendDataOut(command);
                        lbActionState.Text = states.setmbsps.ToString();

                        timer1.Start();
                        nextcommand = "skip";
                    }
                    else
                    {
                        MessageBox.Show("USIM이 정상인지 확인해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nextcommand = "";
                    }
                    break;
                case states.setmbsps:
                    // Bootstrap 요청
                    //AT+QLWM2M="bootstrap",1
                    //nextcommand = states.bootstrap.ToString();
                    break;

                case states.getimsi:
                    if (str1.StartsWith("45006"))
                    {
                        string ctn = "0" + str1.Substring(5, str1.Length - 5);

                        lbIMSI.Text = ctn;
                        lbActionState.Text = states.idle.ToString();
                        this.logPrintInTextBox("IMSI값이 저장되었습니다.", "");
                    }
                    else
                        this.logPrintInTextBox("USIM 상태 확인이 필요합니다.", "");

                    lbActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    break;
                case states.getmodel:
                    lbModel.Text = str1;
                    lbActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    this.logPrintInTextBox("모델값이 저장되었습니다.", "");

                    setModelConfig(str1);

                    if (str1 == "BG96")
                    {
                        nextcommand = "getNWmode";
                    }
                    break;
                case states.getmanufac:
                    lbMaker.Text = str1;
                    lbActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    this.logPrintInTextBox("제조사값이 저장되었습니다.", "");
                    break;
                case states.getmodemver:
                case states.getmodemvertpb23:
                    lbModemVer.Text = str1;
                    lbActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    this.logPrintInTextBox("모뎀버전이 저장되었습니다.", "");
                    break;
                case states.autogetmodemver:
                case states.autogetmodemvertpb23:
                    lbModemVer.Text = str1;
                    this.logPrintInTextBox("모뎀버전이 저장되었습니다.", "");
                    break;
                default:
                    break;
            }
        }

        private void setModelConfig(string model)
        {
            if (lbMaker.Text == "AM Telecom")        //AMTEL/oneM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "AMM5400LG";
                tBoxDeviceSN.Text = "TEST";
                oneM2Mmode = 0;
            }
            else if (lbMaker.Text == "QUALCOMM INCORPORATED")        //텔라딘/oneM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "AMM5400LG";
                tBoxDeviceSN.Text = "TEST";
                oneM2Mmode = 0;
            }
            else if (lbMaker.Text == "LIME-I Co., Ltd")        //라임아이/oneM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "LML-D";
                tBoxDeviceSN.Text = "TEST";
                oneM2Mmode = 0;
            }
            else if (model.StartsWith("NTLM3", System.StringComparison.CurrentCultureIgnoreCase))         //NTmore/oneM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "NTM_Simulator";
                tBoxDeviceSN.Text = "TEST";
                oneM2Mmode = 0;
            }
            else if (model == "BG96")                                                                   //쿼텔/LwM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "LWEMG";
                tBoxDeviceSN.Text = "123456";
                oneM2Mmode = 1;
            }
            else if (model == "TPB23")                                                                   //화웨이/LwM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "TPB23";
                tBoxDeviceSN.Text = "123456";
                oneM2Mmode = 1;
            }
            else if (model == "GDM7243R1")                                                                   //바인테크/GCT/LwM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "VTLM-102G";
                tBoxDeviceSN.Text = "123456";
                oneM2Mmode = 1;
            }
            else                                                                                        //default/LwM2M 메뉴 활성화
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "LWEMG";
                tBoxDeviceSN.Text = "123456";
                oneM2Mmode = 1;
            }
        }

        private void getDeviveInfo()
        {
            this.logPrintInTextBox("DEVICE 정보 전체를 요청합니다.","");

            // 단말 정보 자동 갱신 순서
            // (autogetmanufac) - autogetmodel - autogetimsi - geticcid
            this.sendDataOut(commands["autogetmanufac"]);
            lbActionState.Text = states.autogetmanufac.ToString();

            timer1.Start();
        }

        // AT command를 요청하고 10초 동안 OK 응답이 없으면 COM port 재설정
        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            logPrintInTextBox(lbActionState.Text+"요청에 대해 timeout이 발생하였습니다.","");
            //MessageBox.Show("타이머가 종료되었습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            lbActionState.Text = states.idle.ToString();
        }

        // menubar에서 LWM2M 플랫폼 디바이스 등록을 요청 (bootstrap)
        private void Provision()
        {
            if (isDeviceInfo())
            {
                if (oneM2Mmode == 0)      // oneM2M : MEF Auth인증 요청
                {
                    // 모듈이 oneM2M 모드인지 확인하고 플랫폼 인증 요청
                    this.sendDataOut(commands["getonem2mmode"]);
                    lbActionState.Text = states.getonem2mmode.ToString();

                    // 플랫폼 서버 MEF AUTH 요청
                    //this.sendDataOut(commands["setmefauthnt"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + ",D-" + tBoxIMSI.Text);
                    //tBoxActionState.Text = states.setmefauthnt.ToString();
                }
                else if (lbModel.Text == "BG96")       //쿼텔
                {
                    // 쿼텔 LWM2M bootstrap 자동 요청 순서
                    // (disable) - setcdp - servertype - endpointpame - mbsps - enable
                    // 플랫폼 서버 타입 설정
                    //AT+QLWM2M="select",2
                    //this.sendDataOut(commands["setservertype"]);
                    //tBoxActionState.Text = states.setservertype.ToString();
                    //AT+QLWM2M="enable",0
                    this.sendDataOut(commands["disable_bg96"]);
                    lbActionState.Text = states.disable_bg96.ToString();
                }
                else if (lbModel.Text == "TPB23")
                {
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - setepnstpb23 - setmbspstpb23 - bootstrapmodetpb23 - bootstraptpb23
                    // LWM2M 서버 설정
                    // AT+NCDP=IP,PORT
                    this.sendDataOut(commands["setncdp"] + "\"" + serverip + "\"," + serverport);
                    lbActionState.Text = states.setncdp.ToString();
                }
                else            //일반(U+ command)
                {
                    // LWM2M bootstrap 자동 요청 순서
                    // setncdp - setepnstpb23 - setmbspstpb23 - bootstrapmodetpb23 - bootstraptpb23
                    // LWM2M 서버 설정
                    // AT+NCDP=IP,PORT
                    this.sendDataOut(commands["setncdp"] + serverip + "," + serverport);
                    lbActionState.Text = states.setncdp.ToString();
                }
                timer1.Start();
            }
        }

        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


        private bool isDeviceInfo()
        {
            if((lbIMSI.Text == "알 수 없음") || (lbIccid.Text == "알 수 없음"))
            {
                this.getDeviveInfo();
                MessageBox.Show("모듈 정보를 읽고 있습니다.\n다시 시도해주세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;  
            }

            return true;
        }

        private void CBoxSERVER_TextChanged(object sender, EventArgs e)
        {
            serverip = "\"106.103.233.155\"";
            serverport = "5783";

            setLwm2mServer();
        }

        private void setLwm2mServer()
        {
            if (isDeviceInfo())
            {
                serverip = "106.103.233.155";
                serverport = "5783";

                oneM2MMEFIP = "106.103.234.198";
                oneM2MMEFPort = "80";
                oneM2MBRKIP = "106.103.234.117";
                oneM2MBRKPort = "80";

                // 플랫폼 서버의 IP/port 설정
                if (oneM2Mmode == 0)
                {
                    //AT$OM_SVR_INFO=<svr>,<ip>,<port>
                    this.sendDataOut(commands["setmefserverinfo"] + oneM2MMEFIP + "," + oneM2MMEFPort);
                    lbActionState.Text = states.setmefserverinfo.ToString();
                }
                else if (lbModel.Text == "BG96")
                {
                    //AT+QLWM2M="cdp",<ip>,<port>
                    this.sendDataOut(commands["setserverinfo"] + "\"" + serverip + "\"," + serverport);
                    lbActionState.Text = states.setserverinfo.ToString();
                }
                else if (lbModel.Text == "TPB23")
                {
                    //AT+NCDP=<ip>   TPB23모델
                    this.sendDataOut(commands["setserverinfotpb23"] + "\"" + serverip + "\"," + serverport);
                    lbActionState.Text = states.setserverinfo.ToString();
                }
                else
                {
                    //AT+NCDP=<ip>   일반 LwM2M
                    this.sendDataOut(commands["setserverinfotpb23"] + serverip + "," + serverport);
                    lbActionState.Text = states.setserverinfo.ToString();
                }

                timer1.Start();
            }
        }

        private void TBoxDataOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //입력 Text값을 플랫폼 서버로 전송
                this.sendDataToServer(tBoxDataOut.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void sendDataToServer(string text)
        {
            if (isDeviceInfo())
            {
                if (oneM2Mmode == 0)      // oneM2M
                {
                    // Data send to SERVER (string original)
                    //AT$OM_C_INS_REQ=<object>,<length>,<data>
                    this.sendDataOut(commands["sendonemsgstr"] + tBoxDeviceSN.Text + "," + text.Length + "," + text);
                    lbActionState.Text = states.sendonemsgstr.ToString();

                    timer1.Start();
                }
                else if (lbModel.Text == "BG96")
                {
                        // Data send to SERVER (string original)
                        //AT+QLWM2M="uldata",<object>,<length>,<data>
                        this.sendDataOut(commands["sendmsgstr"] + text.Length + ",\"" + text + "\"");
                        lbActionState.Text = states.sendmsgstr.ToString();

                        timer1.Start();
                }
                else
                {
                    // Data send to SERVER (string original)
                    //AT+MLWULDATA=<length>,<data>
                    string hexOutput = StringToBCD(text.ToCharArray());

                    this.sendDataOut(commands["sendmsgstrtpb23"] + hexOutput.Length / 2 + "," + hexOutput);
                    lbActionState.Text = states.sendmsgstr.ToString();

                    timer1.Start();
                }
            }
        }

        private string BcdToString(char[] charValues)
        {
            string bcdstring = "";
            for (int i = 0; i < charValues.Length - 1;)
            {
                // Convert to the first character.
                int value = bcdvalues[charValues[i++]] * 0x10;

                // Convert to the second character.
                value += bcdvalues[charValues[i++]];

                // Convert the decimal value to a hexadecimal value in string form.
                bcdstring += Char.ConvertFromUtf32(value);
            }
            return bcdstring;
        }

        private string StringToBCD(char[] charValues)
        {

            string hexstring = "";
            foreach (char _eachChar in charValues)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(_eachChar);
                // Convert the decimal value to a hexadecimal value in string form.
                hexstring += String.Format("{0:X}", value);
            }
            return hexstring;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(tBoxDataIN.Text != "")
            {
                string pathname = @"c:\temp\seriallog\";
                DateTime currenttime = DateTime.Now;
                string filename = "lwm2m_log_" + currenttime.ToString("MMdd_hhmmss") + ".txt";

                Directory.CreateDirectory(pathname);

                // Create a file to write to.
                FileStream fs = null;
                try
                {
                    fs = new FileStream(pathname + filename, FileMode.Create, FileAccess.Write);
                    // Create a file to write to.
                    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                    char[] logmsg = tBoxDataIN.Text.ToCharArray();
                    sw.Write(logmsg, 0, tBoxDataIN.TextLength);

                    sw.Close();
                    fs.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            if (network_chkcnt-- > 0)
            {
                this.sendDataOut(commands["getcereg"]);
                lbActionState.Text = states.getcereg.ToString();

                timer1.Start();
                logPrintInTextBox("LTE 연결 상태를 확인합니다.", "");
            }
            else
            {
                this.sendDataOut(commands["reset"]);
                lbActionState.Text = states.reset.ToString();

                timer1.Start();
                logPrintInTextBox("3회 가 over하여 모듈을 reset합니다.", "");
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (oneM2Mmode == 0)      // oneM2M : MEF Auth인증 요청
                DeviceFWVerSendOne(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
            else
                DeviceFWVerSend(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
        }

        private void DeviceFWVerSendOne(string ver, string state, string result)
        {
            if (isDeviceInfo())
            {
                // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                this.sendDataOut(commands["fotamefauthnt"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + ",D-" + lbIMSI.Text);
                lbActionState.Text = states.fotamefauthnt.ToString();
                timer1.Start();
            }
        }

        private void FWUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceFWVerSend(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
        }

        private void DeviceFWVerSend(string ver, string state, string result)
        {
            if (isDeviceInfo())
            {
                // Device firmware 버전 등록 전문 예 : fwVr=1.0|fwSt=1|fwRt=0
                // fwVr ={ VERSION}| fwSt ={ STATUS}| fwRt ={ RESULT_CODE}(|fwIn={index})(|szx={buffersize})
                // fwVr: 현재 Device Firmware 버전
                // fwSt: Firmware Status
                //      1: Success
                //      2: Progress
                //      3: Failure
                // fwRt : Firmware Update 결과(OMA Spec 과 같은 값 사용)
                //      0: Initial value.
                //      1: Firmware updated successfully
                //      2: Not enough flash memory
                //      3: Out of RAM during downloading process.
                //      4: Connection lost during downloading process.
                //      5: Integrity check failure
                //      6: Unsupported package type.
                //      8: Firmware update failed
                //  fwIn : 단말에서 문제가 발생 하여 특정 Index부터 다시 받고 싶을 때 사용
                //      만약 fwSt 가 2(Progress)이면서 fwIn 에 특정 Index 를 보내면
                //      기존에 upload Process 는 중지 하고 해당 Index 부터 다시 Upload 시작 함
                //      fwSt 가 2 가 아닐 경우, fwIn 값이 없거나 0 보다 작을 경우 이어 받기 동작하지 않음
                //      fwIn 의 값이 전체 Index 보다 클 경우 이전 내려받기는 취소 되고 에러 처리 됨
                // szx : FOTA buffer size (1:32, 2:64, 3:128, 4:256, 5:512(default), 6:1024 

                string text = "fwVr=" + ver + "|fwSt=" + state + "|fwRt=" + result;

                if (state == "2")
                {
                    Int32 index = Convert.ToInt32(device_fota_index, 16);
                    text += "|fwIn=" + Convert.ToString(index);
                }

                //if (cBoxFOTASize.Checked == true)
                {
                    text += "|szx=6";       // FOTA buffer size set 1024bytes.
                }

                logPrintInTextBox(text + " 로 FOTA응답하였습니다.", "");

                if (lbModel.Text == "BG96")
                {
                    // Data send to SERVER (string to BCD convert)
                    //AT+QLWM2M="uldata,"fwVr=1.0.0|fwSt=1|fwRt=0"

                    this.sendDataOut(commands["sendmsgver"] + text.Length + ",\"" + text + "\"");
                    lbActionState.Text = states.sendmsgver.ToString();

                    timer1.Start();
                }
                else
                {
                    // Data send to SERVER (string original)
                    //AT+MLWULDATA=<length>,<data>
                    string hexOutput = StringToBCD(text.ToCharArray());

                    this.sendDataOut(commands["sendmsgvertpb23"] + hexOutput.Length / 2 + "," + hexOutput);
                    lbActionState.Text = states.sendmsgvertpb23.ToString();

                    timer1.Start();
                }
            }
        }

        private void BtnFOTAConti_Click(object sender, EventArgs e)
        {
            device_fota_index = "2";      // 이어받기 index 임의로 2설정
            if (oneM2Mmode == 0)      // oneM2M : MEF Auth인증 요청
                DeviceFWVerSendOne(tBoxDeviceVer.Text, "2", device_fota_reseult);
            else
                DeviceFWVerSend(tBoxDeviceVer.Text, "2", device_fota_reseult);
        }

        private void btnTestPage_Click(object sender, EventArgs e)
        {
            
        }


        // 1. MEF 인증
        private void RequestMEF()
        {
            ReqHeader header = new ReqHeader();
            header.Url = mefUrl + "/mef/server";
            header.Method = "POST";
            header.ContentType = "application/xml";
            header.X_M2M_RI = string.Empty;
            header.X_M2M_Origin = string.Empty;
            header.X_MEF_TK = string.Empty;
            header.X_MEF_EKI = string.Empty;
            header.X_M2M_NM = string.Empty;

            string packetStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            packetStr += "<auth>";
            packetStr += "<svcSvrCd>" + svr.svcSvrCd + "</svcSvrCd>";
            packetStr += "<svcCd>" + svr.svcCd + "</svcCd>";
            packetStr += "<svcSvrNum>" + svr.svcSvrNum + "</svcSvrNum>";
            packetStr += "</auth>";

            LogWrite("----------MEF 인증----------");
            string retStr = SendHttpRequest(header, packetStr); // xml
            if (retStr != string.Empty)
            {
                ParsingXml(retStr);

                string nameCSR = svr.entityId.Replace("-", "");
                svr.remoteCSEName = "csr-" + nameCSR;
                //LogWrite("svr.remoteCSEName = " + svr.remoteCSEName);
            }
        }

        private void ParsingXml(string xml)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);
            //LogWrite(xDoc.OuterXml.ToString());

            XmlNodeList xnList = xDoc.SelectNodes("/authdata/http"); //접근할 노드
            foreach (XmlNode xn in xnList)
            {
                svr.enrmtKey = xn["enrmtKey"].InnerText; // oneM2M 인증 KeyID를 생성하기 위한 Key
                svr.entityId = xn["entityId"].InnerText; // oneM2M에서 사용하는 단말 ID
                svr.token = xn["token"].InnerText; // 인증구간 통신을 위해 발급하는 Token
            }
            //LogWrite("enrmtKey = " + svr.enrmtKey);
            //LogWrite("entityId = " + svr.entityId);
            //LogWrite("token = " + svr.token);
            lbEnrmtKey.Text = svr.enrmtKey;
            lbEntityId.Text = svr.entityId;
            lbToken.Text = svr.token;

            // EKI값 계산하기
            // short uuid구하기
            string suuid = svr.entityId.Substring(10, 10);
            //LogWrite("suuid = " + suuid);

            // KeyData Base64URL Decoding
            string output = svr.enrmtKey;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding

            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0:
                    break; // No pad chars in this case
                case 2:
                    output += "==";
                    break; // Two pad chars
                case 3:
                    output += "=";
                    break; // One pad char
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(svr.enrmtKey), "Illegal base64url string!");
            }

            var converted = Convert.FromBase64String(output); // Standard base64 decoder

            // keyData로 AES 128비트 비밀키 생성
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            AesManaged tdes = new AesManaged();
            tdes.Key = converted;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform crypt = tdes.CreateEncryptor();
            byte[] plain = Encoding.UTF8.GetBytes(suuid);
            byte[] cipher = crypt.TransformFinalBlock(plain, 0, plain.Length);
            String enrmtKeyId = Convert.ToBase64String(cipher);

            enrmtKeyId = enrmtKeyId.Split('=')[0]; // Remove any trailing '='s
            enrmtKeyId = enrmtKeyId.Replace('+', '-'); // 62nd char of encoding
            enrmtKeyId = enrmtKeyId.Replace('/', '_'); // 63rd char of encoding

            svr.enrmtKeyId = enrmtKeyId;
            //LogWrite("svr.enrmtKeyId = " + svr.enrmtKeyId);
        }

        // 2. CSEBase-GET : oneM2M 접속 확인
        private void ReqCSEBaseGET()
        {
            ReqHeader header = new ReqHeader();
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1";
            header.Method = "GET";
            header.Accept = "application/xml";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "CSEBase";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            string retStr = SendHttpRequest(header, string.Empty);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

        // 3. RemoteCSE-Get
        private void ReqRemoteCSEGet()
        {
            ReqHeader header = new ReqHeader();
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/" + svr.remoteCSEName;
            header.Method = "GET";
            header.Accept = "application/vnd.onem2m-res+xml";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "RemoteCSE_Retrieve";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            string retStr = SendHttpRequest(header, string.Empty);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

        // 3. RemoteCSE-Create
        private void ReqRemoteCSECreate()
        {
            ReqHeader header = new ReqHeader();
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1";
            header.Method = "POST";
            header.Accept = "application/vnd.onem2m-res+xml";
            header.ContentType = "application/vnd.onem2m-res+xml;ty=16";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "RemoteCSE_Create";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = svr.remoteCSEName;

            string packetStr = "<m2m:csr xmlns:m2m=\"http://www.onem2m.org/xml/protocols\">";
            packetStr += "<cst>3</cst>";
            packetStr += "<cb>/" + svr.entityId + "</cb>";
            packetStr += "<csi>/" + svr.entityId + "/cb-1</csi>";
            packetStr += "<rr>true</rr>";
            packetStr += "<poa>" + tbSeverIP.Text + ":" + tbSeverPort.Text + "</poa>";
            packetStr += "</m2m:csr>";

            string retStr = SendHttpRequest(header, packetStr);

            /*
            var obj = new JObject();
            obj.Add("cst", "3");
            obj.Add("cb", "/" + svr.entityId + "/cb-1");
            obj.Add("csi", "/" + svr.entityId);
            obj.Add("rr", "true");
            var arr = new JArray();
            //arr.Add("http://172.17.224.57:8180");
            arr.Add("http://" + tbSeverIP.Text + ":" + tbSeverPort.Text);
            obj.Add("poa", arr);
            //LogWriteobj.ToString());
            string retStr = SendHttpRequest(header, obj.ToString());
            */
            //if (retStr != string.Empty)
            //{
            //    LogWrite(retStr);
            //    // 이미 같은 이름으로 생성되어 있다면 응답 : {"message": "CONFLICT_INVALID_RESOURCE_NAME"}
            //}
        }

        // 3. RemoteCSE-Update
        private void ReqRemoteCSEUpdate()
        {
            ReqHeader header = new ReqHeader();
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/" + svr.remoteCSEName;
            header.Method = "PUT";
            header.Accept = "application/vnd.onem2m-res+json";
            header.ContentType = "application/vnd.onem2m-res+json";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "RemoteCSE_Update";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;

            string packetStr = "<m2m:csr xmlns:m2m=\"http://www.onem2m.org/xml/protocols\">";
            packetStr += "<cst>3</cst>";
            packetStr += "<cb>/" + svr.entityId + "</cb>";
            packetStr += "<csi>/" + svr.entityId + "/cb-1</csi>";
            packetStr += "<rr>true</rr>";
            packetStr += "<poa>" + tbSeverIP.Text + ":" + tbSeverPort.Text + "</poa>";
            packetStr += "</m2m:csr>";

            string retStr = SendHttpRequest(header, packetStr);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

        // 3. RemoteCSE-Delete
        private void ReqRemoteCSEDEL()
        {
            ReqHeader header = new ReqHeader();
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/" + svr.remoteCSEName;
            header.Method = "DELETE";
            header.Accept = "application/vnd.onem2m-res+xml";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "RemoteCSE_Delete";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            string retStr = SendHttpRequest(header, string.Empty);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

        private void RetriveDataToPlatform()
        {
            ReqHeader header = new ReqHeader();
            //header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_01222990847/cnt-TEMP/la";
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + lbIMSI.Text + "/cnt-" + tbContainer.Text + "/la";
            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "data_retrive";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/xml";
            header.ContentType = string.Empty;

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string format = string.Empty;
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    format = xn["cnf"].InnerText; // data format
                    value = xn["con"].InnerText; // data value
                }
                //LogWrite("value = " + value);
                //LogWrite("format = " + format);

                if (format == "application/octet-stream")
                    lboneM2MRxData.Text = Encoding.UTF8.GetString(Convert.FromBase64String(value));
                else
                    lboneM2MRxData.Text = value;
            }
        }

        private void SendDataToPlatform(string target_comm)
        {
            ReqHeader header = new ReqHeader();
            if (target_comm == "oneM2M")
            {
                //header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_01222990847/cnt-TEMP";
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + lbIMSI.Text + "/cnt-" + tbContainer.Text;
            }
            else
            {
                header.Url = brkUrlL + "/" + dev.entityId + "/10250/0/1";
                //header.Url = brkUrlL + "/IN_CSE-BASE-1/cb-1/" + deviceEntityId + "/10250/0/1";
            }
            header.Method = "POST";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "data_send";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/vnd.onem2m-res+xml";
            header.ContentType = "application/vnd.onem2m-res+xml;ty=4";

            string packetStr = "<m2m:cin xmlns:m2m=\"http://www.onem2m.org/xml/protocols\">";
            packetStr += "<cnf>text/plain</cnf>";
            packetStr += "<con>" + tbData.Text + "</con>";
            packetStr += "</m2m:cin>";
            string retStr = SendHttpRequest(header, packetStr);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

        private void DeviceCheckToPlatform()
        {
            ReqHeader header = new ReqHeader();
            header.Url = brkUrlL + "/" + dev.entityId + "/10250/0/0";
            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "device_status";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/vnd.onem2m-res+xml";
            header.ContentType = "application/vnd.onem2m-res+xml;ty=4";

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string format = string.Empty;
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    format = xn["cnf"].InnerText; // data format
                    value = xn["con"].InnerText; // data value
                }
                //LogWrite("value = " + value);
                //LogWrite("format = " + format);

                if (format == "application/octet-stream")
                    lbLwM2MRxData.Text = Encoding.UTF8.GetString(Convert.FromBase64String(value));
                else
                    lbLwM2MRxData.Text = value;
            }
        }

        public string SendHttpRequest(ReqHeader header, string data)
        {
            string resResult = string.Empty;

            try
            {
                wReq = (HttpWebRequest)WebRequest.Create(header.Url);
                wReq.Method = header.Method;
                if (header.Accept != string.Empty)
                    wReq.Accept = header.Accept;
                if (header.ContentType != string.Empty)
                    wReq.ContentType = header.ContentType;
                if (header.X_M2M_RI != string.Empty)
                    wReq.Headers.Add("X-M2M-RI", header.X_M2M_RI);
                if (header.X_M2M_Origin != string.Empty)
                    wReq.Headers.Add("X-M2M-Origin", header.X_M2M_Origin);
                if (header.X_M2M_NM != string.Empty)
                    wReq.Headers.Add("X-M2M-NM", header.X_M2M_NM);
                if (header.X_MEF_TK != string.Empty)
                    wReq.Headers.Add("X-MEF-TK", header.X_MEF_TK);
                if (header.X_MEF_EKI != string.Empty)
                    wReq.Headers.Add("X-MEF-EKI", header.X_MEF_EKI);

                LogWriteNoTime(wReq.Method + " " + wReq.RequestUri + " HTTP/1.1");
                LogWriteNoTime("");
                for (int i = 0; i < wReq.Headers.Count; ++i)
                    LogWriteNoTime(wReq.Headers.Keys[i] + ": " + wReq.Headers[i]);
                LogWriteNoTime("");
                LogWriteNoTime(data);
                LogWriteNoTime("");

                // POST 전송일 경우      
                if (header.Method == "POST")
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = wReq.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                }

                LogWrite("----------Response from oneM2M----------");
                wReq.Timeout = 20000;          // 서버 응답을 20초동안 기다림
                using (wRes = (HttpWebResponse)wReq.GetResponse())
                {
                    LogWriteNoTime("HTTP/1.1 " + (int)wRes.StatusCode + " " + wRes.StatusCode.ToString());
                    LogWriteNoTime("");
                    for (int i = 0; i < wRes.Headers.Count; ++i)
                        LogWriteNoTime("[" + wRes.Headers.Keys[i] + "] " + wRes.Headers[i]);
                    LogWriteNoTime("");

                    Stream respPostStream = wRes.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"), true);
                    resResult = readerPost.ReadToEnd();
                    LogWriteNoTime(resResult);
                    LogWriteNoTime("");
                }
                return resResult;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    LogWriteNoTime("HTTP/1.1 " + (int)resp.StatusCode + " " + resp.StatusCode.ToString());
                    LogWriteNoTime("");
                    for (int i = 0; i < resp.Headers.Count; ++i)
                        LogWriteNoTime(" " + resp.Headers.Keys[i] + ": " + resp.Headers[i]);
                    LogWriteNoTime("");

                    Stream respPostStream = resp.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"), true);
                    string resError = readerPost.ReadToEnd();
                    LogWriteNoTime(resError);
                    LogWriteNoTime("");
                    //LogWrite("[" + (int)resp.StatusCode + "] " + resp.StatusCode.ToString());
                }
                else
                {
                    LogWrite(ex.ToString());
                }
                return resResult;
            }
        }

        private void LogWrite(string data)
        {
            BeginInvoke(new Action(() =>
            {
                if (tbLog.TextLength > 5000)
                    tbLog.Text = string.Empty;
                tbLog.AppendText(Environment.NewLine);
                tbLog.AppendText(DateTime.Now.ToString("MM/dd HH:mm:ss ") + data);
                tbLog.SelectionStart = tbLog.TextLength;
                tbLog.ScrollToCaret();
            }));
        }

        private void LogWriteNoTime(string data)
        {
            BeginInvoke(new Action(() =>
            {
                if (tbLog.TextLength > 5000)
                    tbLog.Text = string.Empty;
                tbLog.AppendText(Environment.NewLine);
                data = data.Replace("><", ">" + Environment.NewLine + "<");         // xml tag 위치에 줄바꿈 삽입
                tbLog.AppendText(" " + data);
                tbLog.SelectionStart = tbLog.TextLength;
                tbLog.ScrollToCaret();
            }));
        }

        /***** 아래부터는 Http Server 관련 *****/
        HttpListener listener;
        private void StartHttpServer()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://+:" + tbSeverPort.Text + "/");
            listener.Start();
            listener.BeginGetContext(this.OnRequested, this.listener);
            LogWrite("StartHttpServer");
        }

        private void StopHttpServer()
        {
            this.listener.Close();
        }

        private void OnRequested(IAsyncResult result)
        {
            HttpListener listener = (HttpListener)result.AsyncState;
            if (!listener.IsListening)
            {
                LogWrite("listening finished.");
                return;
            }

            LogWrite("OnRequested start.");
            LogWrite("OnRequested result.IsCompleted " + result.IsCompleted);
            LogWrite("OnRequested result.CompletedSynchronously " + result.CompletedSynchronously);
            LogWrite("OnRequested listener.IsListening " + listener.IsListening);

            HttpListenerContext ctx = listener.EndGetContext(result);
            HttpListenerRequest req = null;
            HttpListenerResponse res = null;
            StreamReader reader = null;
            StreamWriter writer = null;

            try
            {
                req = ctx.Request;
                res = ctx.Response;

                DisplayWebHeaderCollection(req);

                reader = new StreamReader(req.InputStream);
                writer = new StreamWriter(res.OutputStream);

                string received = reader.ReadToEnd();
                if (received != string.Empty)
                {
                    LogWrite("[ 수신 데이터 ]");
                    LogWrite(received);
                    ParsingJson(received, req.Url.AbsolutePath);
                }
                //writer.Write(received);
                //writer.Flush();       

                //res.StatusCode = (int)HttpStatusCode.NotFound;
                res.Headers.Add("X-M2M-RI", "response_1");
                res.Headers.Add("X-M2M-RSC", "2000");
                res.StatusCode = (int)HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                LogWrite(ex.ToString());
            }
            finally
            {
                try
                {
                    if (null != writer) writer.Close();
                    if (null != reader) reader.Close();
                    if (null != res) res.Close();  // close할 때 응답이 완료됨..
                }
                catch (Exception ex)
                {
                    LogWrite(ex.ToString());
                }
            }

            listener.BeginGetContext(this.OnRequested, listener);
        }

        public void DisplayWebHeaderCollection(HttpListenerRequest request)
        {
            LogWrite("[ request.Url.AbsolutePath ]");
            LogWrite("   " + request.Url.AbsolutePath);

            System.Collections.Specialized.NameValueCollection headers = request.Headers;

            foreach (string key in headers.AllKeys)
            {
                string[] values = headers.GetValues(key);
                if (values.Length > 0)
                {
                    LogWrite("[ " + key + " ]");
                    foreach (string value in values)
                    {
                        LogWrite("   " + value);
                    }
                }
                else
                    LogWrite("There is no value associated with the header.");
            }
        }

        private void ParsingJson(string jsonStr, string path)
        {
            try
            {
                JObject obj = JObject.Parse(jsonStr);
                if (path == "/" + svr.entityId + "/10250/0/0") // 데이터 수신
                {
                    string temp = obj["nev"]["rep"]["m2m:cin"]["con"].ToString();
                    string data = Encoding.UTF8.GetString(Convert.FromBase64String(temp));
                    string deviceEntityId = obj["cr"].ToString();
                    if (data != string.Empty)
                        LogWrite("[" + deviceEntityId + "][데이터 수신]" + data);
                }
                else if (path == "/" + svr.entityId + "/bs") // 부트스트랩
                {
                    string deviceEntityId = obj["cr"].ToString();
                    LogWrite("[" + deviceEntityId + "] Bootstrap 요청 수신");
                }
                else if (path == "/" + svr.entityId + "/rd") // 레지스터
                {
                    string deviceEntityId = obj["cr"].ToString();
                    LogWrite("[" + deviceEntityId + "] Registration 요청 수신");
                }
                else
                {
                    LogWrite("[ParsingJson] path = " + path);
                }
            }
            catch (Exception ex)
            {
                LogWrite(ex.ToString());
            }
        }
    }

    public class Device
    {
        public string imsi { get; set; } // 디바이스 전화번호
        public string iccid { get; set; } // 디바이스 ICCID
        public string entityId { get; set; } // oneM2M 디바이스 EntityID
    }

    public class ServiceServer
    {
        public string svcSvrCd { get; set; } // 서비스 서버의 시퀀스
        public string svcCd { get; set; } // 서비스 서버의 서비스코드
        public string svcSvrNum { get; set; } // 서비스 서버의 Num ber

        public string enrmtKey { get; set; } // oneM2M 인증 KeyID를 생성하기 위한 Key
        public string entityId { get; set; } // oneM2M에서 사용하는 서버 ID
        public string token { get; set; } // 인증구간 통신을 위해 발급하는 Token

        public string enrmtKeyId { get; set; } // MEF 인증 결과를 통해 생성하는 ID

        public string remoteCSEName { get; set; } // RemoteCSE 리소스 이름
    }

    public class ReqHeader
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public string Accept { get; set; }
        public string ContentType { get; set; }
        public string X_M2M_RI { get; set; } // Request ID(임의 값)
        public string X_M2M_Origin { get; set; } // 서비스서버의 Entity ID
        public string X_MEF_TK { get; set; } // Password : MEF 인증으로 받은 Token 값
        public string X_MEF_EKI { get; set; } // Username(EKI) : MEF 인증으로 받은 Enrollment Key 로 생성한 Enrollment Key ID
        public string X_M2M_NM { get; set; } // 리소스 이름
    }

}
