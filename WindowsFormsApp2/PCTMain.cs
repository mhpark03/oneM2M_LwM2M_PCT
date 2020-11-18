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
            closed,
            booting,
            idle,
            getmodel,
            getmanufac,
            getimsi,
            getimsiwr,
            geticcid,
            autogetmodel,
            autogetmodelgmm,
            autogetmanufac,
            autogetimsi,
            autogetimsiwr,
            autogeticcid,

            bootstrap,
            setserverinfo,
            setserverinfotpb23,
            setmefserverinfo,
            sethttpserverinfo,
            getserverinfo,
            setncdp,
            setservertype,
            setepns,
            setmbsps,
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

            holdoffbc95,
            lwm2mresetbc95,
            disablebc95,
            getsvripbc95,
            setsvrbsbc95,
            setsvripbc95,
            actsetsvrbsbc95,
            actsetsvripbc95,
            autosetsvrbsbc95,
            autosetsvripbc95,
            getepnsbc95,
            setepnsbc95,
            autosetepnsbc95,
            getmbspsbc95,
            setmbspsbc95,
            autosetmbspsbc95,
            bootstrapbc95,
            rebootbc95,

            sendonemsgstr,
            sendonemsgsvr,
            responemsgsvr,

            getonem2mmode,
            setonem2mmode,
            setmefauth,
            fotamefauthnt,
            mfotamefauth,
            getCSEbase,
            getremoteCSE,
            setremoteCSE,
            updateremoteCSE,
            delremoteCSE,
            setcontainer,
            delcontainer,
            setsubscript,
            delsubscript,
            getonem2mdata,
            getACP,
            setACP,
            updateACP,
            delACP,
            setrcvauto,
            setrcvmanu,

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
            registerbc95,
            deregisterbc95,
            sendLWM2Mdatatpb23,
            receiveLWM2Mdatatpb23,
            downloadMDLFOTAtpb23,
            updateMDLFOTAtpb23,
            lwm2mresettpb23,
            sendmsgstrtpb23,
            sendmsgstrbc95,
            sendmsghextpb23,
            sendmsgvertpb23,
            sendmsgverbc95,

            geticcidamtel,
            autogeticcidamtel,

            geticcidlg,
            autogeticcidlg,

            geticcidgct,
            autogeticcidgct,

            geticcidbc95,
            autogeticcidbc95,

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
            rfofftld,
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
            getmodemvergct,
            autogetmodemvergct,
            getmodemvertld,
            autogetmodemvertld,
            getmodemverwr,
            autogetmodemverwr,
            getmodemverbc95,
            autogetmodemverbc95,
            getNWmode,
            autogetNWmode,

            lwm2mtc0201,
            lwm2mtc0202,
            lwm2mtc0203,

            lwm2mtc0301,
            lwm2mtc0302,
            lwm2mtc0303,

            lwm2mtc0401,

            lwm2mtc0501,
            lwm2mtc0502,

            lwm2mtc0601,
            lwm2mtc0602,
            lwm2mtc0603,

            onem2mtc0201011,        // MEF server 설정
            onem2mtc0201012,        // BRK server 설정
            onem2mtc0201013,        // server 설정 값 확인
            onem2mtc0201021,        // 플랫폼 Agent 동작 확인
            onem2mtc0201022,        // 플랫폼 Agent  동작 설정
            onem2mtc0201023,        // 플랫폼 Agent 설정 결과 확인

            onem2mtc020201,         // MEF 인증 요청

            onem2mtc020301,         // remoteCSE 조회 결과에 따라 remoteCSE 신규생성/업데이트 분기 

            onem2mtc020401,         // CSEBase  조회

            onem2mtc0205011,        // remoteCSE 조회-업데이트-삭제후 생성
            onem2mtc0205012,        // remoteCSE 신규 생성 - 업데이트
            onem2mtc0205021,        // 수신 폴더 생성 1회 요청- 성공시 송신 폴더 생성/오류시 수신 폴더 삭제 요청
            onem2mtc0205022,        // 송신 폴더 생성 성공/오류 무관하게 구독 설정 시험 진행
            onem2mtc0205023,        // 수신 폴더 중복 생성 오류 - 삭제 후 생성 요청
            onem2mtc0205031,        // 구독 1회 신청 - 성공시 데이터 전송/오류시 구독 삭제 요청
            onem2mtc0205032,        // 구독 재 생성 - 데이터 전송
            onem2mtc020504,         // 서버 동작시 송신 폴더에 데이터 생성 / 단말 단독 실행시 수신 폴더에 데이터 생성
            onem2mtc0205051,        // remote 업데이트 - 삭제/생성 후 폴더 생성
            onem2mtc0205052,        // remote 업데이트 - 폴더 생성

            onem2mtc020601,         // data noti 이벤트 
            onem2mtc020602,         // data 수신 모드 설정 (자동)
            onem2mtc020603,         // 자동수신
            onem2mtc0206041,         // 구독신청 - data 수신
            onem2mtc0206042,         // 자동수신 - 수동설정 - data 수신

            onem2mtc020701,

            onem2mtc0208011,        // 모듈 OFF
            onem2mtc0208012,        // 모듈 ON - POA 업데이트 이벤트 대기

            onem2mtc0209011,        // ACP 1회 생성
            onem2mtc0209012,        // ACP 생성 오류(존재)/삭제후 생성
            onem2mtc0209013,        // ACP 조회오류(미존재)/생성
            onem2mtc020902,         // ACP 조회
            onem2mtc020903,
            onem2mtc0209041,
            onem2mtc0209042,

            onem2mtc021001,
            onem2mtc021002,         // push test는 별도 수동 진행
            onem2mtc021003,
            onem2mtc021004,

            onem2mtc021101,
            onem2mtc021102,         //  push test는 별도 수동 진행
            onem2mtc021103,
            onem2mtc0211041,        // module version finsh를 위해 MEF인증 요청
            onem2mtc0211042,        // module version report 요청
            onem2mtc0211043,        // module version 완료
            onem2mtc0211044,        // 결과 확인을 위해 module version read

            //onem2mtc021201,         // 데이터 삭제 시험 불필요
            onem2mtc0212021,         // 구독 등록 존재하여 삭제 후 생성 요청
            onem2mtc0212022,         // 구독 삭제 - 폴더 삭제 시험
            onem2mtc0212031,        // 수신 폴더 존재하여 삭제 후 생성 요청
            onem2mtc0212032,        // 폴더 삭제 - remoteCSE 삭제 시험
            onem2mtc0212041,        // remoteCSE 존재하여 삭제 후 생성 요청
            onem2mtc0212042,        // remoteCSE 삭제 (TC 마지막)

        }

        private enum lwm2mtc
        {
            tc0201,
            tc0202,
            tc0203,

            tc0301,
            tc0302,
            tc0303,

            tc0401,

            tc0501,
            tc0502,

            tc0601,
            tc0602,
            tc0603,
        }

        private enum onem2mtc
        {
            tc020101,
            tc020102,

            tc020201,

            tc020301,

            tc020401,

            tc020501,
            tc020502,
            tc020503,
            tc020504,
            tc020505,

            tc020601,
            tc020602,
            tc020603,
            tc020604,

            tc020701,

            tc020801,

            tc020901,
            tc020902,
            tc020903,
            tc020904,

            tc021001,
            tc021002,
            tc021003,
            tc021004,

            tc021101,
            tc021102,
            tc021103,
            tc021104,

            //tc021201,
            tc021202,
            tc021203,
            tc021204,

        }

        int baudrate = 115200;

        string dataIN;
        string serverip = "106.103.233.155";
        string serverport = "5783";
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

        string oneM2MMEFIP = "106.103.234.198";
        string oneM2MMEFPort = "80";
        string oneM2MBRKIP = "106.103.234.117";
        string oneM2MBRKPort = "80";

        Dictionary<string, string> commands = new Dictionary<string, string>();
        Dictionary<char, int> bcdvalues = new Dictionary<char, int>();
        Dictionary<string, string> lwm2mtclist = new Dictionary<string, string>();
        Dictionary<string, string> onem2mtclist = new Dictionary<string, string>();

        HttpWebRequest wReq;
        HttpWebResponse wRes;

        string brkUrl = "https://testbrk.onem2m.uplus.co.kr:443"; // BRK(oneM2M 개발기)       
        string brkUrlL = "https://testbrks.onem2m.uplus.co.kr:8443"; // BRK(LwM2M 개발기)       
        string mefUrl = "https://testmef.onem2m.uplus.co.kr:443"; // MEF(개발기)

        ServiceServer svr = new ServiceServer();
        Device dev = new Device();
        TCResult tc = new TCResult();

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

            gbModule.Enabled = false;

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
            commands.Add("getimsiwr", "AT*IMSI?");
            commands.Add("geticcid", "AT+ICCID");
            commands.Add("geticcidtpb23", "AT+MUICCID");
            commands.Add("geticcidlg", "AT+MUICCID=?");
            commands.Add("geticcidamtel", "AT@ICCID?");
            commands.Add("geticcidgct", "AT%GICCID");
            commands.Add("geticcidbc95", "AT+NCCID");
            commands.Add("getmodel", "AT+CGMM");
            commands.Add("getmanufac", "AT+CGMI");
            commands.Add("setcereg", "AT+CEREG=1");
            commands.Add("setceregtpb23", "AT+CEREG=3");
            commands.Add("getcereg", "AT+CEREG?");
            commands.Add("reset", "AT+CFUN=1,1");

            commands.Add("resettpb23", "AT+NRB");

            commands.Add("autogetimsi", "AT+CIMI");
            commands.Add("autogetimsiwr", "AT*IMSI?");
            commands.Add("autogeticcid", "AT+ICCID");
            commands.Add("autogeticcidtpb23", "AT+MUICCID");
            commands.Add("autogeticcidamtel", "AT@ICCID?");
            commands.Add("autogeticcidlg", "AT+MUICCID=?");
            commands.Add("autogeticcidgct", "AT%GICCID");
            commands.Add("autogeticcidbc95", "AT+NCCID");
            commands.Add("autogetmodel", "AT+CGMM");
            commands.Add("autogetmodelgmm", "AT+GMM");
            commands.Add("autogetmanufac", "AT+CGMI");

            commands.Add("bootstrap", "AT+QLWM2M=\"bootstrap\",1");
            commands.Add("setserverinfo", "AT+QLWM2M=\"cdp\",");
            commands.Add("setservertype", "AT+QLWM2M=\"select\",2");
            //commands.Add("setepns", "AT+QLWM2M=\"epns\",1,\"");
            commands.Add("setepns", "AT+QLWM2M=\"epns\",0,\"");
            commands.Add("setmbsps", "AT+QLWM2M=\"mbsps\",\"");
            commands.Add("enable", "AT+QLWM2M=\"enable\",1");
            commands.Add("register", "AT+QLWM2M=\"register\"");
            commands.Add("deregister", "AT+QLWM2M=\"deregister\"");
            commands.Add("disable", "AT+QLWM2M=\"enable\",0");
            commands.Add("lwm2mreset", "AT+QLWM2M=\"reset\"");
            commands.Add("sendmsgstr", "AT+QLWM2M=\"uldata\",10250,");
            commands.Add("sendmsghex", "AT+QLWM2M=\"ulhex\",10250,");
            commands.Add("sendmsgver", "AT+QLWM2M=\"uldata\",26241,");

            commands.Add("disable_bg96", "AT+QLWM2M=\"enable\",0");
            commands.Add("enable_bg96", "AT+QLWM2M=\"enable\",1");
            commands.Add("setcdp_bg96", "AT+QLWM2M=\"cdp\",");

            commands.Add("sendonemsgstr", "AT$OM_C_INS_REQ=");
            commands.Add("sendonemsgsvr", "AT$OM_C_RCIN_REQ=");
            commands.Add("responemsgsvr", "AT$OM_S_RCIN_REQ=");

            commands.Add("getonem2mmode", "AT$LGTMPF?");
            commands.Add("onem2mtc0201023", "AT$LGTMPF?");
            commands.Add("setonem2mmode", "AT$LGTMPF=5");
            commands.Add("onem2mtc0201022", "AT$LGTMPF=5");
            commands.Add("setmefauth", "AT$OM_AUTH_REQ=");
            commands.Add("fotamefauthnt", "AT$OM_AUTH_REQ=");
            commands.Add("mfotamefauth", "AT$OM_AUTH_REQ=");
            commands.Add("getCSEbase", "AT$OM_B_CSE_REQ");
            commands.Add("getremoteCSE", "AT$OM_R_CSE_REQ");
            commands.Add("setremoteCSE", "AT$OM_C_CSE_REQ");
            commands.Add("updateremoteCSE", "AT$OM_U_CSE_REQ");
            commands.Add("delremoteCSE", "AT$OM_D_CSE_REQ");
            commands.Add("setcontainer", "AT$OM_C_CON_REQ=");
            commands.Add("delcontainer", "AT$OM_D_CON_REQ=");
            commands.Add("setsubscript", "AT$OM_C_SUB_REQ=");
            commands.Add("delsubscript", "AT$OM_D_SUB_REQ=");
            commands.Add("getonem2mdata", "AT$OM_R_INS_REQ=");
            commands.Add("getACP", "AT$OM_R_ACP_REQ");
            commands.Add("setACP", "AT$OM_C_ACP_REQ=63,*");
            commands.Add("updateACP", "AT$OM_U_ACP_REQ=47,*");
            commands.Add("delACP", "AT$OM_D_ACP_REQ");
            commands.Add("setrcvauto", "AT$OM_MODE=ON");
            commands.Add("setrcvmanu", "AT$OM_MODE=OFF");

            commands.Add("setserverinfotpb23", "AT+NCDP=");
            commands.Add("setncdp", "AT+NCDP=");
            commands.Add("bootstrapmodetpb23", "AT+MBOOTSTRAPMODE=1");
            commands.Add("setepnstpb23", "AT+MLWEPNS=");
            commands.Add("setmbspstpb23", "AT+MLWMBSPS=serviceCode=");
            commands.Add("bootstraptpb23", "AT+MLWGOBOOTSTRAP=1");
            commands.Add("registertpb23", "AT+MLWSREGIND=0");
            commands.Add("deregistertpb23", "AT+MLWSREGIND=1");
            commands.Add("registerbc95", "AT+QLWSREGIND=0");
            commands.Add("deregisterbc95", "AT+QLWSREGIND=1");
            commands.Add("lwm2mresettpb23", "AT+MBOOTSTRAPMODE=0");
            commands.Add("sendmsgstrtpb23", "AT+MLWULDATA=");
            commands.Add("sendmsgstbc95", "AT+QLWULDATA=0,");
            commands.Add("sendmsgvertpb23", "AT+MLWULDATA=1,");
            commands.Add("sendmsgverbc95", "AT+QLWULDATA=1,");

            commands.Add("holdoffbc95", "AT+QBOOTSTRAPHOLDOFF=0");
            commands.Add("lwm2mresetbc95", "AT+QREGSWT=2");
            commands.Add("getsvripbc95", "AT+QLWSERVERIP?");
            commands.Add("setsvrbsbc95", "AT+QLWSERVERIP=BS,");
            commands.Add("setsvripbc95", "AT+QLWSERVERIP=LWM2M,");
            commands.Add("autosetsvrbsbc95", "AT+QLWSERVERIP=BS,");
            commands.Add("autosetsvripbc95", "AT+QLWSERVERIP=LWM2M,");
            commands.Add("getepnsbc95", "AT+QLWEPNS?");
            commands.Add("setepnsbc95", "AT+QLWEPNS=0,");
            commands.Add("getmbspsbc95", "AT+QLWMBSPS?");
            commands.Add("setmbspsbc95", "AT+QLWMBSPS=");
            commands.Add("bootstrapbc95", "AT+QREGSWT=1");      // auto (manual=0)
            commands.Add("rebootbc95", "AT+NRB");

            commands.Add("setmefserverinfo", "AT$OM_SVR_INFO=1,");
            commands.Add("sethttpserverinfo", "AT$OM_SVR_INFO=2,");
            commands.Add("getserverinfo", "AT$OM_SVR_INFO?");

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
            commands.Add("rfofftld", "AT+CFUN=4");
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
            commands.Add("getmodemvergct", "AT%GSWV1");
            commands.Add("autogetmodemvergct", "AT%GSWV1");
            commands.Add("getmodemvertld", "AT$$VER?");
            commands.Add("autogetmodemvertld", "AT$$VER?");
            commands.Add("getmodemverwr", "AT$$SWVER?");
            commands.Add("autogetmodemverwr", "AT$$SWVER?");
            commands.Add("getmodemverbc95", "AT+CGMR");
            commands.Add("autogetmodemverbc95", "AT+CGMR");

            lwm2mtclist.Add("tc0201", "2.1 LWM2M 단말 초기 설정 동작 확인 시험");
            lwm2mtclist.Add("tc0202", "2.2 Bootstrap 절차 및 AT command 확인 시험");
            lwm2mtclist.Add("tc0203", "2.3 Bootstrap 상세 동작 확인 시험");
            lwm2mtclist.Add("tc0301", "3.1 Register 절차 및 AT command 확인 시험");
            lwm2mtclist.Add("tc0302", "3.2 Register 상세 동작 확인 시험");
            lwm2mtclist.Add("tc0303", "3.3 Register Update 확인 시험");
            lwm2mtclist.Add("tc0401", "4.1 De-Register 절차 및 AT command 확인 시험");
            lwm2mtclist.Add("tc0501", "5.1 Data 송신 (Data Notification)");
            lwm2mtclist.Add("tc0502", "5.2 Data 수신 (Device Control)");
            lwm2mtclist.Add("tc0601", "6.1 펌웨어 체크 동작 확인");
            lwm2mtclist.Add("tc0602", "6.2 모듈 펌웨어 업그레이드 시험");
            lwm2mtclist.Add("tc0603", "6.3 단말 펌웨어 업그레이드 시험");

            onem2mtclist.Add("tc020101", "2.1.1 oneM2M URL 설정");
            onem2mtclist.Add("tc020102", "2.1.2 oneM2M 플랫폼 동작 설정");
            onem2mtclist.Add("tc020201", "2.2.1 MEF 인증 (at command oneM2M연동 모두 확인)");
            onem2mtclist.Add("tc020301", "2.3.1 단말 IP 송신(remoteCSE조회)");
            onem2mtclist.Add("tc020401", "2.4.1 CSEBase 조회");
            onem2mtclist.Add("tc020501", "2.5.1 remoteCSE 생성요청");
            onem2mtclist.Add("tc020502", "2.5.2 데이터 폴더 생성");
            onem2mtclist.Add("tc020503", "2.5.3 구독 등록");
            onem2mtclist.Add("tc020504", "2.5.4 데이터 생성");
            onem2mtclist.Add("tc020505", "2.5.5 remoteCSE 업데이트요청");
            onem2mtclist.Add("tc020601", "2.6.1 데이터 수신 이벤트");
            onem2mtclist.Add("tc020602", "2.6.2 데이터 자동 수신 모드 설정");
            onem2mtclist.Add("tc020603", "2.6.3 데이터 자동 수신");
            onem2mtclist.Add("tc020604", "2.6.4 데이터 수동 수신 모드 설정");
            onem2mtclist.Add("tc020701", "2.7.1 데이터 읽기");
            onem2mtclist.Add("tc020801", "2.8.1 M2MM(단말) IP 변경");
            onem2mtclist.Add("tc020901", "2.9.1 권한 관리 정보 생성");
            onem2mtclist.Add("tc020902", "2.9.2 권한 관리 정보 읽기");
            onem2mtclist.Add("tc020903", "2.9.3 권한 관리 정보 업데이트");
            onem2mtclist.Add("tc020904", "2.9.4 권한 관리 정보 삭제");
            onem2mtclist.Add("tc021001", "2.10.1 Device FW 신규 버전 요청");
            onem2mtclist.Add("tc021002", "2.10.2 Device FW update Noti");
            onem2mtclist.Add("tc021003", "2.10.3 Device FW update start");
            onem2mtclist.Add("tc021004", "2.10.4 Device FW update finish");
            onem2mtclist.Add("tc021101", "2.11.1 Modem FW 신규 버전 요청");
            onem2mtclist.Add("tc021102", "2.11.2 Modem FW update Noti");
            onem2mtclist.Add("tc021103", "2.11.3 Modem FW update start");
            onem2mtclist.Add("tc021104", "2.11.4 Modem FW update Finish");
            //onem2mtclist.Add("tc021201", "2.12.1 데이터 삭제");
            onem2mtclist.Add("tc021202", "2.12.2 구독 등록 삭제");
            onem2mtclist.Add("tc021203", "2.12.3 데이터 폴더 삭제");
            onem2mtclist.Add("tc021204", "2.12.4 remoteCSE 삭제");

            /////   디바이스 초기값 설정
            dev.entityId = string.Empty;
            dev.type = string.Empty;

            /////   서버 초기값 설정
            svr.enrmtKeyId = string.Empty;

            tc.state = string.Empty;
            tc.lwm2m = new string[(int)lwm2mtc.tc0603+1];
            tc.onem2m = new string[(int)onem2mtc.tc021204+1];

            tbTCResult.Text = string.Empty;
            tBoxDataIN.Text = string.Empty;
            tbLog.Text = string.Empty;
        }

        // COMM PORT 연결
        private void ProgressBar1_Click(object sender, EventArgs e)
        {
            if(cBoxCOMPORT.Items.Count == 0)
            {
                string[] ports = SerialPort.GetPortNames();
                if (ports.Length == 0)
                {
                    logPrintInTextBox("연결 가능한 COM PORT가 없습니다.", "");
                }
                else
                {
                    cBoxCOMPORT.Items.AddRange(ports);
                    cBoxCOMPORT.SelectedIndex = 0;
                }
            }
            else if(serialPort1.IsOpen)
            {
                if (progressBar1.Value == 100)
                    this.doCloseComPort();
            }
            else
            {
                baudrate = 115200;
                this.doOpenComPort();
            }
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {
            if (cBoxCOMPORT.Items.Count == 0)
            {
                string[] ports = SerialPort.GetPortNames();
                if (ports.Length == 0)
                {
                    logPrintInTextBox("연결 가능한 COM PORT가 없습니다.", "");
                }
                else
                {
                    cBoxCOMPORT.Items.AddRange(ports);
                    cBoxCOMPORT.SelectedIndex = 0;
                }
            }
            else if (serialPort1.IsOpen)
            {
                if (progressBar2.Value == 100)
                    this.doCloseComPort();
            }
            else
            {
                baudrate = 9600;
                this.doOpenComPort();
            }
        }

        // 모듈 정보 읽기
        private void btnModuleInfo_Click(object sender, EventArgs e)
        {
            startLwM2MTC("tc0201");

            getDeviveInfo();
        }

        // AT command 보내기
        private void btnATCMD_Click(object sender, EventArgs e)
        {
            if (cBoxATCMD.Text.Length != 0)
                DataOutandstore(cBoxATCMD.Text);
            else
                logPrintInTextBox("전송할 명령어가 없습니다.", "");
        }

        // oneM2M 플랫폼서버로 단말 인증 요청
        private void btnMEFAuthD_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                // oneM2M 플랫폼 인증 요청
                startoneM2MTC("tc020101");
                //AT$OM_SVR_INFO=<svr>,<ip>,<port>
                this.sendDataOut(commands["setmefserverinfo"] + oneM2MMEFIP + "," + oneM2MMEFPort);
                lbActionState.Text = states.setmefserverinfo.ToString();
            }
        }

        // oneM2M 플랫폼서버로 CSEBase확인
        private void btnGetCSED_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc020401");
                this.sendDataOut(commands["getCSEbase"]);
                lbActionState.Text = states.getCSEbase.ToString();
            }
        }

        // oneM2M 플랫폼 서버로 remoteCSE 조회
        private void btnGetDeviceCSR_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc020301");
                this.sendDataOut(commands["getremoteCSE"]);
                lbActionState.Text = states.getremoteCSE.ToString();
            }
        }

        // oneM2M 플랫폼 서버 remoteCSE 생성
        private void btnCreateDeviceCSR_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc020501");
                this.sendDataOut(commands["setremoteCSE"]);
                lbActionState.Text = states.setremoteCSE.ToString();
            }
        }

        // 플랫폼 서버 remoteCSE 수정 (단말 IP 변경시 poa update 필수)
        private void btnDeviceUpdateCSR_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                //startoneM2MTC("tc020501");
                this.sendDataOut(commands["updateremoteCSE"]);
                lbActionState.Text = states.updateremoteCSE.ToString();
            }
        }

        // 플랫폼 서버 remoteCSE 삭제
        private void btnDelDeviceCSR_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc021204");
                this.sendDataOut(commands["delremoteCSE"]);
                lbActionState.Text = states.delremoteCSE.ToString();
            }
        }

        // 디바이스 to 서비스서버 데이터 전송을 위한 플랫폼 서버 폴더 생성
        private void btnSetContainer_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc020502");
                this.sendDataOut(commands["setcontainer"] + "DtoS");
                lbActionState.Text = states.setcontainer.ToString();
            }
            else
                logPrintInTextBox("디바이스 상태 확인바랍니다.","");
        }

        // 디바이스 to 서비스서버 데이터 전송을 위한 플랫폼 서버 폴더 삭제
        private void btnDelContainer_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                if (isDeviceInfo())
                {
                    startoneM2MTC("tc021203");
                    this.sendDataOut(commands["delcontainer"] + "DtoS");
                    lbActionState.Text = states.delcontainer.ToString();
                }
                else
                    logPrintInTextBox("디바이스 상태 확인바랍니다.", "");
            }
        }

        // from 서비스서버 데이터 수신을 위한 플랫폼 서버 폴더 생성
        private void btnSetRxContainer_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc020502");
                this.sendDataOut(commands["setcontainer"] + "StoD");
                lbActionState.Text = states.setcontainer.ToString();
            }
            else
                logPrintInTextBox("디바이스 상태 확인바랍니다.", "");
        }

        // from 서비스서버 데이터 수신을 위한 플랫폼 서버 폴더 삭제
        private void btnDelRxContainer_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                if (isDeviceInfo())
                {
                    startoneM2MTC("tc021203");
                    this.sendDataOut(commands["delcontainer"] + "StoD");
                    lbActionState.Text = states.delcontainer.ToString();
                }
                else
                    logPrintInTextBox("디바이스 상태 확인바랍니다.", "");
            }
        }

        // from 서비스서버 데이터 수신을 위한 플랫폼 서버 구독 신청
        private void btnSetSubscript_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc020503");
                this.sendDataOut(commands["setsubscript"] + "StoD");
                lbActionState.Text = states.setsubscript.ToString();
            }
        }

        // from 서비스서버 데이터 수신을 위한 플랫폼 서버 구독 해제
        private void btnDelSubscript_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc021202");
                this.sendDataOut(commands["delsubscript"] + "StoD");
                lbActionState.Text = states.delsubscript.ToString();
            }
        }

        // 플랫폼 서버 데이터 전송
        private void btnSendDataOneM2M_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc020504");
                // Data send to SERVER (string original)
                //AT$OM_C_INS_REQ=<object>,<length>,<data>
                string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                this.sendDataOut(commands["sendonemsgstr"] + "DtoS" + "," + txData.Length + "," + txData);
                lbActionState.Text = states.sendonemsgstr.ToString();
                lbSendedData.Text = txData;
            }
        }

        // 플랫폼 서버 저장 데이터 수신
        private void btnRcvDataOneM2M_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc020701");
                // 플랫폼 서버에 data 수신 요청
                this.sendDataOut(commands["getonem2mdata"] + "StoD");
                lbActionState.Text = states.getonem2mdata.ToString();
            }
        }

        // 디바이스 버전 보고
        private void btnoneM2MDeviceVer_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc021004");
                // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                this.sendDataOut(commands["fotamefauthnt"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + ",D-" + dev.imsi);
                lbActionState.Text = states.fotamefauthnt.ToString();
                nextcommand = "skip";
            }
        }

        // 디바이스 버전 체크 (업버전이 있으면 다운로드)
        private void btnDeviceFOTA_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc021001");
            this.sendDataOut(commands["getdeviceSvrVer"]);
            lbActionState.Text = states.getdeviceSvrVer.ToString();
        }

        // 모듈 버전 보고
        private void btnoneM2MModuleVer_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startoneM2MTC("tc021104");
                // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                this.sendDataOut(commands["mfotamefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + ",D-" + dev.imsi);
                lbActionState.Text = states.mfotamefauth.ToString();
                nextcommand = "skip";
            }
        }

        // 모듈 버전 체크 (업버전이 있으면 다운로드)
        private void btnModemFOTA_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc021101");
            this.sendDataOut(commands["getmodemSvrVer"]);
            lbActionState.Text = states.getmodemSvrVer.ToString();
        }


        // LwM2M 플랫폼서버로 BOOTSTRAP 요청
        private void btnBootstrap_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startLwM2MTC("tc0202");

                DeviceProvision();
            }
        }

        // LwM2M 플랫폼서버로 REGISTER 요청
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startLwM2MTC("tc0301");

                if (dev.model == "BG96")
                {
                    // 플랫폼 등록 요청
                    //AT+QLWM2M="register"
                    this.sendDataOut(commands["register"]);
                    lbActionState.Text = states.register.ToString();
                }
                else if (dev.model.StartsWith("BC95", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // 플랫폼 등록 요청
                    //AT+QLWSREGIND=0
                    this.sendDataOut(commands["registerbc95"]);
                    lbActionState.Text = states.registerbc95.ToString();
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
        //입력 Text값을 플랫폼 서버로 전송
        private void btnSendData_Click(object sender, EventArgs e)
        {
            sendDataToServer();
        }

        // LwM2M 플랫폼서버로 DEREGISTER 요청
        private void btnDeregister_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startLwM2MTC("tc0401");

                if (dev.model == "BG96")
                {
                    // 플랫폼 등록해제 요청
                    //AT+QLWM2M="deregister"
                    this.sendDataOut(commands["deregister"]);
                    lbActionState.Text = states.deregister.ToString();
                }
                else if (dev.model.StartsWith("BC95", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // 플랫폼 등록해제 요청
                    //AT+QLWSREGIND=1
                    this.sendDataOut(commands["deregisterbc95"]);
                    lbActionState.Text = states.deregisterbc95.ToString();
                }
                else
                {
                    // 플랫폼 등록해제 요청
                    //AT+MLWSREGIND=1
                    this.sendDataOut(commands["deregistertpb23"]);
                    lbActionState.Text = states.deregistertpb23.ToString();
                }
            }
        }

        // LwM2M 플랫폼서버로 DEVICE VERSION REPORT
        private void btnDeviceVerLwM2M_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                startLwM2MTC("tc0603");
                DeviceFWVerSend(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
            }
        }

        // LwM2M 플랫폼 설정 해제
        private void btnLwM2MDisable_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                if (dev.model == "BG96")
                {
                    // 플랫폼 설정 해제 요청
                    //AT+QLWM2M="enable",0
                    this.sendDataOut(commands["disable_bg96"]);
                    lbActionState.Text = states.disable_bg96.ToString();
                }
                else if (dev.model.StartsWith("BC95", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // 플랫폼 설정 해제 요청
                    //AT+QREGSWT=2
                    this.sendDataOut(commands["lwm2mresetbc95"]);
                    lbActionState.Text = states.disablebc95.ToString();
                }
                else if (dev.model == "TPB23")
                {
                    // 플랫폼 정보 초기화
                    this.sendDataOut(commands["lwm2mresettpb23"]);
                    lbActionState.Text = states.lwm2mresettpb23.ToString();
                }
            }
        }

        /// <summary>
        /// 서비스 서버 관련 동작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        // 플랫폼 서버에 등록된 디바이스 리소스 확인 (oneM2M 플랫폼 DB)
        private void btnDeviceCheck_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
            {
                RetrivePoaToPlatform();
                RetriveDverToPlatform();
                RetriveMverToPlatform();
            }
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
                startoneM2MTC("tc020601");
                lbSvroneM2MData.Text = SendDataToPlatform("oneM2M");
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
                startLwM2MTC("tc0502");

                lbSvrLwM2MData.Text = SendDataToPlatform("LwM2M");
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
                serialPort1.BaudRate = baudrate;
                serialPort1.DataBits = (int)8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.ReadTimeout = (int)500;
                serialPort1.WriteTimeout = (int)500;
                serialPort1.DtrEnable = false;
                serialPort1.RtsEnable = false;

                serialPort1.Open();
                if (baudrate == 115200)
                    progressBar1.Value = 100;
                else
                    progressBar2.Value = 100;
                gbModule.Enabled = true;
                logPrintInTextBox("COM PORT가 연결 되었습니다.", "");
                if(lbActionState.Text == states.closed.ToString())
                    lbActionState.Text = states.idle.ToString();
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
            progressBar2.Value = 0;
            gbModule.Enabled = false;
            logPrintInTextBox("COM PORT가 해제 되었습니다.","");
            lbActionState.Text = states.closed.ToString();
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
                    sendmsg = dataOUT + "\r\n";

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
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 시험절차서 시험 결과를 tbTCResult에 표시.
        public void logPrintTC(string message)
        {
            BeginInvoke(new Action(() =>
            {
                tbTCResult.AppendText(Environment.NewLine);
                tbTCResult.AppendText(DateTime.Now.ToString("hh:mm:ss.fff") + " (" + lbActionState.Text + ") : " + message);
                tbTCResult.SelectionStart = tbTCResult.TextLength;
                tbTCResult.ScrollToCaret();
            }));
        }

        // 송수신 명령/응답 값과 동작 설명을 textbox에 삽입하고 앱 종료시 로그파일로 저장한다.
        public void logPrintInTextBox(string message, string kind)
        {
            string displayMsg = makeLogPrintLine(kind);

            tBoxDataIN.AppendText(Environment.NewLine);
            tBoxDataIN.AppendText(displayMsg+message);
            tBoxDataIN.SelectionStart = tBoxDataIN.TextLength;
            tBoxDataIN.ScrollToCaret();

        }

        // 명령어에 대해 동작시각과 방향을 포함하여 저장한다.
        private string makeLogPrintLine(string kind)
        {
            string msg_form;
            DateTime currenttime = DateTime.Now;
            msg_form = currenttime.ToString("hh:mm:ss.fff : ") + "(" + lbActionState.Text + ") ";
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
            return msg_form;
        }

        // 수신 데이터 처리 thread 시작
        private void ShowData(object sender, EventArgs e)
        {
            char[] charValues = dataIN.ToCharArray();

            /* Debug를 위해 Hex로 문자열 표시*/
            /*
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
            */

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
                "%GICCID: ",    // ICCID (GCT 바인테크) 값을 저장한다.
                "+NCCID:",      // ICCID (BC95) 값을 저장한다.
                "+CGSN:",       // IMEI (NB TPB23모델) 값을 저장한다.
                "APPLICATION_A,",    // Modem verion (BC95) 값을 저장한다.
                "AT+MLWDLDATA=",    // LWM2M서버에서 data 수신이벤트
                "+NNMI:",    // LWM2M서버에서 data 수신이벤트
                "AT+MLWEVTIND=",    // LWM2M서버와 연동 상태 이벤트
                "+QLWEVTIND:",    // LWM2M서버와 연동 상태 이벤트
                "AT+CGMI",
                "AT",           // AT는 Device가 modem으로 요청하는 명령어로 무시하기 위함
                "+CEREG:",      // LTE network 상태를 확인하고 연결이 되어 있지 않으면 재접속 시도
                "+QLWEVENT:",    // 모듈 부팅시, LWM2M 등록 상태 이벤트, 진행 상태를 status bar에 진행율 표시
                "+QLWDLDATA:",
                "+QLWOBSERVE:",

                "$OM_SVR_INFO=",
                "$OM_B_CSE_RSP=",
                "$OM_R_CSE_RSP=",
                "$OM_C_CSE_RSP=",
                "$OM_D_CSE_RSP=",
                "$OM_C_CON_RSP=",
                "$OM_D_CON_RSP=",
                "$OM_C_SUB_RSP=",
                "$OM_D_SUB_RSP=",
                "$OM_C_INS_RSP=",
                "$OM_NOTI_IND=",
                "$OM_R_ACP_RSP=",
                "$OM_C_ACP_RSP=",
                "$OM_U_ACP_RSP=",
                "$OM_D_ACP_RSP=",
                "$OM_R_INS_RSP=",
                "$OM_C_MODEM_FWUP_RSP=",
                "$OM_MODEM_FWUP_RSP=",
                "$OM_MODEM_FWUP_FINISH=",
                "$OM_PUSH_MODEM_FWUP_RSP=",
                "$OM_MODEM_UPDATE_START",
                "$OM_MODEM_UPDATE_FINISH",
                "$OM_DEV_FWUP_RSP=",
                "$OM_PUSH_DEV_FWUP_RSP=",
                "$OM_DEV_FWDL_FINISH",
                "$OM_DEV_FWUP_FINISH=",
                "$LGTMPF=",
                "$OM_N_INS_RSP=",
                "$OM_S_RCIN_RSP=",

                "@NETSTI:",

                "*ST*INFO:",
                "$OM_AUTH_RSP=",
                "$OM_U_CSE_RSP=",
                "$OM_POA_NOTI=",

                "$OM_DEV_FWDL_START=",
                "$BIN_DATA=",
                "data=",

                "+QCFG: ",
                "FW_VER: ",
                "$$VER: ",
                "$$SWVER: ",

                "+QLWSERVERIP:BS,",
                "+QLWSERVERIP:LWM2M,",
                "+QLWEPNS: ",
                "+QLWMBSPS: ",
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
                    break;
                case "+ICCID:":
                    // AT+ICCID의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    setDeviceEntityID(str2);
                    logPrintInTextBox("ICCID가 저장되었습니다.", "");

                    if (lbActionState.Text == states.autogeticcid.ToString())
                    {
                        if (dev.model == "BG96" || dev.maker == "LIME-I Co., Ltd" || dev.model == "EC21" || dev.model == "EC25")
                        {
                            nextcommand = states.autogetmodemver.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                        }
                        else if (dev.model == "TPB23")
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
                    setDeviceEntityID(str2);
                    logPrintInTextBox("ICCID가 저장되었습니다.", "");

                    if (lbActionState.Text == states.autogeticcid.ToString())
                    {
                        if (dev.maker == "LIME-I Co., Ltd")
                        {
                            nextcommand = states.autogetmodemver.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                        }
                        else if (dev.maker == "QUALCOMM INCORPORATED")
                        {
                            nextcommand = states.autogetmodemvertld.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                        }
                        else if (dev.maker == "WOORINET")
                        {
                            nextcommand = states.autogetmodemverwr.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
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
                    setDeviceEntityID(str2);
                    logPrintInTextBox("ICCID가 저장되었습니다.", "");

                    if (lbActionState.Text == states.autogeticcidtpb23.ToString())
                    {
                        nextcommand = states.autogetmodemvertpb23.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                    }
                    else if (lbActionState.Text == states.autogeticcidlg.ToString())
                    {
                        this.sendDataOut(commands["autogetmodemver"]);
                        lbActionState.Text = states.autogetmodemver.ToString();
                    }
                    break;
                case "@ICCID:":
                    // AT@ICCID?의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    setDeviceEntityID(str2);
                    logPrintInTextBox("ICCID가 저장되었습니다.", "");

                    if (lbActionState.Text == states.autogeticcidamtel.ToString())
                    {
                        nextcommand = states.autogetmodemver.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                    }
                    break;
                case "%GICCID: ":
                    // AT%GICCID의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    setDeviceEntityID(str2);
                    logPrintInTextBox("ICCID가 저장되었습니다.", "");

                    if (lbActionState.Text == states.autogeticcidgct.ToString())
                    {
                        nextcommand = states.autogetmodemvergct.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                    }
                    break;
                case "+NCCID:":
                    // AT+NCCID (Quectel BC95모델)의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    setDeviceEntityID(str2);
                    logPrintInTextBox("ICCID가 저장되었습니다.", "");

                    if (lbActionState.Text == states.autogeticcidbc95.ToString())
                    {
                        nextcommand = states.autogetmodemverbc95.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                    }
                    break;
                case "+CEREG:":
                    // AT+CEREG의 응답으로 LTE attach 상태 확인하고 disable되어 있어면 attach 요청, 
                    // OK 응답이 따라온다

                    // 수신한 데이터에 대해 space로 시작하는지 확인한다.
                    if (str2.StartsWith(" "))
                    {
                        str2 = str2.Substring(1, str2.Length - 1);
                    }

                    string ltestatus = str2.Substring(0, 1);
                    if (ltestatus == "0")
                    {
                        if(lbActionState.Text == states.onem2mtc0208011.ToString())
                        {
                            this.sendDataOut(commands["rfon"]);
                            lbActionState.Text = states.onem2mtc0208012.ToString();

                            nextcommand = "skip";
                        }
                        else
                        {
                            if (dev.model == "TPB23" || dev.model.StartsWith("BC95", System.StringComparison.CurrentCultureIgnoreCase))
                            {
                                nextcommand = states.setceregtpb23.ToString();
                            }
                            else
                            {
                                nextcommand = states.setcereg.ToString();
                            }
                            logPrintInTextBox("LTE 연결을 요청이 필요합니다.", "");

                            lbActionState.Text = states.idle.ToString();
                        }
                    }
                    else if ((ltestatus == "1") || (ltestatus == "3"))
                    {
                        if (str2.Length > 1)
                        {
                            string lteregi = str2.Substring(2, 1);

                            if (lteregi == "0")
                            {
                                if (lbActionState.Text != states.onem2mtc0208011.ToString())
                                    lbActionState.Text = states.idle.ToString();
                                logPrintInTextBox("LTE 상태 확인이 필요합니다.", "");
                            }
                            else if ((lteregi == "1") || (lteregi == "5"))
                            {
                                logPrintInTextBox("LTE망에 연결 되었습니다.", "");
                            }
                        }
                        else
                        {
                            if ((str2 == "1") || (str2 == "5"))
                            {
                                logPrintInTextBox("LTE망에 연결 되었습니다.", "");
                            }
                        }
                    }
                    break;                    
                case "$OM_SVR_INFO=":
                    // oneM2M server 정보 확인
                    string[] servers = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

                    if (servers[0]==oneM2MMEFIP && servers[1]== oneM2MMEFPort && servers[2]== oneM2MBRKIP && servers[3]== oneM2MBRKPort)
                    {
                        logPrintInTextBox("oneM2M서버 설정이 완료되었습니다.", "");

                        if (tc.state == "tc020101")
                        {
                            endoneM2MTC(tc.state);
                            startoneM2MTC("tc020102");
                        }
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M 서버 설정 확인바랍니다.", "");
                        nextcommand = "";
                        lbActionState.Text = states.idle.ToString();
                    }
                    break;
                case "$OM_AUTH_RSP=":
                    // oneM2M 인증 결과
                    if (str2 == "2000")
                    {
                        logPrintInTextBox("oneM2M서버 인증 성공하였습니다.", "");

                        if (tc.state == "tc021004")         // Device FW 완료 보고
                        {
                            this.sendDataOut(commands["deviceFWUPfinish"]);
                            if(lbActionState.Text != states.onem2mtc021004.ToString())
                                lbActionState.Text = states.deviceFWUPfinish.ToString();
                        }
                        else if (tc.state == "tc021104")    // Modem FW 완료 보고
                        {
                            if (dev.model == "NTLM3410Y")
                            {
                                this.sendDataOut(commands["modemFWUPfinishLTE"]);
                            }
                            else
                            {
                                this.sendDataOut(commands["modemFWUPfinish"]);
                            }
                            if (lbActionState.Text == states.onem2mtc0211042.ToString())
                                lbActionState.Text = states.onem2mtc0211043.ToString();
                            else
                                lbActionState.Text = states.modemFWUPfinish.ToString();
                        }
                        else if (tc.state == "tc020201")
                        {
                            endoneM2MTC(tc.state);
                            if(lbActionState.Text == states.onem2mtc020201.ToString())
                            {
                                startoneM2MTC("tc020301");
                                this.sendDataOut(commands["getremoteCSE"]);
                                lbActionState.Text = states.onem2mtc020301.ToString();
                            }
                        }
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 인증 정보 확인이 필요합니다.", "");
                    }
                    nextcommand = "";
                    break;
                case "$OM_B_CSE_RSP=":
                    // oneM2M CSEBase 조회 결과
                    if (str2 == "2000")
                    {
                        if(tc.state == "tc020401")
                            endoneM2MTC(tc.state);
                    }
                    else
                        logPrintInTextBox("oneM2M서버 인증 정보 확인이 필요합니다.", "");
                    break;
                case "$OM_R_CSE_RSP=":
                    // oneM2M remoteCSE 조회 결과, 4004이면 생성/2000 또는 2004이면 container 확인
                    if (str2 == "4004")
                    {
                        if(tc.state == "tc020301")
                        {
                            endoneM2MTC(tc.state);
                            startoneM2MTC("tc020501");
                        }
                        // 플랫폼 서버 remoteCSE 등록 요청

                        this.sendDataOut(commands["setremoteCSE"]);
                        if (lbActionState.Text == states.onem2mtc020301.ToString())
                        {
                            lbActionState.Text = states.onem2mtc0205012.ToString();     // 신규 삭제
                        }
                        else
                            lbActionState.Text = states.setremoteCSE.ToString();
                    }
                    else if (str2 == "2000")
                    {
                        if (tc.state == "tc020301")
                        {
                            endoneM2MTC(tc.state);
                            startoneM2MTC("tc020505");
                        }
                        // 플랫폼 서버 remoteCSE 업데이트 요청

                        this.sendDataOut(commands["updateremoteCSE"]);
                        if (lbActionState.Text == states.onem2mtc020301.ToString())
                        {
                            lbActionState.Text = states.onem2mtc0205051.ToString();
                        }
                        else
                            lbActionState.Text = states.updateremoteCSE.ToString();
                    }
                    break;
                case "$OM_C_CSE_RSP=":
                    // oneM2M remoteCSE 생성 결과, 2001이면 container 생성 요청
                    if (str2 == "2001")
                    {
                        if (tc.state == "tc020501")
                            endoneM2MTC(tc.state);

                        if (svr.enrmtKeyId != string.Empty)
                        {
                            RetrivePoaToPlatform();
                            RetriveDverToPlatform();
                            RetriveMverToPlatform();
                        }

                        if (lbActionState.Text == states.onem2mtc0205011.ToString())        // 조회-업데이트-삭제-생성 완료
                        {
                            startoneM2MTC("tc020502");
                            this.sendDataOut(commands["setcontainer"] + "DtoS");
                            lbActionState.Text = states.onem2mtc0205021.ToString();
                        }
                        else if (lbActionState.Text == states.onem2mtc0205012.ToString())       // 조회-신규생성-업데이트 동작 확인 필요
                        {
                            startoneM2MTC("tc020505");
                            this.sendDataOut(commands["updateremoteCSE"]);
                            lbActionState.Text = states.onem2mtc0205052.ToString();
                        }
                    }
                    else
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    break;
                case "$OM_D_CSE_RSP=":
                    // oneM2M remoteCSE 삭제 결과, 2002이면 성공
                    if (str2 == "2002")
                    {
                        if (tc.state == "tc021204")
                            endoneM2MTC(tc.state);

                        if (lbActionState.Text == states.onem2mtc0212041.ToString())
                        {
                            startoneM2MTC("tc020501");
                            this.sendDataOut(commands["setremoteCSE"]);
                            lbActionState.Text = states.onem2mtc0205011.ToString();     // remoteCSE 조회-업데이트-삭제 후 생성 요청
                        }
                        else if (lbActionState.Text == states.onem2mtc0212042.ToString())
                        {
                            startoneM2MTC("tc020401");
                            this.sendDataOut(commands["getCSEbase"]);
                            lbActionState.Text = states.onem2mtc020401.ToString();
                        }
                    }
                    else
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    break;
                case "$OM_U_CSE_RSP=":
                    // oneM2M remoteCSE 업데이트 결과, 2004이면 remoteCSE (poa) 업데이트 성공
                    if (str2 == "2004")
                    {
                        if (tc.state == "tc020505")
                            endoneM2MTC(tc.state);

                        if(svr.enrmtKeyId != string.Empty)
                            RetrivePoaToPlatform();

                        if (lbActionState.Text == states.onem2mtc0205051.ToString())
                        {
                            startoneM2MTC("tc021204");
                            this.sendDataOut(commands["delremoteCSE"]);
                            lbActionState.Text = states.onem2mtc0212041.ToString();
                        }
                       else
                        {
                            startoneM2MTC("tc020502");
                            this.sendDataOut(commands["setcontainer"] + "DtoS");
                            lbActionState.Text = states.onem2mtc0205021.ToString();
                        }
                    }
                    break;
                case "$OM_POA_NOTI=":
                    // oneM2M remoteCSE 업데이트 결과, 2004이면 remoteCSE (poa) 업데이트 성공
                    if (str2 == "2004")
                    {
                        endoneM2MTC("tc020801");

                        if (svr.enrmtKeyId != string.Empty)
                            RetrivePoaToPlatform();

                        if (lbActionState.Text == states.onem2mtc0208012.ToString())
                        {
                            startoneM2MTC("tc020901");
                            this.sendDataOut(commands["setACP"]);
                            lbActionState.Text = states.onem2mtc0209011.ToString();

                            /*
                            startoneM2MTC("tc021001");
                            this.sendDataOut(commands["getdeviceSvrVer"]);
                            lbActionState.Text = states.onem2mtc021001.ToString();
                            */
                        }
                    }
                    break;
                case "$OM_C_CON_RSP=":
                    // oneM2M container 생성 결과, 2001이면 성공
                    if (str2 == "2001")
                    {
                        if (tc.state == "tc020502")
                            endoneM2MTC(tc.state);

                        if (lbActionState.Text == states.onem2mtc0205021.ToString() || lbActionState.Text == states.onem2mtc0205023.ToString())
                        {
                            startoneM2MTC("tc020502");
                            this.sendDataOut(commands["setcontainer"] + "StoD");
                            lbActionState.Text = states.onem2mtc0205022.ToString();
                        }
                        else if (lbActionState.Text == states.onem2mtc0205022.ToString())
                        {
                            startoneM2MTC("tc020503");
                            this.sendDataOut(commands["setsubscript"] + "StoD");
                            lbActionState.Text = states.onem2mtc0205031.ToString();
                        }
                    }
                    else if (str2 == "4105")
                    {
                        if (lbActionState.Text == states.onem2mtc0205021.ToString())
                        {
                            startoneM2MTC("tc021203");
                            this.sendDataOut(commands["delcontainer"] + "StoD");
                            lbActionState.Text = states.onem2mtc0212031.ToString();
                        }
                        else if (lbActionState.Text == states.onem2mtc0205022.ToString())
                        {
                            startoneM2MTC("tc020503");
                            this.sendDataOut(commands["setsubscript"] + "StoD");
                            lbActionState.Text = states.onem2mtc0205031.ToString();
                        }
                    }
                    break;
                case "$OM_D_CON_RSP=":
                    // oneM2M container 삭제 결과, 2002이면 성공
                    if (str2 == "2002")
                    {
                        if (tc.state == "tc021203")
                            endoneM2MTC(tc.state);

                        if (lbActionState.Text == states.onem2mtc0212031.ToString())
                        {
                            startoneM2MTC("tc020502");
                            this.sendDataOut(commands["setcontainer"] + "StoD");
                            lbActionState.Text = states.onem2mtc0205023.ToString();
                        }
                        else if (lbActionState.Text == states.onem2mtc0212032.ToString())
                        {
                            startoneM2MTC("tc021204");
                            this.sendDataOut(commands["delremoteCSE"]);
                            lbActionState.Text = states.onem2mtc0212042.ToString();
                        }
                    }
                    break;
                case "$OM_C_ACP_RSP=":
                    // oneM2M ACP 신청 결과
                    if (str2 == "2001")
                    {
                        if (tc.state == "tc020901")
                            endoneM2MTC(tc.state);

                        if (lbActionState.Text == states.onem2mtc0209011.ToString() || lbActionState.Text == states.onem2mtc0209012.ToString() || lbActionState.Text == states.onem2mtc0209013.ToString())
                        {
                            startoneM2MTC("tc020902");
                            this.sendDataOut(commands["getACP"]);
                            lbActionState.Text = states.onem2mtc020902.ToString();
                        }
                    }
                    else if (str2 == "4105")
                    {
                        if (lbActionState.Text == states.onem2mtc0209011.ToString())            // 1회 생성 오류 (기존재) - 삭제 후 재생성
                        {
                            startoneM2MTC("tc020904");
                            this.sendDataOut(commands["delACP"]);
                            lbActionState.Text = states.onem2mtc0209041.ToString();
                        }
                        else if (lbActionState.Text == states.onem2mtc0209012.ToString())       // 삭제후 생성 요청(2회) 에서도 오류
                        {
                            startoneM2MTC("tc020902");
                            this.sendDataOut(commands["getACP"]);
                            lbActionState.Text = states.onem2mtc020902.ToString();
                        }
                        else if (lbActionState.Text == states.onem2mtc0209013.ToString())       // 조회 오류(미존재)로 재생성 요청에서도 오류
                        {
                            startoneM2MTC("tc021001");
                            this.sendDataOut(commands["getdeviceSvrVer"]);
                            lbActionState.Text = states.onem2mtc021001.ToString();
                        }
                    }
                    break;
                case "$OM_R_ACP_RSP=":
                    // oneM2M ACP 조회 결과 확인
                    string[] acpdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

                    if (acpdatas[0] == "4004")
                    {
                        if (tc.state == "tc020902")
                        {
                            endoneM2MTC(tc.state);
                        }

                        if (lbActionState.Text == states.onem2mtc020902.ToString())        // 1회 조회 오류(미존재) 생성 요청 시도
                        {
                            startoneM2MTC("tc020901");
                            this.sendDataOut(commands["setACP"]);
                            lbActionState.Text = states.onem2mtc0209013.ToString();
                        }
                    }
                    else if (acpdatas[0] == "2000")
                    {
                        if (tc.state == "tc020902")
                        {
                            endoneM2MTC(tc.state);
                        }

                        if (lbActionState.Text == states.onem2mtc020902.ToString())
                        {
                            startoneM2MTC("tc020903");
                            this.sendDataOut(commands["updateACP"]);
                            lbActionState.Text = states.onem2mtc020903.ToString();
                        }
                    }
                    break;
                case "$OM_U_ACP_RSP=":
                    // oneM2M ACP 업데이트 결과, 2004이면 업데이트 성공
                    if (str2 == "2004")
                    {
                        if (tc.state == "tc020903")
                            endoneM2MTC(tc.state);

                        if (lbActionState.Text == states.onem2mtc020903.ToString())
                        {
                            startoneM2MTC("tc020904");
                            this.sendDataOut(commands["delACP"]);
                            lbActionState.Text = states.onem2mtc0209042.ToString();
                        }
                    }
                    break;
                case "$OM_D_ACP_RSP=":
                    // oneM2M ACP 삭제 결과
                    if (str2 == "2002")
                    {
                        if (tc.state == "tc020904")
                        {
                            endoneM2MTC(tc.state);

                            if (lbActionState.Text == states.onem2mtc0209041.ToString())
                            {
                                startoneM2MTC("tc020901");
                                this.sendDataOut(commands["setACP"]);
                                lbActionState.Text = states.onem2mtc0209012.ToString();
                            }
                            else if (lbActionState.Text == states.onem2mtc0209042.ToString())
                            {
                                startoneM2MTC("tc021001");
                                this.sendDataOut(commands["getdeviceSvrVer"]);
                                lbActionState.Text = states.onem2mtc021001.ToString();
                            }
                        }
                    }
                    break;
                case "$OM_C_SUB_RSP=":
                    // oneM2M subscription 신청 결과
                    if (str2 == "2001")
                    {
                        if (tc.state == "tc020503")
                            endoneM2MTC(tc.state);

                        if (lbActionState.Text == states.onem2mtc0205031.ToString() || lbActionState.Text == states.onem2mtc0205032.ToString())
                        {
                            startoneM2MTC("tc020504");
                            // Data send to SERVER (string original)
                            //AT$OM_C_INS_REQ=<object>,<length>,<data>
                            string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                            if (svr.enrmtKeyId != string.Empty)
                                this.sendDataOut(commands["sendonemsgstr"] + "DtoS" + "," + txData.Length + "," + txData);
                            else
                                this.sendDataOut(commands["sendonemsgstr"] + "StoD" + "," + txData.Length + "," + txData);
                            lbActionState.Text = states.onem2mtc020504.ToString();
                            lbSendedData.Text = txData;
                        }
                    }
                    else if (str2 == "4105")
                    {
                        if (lbActionState.Text == states.onem2mtc0205031.ToString())
                        {
                            startoneM2MTC("tc021202");
                            this.sendDataOut(commands["delsubscript"] + "StoD");
                            lbActionState.Text = states.onem2mtc0212021.ToString();
                        }
                        else if (lbActionState.Text == states.onem2mtc0205032.ToString())
                        {
                            startoneM2MTC("tc020504");
                            // Data send to SERVER (string original)
                            //AT$OM_C_INS_REQ=<object>,<length>,<data>
                            string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                            this.sendDataOut(commands["sendonemsgstr"] + "StoD" + "," + txData.Length + "," + txData);
                            lbActionState.Text = states.onem2mtc020504.ToString();
                            lbSendedData.Text = txData;
                        }
                    }
                    break;
                case "$OM_D_SUB_RSP=":
                    // oneM2M subscription 삭제 결과
                    if (str2 == "2002")
                    {
                        if (tc.state == "tc021202")
                        {
                            endoneM2MTC(tc.state);

                            if (lbActionState.Text == states.onem2mtc0212021.ToString())
                            {
                                startoneM2MTC("tc020503");
                                this.sendDataOut(commands["setsubscript"] + "StoD");
                                lbActionState.Text = states.onem2mtc0205032.ToString();
                            }
                            else if (lbActionState.Text == states.onem2mtc0212022.ToString())
                            {
                                startoneM2MTC("tc021203");
                                this.sendDataOut(commands["delcontainer"] + "StoD");
                                lbActionState.Text = states.onem2mtc0212032.ToString();
                            }
                        }
                    }
                    break;
                case "$OM_C_INS_RSP=":
                    // 플랫폼 서버에 data 송신

                    string[] rxwords = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rxwords[0] == "2001")
                    {
                        if (tc.state == "tc020504")
                        {
                            if (svr.enrmtKeyId != string.Empty)
                                RetriveDataToPlatform();
                            else
                            {
                                endoneM2MTC(tc.state);

                                if (lbActionState.Text == states.onem2mtc020504.ToString())
                                {
                                    startoneM2MTC("tc020601");
                                    lbActionState.Text = states.onem2mtc020601.ToString();
                                }
                            }
                        }
                        else if ((tc.state == "tc020601") || (tc.state == "tc020603") || (tc.state == "tc020604"))
                        {
                            if (svr.enrmtKeyId != string.Empty)
                                RetriveDataToPlatform();
                        }
                    }
                    break;
                case "$OM_NOTI_IND=":
                    // oneM2M subscription 설정에 의한 data 수신 이벤트
                    if (dev.maker == "Quectel")
                    {
                        if (tc.state == "tc020601")
                            endoneM2MTC(tc.state);

                        if (lbActionState.Text == states.onem2mtc020601.ToString())
                        {
                            startoneM2MTC("tc020602");
                            // 플랫폼 서버에 data 수신 요청
                            this.sendDataOut(commands["setrcvauto"]);
                            lbActionState.Text = states.onem2mtc020602.ToString();
                        }
                        else
                        {
                            // 플랫폼 서버에 data 수신 요청
                            this.sendDataOut(commands["getonem2mdata"] + str2);
                            lbActionState.Text = states.getonem2mdata.ToString();
                        }
                    }

                    else
                    {
                        if (tc.state == "tc020601")
                            endoneM2MTC("tc020601");

                        startoneM2MTC("tc020701");
                        // 플랫폼 서버에 data 수신 요청
                        this.sendDataOut(commands["getonem2mdata"] + str2);
                        if (lbActionState.Text == states.onem2mtc020601.ToString())
                            lbActionState.Text = states.onem2mtc020701.ToString();
                        else
                            lbActionState.Text = states.getonem2mdata.ToString();
                    }
                    break;
                case "$OM_N_INS_RSP=":
                    // oneM2M 데이터 자동 수신 결과
                    string[] rx_datas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

                    if (rx_datas[0] == "2000")
                    {
                        // 수신한 데이터 사이즈 확이
                        int rxsize = Convert.ToInt32(rx_datas[1]);
                        if (rxsize == rx_datas[2].Length)
                        {
                            if (tc.state == "tc020601")
                            {
                                startoneM2MTC("tc020604");
                                this.sendDataOut(commands["setrcvmanu"]);
                                lbActionState.Text = states.onem2mtc0206041.ToString();
                            }
                            else
                            {
                                if (tc.state == "tc020603")
                                    endoneM2MTC(tc.state);

                                startoneM2MTC("tc020604");
                                this.sendDataOut(commands["setrcvmanu"]);
                                lbActionState.Text = states.onem2mtc0206042.ToString();
                            }
                            lboneM2MRcvData.Text = rx_datas[2];
                            logPrintInTextBox(rx_datas[2] + "를 수신하였습니다.", "");
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
                case "$OM_R_INS_RSP=":
                    // 플랫폼 서버에 data 수신

                    string[] rcvdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rcvdatas[0] == "2000")
                    {
                        // 수신한 데이터 사이즈 확이
                        int rxsize = Convert.ToInt32(rcvdatas[1]);
                        if (rxsize == rcvdatas[2].Length)
                        {
                            if (tc.state == "tc020701")
                            {
                                if (svr.enrmtKeyId == string.Empty)
                                {
                                    if (rcvdatas[2] == lbSendedData.Text)
                                    {
                                        endoneM2MTC(tc.state);

                                        if (lbActionState.Text == states.onem2mtc020701.ToString())
                                        {
                                            startoneM2MTC("tc020801");
                                            if (dev.maker == "QUALCOMM INCORPORATED")        //텔라딘/oneM2M 모듈
                                                this.sendDataOut(commands["rfofftld"]);
                                            else
                                                this.sendDataOut(commands["rfoff"]);
                                            lbActionState.Text = states.onem2mtc0208011.ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    if (rcvdatas[2] == lbSvroneM2MData.Text)
                                    {
                                        endoneM2MTC(tc.state);

                                        if (lbActionState.Text == states.onem2mtc020701.ToString())
                                        {
                                            startoneM2MTC("tc020801");
                                            if (dev.maker == "QUALCOMM INCORPORATED")        //텔라딘/oneM2M 모듈
                                                this.sendDataOut(commands["rfofftld"]);
                                            else
                                                this.sendDataOut(commands["rfoff"]);
                                            lbActionState.Text = states.onem2mtc0208011.ToString();
                                        }
                                    }
                                }
                            }
                            lboneM2MRcvData.Text = rcvdatas[2];
                            logPrintInTextBox(rcvdatas[2] + "를 수신하였습니다.", "");
                        }
                        else
                        {
                            logPrintInTextBox("수신한 데이터 사이즈를 확인하세요", "");

                            if (tc.state == "tc020701")
                            {
                                startoneM2MTC("tc020801");
                                if (dev.maker == "QUALCOMM INCORPORATED")        //텔라딘/oneM2M 모듈
                                    this.sendDataOut(commands["rfofftld"]);
                                else
                                    this.sendDataOut(commands["rfoff"]);
                                lbActionState.Text = states.onem2mtc0208011.ToString();
                            }
                        }
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_S_RCIN_RSP=":
                    // 플랫폼 서버에 device status check 수신

                    logPrintInTextBox(str2 + "에 대해 상태 요청을 수신하였습니다.", "");

                    string txData2 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " response";
                    this.sendDataOut(commands["responemsgsvr"] + str2 + "," + txData2.Length + "," + txData2);

                    nextcommand = "skip";
                    break;
                case "*ST*INFO:":
                    string[] modeminfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    lbModemVer.Text = modeminfos[1];
                    dev.version = lbModemVer.Text;
                    logPrintInTextBox("MODEM의 버전을 저장하였습니다.", "");
                    break;
                case "APPLICATION_A,":
                    lbModemVer.Text = str2;
                    logPrintInTextBox("MODEM의 버전을 저장하였습니다.", "");
                    break;
                case "+QLWSERVERIP:BS,":
                    if (str2 != serverip + "," + serverport)
                    {
                        //AT+QLWSERVERIP=BS,<ip>,<port>   BC95모델
                        //this.sendDataOut(commands["autosetsvrbsbc95"] + serverip + "," + serverport);
                        lbActionState.Text = states.actsetsvrbsbc95.ToString();
                        //nextcommand = "skip";
                    }
                    break;
                case "+QLWSERVERIP:LWM2M,":
                    if ((str2 != serverip + "," + serverport))
                    {
                        if (lbActionState.Text != states.actsetsvrbsbc95.ToString())
                        {
                            //AT+QLWSERVERIP=LWM2M,<ip>,<port>   BC95모델 서버정보 갱신
                            //this.sendDataOut(commands["autosetsvripbc95"] + serverip + "," + serverport);
                            lbActionState.Text = states.actsetsvripbc95.ToString();
                            //nextcommand = "skip";
                        }
                    }
                    break;
                case "+QLWEPNS: ":
                    String md5value = getMd5Hash(lbIMSI.Text + lbIccid.Text);
                    string epn = md5value.Substring(0, 5) + md5value.Substring(md5value.Length - 5, 5);

                    if (str2 != "ASN_CSE-D-" + epn + "-" + tbSvcCd.Text)
                    {
                        //AT+QLWSERVERIP=LWM2M,<ip>,<port>   BC95모델 서버정보 갱신
                        lbActionState.Text = states.autosetepnsbc95.ToString();
                        nextcommand = commands["setepnsbc95"] + tbSvcCd.Text;
                    }
                    break;
                case "+QLWMBSPS: ":
                    //AT+QLWMBSPS=<service code>,<sn>,<ctn>,<iccid>,<device model>
                    string epncmd = "\"" + tbSvcCd.Text + "\",\"";
                    epncmd = epncmd + tBoxDeviceSN.Text + "\",\"";
                    epncmd = epncmd + lbIMSI.Text + "\",\"";

                    string epniccid = lbIccid.Text;
                    epncmd = epncmd + epniccid.Substring(epniccid.Length - 6, 6) + "\",\"";
                    epncmd = epncmd + tBoxDeviceModel.Text + "\"";

                    if (str2 != epncmd)
                    {
                        lbActionState.Text = states.autosetmbspsbc95.ToString();
                        nextcommand = commands["setmbspsbc95"] + epncmd;
                    }
                    break;
                case "$OM_DEV_FWDL_START=":
                    oneM2Mtotalsize = Convert.ToUInt32(str2);
                    logPrintInTextBox("FOTA 이미지 크기는 " + str2 + "입니다.", "");
                    break;
                case "$BIN_DATA=":
                    if (dev.maker == "AM Telecom")        //AMTEL 모듈은 OK가 오지 않음
                    {
                        string[] oneM2Minfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                        oneM2Mrcvsize += Convert.ToUInt32(oneM2Minfos[0]);
                    }
                    else
                    {
                        oneM2Mrcvsize += (UInt32)str2.Length / 2;
                    }
                    // logPrintInTextBox("index= " + oneM2Mrcvsize + "/" + oneM2Mtotalsize + "를 수신하였습니다.", "");
                    break;
                case "data=":
                    string[] TM800infos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    oneM2Mrcvsize += Convert.ToUInt32(TM800infos[1]);
                    // logPrintInTextBox("index= " + oneM2Mrcvsize + "/" + oneM2Mtotalsize + "를 수신하였습니다.", "");
                    break;
                case "$OM_C_MODEM_FWUP_RSP=":
                    break;
                case "$OM_MODEM_FWUP_RSP=":
                case "$OM_PUSH_MODEM_FWUP_RSP=":
                    string[] modemverinfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (modemverinfos[0] == "2000")
                    {
                        if (tc.state == "tc021101")
                        {
                            endoneM2MTC(tc.state);
                            startoneM2MTC("tc021103");
                        }
                        else if (tc.state == string.Empty)
                        {
                            endoneM2MTC("tc021102");
                            startoneM2MTC("tc021103");
                        }
                        logPrintInTextBox("수신한 MODEM의 버전은 " + modemverinfos[1] + "입니다. 업데이트를 시도합니다.", "");

                        this.sendDataOut(commands["modemFWUPstart"]);
                        if (lbActionState.Text == states.onem2mtc021101.ToString())
                            lbActionState.Text = states.onem2mtc021103.ToString();
                        else
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
                case "$OM_MODEM_UPDATE_START":
                    // 모듈 업데이트 작업 중에 COM 포트가 끊어질 수 있음.
                    break;
                case "$OM_MODEM_UPDATE_FINISH":
                    if (tc.state == "tc021103")
                    {
                        endoneM2MTC(tc.state);
                        startoneM2MTC("tc021104");
                    }
                    else if (tc.state == string.Empty)
                        startoneM2MTC("tc021104");


                    // 디바이스는 업데이트 작업 및 재부팅한 후에 신규 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                    if (lbActionState.Text == states.onem2mtc021103.ToString())
                    {
                        this.sendDataOut(commands["setonem2mmode"]);
                        lbActionState.Text = states.onem2mtc0211041.ToString();
                    }
                    else if (lbActionState.Text == states.getcereg.ToString())
                    {
                        this.sendDataOut(commands["setonem2mmode"]);
                        lbActionState.Text = states.setonem2mmode.ToString();

                        this.sendDataOut(commands["mfotamefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + ",D-" + dev.imsi);
                        lbActionState.Text = states.mfotamefauth.ToString();
                    }
                    else
                    {
                        this.sendDataOut(commands["mfotamefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + ",D-" + dev.imsi);
                        lbActionState.Text = states.mfotamefauth.ToString();
                    }
                    nextcommand = "skip";
                    break;
                case "$OM_MODEM_FWUP_FINISH=":
                    if (tc.state == "tc021104" && str2 == "2004")
                    {
                        if (svr.enrmtKeyId != string.Empty)
                        {
                            RetriveMverToPlatform();

                            if (dev.maker == "QUALCOMM INCORPORATED")
                            {
                                this.sendDataOut(commands["getmodemvertld"]);
                            }
                            else
                            {
                                this.sendDataOut(commands["getmodemver"]);
                            }

                            if (lbActionState.Text == states.onem2mtc0211043.ToString())
                                lbActionState.Text = states.onem2mtc0211044.ToString();
                            else
                                lbActionState.Text = states.getmodemver.ToString();
                        }
                        else
                        {
                            endoneM2MTC(tc.state);

                            if (lbActionState.Text == states.onem2mtc0211043.ToString())
                            {
                                startoneM2MTC("tc021202");
                                this.sendDataOut(commands["delsubscript"] + "StoD");
                                lbActionState.Text = states.onem2mtc0212022.ToString();
                            }
                        }
                    }
                    break;
                case "$OM_DEV_FWUP_RSP=":
                case "$OM_PUSH_DEV_FWUP_RSP=":
                    string[] deviceverinfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (deviceverinfos[0] == "2000")
                    {
                        if (tc.state == "tc021001")
                        {
                            endoneM2MTC(tc.state);
                            startoneM2MTC("tc021003");
                        }
                        else if (tc.state == string.Empty)
                        {
                            endoneM2MTC("tc021002");
                            startoneM2MTC("tc021003");
                        }
                        tBoxDeviceVer.Text = deviceverinfos[1];
                        logPrintInTextBox("수신한 DEVICE의 버전은 " + deviceverinfos[1] + "입니다. 업데이트를 시도합니다.", "");

                        this.sendDataOut(commands["deviceFWUPstart"]);

                        if (lbActionState.Text == states.onem2mtc021001.ToString())
                            lbActionState.Text = states.onem2mtc021003.ToString();
                        else
                            lbActionState.Text = states.deviceFWUPstart.ToString();

                        oneM2Mrcvsize = 0;
                        oneM2Mtotalsize = 0;
                    }
                    else if (deviceverinfos[0] == "9001")
                    {
                        if (tc.state == "tc021001")
                            endoneM2MTC(tc.state);
                        logPrintInTextBox("현재 DEVICE 버전이 최신버전입니다.", "");

                        if (lbActionState.Text == states.onem2mtc021001.ToString())
                        {
                            startoneM2MTC("tc021101");
                            this.sendDataOut(commands["getmodemSvrVer"]);
                            lbActionState.Text = states.onem2mtc021101.ToString();
                        }
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");

                        if (lbActionState.Text == states.onem2mtc021001.ToString())
                        {
                            startoneM2MTC("tc021101");
                            this.sendDataOut(commands["getmodemSvrVer"]);
                            lbActionState.Text = states.onem2mtc021101.ToString();
                        }

                    }
                    break;
                case "$OM_DEV_FWDL_FINISH":
                    logPrintInTextBox(oneM2Mrcvsize + "/" + oneM2Mtotalsize + "를 수신하였습니다.", "");

                    if (tc.state == "tc021003" && oneM2Mrcvsize == oneM2Mtotalsize)
                    {
                        endoneM2MTC(tc.state);
                        startoneM2MTC("tc021004");
                    }
                    else if (tc.state == string.Empty)
                        startoneM2MTC("tc021004");

                    // 디바이스는 업데이트 작업 및 재부팅한 후에 신규 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                    this.sendDataOut(commands["fotamefauthnt"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + ",D-" + dev.imsi);
                    if (lbActionState.Text == states.onem2mtc021003.ToString())
                        lbActionState.Text = states.onem2mtc021004.ToString();
                    else
                        lbActionState.Text = states.fotamefauthnt.ToString();
                    nextcommand = "skip";
                    break;
                case "$OM_DEV_FWUP_FINISH=":
                    if (tc.state == "tc021004" && str2 == "2004")
                    {
                        if (svr.enrmtKeyId != string.Empty)
                        {
                            RetriveDverToPlatform();
                            if (tBoxDeviceVer.Text == lbdevicever.Text)
                            {
                                endoneM2MTC(tc.state);

                                if (lbActionState.Text == states.onem2mtc021004.ToString())
                                {
                                    startoneM2MTC("tc021101");
                                    this.sendDataOut(commands["getmodemSvrVer"]);
                                    lbActionState.Text = states.onem2mtc021101.ToString();
                                }
                            }
                        }
                        else
                        {
                            endoneM2MTC(tc.state);

                            if (lbActionState.Text == states.onem2mtc021004.ToString())
                            {
                                startoneM2MTC("tc021101");
                                this.sendDataOut(commands["getmodemSvrVer"]);
                                lbActionState.Text = states.onem2mtc021101.ToString();
                            }
                        }
                    }
                    break;
                case "@NETSTI:":
                    // AMTEL RF 동작 상태
                    if (str2 == "0")
                    {
                        if (lbActionState.Text == states.onem2mtc0208011.ToString())
                        {
                            if (dev.maker == "QUALCOMM INCORPORATED")        //텔라딘/oneM2M 모듈
                            {
                                this.sendDataOut(commands["rfon"]);
                                lbActionState.Text = states.onem2mtc0208012.ToString();
                            }
                            nextcommand = "skip";
                        }
                    }
                    else if (lbActionState.Text == states.onem2mtc0208012.ToString())
                        nextcommand = "skip";
                    else
                        nextcommand = "";
                    break;
                case "$$VER: ":
                    lbModemVer.Text = str2;
                    dev.version = str2;
                    this.logPrintInTextBox("모뎀버전이 저장되었습니다.", "");

                    if (tc.state == "tc021104" && lbModemVer.Text == lbmodemfwrver.Text)
                    {
                        endoneM2MTC(tc.state);

                        if(lbActionState.Text == states.onem2mtc0211043.ToString())
                        {
                            startoneM2MTC("tc021202");
                            this.sendDataOut(commands["delsubscript"] + "StoD");
                            lbActionState.Text = states.onem2mtc0212022.ToString();
                        }

                    }
                    break;
                case "$$SWVER: ":
                    string[] swvers = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    lbModemVer.Text = swvers[0];
                    dev.version = swvers[0];
                    this.logPrintInTextBox("모뎀버전이 저장되었습니다.", "");

                    if (tc.state == "tc021104" && lbModemVer.Text == lbmodemfwrver.Text)
                    {
                        endoneM2MTC(tc.state);

                        if (lbActionState.Text == states.onem2mtc0211043.ToString())
                        {
                            startoneM2MTC("tc021202");
                            this.sendDataOut(commands["delsubscript"] + "StoD");
                            lbActionState.Text = states.onem2mtc0212022.ToString();
                        }

                    }
                    break;
                case "+QLWEVENT:":
                    // 모듈이 LWM2M서버에 접속/등록하는 단계에서 발생하는 이벤트,
                    // OK 응답 발생하지 않음
                    // +QLWEVENT=<type>

                    if (tc.state == "tc0202" && str2.StartsWith(" 3", System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        endLwM2MTC(tc.state);
                        startLwM2MTC("tc0301");       // BG96모델은 Bootstrap 이후 Register 동작 연결됨
                    }
                    else if (tc.state == "tc0301" && str2.StartsWith(" 5", System.StringComparison.CurrentCultureIgnoreCase))
                        endLwM2MTC(tc.state);
                    else if (str2.StartsWith("6", System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (tc.state == string.Empty)
                            startLwM2MTC("tc0602");         // 서버에서 모듈 FOTA 요청
                        else if (tc.state == "tc0602")
                            endLwM2MTC("tc0602");           // 서버에 업데이트 버전 보고 완료
                    }

                    if (nextcommand == states.getcereg.ToString())
                        nextcommand = "";
                    break;
                case "AT+MLWEVTIND=":
                case "+QLWEVTIND:":
                    // 모듈이 LWM2M서버 연동 상태 이벤트,
                    // OK 응답 발생하지 않음
                    // AT+MLWEVTIND=<type>
                    switch (str2)
                    {
                        case "0":
                            logPrintInTextBox("registration completed", " ");
                            break;
                        case "1":
                            if (tc.state == "tc0401")
                                endLwM2MTC(tc.state);
                            logPrintInTextBox("deregistration completed", " ");
                            break;
                        case "2":
                            logPrintInTextBox("registration update completed", " ");
                            break;
                        case "3":
                            logPrintInTextBox("10250 object subscription completed", " ");
                            break;
                        case "4":
                            if (tc.state == "tc0202")
                                endLwM2MTC(tc.state);
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
                            if (tc.state == "tc0301")
                                endLwM2MTC(tc.state);
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
                            lbLwM2MRcvData.Text = receiveDataIN;
                            if (tc.state == "tc0502" && receiveDataIN == lbSvrLwM2MData.Text)
                                endLwM2MTC(tc.state);
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
                case "+NNMI:":
                    // 모듈이 LWM2M서버에서 받은 데이터를 전달하는 이벤트,
                    // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                    // +NNMI:<length>,<hex data>
                    string[] rxdatasbc95 = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                                                               // 10250 DATA object RECEIVED!!!
                    if (Convert.ToInt32(rxdatasbc95[0]) == rxdatasbc95[1].Length / 2)    // data size 비교
                    {
                        //received hex data make to ascii code
                        string receiveDataIN = BcdToString(rxdatasbc95[1].ToCharArray());
                        logPrintInTextBox("\"" + receiveDataIN + "\"를 수신하였습니다.", "");
                        lbLwM2MRcvData.Text = receiveDataIN;
                        if (tc.state == "tc0502" && receiveDataIN == lbSvrLwM2MData.Text)
                            endLwM2MTC(tc.state);
                    }
                    else
                    {
                        logPrintInTextBox("data size가 맞지 않습니다.", "");
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
                                lbLwM2MRcvData.Text = words[3];
                                if (tc.state == "tc0502" && words[3] == lbSvrLwM2MData.Text)
                                    endLwM2MTC(tc.state);
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
                                lbLwM2MRcvData.Text = receiveDataIN;
                                if (tc.state == "tc0502" && receiveDataIN == lbSvrLwM2MData.Text)
                                    endLwM2MTC(tc.state);
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
                        if(tc.state=="tc020102")
                        {
                            endoneM2MTC(tc.state);
                            startoneM2MTC("tc020201");
                        }
                        // 플랫폼 서버 MEF AUTH 요청
                        this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                        if (lbActionState.Text == states.onem2mtc0201021.ToString() || lbActionState.Text == states.onem2mtc0201023.ToString())
                            lbActionState.Text = states.onem2mtc020201.ToString();
                        else
                            lbActionState.Text = states.setmefauth.ToString();
                        nextcommand = "skip";
                    }
                    else
                    {
                        // 모듈 oneM2M 플랫폼 모드 요청
                        if (lbActionState.Text == states.onem2mtc0201021.ToString())
                            nextcommand = states.onem2mtc0201022.ToString();
                        else
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
                    dev.version = str2;
                    logPrintInTextBox("모뎀 버전이 저장되었습니다.", "");
                    break;
                default:
                    break;
            }
        }

        private void startLwM2MTC(string tcindex)
        {
            tc.state = tcindex;
            logPrintTC(lwm2mtclist[tcindex] + " [시작]");
            lwm2mtc index = (lwm2mtc)Enum.Parse(typeof(lwm2mtc), tcindex);
            tc.lwm2m[(int)index] = "FAIL";             // 시험 결과 초기 값(FAIL) 설정, 테스트 후 결과 수정
        }

        private void endLwM2MTC(string tcindex)
        {
            lwm2mtc state = (lwm2mtc)Enum.Parse(typeof(lwm2mtc), tcindex);
            logPrintTC(lwm2mtclist[state.ToString()] + " [성공]");
            tc.lwm2m[(int) state] = "PASS";             // 시험 결과 저장
            tc.state = string.Empty;
        }

        private void startoneM2MTC(string tcindex)
        {
            tc.state = tcindex;
            logPrintTC(onem2mtclist[tcindex] + " [시작]");
            onem2mtc index = (onem2mtc)Enum.Parse(typeof(onem2mtc), tcindex);
            tc.onem2m[(int)index] = "FAIL";             // 시험 결과 초기 값(FAIL) 설정, 테스트 후 결과 수정
        }

        private void endoneM2MTC(string tcindex)
        {
            onem2mtc state = (onem2mtc)Enum.Parse(typeof(onem2mtc), tcindex);
            logPrintTC(onem2mtclist[state.ToString()] + " [성공]");
            tc.onem2m[(int)state] = "PASS";             // 시험 결과 저장
            tc.state = string.Empty;
        }

        private void setDeviceEntityID(string str)
        {
            string[] strchs = str.Split(' ');        // Remove first char ' '
            if (strchs.Length > 1)
                str = strchs[strchs.Length-1];

            if (str.Length > 19)
                lbIccid.Text = str.Substring(str.Length - 20, 19);
            else
                lbIccid.Text = str;

            dev.iccid = lbIccid.Text;
            if(dev.imsi.Length == 11)
            {
                String md5value = getMd5Hash(dev.imsi + dev.iccid);
                //logPrintInTextBox(md5value, "");

                string epn = md5value.Substring(0, 5) + md5value.Substring(md5value.Length - 5, 5);
                string entityid = "ASN_CSE-D-" + epn + "-" + tbSvcCd.Text;

                if(dev.entityId != entityid)
                {
                    dev.entityId = entityid;
                    lbDevEntityId.Text = dev.entityId;
                    logPrintInTextBox("Device EntityID가 " + dev.entityId + "수정되었습니다.", "");
                }

                if (dev.type == "oneM2M")
                {
                    tbTCResult.Text = string.Empty;
                    tc.state = string.Empty;
                }
                else if (tc.state == "tc0201")
                    endLwM2MTC(tc.state);
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
                        if (tc.state == "tc0603")
                            endLwM2MTC("tc0603");
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
            string txData = string.Empty;

            states state = (states)Enum.Parse(typeof(states), lbActionState.Text);
            switch (state)
            {
                case states.setmefserverinfo:
                    //AT$OM_SVR_INFO=<svr>,<ip>,<port>
                    this.sendDataOut(commands["sethttpserverinfo"] + oneM2MBRKIP + "," + oneM2MBRKPort);
                    lbActionState.Text = states.sethttpserverinfo.ToString();

                    nextcommand = "skip";
                    break;
                case states.onem2mtc0201011:
                    //AT$OM_SVR_INFO=<svr>,<ip>,<port>
                    this.sendDataOut(commands["sethttpserverinfo"] + oneM2MBRKIP + "," + oneM2MBRKPort);
                    lbActionState.Text = states.onem2mtc0201012.ToString();

                    nextcommand = "skip";
                    break;
                case states.sethttpserverinfo:
                    this.sendDataOut(commands["getserverinfo"]);
                    lbActionState.Text = states.getserverinfo.ToString();

                    nextcommand = "skip";
                    break;
                case states.onem2mtc0201012:
                    this.sendDataOut(commands["getserverinfo"]);
                    lbActionState.Text = states.onem2mtc0201013.ToString();

                    nextcommand = "skip";
                    break;
                case states.getserverinfo:
                    nextcommand = states.getonem2mmode.ToString();
                    break;
                case states.onem2mtc0201013:
                    this.sendDataOut(commands["getonem2mmode"]);
                    lbActionState.Text = states.onem2mtc0201021.ToString();

                    nextcommand = "skip";
                    break;
                case states.onem2mtc020301:
                case states.onem2mtc0205021:
                case states.onem2mtc0205022:
                case states.onem2mtc0205023:
                case states.onem2mtc0205051:
                case states.onem2mtc0205052:
                case states.onem2mtc020601:
                case states.onem2mtc020603:
                case states.onem2mtc020701:
                case states.onem2mtc021004:
                case states.onem2mtc0211042:
                case states.onem2mtc0211043:
                case states.onem2mtc0212031:
                case states.onem2mtc0212032:
                case states.onem2mtc0212041:
                    nextcommand = "skip";
                    break;
                case states.onem2mtc020602:
                    if (tc.state == "tc020602")
                        endoneM2MTC(tc.state);

                    startoneM2MTC("tc020603");
                    lbActionState.Text = states.onem2mtc020603.ToString();

                    // Data send to SERVER (string original)
                    txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                    if (svr.enrmtKeyId != string.Empty)
                        this.sendDataOut(commands["sendonemsgstr"] + "DtoS" + "," + txData.Length + "," + txData);
                    else
                        this.sendDataOut(commands["sendonemsgstr"] + "StoD" + "," + txData.Length + "," + txData);

                    nextcommand = "skip";
                    break;
                case states.onem2mtc0206041:
                    startoneM2MTC("tc020601");
                    lbActionState.Text = states.onem2mtc020601.ToString();

                    // Data send to SERVER (string original)
                    txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                    if (svr.enrmtKeyId != string.Empty)
                        this.sendDataOut(commands["sendonemsgstr"] + "DtoS" + "," + txData.Length + "," + txData);
                    else
                        this.sendDataOut(commands["sendonemsgstr"] + "StoD" + "," + txData.Length + "," + txData);

                    nextcommand = "skip";
                    break;
                case states.onem2mtc0206042:
                    endoneM2MTC(tc.state);

                    startoneM2MTC("tc020701");
                    // 플랫폼 서버에 data 수신 요청
                    this.sendDataOut(commands["getonem2mdata"] + "StoD");
                    lbActionState.Text = states.onem2mtc020701.ToString();

                    nextcommand = "skip";
                    break;
                case states.onem2mtc0211041:
                    this.sendDataOut(commands["mfotamefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + ",D-" + dev.imsi);
                    lbActionState.Text = states.onem2mtc0211042.ToString();
                    nextcommand = "skip";
                    break;
                case states.setserverinfo:
                    if (dev.model == "BG96")
                    {
                        nextcommand = "rfreset";           // 서버 변경후 망 재연결
                    }
                    break;
                case states.setcdp_bg96:
                    // 쿼텔 LWM2M bootstrap 자동 요청 순서
                    // (setcdp) - (servertype) - endpointpame - mbsps - enable - register
                    // 플랫폼 서버 타입 설정
                    //AT+QLWM2M="select",2
                    this.sendDataOut(commands["setservertype"]);
                    lbActionState.Text = states.setservertype.ToString();

                    nextcommand = "skip";
                    break;
                case states.setservertype:
                    // 쿼텔 LWM2M bootstrap 자동 요청 순서
                    // setcdp - (servertype) - (endpointpame) - mbsps - enable - register
                    // EndPointName 플랫폼 device ID 설정
                    //AT+QLWM2M="enps",0,<service code>
                    //this.sendDataOut(commands["setepns"] + "ASN-CSE-D-6399301537-FOTA" + "\"");
                    this.sendDataOut(commands["setepns"] + tbSvcCd.Text + "\"");
                    lbActionState.Text = states.setepns.ToString();

                    nextcommand = "skip";
                    break;
                case states.setsvrbsbc95:
                    //AT+QLWSERVERIP=LWM2M,<ip>,<port>   BC95모델
                    this.sendDataOut(commands["setsvripbc95"] + serverip + "," + serverport);
                    lbActionState.Text = states.setsvripbc95.ToString();
                    nextcommand = "skip";
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmanufac - autogetmodel - autogetimsi - (autogetimei) - (geticcid) - 마지막
                case states.setepns:
                    // 쿼텔 LWM2M bootstrap 자동 요청 순서
                    // setcdp - servertype - (endpointpame) - (mbsps) - enable - register
                    // PLMN 정보 확인 후 진행
                    string ctn = dev.imsi;
                    if (ctn != ".")
                    {
                        // Bootstrap Parameter 설정
                        //AT+QLWM2M="mbsps",<service code>,<sn>,<ctn>,<iccid>,<device model>
                        string epncmd = commands["setmbsps"] + tbSvcCd.Text + "\",\"";
                        epncmd = epncmd + tBoxDeviceSN.Text + "\",\"";
                        epncmd = epncmd + ctn + "\",\"";

                        string epniccid = dev.iccid;
                        epncmd = epncmd + epniccid.Substring(epniccid.Length - 6, 6) + "\",\"";
                        epncmd = epncmd + tBoxDeviceModel.Text + "\"";
                        this.sendDataOut(epncmd);
                        lbActionState.Text = states.setmbsps.ToString();

                        nextcommand = "skip";
                    }
                    else
                    {
                        MessageBox.Show("USIM이 정상인지 확인해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nextcommand = "";
                    }
                    break;
                case states.setmbsps:
                    if (dev.model == "BG96")
                    {
                        // 쿼텔 LWM2M bootstrap 자동 요청 순서
                        // setcdp - servertype - endpointpame - (mbsps) - (enable) - register
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
                case states.enable_bg96:
                    // 쿼텔 LWM2M bootstrap 자동 요청 순서
                    // disable - setcdp - servertype - endpointpame - mbsps - (enable) - (register)
                    // enable 요청
                    //AT+QLWM2M="register"
                    nextcommand = states.register.ToString();
                    break;
                case states.lwm2mresetbc95:
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // (lwm2mresetbc95) - (holdoffbc95) - getsvripbc95 - autosetsvrbsbc95 - autosetsvripbc95 - getepnsbc95 - setepnsbc95 - getmbspsbc95 - setmbspsbc95 - bootstrapbc95
                    // LWM2M 서버 설정
                    // AT+QBOOTSTRAPHOLDOFF=0
                    nextcommand = states.holdoffbc95.ToString();
                    break;
                case states.holdoffbc95:
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // lwm2mresetbc95 - (holdoffbc95) - (getsvripbc95) - autosetsvrbsbc95 - autosetsvripbc95 - getepnsbc95 - setepnsbc95 - getmbspsbc95 - setmbspsbc95 - bootstrapbc95
                    nextcommand = states.getsvripbc95.ToString();
                    break;
                case states.actsetsvrbsbc95:
                    //AT+QLWSERVERIP=BS,<ip>,<port>   BC95모델
                    this.sendDataOut(commands["autosetsvrbsbc95"] + serverip + "," + serverport);
                    lbActionState.Text = states.autosetsvrbsbc95.ToString();
                    nextcommand = "skip";
                    break;
                case states.autosetsvrbsbc95:
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // lwm2mresetbc95 - holdoffbc95 - getsvripbc95 - (autosetsvrbsbc95) - (autosetsvripbc95) - getepnsbc95 - setepnsbc95 - getmbspsbc95 - setmbspsbc95 - bootstrapbc95
                    //AT+QLWSERVERIP=LWM2M,<ip>,<port>   BC95모델
                    this.sendDataOut(commands["autosetsvripbc95"] + serverip + "," + serverport);
                    lbActionState.Text = states.autosetsvripbc95.ToString();
                    nextcommand = "skip";
                    break;
                case states.actsetsvripbc95:
                    //AT+QLWSERVERIP=LWM2M,<ip>,<port>   BC95모델
                    this.sendDataOut(commands["autosetsvripbc95"] + serverip + "," + serverport);
                    lbActionState.Text = states.autosetsvripbc95.ToString();
                    nextcommand = "skip";
                    break;
                case states.autosetsvripbc95:
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // lwm2mresetbc95 - holdoffbc95 - getsvripbc95 - autosetsvrbsbc95 - (autosetsvripbc95) - (getepnsbc95) - setepnsbc95 - getmbspsbc95 - setmbspsbc95 - bootstrapbc95
                    nextcommand = states.getepnsbc95.ToString();
                    break;
                case states.getsvripbc95:
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // lwm2mresetbc95 - holdoffbc95 - (getsvripbc95) - autosetsvrbsbc95 - autosetsvripbc95 - (getepnsbc95) - setepnsbc95 - (getmbspsbc95) - setmbspsbc95 - bootstrapbc95
                    nextcommand = states.getepnsbc95.ToString();
                    break;
                case states.getepnsbc95:
                // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                // lwm2mresetbc95 - holdoffbc95 - getsvripbc95 - autosetsvrbsbc95 - autosetsvripbc95 - (getepnsbc95) - setepnsbc95 - (getmbspsbc95) - setmbspsbc95 - bootstrapbc95
                case states.setepnsbc95:
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // lwm2mresetbc95 - holdoffbc95 - getsvripbc95 - autosetsvrbsbc95 - autosetsvripbc95 - getepnsbc95 - (setepnsbc95) - (getmbspsbc95) - setmbspsbc95 - bootstrapbc95
                    nextcommand = states.getmbspsbc95.ToString();
                    break;
                case states.autosetepnsbc95:
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // lwm2mresetbc95 - holdoffbc95 - getsvripbc95 - autosetsvrbsbc95 - autosetsvripbc95 - getepnsbc95 - (setepnsbc95) - getmbspsbc95 - setmbspsbc95 - bootstrapbc95
                    this.sendDataOut(nextcommand);
                    lbActionState.Text = states.setepnsbc95.ToString();
                    nextcommand = "skip";
                    break;
                case states.getmbspsbc95:
                // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                // lwm2mresetbc95 - holdoffbc95 - getsvripbc95 - autosetsvrbsbc95 - autosetsvripbc95 - getepnsbc95 - setepnsbc95 - (getmbspsbc95) - setmbspsbc95 - (bootstrapbc95)
                case states.setmbspsbc95:
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // lwm2mresetbc95 - holdoffbc95 - getsvripbc95 - autosetsvrbsbc95 - autosetsvripbc95 - getepnsbc95 - setepnsbc95 - getmbspsbc95 - (setmbspsbc95) - (bootstrapbc95)
                    nextcommand = states.bootstrapbc95.ToString();
                    break;
                case states.autosetmbspsbc95:
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // lwm2mresetbc95 - holdoffbc95 - getsvripbc95 - autosetsvrbsbc95 - autosetsvripbc95 - getepnsbc95 - setepnsbc95 - getmbspsbc95 - (setmbspsbc95) - bootstrapbc95
                    this.sendDataOut(nextcommand);
                    lbActionState.Text = states.setmbspsbc95.ToString();
                    nextcommand = "skip";
                    break;
                case states.bootstrapbc95:
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // lwm2mresetbc95 - holdoffbc95 - getsvripbc95 - autosetsvrbsbc95 - autosetsvripbc95 - getepnsbc95 - setepnsbc95 - getmbspsbc95 - (setmbspsbc95) - (bootstrapbc95) - reboot module
                case states.disablebc95:
                    nextcommand = states.rebootbc95.ToString();
                    break;
                case states.autogetmodemver:
                case states.autogetmodemvertpb23:
                case states.autogetmodemvernt:
                case states.autogetmodemvertld:
                case states.autogetmodemverwr:
                case states.autogetmodemverbc95:
                    // 모듈 정보 자동 확인 후 , LTE network attach 요청하면 정상적으로 attach 성공했는지 확인
                    nextcommand = states.getcereg.ToString();
                    break;
                case states.setcereg:
                case states.setceregtpb23:
                    // LTE network attach 요청하면 정상적으로 attach 성공했는지 확인 필요
                    nextcommand = states.getcereg.ToString();
                    break;
                case states.setncdp:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // (setncdp) - (setepnstpb23) - setmbspstpb23 - bootstrapmodetpb23 - bootstraptpb23
                    // End Point Name Parameter 설정
                    //AT+MLWEPNS="LWM2M 서버 entityID"
                    setDeviceEntityID(lbIccid.Text);
                    this.sendDataOut(commands["setepnstpb23"] + dev.entityId);
                    lbActionState.Text = states.setepnstpb23.ToString();

                    nextcommand = "skip";
                    break;
                case states.setepnstpb23:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - (setepnstpb23) - (setmbspstpb23) - bootstrapmodetpb23 - bootstraptpb23
                    // Bootstarp Parameter 설정
                    //AT+MLWMBSPS="serviceCode=GAMR|deviceSerialNo=1234567|ctn=01022335078 | iccId = 127313 | deviceModel = Summer | mac = "

                    string command = tbSvcCd.Text + "|deviceSerialNo=";
                    command += tBoxDeviceSN.Text + "|ctn=";
                    command += dev.imsi + "|iccId=";

                    string iccid = dev.iccid;
                    command += iccid.Substring(iccid.Length - 6, 6) + "|deviceModel=";
                    command += tBoxDeviceModel.Text + "|mac=";

                    this.sendDataOut(commands["setmbspstpb23"] + command);
                    lbActionState.Text = states.setmbspstpb23.ToString();

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
                case states.onem2mtc0201022:
                    nextcommand = states.onem2mtc0201023.ToString();
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
                case states.sendmsgstr:
                case states.sendmsghex:
                case states.sendmsgstrtpb23:
                    endLwM2MTC("tc0501");
                    break;
                case states.deregister:
                    endLwM2MTC("tc0401");
                    break;
                case states.deregistertpb23:        // TPB23 모델은 AT+MLWEVTIND=1 이벤트를 기다림
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
                }
                else
                {
                    lbActionState.Text = states.idle.ToString();
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
                    dev.maker = str1;
                    this.logPrintInTextBox("제조사값이 저장되었습니다.", "");
                    if (str1 == "AM Telecom" || str1 == "QUALCOMM INCORPORATED"
                        || str1 == "LIME-I Co., Ltd")        //AMTEL 모듈은 OK가 오지 않음
                    {
                        this.sendDataOut(commands["autogetmodelgmm"]);
                        lbActionState.Text = states.autogetmodel.ToString();

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
                    dev.model = str1;
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
                        dev.imsi = ctn;

                        if (dev.maker == "AM Telecom")        //AMTEL 모듈은 OK가 오지 않음
                        {
                            lbActionState.Text = states.autogeticcidamtel.ToString();
                            nextcommand = states.autogeticcidamtel.ToString();
                        }
                        else if (dev.maker == "GCT")
                        {
                            lbActionState.Text = states.autogeticcidgct.ToString();
                            nextcommand = states.autogeticcidgct.ToString();
                        }
                        else if (dev.model == "TPB23")
                        {
                            lbActionState.Text = states.autogeticcidtpb23.ToString();
                            nextcommand = states.autogeticcidtpb23.ToString();
                        }
                        else if (dev.model.StartsWith("BC95", System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            nextcommand = states.autogeticcidbc95.ToString();
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

                    nextcommand = "skip";
                    break;
                case states.setepns:
                    if (dev.imsi != "알 수 없음")
                    {
                        // Bootstrap Parameter 설정
                        //AT+QLWM2M="mbsps",<service code>,<sn>,<ctn>,<iccid>,<device model>
                        string command = commands["setmbsps"] + tbSvcCd.Text + "\",\"";
                        command = command + tBoxDeviceSN.Text + "\",\"";
                        command = command + dev.imsi + "\",\"";

                        string iccid = dev.iccid;
                        command = command + iccid.Substring(iccid.Length - 6, 6) + "\",\"";
                        command = command + tBoxDeviceModel.Text + "\"";
                        this.sendDataOut(command);
                        lbActionState.Text = states.setmbsps.ToString();

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
                        dev.imsi = ctn;
                        lbActionState.Text = states.idle.ToString();
                        this.logPrintInTextBox("IMSI값이 저장되었습니다.", "");
                    }
                    else
                        this.logPrintInTextBox("USIM 상태 확인이 필요합니다.", "");

                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.getmodel:
                    lbModel.Text = str1;
                    dev.model = str1;
                    lbActionState.Text = states.idle.ToString();
                    this.logPrintInTextBox("모델값이 저장되었습니다.", "");

                    setModelConfig(str1);

                    if (str1 == "BG96")
                    {
                        nextcommand = "getNWmode";
                    }
                    break;
                case states.getmanufac:
                    lbMaker.Text = str1;
                    dev.maker = str1;
                    lbActionState.Text = states.idle.ToString();
                    this.logPrintInTextBox("제조사값이 저장되었습니다.", "");
                    break;
                case states.getmodemver:
                case states.getmodemvertpb23:
                    lbModemVer.Text = str1;
                    dev.version = str1;
                    lbActionState.Text = states.idle.ToString();
                    this.logPrintInTextBox("모뎀버전이 저장되었습니다.", "");

                    if (tc.state == "tc021104" && lbModemVer.Text == lbmodemfwrver.Text)
                        endoneM2MTC(tc.state);
                    break;
                case states.onem2mtc0211044:
                    lbModemVer.Text = str1;
                    dev.version = str1;
                    if (tc.state == "tc021104" && lbModemVer.Text == lbmodemfwrver.Text)
                    {
                        endoneM2MTC(tc.state);

                        startoneM2MTC("tc021202");
                        this.sendDataOut(commands["delsubscript"] + "StoD");
                        lbActionState.Text = states.onem2mtc0212022.ToString();
                    }
                    break;
                case states.autogetmodemver:
                case states.autogetmodemvertpb23:
                    lbModemVer.Text = str1;
                    dev.version = str1;
                    this.logPrintInTextBox("모뎀버전이 저장되었습니다.", "");
                    break;
                default:
                    break;
            }
        }

        private void setModelConfig(string model)
        {
            if (dev.maker == "AM Telecom")        //AMTEL/oneM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "AMM5400LG";
                dev.type = "oneM2M";
            }
            else if (dev.maker == "QUALCOMM INCORPORATED")        //텔라딘/oneM2M 모듈
            {
                tbSvcCd.Text = "SMCL";
                tBoxDeviceModel.Text = "TM800L";
                dev.type = "oneM2M";
            }
            else if (dev.maker == "LIME-I Co., Ltd")        //라임아이/oneM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "LML-D";
                dev.type = "oneM2M";
            }
            else if (model.StartsWith("NTLM3", System.StringComparison.CurrentCultureIgnoreCase))         //NTmore/oneM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "NTM_Simulator";
                dev.type = "oneM2M";
            }
            else if (model == "EC25" || model == "EC21")                                                 //쿼텔/oneM2M 모듈
            {
                tbSvcCd.Text = "CATO";
                tBoxDeviceModel.Text = "EC25-E";
                dev.type = "oneM2M";
            }
            else if (model == "BG96")                                                                   //쿼텔/LwM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "LWEMG";
                dev.type = "LwM2M";
            }
            else if (model.StartsWith("BC95", System.StringComparison.CurrentCultureIgnoreCase))         //쿼텔/LwM2M 모듈
            {
                tbSvcCd.Text = "CATO";
                tBoxDeviceModel.Text = "LWEMG";
                dev.type = "LwM2M";
            }
            else if (model == "TPB23")                                                                   //화웨이/LwM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "TPB23";
                dev.type = "LwM2M";
            }
            else if (model == "GDM7243R1")                                                                   //바인테크/GCT/LwM2M 모듈
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "VTLM-102G";
                dev.type = "LwM2M";
            }
            else                                                                                        //default/LwM2M 메뉴 활성화
            {
                tbSvcCd.Text = "CATM";
                tBoxDeviceModel.Text = "LWEMG";
                dev.type = "LwM2M";
            }

            setControlPanel();
        }

        private void setControlPanel()
        {
            if (dev.type == "oneM2M")                     // oneM2M Device
            {
                gbLwM2MDevice.Enabled = false;
                gbOneM2MDevice.Enabled = true;

                if (svr.enrmtKeyId != string.Empty)
                    gbOneM2MServer.Enabled = true;
                else
                    gbOneM2MServer.Enabled = false;
                gbLwM2MServer.Enabled = false;
            }
            else if (dev.type == "LwM2M")                // LwM2M Device
            {
                gbLwM2MDevice.Enabled = true;
                gbOneM2MDevice.Enabled = false;

                if (svr.enrmtKeyId != string.Empty)
                    gbLwM2MServer.Enabled = true;
                else
                    gbLwM2MServer.Enabled = false;
                gbOneM2MServer.Enabled = false;
            }
            else                                    // Device information None
            {
                gbLwM2MDevice.Enabled = false;
                gbLwM2MServer.Enabled = false;
                gbOneM2MDevice.Enabled = false;
                gbOneM2MServer.Enabled = false;
            }
        }

        private void getDeviveInfo()
        {
            this.logPrintInTextBox("DEVICE 정보 전체를 요청합니다.","");

            // 단말 정보 자동 갱신 순서
            // (autogetmanufac) - autogetmodel - autogetimsi - geticcid
            this.sendDataOut(commands["autogetmanufac"]);
            lbActionState.Text = states.autogetmanufac.ToString();
        }

        // LWM2M 플랫폼 디바이스 등록을 요청 (bootstrap)
        private void DeviceProvision()
        {
            if (isDeviceInfo())
            {
                if (dev.model == "BG96")       //쿼텔
                {
                    // 쿼텔 LWM2M bootstrap 자동 요청 순서
                    // (setcdp) - servertype - endpointpame - mbsps - enable
                    // 플랫폼 서버 타입 설정
                    //AT+QLWM2M="cdp",<ip>,<port>
                    this.sendDataOut(commands["setcdp_bg96"] + "\"" + serverip + "\"," + serverport);
                    lbActionState.Text = states.setcdp_bg96.ToString();
                }
                else if (dev.model == "TPB23")
                {
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - setepnstpb23 - setmbspstpb23 - bootstrapmodetpb23 - bootstraptpb23
                    // LWM2M 서버 설정
                    // AT+NCDP=IP,PORT
                    this.sendDataOut(commands["setncdp"] + "\"" + serverip + "\"," + serverport);
                    lbActionState.Text = states.setncdp.ToString();
                }
                else if (dev.model.StartsWith("BC95", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // LWM2M bootstrap 자동 요청 순서 (BC95 V150)
                    // lwm2mresetbc95 - holdoffbc95 - getsvripbc95 - autosetsvrbsbc95 - autosetsvripbc95 - getepnsbc95 - setepnsbc95 - getmbspsbc95 - setmbspsbc95 - bootstrapbc95
                    // LWM2M 서버 설정
                    this.sendDataOut(commands["lwm2mresetbc95"]);
                    lbActionState.Text = states.lwm2mresetbc95.ToString();
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
            if(dev.entityId == string.Empty)
            {
                this.getDeviveInfo();
                MessageBox.Show("모듈 정보를 읽고 있습니다.\n다시 시도해주세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;  
            }

            return true;
        }

        private void sendDataToServer()
        {
            if (isDeviceInfo())
            {
                string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " LwM2M device";
                lbDevLwM2MData.Text = txData;
                if (dev.model == "BG96")
                {
                    // Data send to SERVER (string original)
                    //AT+QLWM2M="uldata",<object>,<length>,<data>
                    startLwM2MTC("tc0501");
                    this.sendDataOut(commands["sendmsgstr"] + txData.Length + ",\"" + txData + "\"");
                    lbActionState.Text = states.sendmsgstr.ToString();
                }
                else if (dev.model.StartsWith("BC95", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // Data send to SERVER (string original)
                    //AT+QLWULDATA=<length>,<data>
                    startLwM2MTC("tc0501");
                    string hexOutput = StringToBCD(txData.ToCharArray());
                    this.sendDataOut(commands["sendmsgstbc95"] + hexOutput.Length / 2 + "," + hexOutput);
                    lbActionState.Text = states.sendmsgstr.ToString();
                }
                else
                {
                    // Data send to SERVER (string original)
                    //AT+MLWULDATA=<length>,<data>
                    startLwM2MTC("tc0501");
                    string hexOutput = StringToBCD(txData.ToCharArray());

                    this.sendDataOut(commands["sendmsgstrtpb23"] + hexOutput.Length / 2 + "," + hexOutput);
                    lbActionState.Text = states.sendmsgstr.ToString();
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
            string pathname = @"c:\temp\seriallog\";
            DateTime currenttime = DateTime.Now;
            string filename = null;

            Directory.CreateDirectory(pathname);

            if (tbTCResult.Text != string.Empty)
            {
                filename = "TestResult_" + currenttime.ToString("MMdd_hhmmss") + ".csv";
                resultFileWrite(pathname, filename);

                filename = "tcresult_log_" + currenttime.ToString("MMdd_hhmmss") + ".txt";
                logFileWrite(pathname, filename, tbTCResult.Text);
            }

            if (tBoxDataIN.Text != string.Empty)
            {
                filename = "device_log_" + currenttime.ToString("MMdd_hhmmss") + ".txt";
                logFileWrite(pathname, filename, tBoxDataIN.Text);
            }

            if (tbLog.Text != string.Empty)
            {
                filename = "server_log_" + currenttime.ToString("MMdd_hhmmss") + ".txt";
                logFileWrite(pathname, filename, tbLog.Text);
            }
        }

        private void logFileWrite(string path, string filename, string text)
        {
            // Create a file to write to.
            FileStream fs = null;
            try
            {
                fs = new FileStream(path + filename, FileMode.Create, FileAccess.Write);
                // Create a file to write to.
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                char[] logmsg = text.ToCharArray();
                sw.Write(logmsg, 0, text.Length);

                sw.Close();
                fs.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resultFileWrite(string pathname, string filename)
        {
            try
            {
                // Create a file to write to.
                FileStream fs = new FileStream(pathname + filename, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096);

                // Create a file to write to.
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                string devinfo = "모델명," + dev.model;
                sw.WriteLine(devinfo);
                devinfo = "제조사," + dev.maker;
                sw.WriteLine(devinfo);
                devinfo = "버전," + dev.version;
                sw.WriteLine(devinfo);
                sw.WriteLine("시험일," + DateTime.Now.ToString("MM/dd hh:mm:ss"));
                sw.WriteLine("EntityID," + dev.entityId);
                sw.WriteLine(string.Empty);

                string tcresult;
                if (dev.type == "oneM2M")
                {
                    foreach (string tcindex in Enum.GetNames(typeof(onem2mtc)))
                    {
                        devinfo = onem2mtclist[tcindex] + ",";
                        onem2mtc index = (onem2mtc)Enum.Parse(typeof(onem2mtc), tcindex);
                        tcresult = tc.onem2m[(int)index];
                        if (tcresult == null)
                            devinfo += "Not TEST";
                        else
                            devinfo += tcresult;
                        sw.WriteLine(devinfo);

                    }
                }
                else
                {
                    foreach (string tcindex in Enum.GetNames(typeof(lwm2mtc)))
                    {
                        devinfo = lwm2mtclist[tcindex] + ",";
                        lwm2mtc indexl = (lwm2mtc)Enum.Parse(typeof(lwm2mtc), tcindex);
                        tcresult = tc.lwm2m[(int)indexl];
                        if (tcresult == null)
                            devinfo += "Not TEST";
                        else
                            devinfo += tcresult;
                        sw.WriteLine(devinfo);
                    }
                }

                sw.WriteLine(string.Empty);

                sw.Close();
                fs.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                if (dev.model != "TPB23" || dev.model.StartsWith("BC95", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    text += "|szx=6";       // FOTA buffer size set 1024bytes.
                }

                logPrintInTextBox(text + " 로 FOTA응답하였습니다.", "");

                if (dev.model == "BG96")
                {
                    // Data send to SERVER (string to BCD convert)
                    //AT+QLWM2M="uldata,"fwVr=1.0.0|fwSt=1|fwRt=0"

                    this.sendDataOut(commands["sendmsgver"] + text.Length + ",\"" + text + "\"");
                    lbActionState.Text = states.sendmsgver.ToString();
                }
                else if (dev.model.StartsWith("BC95", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // Data send to SERVER (string original)
                    //AT+QLWULDATA=1,<length>,<data>
                    string hexOutput = StringToBCD(text.ToCharArray());

                    this.sendDataOut(commands["sendmsgverbc95"] + hexOutput.Length / 2 + "," + hexOutput);
                    lbActionState.Text = states.sendmsgverbc95.ToString();
                }
                else
                {
                    // Data send to SERVER (string original)
                    //AT+MLWULDATA=<length>,<data>
                    string hexOutput = StringToBCD(text.ToCharArray());

                    this.sendDataOut(commands["sendmsgvertpb23"] + hexOutput.Length / 2 + "," + hexOutput);
                    lbActionState.Text = states.sendmsgvertpb23.ToString();
                }
            }
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

                setControlPanel();
                gbServer.Enabled = true;
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
            packetStr += "<csi>/" + svr.entityId + "</csi>";
            packetStr += "<cb>/" + svr.entityId + "/cb-1</cb>";
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

        private void RetrivePoaToPlatform()
        {
            ReqHeader header = new ReqHeader();
            //header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_01222990847";
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi;
            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "device_CSR_retrive";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/xml";
            header.ContentType = string.Empty;

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    value = xn["poa"].InnerText; // data value
                }
                lbdevicepoa.Text = value;
            }
        }

        private void RetriveDverToPlatform()
        {
            ReqHeader header = new ReqHeader();
            //header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_01222990847";
            if(dev.maker == "QUALCOMM INCORPORATED" || dev.model == "EC21" || dev.model == "EC25")
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/nod-m2m_" + dev.imsi + "/fwr-m2m_D_" + dev.imsi;
            else
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/nod-m2m_" + dev.imsi + "/fwr-m2m_D" + dev.imsi;
            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "device_CSR_retrive";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/xml";
            header.ContentType = string.Empty;

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    value = xn["vr"].InnerText; // data value
                }
                lbdevicever.Text = value;
            }
        }

        private void RetriveMverToPlatform()
        {
            ReqHeader header = new ReqHeader();
            //header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_01222990847";
            if (dev.maker == "QUALCOMM INCORPORATED")
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/nod-m2m_" + dev.imsi + "/fwr-m2m_" + dev.imsi;
            else if (dev.model == "EC21" || dev.model == "EC25")
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/nod-m2m_" + dev.imsi + "/fwr-m2m_M_" + dev.imsi;
            else
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/nod-m2m_" + dev.imsi + "/fwr-m2m_M" + dev.imsi;
            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "device_CSR_retrive";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/xml";
            header.ContentType = string.Empty;

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    value = xn["vr"].InnerText; // data value
                }
                lbmodemfwrver.Text = value;
            }
        }

        private void RetriveDataToPlatform()
        {
            ReqHeader header = new ReqHeader();
            //header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_01222990847/cnt-TEMP/la";
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/cnt-DtoS" + "/la";
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

                if (lboneM2MRxData.Text == lbSendedData.Text)
                {
                    if (tc.state == "tc020504")
                    {
                        endoneM2MTC(tc.state);

                        if (lbActionState.Text == states.onem2mtc020504.ToString())
                        {
                            startoneM2MTC("tc020601");
                            lbSvroneM2MData.Text = SendDataToPlatform("oneM2M");
                            lbActionState.Text = states.onem2mtc020601.ToString();
                        }
                    }
                }
                if ((lbActionState.Text == states.onem2mtc020601.ToString()) || (lbActionState.Text == states.onem2mtc020603.ToString()) || (lbActionState.Text == states.onem2mtc0206041.ToString()))
                {
                    lbSvroneM2MData.Text = SendDataToPlatform("oneM2M");
                }
            }
        }

        private void RetriveDataToDevice()
        {
            ReqHeader header = new ReqHeader();
            setDeviceEntityID(lbIccid.Text);
            header.Url = brkUrl + "/" + dev.entityId  + "/TEST";
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
                    lbDirectRxData.Text = Encoding.UTF8.GetString(Convert.FromBase64String(value));
                else
                    lbDirectRxData.Text = value;
            }
        }

        private string SendDataToPlatform(string target_comm)
        {
            ReqHeader header = new ReqHeader();
            if (target_comm == "oneM2M")
            {
                //header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_01222990847/cnt-TEMP";
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/cnt-StoD";
            }
            else if (target_comm == "oneDevice")
            {
                setDeviceEntityID(lbIccid.Text);
                header.Url = brkUrl + "/" + dev.entityId + "/TEST";
            }
            else
            {
                setDeviceEntityID(lbIccid.Text);
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
            string txData = string.Empty;
            if ((lbActionState.Text == states.onem2mtc020504.ToString()) || (lbActionState.Text == states.onem2mtc020601.ToString()) || (lbActionState.Text == states.onem2mtc020603.ToString()) || (lbActionState.Text == states.onem2mtc0206041.ToString()))
                txData = lbSendedData.Text;
            else
                txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " server";
            packetStr += "<con>" + txData + "</con>";
            packetStr += "</m2m:cin>";
            string retStr = SendHttpRequest(header, packetStr);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
            return txData;
        }

        private void DeviceCheckToPlatform()
        {
            ReqHeader header = new ReqHeader();
            setDeviceEntityID(lbIccid.Text);
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
                tbLog.AppendText(Environment.NewLine);
                tbLog.AppendText(DateTime.Now.ToString("hh:mm:ss.fff") + " (" + lbActionState.Text + ") : " + data);
                tbLog.SelectionStart = tbLog.TextLength;
                tbLog.ScrollToCaret();
            }));
        }

        private void LogWriteNoTime(string data)
        {
            BeginInvoke(new Action(() =>
            {
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

        private void btnoneM2MFullTest_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                // oneM2M 플랫폼 인증 요청
                startoneM2MTC("tc020101");
                //AT$OM_SVR_INFO=<svr>,<ip>,<port>
                this.sendDataOut(commands["setmefserverinfo"] + oneM2MMEFIP + "," + oneM2MMEFPort);
                lbActionState.Text = states.onem2mtc0201011.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                if (progressBar1.Value == 100 || progressBar2.Value == 100)
                {
                    logPrintInTextBox("잠시 후 COM 포트 재오픈이 필요합니다.", "");

                    if (lbActionState.Text == states.idle.ToString())
                    {
                        lbActionState.Text = states.closed.ToString();
                        timer1.Stop();
                    }
                    progressBar1.Value = 0;
                    progressBar2.Value = 0;
                }
                else if (lbActionState.Text == states.onem2mtc021103.ToString() || lbActionState.Text == states.onem2mtc0208011.ToString())
                    doOpenComPort();
            }
        }

        private void btnTCResultSave_Click(object sender, EventArgs e)
        {
            string pathname = @"c:\temp\seriallog\";
            DateTime currenttime = DateTime.Now;
            string filename = null;

            Directory.CreateDirectory(pathname);

            if (tbTCResult.Text != string.Empty)
            {
                filename = "TestResult_" + currenttime.ToString("MMdd_hhmmss") + ".csv";
                resultFileWrite(pathname, filename);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo() && svr.entityId != string.Empty)
            {
                startoneM2MTC("tc020504");
                // Data send to SERVER (string original)
                //AT$OM_C_INS_REQ=<server id>,<object>,<length>,<data>
                string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                this.sendDataOut(commands["sendonemsgsvr"] + svr.entityId + "," + "DtoS" + "," + txData.Length + "," + txData);
                lbActionState.Text = states.sendonemsgsvr.ToString();
                lbDirectTxData.Text = txData;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LogWrite("----------DATA SEND----------");
            if (svr.enrmtKeyId != string.Empty)
            {
                startoneM2MTC("tc020601");
                label13.Text = SendDataToPlatform("oneDevice");
            }
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogWrite("----------DATA RECIEVE----------");
            if (svr.enrmtKeyId != string.Empty)
                RetriveDataToDevice();
            else
                LogWrite("서버인증파라미터 세팅하세요");
        }

        private void btnLwM2MFullTest_Click(object sender, EventArgs e)
        {

        }

        private void tbSvcCd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dev.entityId != string.Empty)
                    setDeviceEntityID(lbIccid.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }

    public class TCResult
    {
        public string state { get; set; }            // 테스트 중인 항목
        public string[] lwm2m { get; set; }           // LwM2M 항목별 시험결과
        public string[] onem2m { get; set; }           // oneM2M 항목별 시험결과
    }

    public class Device
    {
        public string imsi { get; set; }            // 디바이스 전화번호
        public string iccid { get; set; }           // 디바이스 ICCID
        public string entityId { get; set; }        // oneM2M 디바이스 EntityID

        public string maker { get; set; }           // 모듈 제조사
        public string model { get; set; }           // 모듈 모델명
        public string version { get; set; }         // 모듈 펌웨어 버전

        public string type { get; set; }            // 플랫폼 연동 방식 (None/oneM2M/LwM2M)
    }

    public class ServiceServer
    {
        public string svcSvrCd { get; set; }        // 서비스 서버의 시퀀스
        public string svcCd { get; set; }           // 서비스 서버의 서비스코드
        public string svcSvrNum { get; set; }       // 서비스 서버의 Num ber

        public string enrmtKey { get; set; }        // oneM2M 인증 KeyID를 생성하기 위한 Key
        public string entityId { get; set; }        // oneM2M에서 사용하는 서버 ID
        public string token { get; set; }           // 인증구간 통신을 위해 발급하는 Token

        public string enrmtKeyId { get; set; }      // MEF 인증 결과를 통해 생성하는 ID

        public string remoteCSEName { get; set; }   // RemoteCSE 리소스 이름
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
