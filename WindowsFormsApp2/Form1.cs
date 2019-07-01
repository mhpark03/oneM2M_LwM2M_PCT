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
        string dataOUT;
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
            RxDispOrder = "TOP";

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
                groupBox3.Enabled = true;
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox3.Enabled = false;
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
            groupBox3.Enabled = false;
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
            if (serialPort1.IsOpen)
            {
                dataOUT = tBoxDataOut.Text;
                if (sendWith == "None")
                {
                    serialPort1.Write(dataOUT);
                }
                else if (sendWith == "Both")
                {
                    serialPort1.Write(dataOUT+"\r\n");
                }
                else if (sendWith == "LF")
                {
                    serialPort1.Write(dataOUT+"\r");
                }
                else if (sendWith == "CR")
                {
                    serialPort1.Write(dataOUT+"\n");
                }
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
                this.doSomething();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void doSomething()
        {
            if (serialPort1.IsOpen)
            {
                dataOUT = tBoxDataOut.Text;
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

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData));
        }

        private void ShowData(object sender, EventArgs e)
        {
            int dataINLength = dataIN.Length;
            lblDataInLength.Text = string.Format("{0:00}", dataINLength);

            if (RxDisplayRule == "Update")
            {
                tBoxDataIN.Text = dataIN;
            }
            else if (RxDisplayRule == "All")
            {
                if(RxDispOrder == "TOP")
                {
                    tBoxDataIN.Text = tBoxDataIN.Text.Insert(0, dataIN);
                }
                else
                {
                    tBoxDataIN.Text += dataIN;
                }
            }

            this.parseRXData();
        }

        private void parseRXData()
        {
            string[] sentences =
            {
                "methods",
                "have",
                "count"
            };

            foreach (string s in sentences)
            {
                tBoxDataIN.Text += "\r\n";
                tBoxDataIN.Text += s;

                if (System.Text.RegularExpressions.Regex.IsMatch(dataIN, s, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    tBoxDataIN.Text += "\r\nThere is matching data.\r\n";

                    //string factMessage = "Extension methods have all the capabilities of regular static methods.";
                    string factMessage = dataIN;

                    // This search returns the substring between two strings, so 
                    // the first index is moved to the character just after the first string.
                    int first = factMessage.IndexOf(s) + s.Length;
                    int last = factMessage.LastIndexOf(s);
                    if(last > first)
                    {
                        string str2 = factMessage.Substring(first, last - first);
                        tBoxDataIN.Text += "\r\n";
                        tBoxDataIN.Text += str2;
                    }
                    else
                    {
                        string str2 = factMessage.Substring(first, factMessage.Length - first);
                        tBoxDataIN.Text += "\r\n";
                        tBoxDataIN.Text += str2;

                    }
                }
                else
                {
                    tBoxDataIN.Text += "\r\nThere is not matching data.";
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
    }
}
