using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace ADV212Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbCOMPort.SelectedIndex = 0;
            cbBaudRate.SelectedIndex = 0;
            cbDataBits.SelectedIndex = 3;
            cbStopBits.SelectedIndex = 1;
            cbParity.SelectedIndex = 0;
        }

        public bool isOpenSerialPort = false;
        public string firmwareFileName = "";


        public bool SetSerialPortProperty()
        {
            sp.PortName = cbCOMPort.Text.Trim();                   //设置串口名
            sp.BaudRate = Convert.ToInt32(cbBaudRate.Text.Trim()); //设置波特率
            sp.DataBits = Convert.ToInt16(cbDataBits.Text.Trim()); //设置数据位
            //设置停止位
            float fd = Convert.ToSingle(cbStopBits.Text.Trim());
            if (0 == fd)
            {
                sp.StopBits = StopBits.None;
            }
            else if (1 == fd)
            {
                sp.StopBits = StopBits.One;
            }
            else if (1.5 == fd)
            {
                sp.StopBits = StopBits.OnePointFive;
            }
            else if (2 == fd)
            {
                sp.StopBits = StopBits.Two;
            }
            else
            {
                sp.StopBits = StopBits.One;
            }
            // 设置奇偶校验位
            string s = cbParity.Text.Trim();
            if (s.CompareTo("无校验") == 0)
            {
                sp.Parity = Parity.None;
            }
            else if (s.CompareTo("奇校验") == 0)
            {
                sp.Parity = Parity.Odd;
            }
            else if (s.CompareTo("偶校验") == 0)
            {
                sp.Parity = Parity.Even;
            }
            else
            {
                sp.Parity = Parity.None;
            }
            try
            {

                sp.Open();
                label_light.ForeColor = Color.Green;
                BtnOpenSerialPort.Text = "关闭串口";
                isOpenSerialPort = true; //串口打开标志  isOpenSerialPort 为 true 表示串口已打开
                this.sp.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.OnDataReceived);

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error;" + ex.Message, "Error");
                return false;
            }


        }

        FileStream fsRecv = new FileStream("RecvData.bin", FileMode.Create, FileAccess.Write);

        void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp.IsOpen)
            {

                try
                {
                    Byte[] receiveData = new Byte[sp.BytesToRead];
                    int read_num = sp.Read(receiveData, 0, receiveData.Length);
                    fsRecv.Write(receiveData, 0, read_num);
                    fsRecv.Flush();

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error;" + ex.Message, "Error");
                }
            }
        }

        private void BtnOpenSerialPort_Click(object sender, EventArgs e)
        {
            if (!sp.IsOpen)
            {
                SetSerialPortProperty();
            } 
            else
            {
                sp.Close();
                progressBar1.Invoke(new Action(() =>
                {
                    progressBar1.Value = 0;
                }));

                lbPercent.Invoke(new Action(() =>
                {
                    lbPercent.Text = "0%";
                }));
                //fsRecv.Close();
                label_light.ForeColor = Color.Red;
                BtnOpenSerialPort.Text = "打开串口";
                isOpenSerialPort = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tBRcv.Clear();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            openfile.Filter = "固件文件|*.sea|所有文件|*.*";
            openfile.RestoreDirectory = true;
            openfile.FilterIndex = 1;

            if (openfile.ShowDialog() == DialogResult.OK)  //保存获取的文件夹的路径
            {
                firmwareFileName = openfile.FileName;
                openfiletextBox.Text = openfile.FileName;
            }
            else
            {
                MessageBox.Show("未选择待加载文件！！！");
                return;
            }
        }

        public void InitialCommand()
        {
            byte[] SetInternalClockH = { Register.commandWrite, Register.PLL_HIRegAddr, Register.PLL_HIRegValueH, Register.PLL_HIRegValueL };
            byte[] SetInternalClockL = { Register.commandWrite, Register.PLL_LORegAddr, Register.PLL_LORegValueH, Register.PLL_LORegValueL };
            byte[] EnterNoHostBootMode = { Register.commandWrite, Register.BootRegAddr, Register.BootRegNoHostBootValueH, Register.BootRegNoHostBootValueL };
            byte[] SetBusMode = { Register.commandWrite, Register.BUSMODERegAddr, Register.BUSMODERegValueH, Register.BUSMODERegValueL };
            byte[] SetMMode = { Register.commandWrite, Register.MMODERegAddr, Register.MMODERegValueH, Register.MMODERegValueL };
            sp.Write(SetInternalClockH,0,SetInternalClockH.Length);
            sp.Write(SetInternalClockL, 0, SetInternalClockL.Length);
            Thread.Sleep(1);
            sp.Write(EnterNoHostBootMode, 0, EnterNoHostBootMode.Length);
            sp.Write(SetBusMode, 0, SetBusMode.Length);
            sp.Write(SetMMode, 0, SetMMode.Length);

        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            string sendBufParameters = tBParameters.Text;
            string parametersBuf = sendBufParameters.Trim();
            parametersBuf = parametersBuf.Replace(" ", "");

            string sendBufInditrectRegisterValues = tBIndirectRegisterValue.Text;
            string indirectRegisterBuf = sendBufInditrectRegisterValues.Trim();
            indirectRegisterBuf = indirectRegisterBuf.Replace(" ", "");
            if (parametersBuf.Length != 32)
            {
                MessageBox.Show("参数信息有误！！！");
            }
            else if (indirectRegisterBuf.Length != 26)
            {
                MessageBox.Show("间接寄存器值有误！！！");
            }
            else
            {
                Thread threadLoad = new Thread(new ThreadStart(LoadFile));
                threadLoad.IsBackground = true;
                threadLoad.Start();

            }
        }

        public void LoadFile()
        {
            if (sp.IsOpen)
            {
                InitialCommand();
                LoadFirmware();
                BeginEncode();
            }
            else
            {
                MessageBox.Show("请先打开串口！！！");
            }
        }

        public void LoadFirmware()
        {
            if (firmwareFileName == "")
            {
                MessageBox.Show("请先选择待下载固件文件!");
                return;
            }
            else
            {
                byte[] loadFirmwareAddrH = { Register.commandWrite, Register.StageRegAddr, Register.StageRegLoadFirmwareValueH, Register.StageRegLoadFirmwareValueL };
                byte[] loadFirmwareAddrL = { Register.commandWrite, Register.IADDRRegAddr, Register.IADDRRegLoadFirmwareValueH, Register.IADDRRegLoadFirmwareValueL };
                sp.Write(loadFirmwareAddrH, 0, loadFirmwareAddrH.Length);
                sp.Write(loadFirmwareAddrL, 0, loadFirmwareAddrL.Length);
                FileStream fsFirmware = new FileStream(firmwareFileName,FileMode.Open,FileAccess.Read);
                int firmwareFileLength = (int)fsFirmware.Length;
                byte[] byteFirmware = new byte[firmwareFileLength];
                fsFirmware.Read(byteFirmware, 0, firmwareFileLength);
                //设置进度条显示
                //Thread threadProgressBarStatus = new Thread(new ThreadStart(ProgressBarStatus));
                //threadProgressBarStatus.IsBackground = true;
                //threadProgressBarStatus.Start();

                progressBar1.Invoke(new Action(() =>
                {
                    progressBar1.Maximum = firmwareFileLength;
                }));

                for (int i = 0; i < firmwareFileLength ;i += 2 )
                {
                    byte[] firmwareCommand = { Register.commandWrite, Register.IDATARegAddr, byteFirmware[i], byteFirmware[i+1]};
                    sp.Write(firmwareCommand, 0, firmwareCommand.Length);
                    progressBar1.Invoke(new Action(() => { progressBar1.Value += (firmwareCommand.Length / 2); }));
                    float percent = 100 * progressBar1.Value / firmwareFileLength;
                    lbPercent.Invoke(new Action(() =>
                    {
                        lbPercent.Text = percent.ToString() + "%";
                    }));
                    
                }
                fsFirmware.Close();
                //progressBar1.Invoke(new Action(() => { progressBar1.Visible = false; }));
                
                //MessageBox.Show("固件加载完成");
            }

        }




        public void BeginEncode()
        {
            byte[] softReBoot = { Register.commandWrite, Register.BootRegAddr, Register.BootRegSoftReBootValueH, Register.BootRegSoftReBootValueL};
            byte[] SetBusMode = { Register.commandWrite, Register.BUSMODERegAddr, Register.BUSMODERegValueH, Register.BUSMODERegValueL };
            byte[] SetMMode = { Register.commandWrite, Register.MMODERegAddr, Register.MMODERegValueH, Register.MMODERegValueL };
            byte[] setEncodeParametersAddrH = { Register.commandWrite, Register.StageRegAddr, Register.StageRegSetEncodeValueH, Register.StageRegSetEncodeValueL };
            byte[] setEncodeParametersAddrL = { Register.commandWrite, Register.IADDRRegAddr, Register.IADDRRegSetEncodeValueH, Register.IADDRRegSetEncodeValueL };
            //if (tBParameters.Text.Length != 16)
            //{
            //    MessageBox.Show("参数信息有误！！！");
            //}
            //else
            //{
                string sendBufParameters = tBParameters.Text;
                string parametersBuf = sendBufParameters.Trim();
                parametersBuf = parametersBuf.Replace(" ","");
                int arrayParametersLength = parametersBuf.Length / 2;
                string[] arrayParametersBuf = new string[arrayParametersLength];
                byte[] byteParametersBuf = new byte[arrayParametersLength];

                for(int i = 0;i < 16; i+=2)
                {
                    arrayParametersBuf[i] = parametersBuf.Substring(2 * i, 2);
                    byteParametersBuf[i] = Convert.ToByte(arrayParametersBuf[i], 16);
                    arrayParametersBuf[i+1] = parametersBuf.Substring(2 * (i+1), 2);
                    byteParametersBuf[i+1] = Convert.ToByte(arrayParametersBuf[i+1], 16);
                    byte[] setEncodeParametersData = { Register.commandWrite, Register.IDATARegAddr, byteParametersBuf[i], byteParametersBuf[i+1] };
                    sp.Write(setEncodeParametersData, 0, setEncodeParametersData.Length);
                }


                string sendBufIndirectRegisterValues = tBParameters.Text;
                string indirectRegisterValuesBuf = sendBufIndirectRegisterValues.Trim();
                indirectRegisterValuesBuf = indirectRegisterValuesBuf.Replace(" ", "");
                int arrayIndirectRegisterValuesLength = indirectRegisterValuesBuf.Length / 2;
                string[] arrayIndirectRegisterValuesBuf = new string[arrayIndirectRegisterValuesLength];
                byte[] byteIndirectRegisterValuesBuf = new byte[arrayIndirectRegisterValuesLength];

                for (int i = 0; i < 16; i++)
                {
                    arrayIndirectRegisterValuesBuf[i] = indirectRegisterValuesBuf.Substring(2 * i, 2);
                    byteIndirectRegisterValuesBuf[i] = Convert.ToByte(arrayIndirectRegisterValuesBuf[i], 16);
                }
                byte[] setIndirectRegisterPMODE1AddrH = { Register.commandWrite, Register.StageRegAddr, Register.StageRegSetIndirectRegisterValuePMODE11, Register.StageRegSetIndirectRegisterValuePMODE12 };
                byte[] setIndirectRegisterPMODE1AddrL = { Register.commandWrite, Register.IADDRRegAddr, Register.StageRegSetIndirectRegisterValuePMODE13, Register.StageRegSetIndirectRegisterValuePMODE14 };
                byte[] setIndirectRegisterPMODE1Data = { Register.commandWrite, Register.IDATARegAddr, byteIndirectRegisterValuesBuf[0], byteIndirectRegisterValuesBuf[1] };
                sp.Write(setIndirectRegisterPMODE1AddrH, 0, setIndirectRegisterPMODE1AddrH.Length);
                sp.Write(setIndirectRegisterPMODE1AddrL, 0, setIndirectRegisterPMODE1AddrL.Length);
                sp.Write(setIndirectRegisterPMODE1Data, 0, setIndirectRegisterPMODE1Data.Length);

                byte[] setIndirectRegisterXTOTAddrH = { Register.commandWrite, Register.StageRegAddr, Register.StageRegSetIndirectRegisterValueXTOT1, Register.StageRegSetIndirectRegisterValueXTOT2 };
                byte[] setIndirectRegisterXTOTAddrL = { Register.commandWrite, Register.IADDRRegAddr, Register.StageRegSetIndirectRegisterValueXTOT3, Register.StageRegSetIndirectRegisterValueXTOT4 };
                sp.Write(setIndirectRegisterXTOTAddrH, 0, setIndirectRegisterXTOTAddrH.Length);
                sp.Write(setIndirectRegisterXTOTAddrL, 0, setIndirectRegisterXTOTAddrL.Length);
                for (int i = 2; i < 22;i+=2 )
                {
                    byte[] setIndirectRegisterXTOTData = { Register.commandWrite, Register.IDATARegAddr, byteIndirectRegisterValuesBuf[i], byteIndirectRegisterValuesBuf[i+1] };
                    sp.Write(setIndirectRegisterXTOTData, 0, setIndirectRegisterXTOTData.Length);
                }

                byte[] setIndirectRegisterPMODE2AddrH = { Register.commandWrite, Register.StageRegAddr, Register.StageRegSetIndirectRegisterValuePMODE21, Register.StageRegSetIndirectRegisterValuePMODE22 };
                byte[] setIndirectRegisterPMODE2AddrL = { Register.commandWrite, Register.IADDRRegAddr, Register.StageRegSetIndirectRegisterValuePMODE23, Register.StageRegSetIndirectRegisterValuePMODE24 };
                byte[] setIndirectRegisterPMODE2Data = { Register.commandWrite, Register.IDATARegAddr, byteIndirectRegisterValuesBuf[22], byteIndirectRegisterValuesBuf[23] };
                byte[] setIndirectRegisterVMODEData = { Register.commandWrite, Register.IDATARegAddr, byteIndirectRegisterValuesBuf[24], byteIndirectRegisterValuesBuf[25] };
                sp.Write(setIndirectRegisterPMODE2AddrH, 0, setIndirectRegisterPMODE2AddrH.Length);
                sp.Write(setIndirectRegisterPMODE2AddrL, 0, setIndirectRegisterPMODE2AddrL.Length);
                sp.Write(setIndirectRegisterPMODE2Data, 0, setIndirectRegisterPMODE2Data.Length);
                sp.Write(setIndirectRegisterVMODEData, 0, setIndirectRegisterVMODEData.Length);
                


            //}
            byte[] setThreshold64WordsAddrH = { Register.commandWrite, Register.StageRegAddr, Register.StageRegSetThreshold64ValueH, Register.StageRegSetThreshold64ValueL };
            byte[] setThreshold64WordsAddrL = { Register.commandWrite, Register.IADDRRegAddr, Register.IADDRRegSetThreshold64ValueH, Register.IADDRRegSetThreshold64ValueL };
            byte[] setThreshold64WordsData = { Register.commandWrite, Register.IDATARegAddr, Register.IDATARegSetThreshold64ValueH, Register.IDATARegSetThreshold64ValueL };
            byte[] enableEIRQIE1and10 = { Register.commandWrite, Register.EIRQIERegAddr, Register.EIRQIERegValueH, Register.EIRQIERegValueL };
            sp.Write(softReBoot, 0, softReBoot.Length);
            sp.Write(SetBusMode, 0, SetBusMode.Length);
            sp.Write(SetMMode, 0, SetMMode.Length);
            sp.Write(setEncodeParametersAddrH, 0, setEncodeParametersAddrH.Length);
            sp.Write(setEncodeParametersAddrL, 0, setEncodeParametersAddrL.Length);
            sp.Write(setThreshold64WordsAddrH, 0, setThreshold64WordsAddrH.Length);
            sp.Write(setThreshold64WordsAddrL, 0, setThreshold64WordsAddrL.Length);
            sp.Write(setThreshold64WordsData, 0, setThreshold64WordsData.Length);
            sp.Write(enableEIRQIE1and10, 0, enableEIRQIE1and10.Length);
            byte[] checkEIRQFLG10 = { Register.commandRead, Register.EIRQFLGRegAddr, Register.zeroFill, Register.zeroFill };
            byte[] checkFirmwareCorrectlyLoaded = { Register.commandRead, Register.SWFLAGRegAddr, Register.zeroFill, Register.zeroFill };
            byte[] clearFlagsToBeginEncoding = { Register.commandWrite, Register.EIRQFLGRegAddr, Register.EIRQFLGRegValueH, Register.EIRQFLGRegValueL };
            sp.Write(checkEIRQFLG10, 0, checkEIRQFLG10.Length);

            sp.Write(checkFirmwareCorrectlyLoaded, 0, checkFirmwareCorrectlyLoaded.Length);

            //sp.Write(clearFlagsToBeginEncoding, 0, clearFlagsToBeginEncoding.Length);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sp.IsOpen)
            {
                if (DialogResult.Yes == MessageBox.Show("串口还在通信，确认退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    fsRecv.Close();
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            
        }

    }
}
