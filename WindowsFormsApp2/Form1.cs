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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private enum states
        {
            idle,
            getmodel,
            getmanufac,
            getimsi,
            getimei,
            geticcid,
            autogetmodel,
            autogetmanufac,
            autogetimsi,
            autogetimei,
            autogeticcid,
            bootstrap,
            setserverinfo,
            setservertype,
            setepns,
            setmbsps,
            setAutoBS,
            register,
            deregister,
            sendLWM2Mdata,
            receiveLWM2Mdata,
            setFOTAinfo,
            receiveFOTAdata,
            downloadMDLFOTA,
            updateMDLFOTA,
            lwm2mreset,
            sendmsgstr,
            sendmsghex,
            setcereg,
            getcereg,
            reset
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

        Dictionary<string, string> commands = new Dictionary<string, string>();
        Dictionary<char, int> bcdvalues = new Dictionary<char, int>();

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
                tSCBoxComPort.Items.AddRange(ports);
                cBoxCOMPORT.SelectedIndex = 0;
            }

            chBoxDtrEnable.Checked = false;
            serialPort1.DtrEnable = false;
            chBoxRTSEnable.Checked = false;
            serialPort1.RtsEnable = false;

            sendWith = "Both";
            RxDispOrder = "BOTTOM";

            this.setWindowLayOut();
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
            commands.Add("getimei", "AT+GSN");
            commands.Add("getmodel", "AT+CGMM");
            commands.Add("getmanufac", "AT+CGMI");
            commands.Add("setcereg", "AT+CEREG=1");
            commands.Add("getcereg", "AT+CEREG?");
            commands.Add("reset", "AT+CFUN=3,3");

            commands.Add("setserverinfo", "AT+QLWM2M=\"cdp\",");
            commands.Add("setservertype", "AT+QLWM2M=\"select\",2");
            //commands.Add("setepns", "AT+QLWM2M=\"epns\",1,\"");
            commands.Add("setepns", "AT+QLWM2M=\"epns\",0,\"");
            commands.Add("setmbsps", "AT+QLWM2M=\"mbsps\",\"");
            commands.Add("setAutoBS", "AT+QLWM2M=\"enable\",");
            commands.Add("register", "AT+QLWM2M=\"register\"");
            commands.Add("deregister", "AT+QLWM2M=\"deregister\"");
            commands.Add("lwm2mreset", "AT+QLWM2M=\"reset\"");
            commands.Add("bootstrap", "AT+QLWM2M=\"bootstrap\",1");
            commands.Add("sendmsgstr", "AT+QLWM2M=\"uldata\",10250,");
            commands.Add("sendmsghex", "AT+QLWM2M=\"ulhex\",10250,");

        }

        private void setWindowLayOut()
        {
            groupBox4.Width = panel1.Width - 230;
            groupBox4.Height = panel1.Height - 55;
            cBoxATCMD.Width = groupBox4.Width - 90;

            groupBox3.Width = groupBox4.Width - 230;
            groupBox3.Height = groupBox4.Height - 35;

            tBoxDataIN.Height = groupBox3.Height - 54;
            tBoxDataOut.Width = groupBox3.Width - 90;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.doOpenComPort();
        }

        private void doOpenComPort()
        {
            try
            {
                if(!serialPort1.IsOpen)
                {
                    serialPort1.PortName = cBoxCOMPORT.Text;
                    serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                    serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                    serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                    serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);
                }

                serialPort1.Open();
                progressBar1.Value = 100;
                groupBox1.Enabled = true;
                groupBox4.Enabled = true;
                logPrintInTextBox("COM PORT가 연결 되었습니다.","");

                this.sendDataOut(commands["getcereg"]);
                tBoxActionState.Text = states.getcereg.ToString();

                timer1.Start();                
            }

            catch (Exception err)
            {
                //groupBox1.Enabled = false;
                //groupBox4.Enabled = false;
                logPrintInTextBox(err.Message, "");

            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                this.doCloseComPort();
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

        private void ChBoxDtrEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxDtrEnable.Checked)
            {
                serialPort1.DtrEnable = true;
                MessageBox.Show("DTR Enable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else { serialPort1.DtrEnable = false; }
        }

        private void ChBoxRTSEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxRTSEnable.Checked)
            {
                serialPort1.RtsEnable = true;
                MessageBox.Show("RTS Enable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else { serialPort1.RtsEnable = false; }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tBoxDataOut.Text != "")
            {
                tBoxDataOut.Text = "";
            }
        }

        private void BtnATCMD_Click(object sender, EventArgs e)
        {
            if (cBoxATCMD.Text.Length != 0)
            {
                DataOutandstore(cBoxATCMD.Text);
            }

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
                    if (tBoxActionState.Text == "idle")
                    {
                        string command = dataOUT.ToUpper();
                        if (command == "AT+CIMI")
                        {
                            tBoxActionState.Text = states.getimsi.ToString();
                        }
                        else if (command == "AT+ICCID")
                        {
                            tBoxActionState.Text = states.geticcid.ToString();
                        }
                        else if (command == "AT+GSN")
                        {
                            tBoxActionState.Text = states.getimei.ToString();
                        }
                        else if (command == "AT+CGMM")
                        {
                            tBoxActionState.Text = states.getmodel.ToString();
                        }
                        else if (command == "AT+CGMI")
                        {
                            tBoxActionState.Text = states.getmanufac.ToString();
                        }

                        timer1.Start();
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.doOpenComPort();     // Serial port가 끊어진 것으로 판단, 포트 재오픈
            }
        }

        private void ClearRXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tBoxDataIN.Text != "")
            {
                tBoxDataIN.Text = "";
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Minho Park\nSince 2019", "Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.setWindowLayOut();
        }

        // menu bar에서 COM port의 data format를 설정
        private void TSMenu6bits_Click(object sender, EventArgs e)
        {
            cBoxDataBits.Text = "6";
        }

        private void TSMenu7bits_Click(object sender, EventArgs e)
        {
            cBoxDataBits.Text = "7";
        }

        private void TSMenu8bits_Click(object sender, EventArgs e)
        {
            cBoxDataBits.Text = "8";
        }

        // menu bar에서 COM port의 stop bits format를 설정
        private void TSMenuStopOne_Click(object sender, EventArgs e)
        {
            cBoxStopBits.Text = "One";
        }

        private void TSMenuStopTwo_Click(object sender, EventArgs e)
        {
            cBoxStopBits.Text = "Two";
        }

        // menu bar에서 COM port의 parity bit format를 설정
        private void TSMenuParityNone_Click(object sender, EventArgs e)
        {
            cBoxParityBits.Text = "None";
        }

        private void TSMenuParityOdd_Click(object sender, EventArgs e)
        {
            cBoxParityBits.Text = "Odd";
        }

        private void TSMenuParityEven_Click(object sender, EventArgs e)
        {
            cBoxParityBits.Text = "Even";
        }

        // menu bar에서 COM port의 baud rate를 설정
        private void TSMenuBaudRate24_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "2400";
        }

        private void TSMenuBaudRate48_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "4800";
        }

        private void TSMenuBaudRate96_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "9600";
        }

        private void TSMenuBaudRate384_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "38400";
        }

        private void TSMenuBaudRate768_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "76800";
        }

        private void TSMenuBaudRate1152_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "115200";
        }

        // menu bar에서 COM port의 하드웨어 DTR control를 설정
        private void TSMenuDTRDisable_Click(object sender, EventArgs e)
        {
            chBoxDtrEnable.Checked = false;
        }

        private void TSMenuDTREnable_Click(object sender, EventArgs e)
        {
            chBoxDtrEnable.Checked = true;
        }

        // menu bar에서 COM port의 하드웨어 RTS control를 설정
        private void TSMenuRTSDisable_Click(object sender, EventArgs e)
        {
            chBoxRTSEnable.Checked = false;
        }

        private void TSMenuRTSEnable_Click(object sender, EventArgs e)
        {
            chBoxRTSEnable.Checked = true;
        }

        // menu bar에서 COM port를 변경하면 화면의 COM port 값도 같이 변경
        private void TSCBoxComPort_TextChanged(object sender, EventArgs e)
        {
            cBoxCOMPORT.Text = tSCBoxComPort.Text;
        }

        // 화면에서 COM port를 변경하면 menu bar의 COM port 값도 같이 변경
        private void CBoxCOMPORT_TextChanged(object sender, EventArgs e)
        {
            tSCBoxComPort.Text = cBoxCOMPORT.Text;
        }

        // menu bar에서 명령어 전송시 자동으로 문장 마지막에 추가할 문자를 설정
        private void TSMenuEndLineNone_Click(object sender, EventArgs e)
        {
            sendWith = "None";
        }

        private void TSMenuEndLineBoth_Click(object sender, EventArgs e)
        {
            sendWith = "Both";
        }

        private void TSMenuEndLineLF_Click(object sender, EventArgs e)
        {
            sendWith = "LF";

        }

        private void TSMenuEndLineCR_Click(object sender, EventArgs e)
        {
            sendWith = "CR";
        }

        // menu bar에서 수신한 값을 표시하는 방향(위/아래)을 설정
        private void TSMenuTop_Click(object sender, EventArgs e)
        {
            RxDispOrder = "TOP";
        }

        private void TSMenuDown_Click(object sender, EventArgs e)
        {
            RxDispOrder = "BOTTOM";
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

        // serial port에서 data 수신이 될 때, 발생하는 이벤트 함수
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort1.ReadExisting();    // 수신한 버퍼에 있는 데이터 모두 받음
            this.Invoke(new EventHandler(ShowData));
        }

        // 수신 데이터 처리 thread 시작
        private void ShowData(object sender, EventArgs e)
        {
            //logPrintInTextBox(dataIN,"rx");

            string[] words = dataIN.Split('\n');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

            foreach (var word in words)
            {
                string str1;

                int lflength = word.IndexOf("\r");
                if(lflength>1)
                {
                    str1 = word.Substring(0 , lflength);    // \r\n를 제외하고 명령어만 처리하기 위함
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
                //"AT+CIMI",
                "+ICCID:",      // ICCID 값을 저장한다.
                //"AT+GSN",
                //"AT+CGMM",
                //"AT+CGMI",
                //"AT+CEREG=1",
                //"AT+CEREG?",
                "+CEREG:",      // LTE network 상태를 확인하고 연결이 되어 있지 않으면 재접속 시도
                "+QLWEVENT:",    // 모듈 부팅시, LWM2M 등록 상태 이벤트, 진행 상태를 status bar에 진행율 표시
                "+QLWDLDATA:"
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
                hexOutput += String.Format("{0:XX}", value);
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
            if (find_msg == false)
            {
                //logPrintInTextBox("No Matching Data!!!","");

                this.parseNoPrefixData(rxMsg);
            }

        }

        // 수신한 응답 값과 특정 값과 일치하는 경우
        // 응답을 받고 후 작업이 필요한지 확인한다. 
        void parseReceiveData(string s, string str2)
        {
            if (s == "OK")
            {
                states state = (states)Enum.Parse(typeof(states), tBoxActionState.Text);
                switch (state)
                {
                    case states.setservertype:
                        // LWM2M bootstrap 자동 요청 순서
                        // (servertype) - (endpointpame) - mbsps - bootstrap
                        // EndPointName 플랫폼 device ID 설정
                        //AT+QLWM2M="enps",0,<service code>
                        //this.sendDataOut(commands["setepns"] + "ASN-CSE-D-6399301537-FOTA" + "\"");
                        this.sendDataOut(commands["setepns"] + tBoxSVCCD.Text + "\"");
                        tBoxActionState.Text = states.setepns.ToString();

                        timer1.Start();
                        nextcommand = "skip";
                        break;
                    case states.setepns:
                        // LWM2M bootstrap 자동 요청 순서
                        // servertype - (endpointpame) - (mbsps) - bootstrap
                        // PLMN 정보 확인 후 진행
                        string imsi = tBoxIMSI.Text;
                        if (imsi.StartsWith("45006"))
                        {
                            string ctn = "0" + imsi.Substring(5, imsi.Length-5);

                            // Bootstrap Parameter 설정
                            //AT+QLWM2M="mbsps",<service code>,<sn>,<ctn>,<iccid>,<device model>
                            string command = commands["setmbsps"] + tBoxSVCCD.Text + "\",\"";
                            command = command + tBoxDeviceSN.Text + "\",\"";
                            command = command + ctn + "\",\"";

                            string iccid = tBoxIccid.Text;
                            command = command + iccid.Substring(iccid.Length - 6, 6) + "\",\"";
                            command = command + tBoxDeviceModel.Text +"\"";
                            this.sendDataOut(command);
                            tBoxActionState.Text = states.setmbsps.ToString();

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
                        // LWM2M bootstrap 자동 요청 순서
                        // servertype - endpointpame - (mbsps) - (bootstrap) 마지막
                        // Bootstrap 요청
                        //AT+QLWM2M="bootstrap",1
                        nextcommand = states.bootstrap.ToString();
                        break;
                    case states.setcereg:
                        // LTE network attach 요청하면 정상적으로 attach 성공했는지 확인 필요
                        nextcommand = states.getcereg.ToString();
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
                        tBoxActionState.Text = nextcommand;
                        nextcommand = "";

                        timer1.Start();
                    }
                    else
                    {
                        tBoxActionState.Text = states.idle.ToString();
                        timer1.Stop();
                    }
                }
            }
            else if (s == "ERROR")
            {
                tBoxActionState.Text = states.idle.ToString();
                nextcommand = "";
                timer1.Stop();
            }
            else if (s == "+ICCID:")
            {
                // AT+ICCID의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                // OK 응답이 따라온다
                tBoxIccid.Text = str2.Substring(0, 20);
                logPrintInTextBox("ICCID값이 저장되었습니다.","");
            }
            else if (s == "+CEREG:")
            {
                // AT+CEREG의 응답으로 LTE attach 상태 확인하고 disable되어 있어면 attach 요청, 
                // attach가 완료되지 않았으면 1초 후에 재확인, (timer2 사용)
                // OK 응답이 따라온다
                timer2.Stop();

                string ltestatus = str2.Substring(1, 1);
                if(ltestatus == "0")
                {
                    tSStatusLblLTE.Text = "disconnect";
                    tSProgressLTE.Value = 0;

                    network_chkcnt = 3;             // LTE attach disable을 경우 enable하고 getcereg 3회 확인
                    nextcommand = states.setcereg.ToString();
                    logPrintInTextBox("LTE 연결을 요청이 필요합니다.", "");
                }
                else if(ltestatus == "1")
                {
                    string lteregi = str2.Substring(3, 1);

                    if ((lteregi == "1")|| (lteregi == "5"))
                    {
                        tSStatusLblLTE.Text = "registered";
                        tSProgressLTE.Value = 100;
                        timer2.Stop();
                        logPrintInTextBox("LTE망에 연결 되었습니다.", "");
                    }
                    else
                    {
                        // LTE attach 시도 중
                        tSStatusLblLTE.Text = "registerring";
                        tSProgressLTE.Value = 50;

                        timer2.Start();     // 1초 후에 AT+CEREG 호출
                    }
                }
                else
                {
                    tSStatusLblLTE.Text = "enable";
                    tSProgressLTE.Value = 100;

                    timer2.Stop();
                }

                tBoxActionState.Text = states.idle.ToString();
                timer1.Stop();
            }
            else if (s == "+QLWEVENT:")
            {
                // 모듈이 LWM2M서버에 접속/등록하는 단계에서 발생하는 이벤트,
                // OK 응답 발생하지 않음
                char[] lwm2mstep = str2.ToCharArray();
                int value = Convert.ToInt32(lwm2mstep[0]);
                if (value < 6)
                {
                    tSProgressLwm2m.Value = value * 20;

                }
                else
                {
                    tSProgressLwm2m.Value = 100;
                }

                int first = str2.IndexOf("\"");
                int last = str2.LastIndexOf("\"");
                string lwm2mstate = str2.Substring(first+1, last-first-2);
                tSStatusLblLWM2M.Text = lwm2mstate;
            }
            else if (s == "+QLWDLDATA:")
            {
                // 모듈이 LWM2M서버에서 받은 데이터를 전달하는 이벤트,
                // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                string[] words = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                if(words[0] == " \"/10250/0/1\"")       // data object인지 확인
                {
                    if(Convert.ToInt32(words[2]) == (words[3].Length-2)/2)    // data size 비교 (양쪽 끝의 " 크기 빼고)
                    {
                        //received hex data make to ascii code
                        string hexInPut = words[3].Substring(1, words[3].Length - 2);
                        string receiveDataIN = BcdToString(hexInPut.ToCharArray());
                        logPrintInTextBox("\""+receiveDataIN+"\"를 수신하였습니다.", "");
                    }
                }
            }
        }

        private void parseNoPrefixData(string str1)
        {
            states state = (states)Enum.Parse(typeof(states), tBoxActionState.Text);
            switch(state)
            {
                // 단말 정보 자동 갱신 순서
                // (autogetmodel) - (autogetmanufac) - autogetimsi - autogetimei - geticcid
                case states.autogetmodel:
                    tBoxModel.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    nextcommand = states.autogetmanufac.ToString();
                    this.logPrintInTextBox("모델값이 저장되었습니다.", "");
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmodel - (autogetmanufac) - (autogetimsi) - autogetimei - geticcid
                case states.autogetmanufac:
                    tBoxManu.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    nextcommand = states.autogetimsi.ToString();
                    this.logPrintInTextBox("제조사값이 저장되었습니다.", "");
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmodel - autogetmanufac - (autogetimsi) - (autogetimei) - geticcid
                case states.autogetimsi:
                    tBoxIMSI.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    nextcommand = states.autogetimei.ToString();
                    this.logPrintInTextBox("IMSI값이 저장되었습니다.", "");
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmodel - autogetmanufac - autogetimsi - (autogetimei) - (geticcid) - 마지막
                case states.autogetimei:
                    tBoxIMEI.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    nextcommand = states.geticcid.ToString();
                    this.logPrintInTextBox("IMEI값이이 저장되었습니다.", "");
                    break;
                case states.setservertype:
                    // EndPointName 플랫폼 device ID 설정
                    //AT+QLWM2M="enps",0,<service code>
                    //this.sendDataOut(commands["setepns"] + "ASN-CSE-D-6399301537-FOTA" + "\"");
                    this.sendDataOut(commands["setepns"] + tBoxSVCCD.Text + "\"");
                    tBoxActionState.Text = states.setepns.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.setepns:
                    string imsi = tBoxIMSI.Text;
                    if (imsi.StartsWith("45006"))
                    {
                        string ctn = "0" + imsi.Substring(5, imsi.Length - 5);

                        // Bootstrap Parameter 설정
                        //AT+QLWM2M="mbsps",<service code>,<sn>,<ctn>,<iccid>,<device model>
                        string command = commands["setmbsps"] + tBoxSVCCD.Text + "\",\"";
                        command = command + tBoxDeviceSN.Text + "\",\"";
                        command = command + ctn + "\",\"";

                        string iccid = tBoxIccid.Text;
                        command = command + iccid.Substring(iccid.Length - 6, 6) + "\",\"";
                        command = command + tBoxDeviceModel.Text + "\"";
                        this.sendDataOut(command);
                        tBoxActionState.Text = states.setmbsps.ToString();

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
                    nextcommand = states.bootstrap.ToString();
                    break;

                case states.getimsi:
                    tBoxIMSI.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    this.logPrintInTextBox("IMSI값이 저장되었습니다.", "");
                    break;
                case states.getimei:
                    tBoxIMEI.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    this.logPrintInTextBox("IMEI값이이 저장되었습니다.", "");
                    break;
                case states.getmodel:
                    tBoxModel.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    this.logPrintInTextBox("모델값이 저장되었습니다.", "");
                    break;
                case states.getmanufac:
                    tBoxManu.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    this.logPrintInTextBox("제조사값이 저장되었습니다.", "");
                    break;
                default:
                    break;
            }
        }

        private void InitinfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getDeviveInfo();
         }

        private void getDeviveInfo()
        {
            this.logPrintInTextBox("DEVICE 정보 전체를 요청합니다.","");

            // 단말 정보 자동 갱신 순서
            // (autogetmodel) - autogetmanufac - autogetimsi - autogetimei - geticcid - bootstrap
            this.sendDataOut(commands["getmodel"]);
            tBoxActionState.Text = states.autogetmodel.ToString();

            timer1.Start();
        }

        private void btnIMSI_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getimsi"]);
            tBoxActionState.Text = states.getimsi.ToString();
            timer1.Start();
        }

        private void btnICCID_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["geticcid"]);
            tBoxActionState.Text = states.geticcid.ToString();
            timer1.Start();
        }

        private void btnIMEI_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getimei"]);
            tBoxActionState.Text = states.getimei.ToString();
            timer1.Start();
        }

        private void BtnModel_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getmodel"]);
            tBoxActionState.Text = states.getmodel.ToString();
            timer1.Start();
        }

        private void btnManufac_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getmanufac"]);
            tBoxActionState.Text = states.getmanufac.ToString();
            timer1.Start();
        }

        // AT command를 요청하고 10초 동안 OK 응답이 없으면 COM port 재설정
        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            logPrintInTextBox(tBoxActionState.Text+"요청에 대해 timeout이 발생하였습니다.","");
            //MessageBox.Show("타이머가 종료되었습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            tBoxActionState.Text = states.idle.ToString();

            this.doOpenComPort();
        }

        // menubar에서 LWM2M 플랫폼 디바이스 등록을 요청 (bootstrap)
        private void ProvisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tSStatusLblLTE.Text == "register")
            {
                if ((tBoxIMSI.Text == "알 수 없음") || (tBoxIccid.Text == "알 수 없음"))
                {
                    this.getDeviveInfo();
                    this.logPrintInTextBox("모듈 정보를 먼저 읽고 있습니다. 다시 시도해주세요.","");
                }
                if (isDeviceInfo())
                {
                    // LWM2M bootstrap 자동 요청 순서
                    // (servertype) - endpointpame - mbsps - bootstrap
                    // 플랫폼 서버 타입 설정
                    //AT+QLWM2M="select",2
                    this.sendDataOut(commands["setservertype"]);
                    tBoxActionState.Text = states.setservertype.ToString();

                    timer1.Start();
                }
            }
            else
            {
                logPrintInTextBox("LTE 망에 연결되지 않았습니다.", "");
            }
        }

        private bool isDeviceInfo()
        {
            if((tBoxIMSI.Text == "알 수 없음") || (tBoxIccid.Text == "알 수 없음"))
            {
                this.getDeviveInfo();
                MessageBox.Show("모듈 정보를 읽고 있습니다.\n다시 시도해주세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;  
            }

            return true;
        }

        private void DevserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBoxSERVER.Text = "개발";
        }

        private void CvsserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBoxSERVER.Text = "검증";
        }

        private void OpserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBoxSERVER.Text = "상용";
        }

        private void CBoxSERVER_TextChanged(object sender, EventArgs e)
        {
            if(cBoxSERVER.Text == "개발")
            {
                serverip = "\"106.103.233.155\"";
            }
            else if (cBoxSERVER.Text == "검증")
            {
                serverip = "\"106.103.230.51\"";
            }
            else if (cBoxSERVER.Text == "상용")
            {
                serverip = "\"106.103.250.108\"";
            }
            serverport = "5783";

            setLwm2mServer();
        }

        private void setLwm2mServer()
        {
            // 플랫폼 서버의 IP/port 설정
            //AT+QLWM2M="cdp",<ip>,<port>
            this.sendDataOut(commands["setserverinfo"] + serverip + "," + serverport);
            tBoxActionState.Text = states.setserverinfo.ToString();

            timer1.Start();
        }

        private void RegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 플랫폼 등록 요청
            //AT+QLWM2M="register"
            this.sendDataOut(commands["register"]);
            tBoxActionState.Text = states.register.ToString();
        }

        private void DeregisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 플랫폼 등록해제 요청
            //AT+QLWM2M="deregister"
            this.sendDataOut(commands["deregister"]);
            tBoxActionState.Text = states.deregister.ToString();
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 플랫폼 정보 삭제 요청
            //AT+QLWM2M="reset"
            this.sendDataOut(commands["lwm2mreset"]);
            tBoxActionState.Text = states.lwm2mreset.ToString();

        }

        private void CBoxAutoBS_CheckedChanged(object sender, EventArgs e)
        {
            if(cBoxAutoBS.Checked)
            {
                // Auto BS & Registration 설정
                //AT+QLWM2M="enable",0 or 1
                this.sendDataOut(commands["setAutoBS"] + "1");
                tBoxActionState.Text = states.setAutoBS.ToString();
            }
            else
            {
                // Auto BS & Registration 설정
                //AT+QLWM2M="enable",0 or 1
                this.sendDataOut(commands["setAutoBS"] + "0");
                tBoxActionState.Text = states.setAutoBS.ToString();
            }
        }

        private void EnableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBoxAutoBS.Checked = true;
        }

        private void DisableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBoxAutoBS.Checked = false;
        }

        private void TBoxDataIN_TextChanged(object sender, EventArgs e)
        {
            if(RxDispOrder == "BOTTOM")
            {
                tBoxDataIN.Select(tBoxDataIN.Text.Length, 0);
                tBoxDataIN.ScrollToCaret();
            }
        }

        private void BtnSendData_Click(object sender, EventArgs e)
        {
            //입력 Text값을 플랫폼 서버로 전송
            sendDataToServer(tBoxDataOut.Text);
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
            if(cBoxSendHex.Checked == false)
            {
                // Data send to SERVER (string original)
                //AT+QLWM2M="uldata",<object>,<length>,<data>
                this.sendDataOut(commands["sendmsgstr"] + text.Length + ",\"" + text + "\"");
                tBoxActionState.Text = states.sendmsgstr.ToString();

                timer1.Start();
            }
            else
            {
                // Data send to SERVER (string to BCD convert)
                //AT+QLWM2M="ulhex",<object>,<length>,<data>

                string hexOutput = StringToBCD(text.ToCharArray());

                this.sendDataOut(commands["sendmsghex"] + hexOutput.Length/2 + ",\"" + hexOutput + "\"");
                tBoxActionState.Text = states.sendmsghex.ToString();

                timer1.Start();
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
            if((tBoxDataIN.Text != "") && (cBoxLogSave.Checked == true))
            {
                string pathname = @"c:\temp\seriallog\";
                DateTime currenttime = DateTime.Now;
                string filename = "atlog_" + currenttime.ToString("MMdd_hhmmss") + ".txt";

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
                tBoxActionState.Text = states.getcereg.ToString();

                timer1.Start();
                logPrintInTextBox("LTE 연결 상태를 확인합니다.", "");
            }
            else
            {
                this.sendDataOut(commands["reset"]);
                tBoxActionState.Text = states.reset.ToString();

                timer1.Start();
                logPrintInTextBox("3회 가 over하여 모듈을 reset합니다.", "");
            }
        }
    }
}
