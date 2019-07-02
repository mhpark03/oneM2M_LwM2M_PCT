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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string sendWith;
        string dataIN;
        string RxDisplayRule;
        string RxDispOrder;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            //foreach()
            //ToolStripItem[] items = ports;
            cBoxCOMPORT.Items.AddRange(ports);
            tSCBoxComPort.Items.AddRange(ports);
            //comportTSMenu.DropDownItems.AddRange(ports);

            chBoxDtrEnable.Checked = false;
            serialPort1.DtrEnable = false;
            chBoxRTSEnable.Checked = false;
            serialPort1.RtsEnable = false;

            sendWith = "Both";
            RxDisplayRule = "All";
            RxDispOrder = "BOTTOM";

            this.setWindowLayOut();
            groupBox3.Enabled = false;
        }

        private void setWindowLayOut()
        {
            groupBox3.Width = panel1.Width - 230;
            groupBox3.Height = panel1.Height - 55;

            tBoxDataIN.Height = groupBox3.Height - 54;
            tBoxDataOut.Width = groupBox3.Width - 72;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.doOpenComPort();
        }

        private void doOpenComPort()
        {
            try
            {
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);

                serialPort1.Open();
                progressBar1.Value = 100;
                groupBox1.Enabled = true;
                groupBox3.Enabled = true;
                logPrintInTextBox("COM PORT가 연결 되었습니다.");

            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                logPrintInTextBox("COM PORT 연결이 실패하였습니다.");

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
            groupBox3.Enabled = false;
            logPrintInTextBox("COM PORT가 해제 되었습니다.");

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

        private void BtnSendData_Click(object sender, EventArgs e)
        {
            if(tBoxDataOut.Text != "")
            {
                this.sendDataOut(tBoxDataOut.Text);
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

        private void TBoxDataOut_TextChanged(object sender, EventArgs e)
        {
            int dataOUTLength = tBoxDataOut.TextLength;
            lblDataOutLength.Text = string.Format("{0:00}", dataOUTLength);
        }

        private void TBoxDataOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.sendDataOut(tBoxDataOut.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void sendDataOut(string dataOUT)
        {
            if (serialPort1.IsOpen)
            {
                if (sendWith == "None")
                {
                    serialPort1.Write(dataOUT);
                }
                else if (sendWith == "Both")
                {
                    serialPort1.Write(dataOUT + "\r\n");
                }
                else if (sendWith == "LF")
                {
                    serialPort1.Write(dataOUT + "\r");
                }
                else if (sendWith == "CR")
                {
                    serialPort1.Write(dataOUT + "\n");
                }
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
            MessageBox.Show("Created by Minho Park", "Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.setWindowLayOut();
        }

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

        private void TSMenuStopOne_Click(object sender, EventArgs e)
        {
            cBoxStopBits.Text = "One";
        }

        private void TSMenuStopTwo_Click(object sender, EventArgs e)
        {
            cBoxStopBits.Text = "Two";
        }

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

        private void TSMenuDTRDisable_Click(object sender, EventArgs e)
        {
            chBoxDtrEnable.Checked = false;
        }

        private void TSMenuDTREnable_Click(object sender, EventArgs e)
        {
            chBoxDtrEnable.Checked = true;
        }

        private void TSMenuRTSDisable_Click(object sender, EventArgs e)
        {
            chBoxRTSEnable.Checked = false;
        }

        private void TSMenuRTSEnable_Click(object sender, EventArgs e)
        {
            chBoxRTSEnable.Checked = true;
        }

        private void TSCBoxComPort_TextChanged(object sender, EventArgs e)
        {
            cBoxCOMPORT.Text = tSCBoxComPort.Text;
        }

        private void CBoxCOMPORT_TextChanged(object sender, EventArgs e)
        {
            tSCBoxComPort.Text = cBoxCOMPORT.Text;
        }

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

        private void TSMenuRxUpdate_Click(object sender, EventArgs e)
        {
            RxDisplayRule = "Update";
        }

        private void TSMenuRxAll_Click(object sender, EventArgs e)
        {
            RxDisplayRule = "All";
        }

        private void TSMenuTop_Click(object sender, EventArgs e)
        {
            RxDispOrder = "TOP";
        }

        private void TSMenuDown_Click(object sender, EventArgs e)
        {
            RxDispOrder = "BOTTOM";
        }

        private void BtnModel_Click(object sender, EventArgs e)
        {

        }
        private void logPrintInTextBox(string v)
        {
            string displayMsg = makeLogPrintLine(v);

            if (RxDisplayRule == "Update")
            {
                tBoxDataIN.Text = displayMsg;
            }
            else if (RxDisplayRule == "All")
            {
                if (RxDispOrder == "TOP")
                {
                    tBoxDataIN.Text = tBoxDataIN.Text.Insert(0, displayMsg);
                }
                else
                {
                    tBoxDataIN.Text += displayMsg;
                }
            }

        }

        private string makeLogPrintLine(string msg)
        {
            string msg_form;
            DateTime currenttime = DateTime.Now;
            msg_form = currenttime.ToString("hh:mm:ss.fff") + " : " + msg + "\r\n";
            return msg_form;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.sendDataOut("AT+CIMI");
            tBoxActionState.Text = "GET IMSI";
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData));
        }

        private void ShowData(object sender, EventArgs e)
        {
            int dataINLength = dataIN.Length;
            lblDataInLength.Text = string.Format("{0:00}", dataINLength);

            //logPrintInTextBox(dataIN);

            string[] words = dataIN.Split('\n');

            foreach (var word in words)
            {
                string str1;

                int lflength = word.IndexOf("\r");
                if(lflength>1)
                {
                    str1 = word.Substring(0 , lflength);
                }
                else
                {
                    str1 = word;
                }

                if (str1 != "")
                {
                    this.parseRXData(str1);
                }
            }
        }

        private void parseRXData(string rxMsg)
        {
            string[] sentences =
            {
                "OK",
                "ERROR",
                "AT+CIMI",
                "+QCCID:",
                "AT+GSN:"
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
            logPrintInTextBox(hexOutput);
            */

            logPrintInTextBox(rxMsg);
            bool find_msg = false;

            foreach (string s in sentences)
            {
                //logPrintInTextBox(s);

                //if (System.Text.RegularExpressions.Regex.IsMatch(rxMsg, s, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                if (rxMsg.StartsWith(s, System.StringComparison.CurrentCultureIgnoreCase))
                {
                   logPrintInTextBox(s + " : There is matching data.");

                    // This search returns the substring between two strings, so 
                    // the first index is moved to the character just after the first string.
                    int first = rxMsg.IndexOf(s) + s.Length;
                    string str2 = "";
                    str2 = rxMsg.Substring(first, rxMsg.Length - first);
                    logPrintInTextBox("남은 문자열 : " + str2);

                    this.parseReceiveData(s, str2);

                    find_msg = true;
                    break;
                }
            }

            if (find_msg == false)
            {
                logPrintInTextBox("No Matching Data!!!");

                this.parseNoPrefixData(rxMsg);
            }

        }

        void parseReceiveData(string s, string str2)
        {
            if (s == "OK" || s == "ERROR")
            {
                tBoxActionState.Text = "Idle";
            }
            else if (s == "AT+CIMI")
            {
                tBoxActionState.Text = "GET IMSI";
            }
            else if(s == "+QCCID:")
            {
                tBoxIccid.Text = str2.Substring(0, 20);
            }
            else if(s == "AT+GSN")
            {
                tBoxActionState.Text = "GET IMEI";
            }
        }

        private void parseNoPrefixData(string str1)
        {
            if (tBoxActionState.Text == "GET IMSI")
            {
                tBoxIMSI.Text = str1;
                tBoxActionState.Text = "Idle";
            }
            else if (tBoxActionState.Text == "AUTO INFO IMSI")
            {
                tBoxIMSI.Text = str1;
                tBoxActionState.Text = "Idle";
                
                timer1.Stop();
            }
            else if (tBoxActionState.Text == "GET IMEI")
            {
                tBoxIMEI.Text = str1;
                tBoxActionState.Text = "Idle";
            }
        }

        private void InitinfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sendDataOut("AT+CIMI");
            tBoxActionState.Text = "AUTO INFO IMSI";

            timer1.Start();

            //this.sendDataOut("AT+QCCID");
            //tBoxActionState.Text = "AUTO INFO ICCID";

            //this.sendDataOut("AT+GSN");
            //tBoxActionState.Text = "AUTO INFO IMEI";

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.sendDataOut("AT+QCCID");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.sendDataOut("AT+GSN");
            tBoxActionState.Text = "GET IMEI";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            logPrintInTextBox("타이머가 종료 되었습니다.");
            MessageBox.Show("타이머가 종료되었습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            tBoxActionState.Text = "Idle";
        }
    }
}
