using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VZTestFunctionApp01
{
    public partial class SettingCommand : Form
    {
        string cmdModDet = "adb.exe shell factory 0 4";
        public string MyCmdModTest
        {
            get { return cmdModDet; }
        }
        string cmdDetectDevices = "adb.exe devices";
        public string MyCmdDetect
        {
            get { return cmdDetectDevices; }
        }
        string cmdVersionTest;
        public string MyCmdVersion
        {
            get { return cmdVersionTest; }
        }
        //string cmdVersion;
        //public string MyCmdVersionSet
        //{
        //    get { return cmdVersion; }
        //}
        string cmdPushAudio;
        public string MyCmdPush
        {
            get { return cmdPushAudio; }
        }
        string cmdFlashTest;
        public string MyCmdFlashTest
        {
            get { return cmdFlashTest; }
        }
        //string cmdFlashSize;
        //public string MyCmdFlashSize
        //{
        //    get { return cmdFlashSize; }
        //}
        string cmdDdrTest;
        public string MyCmdDdrTest
        {
            get { return cmdDdrTest; }
        }
        //string cmdDdrSize;
        //public string MyCmdDdrSize
        //{
        //    get { return cmdDdrSize; }
        //}
        string cmdWifiConnectTest;
        public string MyCmdWifiConnectTest
        {
            get { return cmdWifiConnectTest; }
        }
        //string cmdWifiNameAndPWD;
        //public string MyCmdWifiNamePWD
        //{
        //    get { return cmdWifiNameAndPWD; }
        //}
        string cmdWifiScanTest;
        public string MyCmdWifiScanTest
        {
            get { return cmdWifiScanTest; }
        }
        string cmdBtMacTest;
        public string MyCmdBtMacTest
        {
            get { return cmdBtMacTest; }
        }
        //string cmdBtName;
        //public string MyCmdBtName
        //{
        //    get { return cmdBtName; }
        //}
        string cmdBSinkTest;
        public string MyCmdBSinkTest
        {
            get { return cmdBSinkTest; }
        }
        string cmdKeyTest;
        public string MyCmdKeyTest
        {
            get { return cmdKeyTest; }
        }
        //string cmdKeyAnswerGPIO;
        //public string MyCmdKeyAnswer
        //{
        //    get { return cmdKeyAnswerGPIO; }
        //}
        string cmdLEDTest;
        public string MyCmdLEDTest
        {
            get { return cmdLEDTest; }
        }
        string cmdAudioTest;
        public string MyCmdAudioTest
        {
            get { return cmdAudioTest; }
        }
        string cmdAudioResponse;
        public string MyCmdAudioResponse
        {
            get { return cmdAudioResponse; }
        }
        string cmdPullLog;
        public string MyCmdPullLog
        {
            get { return cmdPullLog; }
        }
        string cmdrecord;
        public string MyCmdrecord
        {
            get { return cmdrecord; }
        }
        string cmdPullrecord;
        public string MyCmdPullrecord
        {
            get { return cmdPullrecord; }
        }
        string cmdTouchTest;
        public string MyCmdTouchTest
        {
            get { return cmdTouchTest; }
        }
        string cmdBurnSeed;
        public string MyCmdBurnSeed
        {
            get { return cmdBurnSeed; }
        }
        string cmdReadSeed;
        public string MyCmdReadSeed
        {
            get { return cmdReadSeed; }
        }
        string cmdBurnSN;
        public string MyCmdBurnSN
        {
            get { return cmdBurnSN; }
        }
        string cmdReadSN;
        public string MyCmdReadSN
        {
            get { return cmdReadSN; }
        }
        static string address = ".\\config\\cmd.txt";        
        string WriteContent = string.Empty;
        string result = string.Empty;
        string cmdDetectDevices2 = string.Empty;
        string str;
        string []cmd = new string[50];
        //int i = 0;

        public SettingCommand()
        {
            InitializeComponent();
            if (File.Exists(address) == false)
            {
                try
                {
                    FileStream SetFile1 = new FileStream(address, FileMode.Create, FileAccess.Write);
                    StreamWriter streamWriter = new StreamWriter(SetFile1);
                    //streamWriter.WriteLine("cmdDetectDevices = C:\\adb.exe devices");
                    streamWriter.WriteLine("cmdVersionTest = ");
                    //streamWriter.WriteLine("cmdVersion = ");
                    streamWriter.WriteLine("cmdFlashTest = ");
                    //streamWriter.WriteLine("cmdFlashSize = ");
                    streamWriter.WriteLine("cmdDdrTest = ");
                    //streamWriter.WriteLine("cmdDdrSize = ");
                    streamWriter.WriteLine("cmdWifiConnectTest = ");
                    //streamWriter.WriteLine("cmdWifiNameAndPWD = ");
                    //streamWriter.WriteLine("cmdBSinkTest = ");
                    streamWriter.WriteLine("cmdBtMacTest =");
                    //streamWriter.WriteLine("cmdBtName =");
                    streamWriter.WriteLine("cmdKeyTest = ");
                    //streamWriter.WriteLine("cmdKeyAnswerGPIO = ");
                    streamWriter.WriteLine("cmdAudioTest = ");
                    streamWriter.WriteLine("cmdLEDTest = ");
                    streamWriter.WriteLine("cmdrecord = ");
                    streamWriter.WriteLine("cmdPushAudio = ");
                    streamWriter.WriteLine("cmdPullrecord = ");
                    streamWriter.WriteLine("cmdBurnSN = ");
                    streamWriter.WriteLine("cmdBurnSeed = ");
                    streamWriter.Dispose();
                    streamWriter.Close();
                    SetFile1.Dispose();
                    SetFile1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("OpenFile1 Error!");
                    MessageBox.Show(ex.Message);
                }                              
            }
            else
            {
                //MessageBox.Show("NoExist");
                //MessageBox.Show("Exist");

                //分离命令参数
                int i = 1;
                try
                {
                    FileStream SetFile2 = new FileStream(address, FileMode.Open);
                    TextReader Setread2 = new StreamReader(SetFile2);
                    string SetContent2 = string.Empty;                    
                    while (null != (SetContent2 = Setread2.ReadLine()))
                    {
                        //逐行读取对照赋值
                        SetContent2 = SetContent2.Trim().ToString();
                        char split = '=';
                        string[] sArray = SetContent2.Split(split);

                        //MessageBox.Show(sArray[1].Trim().ToString());
                        //if (sArray[0].Trim().ToString().Equals("cmdDetectDevices")) {  cmdDetectDevices = sArray[1].Trim(); cmd[i] = SetContent; }
                        if (sArray[0].Trim().ToString().Equals("cmdVersionTest")) { SofewaretextBox.Text = cmdVersionTest = sArray[1].Trim(); cmd[i] = SetContent2; }
                        //if (sArray[0].Trim().ToString().Equals("cmdSetVersion")) { SVersiontextBox.Text = cmdVersion = sArray[1].Trim(); cmd[i] = SetContent; }
                        if (sArray[0].Trim().ToString().Equals("cmdFlashTest")) { FlashSizetextBox.Text = cmdFlashTest = sArray[1].Trim(); cmd[i] = SetContent2; }
                        //if (sArray[0].Trim().ToString().Equals("cmdFlashSize")) { FSizetextBox.Text = cmdFlashSize = sArray[1].Trim(); cmd[i] = SetContent; }
                        if (sArray[0].Trim().ToString().Equals("cmdDdrTest")) { DDRSizetextBox.Text = cmdDdrTest = sArray[1].Trim(); cmd[i] = SetContent2; }
                        //if (sArray[0].Trim().ToString().Equals("cmdDdrSize")) { DSizetextBox.Text = cmdDdrSize = sArray[1].Trim(); cmd[i] = SetContent; }
                        if (sArray[0].Trim().ToString().Equals("cmdWifiConnectTest")) { WIFITesttextBox.Text = cmdWifiConnectTest = sArray[1].Trim(); cmd[i] = SetContent2; }
                        //if (sArray[0].Trim().ToString().Equals("cmdWifiNameAndPWD")) { WIFINameAndPWDtextBox.Text = cmdWifiNameAndPWD = sArray[1].Trim(); cmd[i] = SetContent; }
                        if (sArray[0].Trim().ToString().Equals("cmdBtMacTest")) { BTTesttextBox.Text = cmdBtMacTest = sArray[1].Trim(); cmd[i] = SetContent2; }
                        //if (sArray[0].Trim().ToString().Equals("cmdBtName")) { BTNametextBox.Text = cmdBtName = sArray[1].Trim(); cmd[i] = SetContent; }
                        if (sArray[0].Trim().ToString().Equals("cmdKeyTest")) { KeyTesttextBox.Text = cmdKeyTest = sArray[1].Trim(); cmd[i] = SetContent2; }
                        //if (sArray[0].Trim().ToString().Equals("cmdKeyAnswerGPIO")) { KeyAnswertextBox.Text = cmdKeyAnswerGPIO = sArray[1].Trim(); cmd[i] = SetContent; }
                        if (sArray[0].Trim().ToString().Equals("cmdAudioTest")) { AmpTesttextBox.Text = cmdAudioTest = sArray[1].Trim(); cmd[i] = SetContent2; }
                        if (sArray[0].Trim().ToString().Equals("cmdLEDTest")) { LEDTesttextBox.Text = cmdLEDTest = sArray[1].Trim(); cmd[i] = SetContent2; }
                        if (sArray[0].Trim().ToString().Equals("cmdrecord")) { RecordtextBox.Text = cmdrecord = sArray[1].Trim(); cmd[i] = SetContent2; }
                        if (sArray[0].Trim().ToString().Equals("cmdPushAudio")) { AdbPushtextBox.Text = cmdPushAudio = sArray[1].Trim(); cmd[i] = SetContent2; }
                        if (sArray[0].Trim().ToString().Equals("cmdPullrecord")) { AdbPulltextBox.Text = cmdPullrecord = sArray[1].Trim(); cmd[i] = SetContent2; }
                        if (sArray[0].Trim().ToString().Equals("cmdBurnSN")) { BurnSNtextBox.Text = cmdBurnSN = sArray[1].Trim(); cmd[i] = SetContent2; }
                        if (sArray[0].Trim().ToString().Equals("cmdBurnSeed")) { BurnSeedtextBox.Text = cmdBurnSeed = sArray[1].Trim(); cmd[i] = SetContent2; }
                        //MessageBox.Show(cmd[i]);
                        i++;
                    }
                    Setread2.Dispose();
                    Setread2.Close();
                    SetFile2.Dispose();
                    SetFile2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("OpenFile1 Error!");
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    FileStream SetFile3 = new FileStream(address, FileMode.Open);
                    TextReader Setread3 = new StreamReader(SetFile3);
                    str = Setread3.ReadToEnd();
                    Setread3.Dispose();
                    Setread3.Close();
                    SetFile3.Dispose();
                    SetFile3.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show("OpenFile3 Error!");
                    MessageBox.Show(ex.Message);
                }

                //添加缺少项
                try
                {
                    FileStream SetFile4 = new FileStream(address, FileMode.Append);
                    StreamWriter streamWriter4 = new StreamWriter(SetFile4);
                    //int a = 1,i = 1;
                    if (!str.Contains("cmdVersionTest"))
                    { cmd[++i] = "cmdVersionTest = "; streamWriter4.WriteLine(cmd[i]); }
                    //if (!str.Contains("cmdSetVersion"))
                    //{ cmd[++i] = "cmdSetVersion = "; streamWriter1.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdFlashTest"))
                    { cmd[++i] = "cmdFlashTest ="; streamWriter4.WriteLine(cmd[i]); }
                    //if (!str.Contains("cmdFlashSize"))
                    //{ cmd[++i] = "cmdFlashSize ="; streamWriter1.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdDdrTest"))
                    { cmd[++i] = "cmdDdrTest ="; streamWriter4.WriteLine(cmd[i]); }
                    //if (!str.Contains("cmdDdrSize"))
                    //{ cmd[++i] = "cmdDdrSize ="; streamWriter1.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdWifiConnectTest"))
                    { cmd[++i] = "cmdWifiConnectTest ="; streamWriter4.WriteLine(cmd[i]); }
                    //if (!str.Contains("cmdWifiNameAndPWD"))
                    //{ cmd[++i] = "cmdWifiNameAndPWD ="; streamWriter1.WriteLine(cmd[i]); }
                    //if (!str.Contains("cmdBSinkTest ="))
                    //{ cmd[i++] = "cmdBSinkTest ="; streamWriter1.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdBtMacTest"))
                    { cmd[++i] = "cmdBtMacTest ="; streamWriter4.WriteLine(cmd[i]); }
                    //if (!str.Contains("cmdBtName"))
                    //{ cmd[++i] = "cmdBtName ="; streamWriter1.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdKeyTest"))
                    { cmd[++i] = "cmdKeyTest ="; streamWriter4.WriteLine(cmd[i]); }
                    //if (!str.Contains("cmdKeyAnswerGPIO"))
                    //{ cmd[++i] = "cmdKeyAnswerGPIO ="; streamWriter1.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdAudioTest"))
                    { cmd[++i] = "cmdAudioTest ="; streamWriter4.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdLEDTest"))
                    { cmd[++i] = "cmdLEDTest ="; streamWriter4.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdrecord"))
                    { cmd[++i] = "cmdrecord ="; streamWriter4.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdPushAudio"))
                    { cmd[++i] = "cmdPushAudio ="; streamWriter4.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdPullrecord"))
                    { cmd[++i] = "cmdPullrecord ="; streamWriter4.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdBurnSN"))
                    { cmd[++i] = "cmdBurnSN ="; streamWriter4.WriteLine(cmd[i]); }
                    if (!str.Contains("cmdBurnSeed"))
                    { cmd[++i] = "cmdBurnSeed ="; streamWriter4.WriteLine(cmd[i]); }
                    streamWriter4.Dispose();
                    streamWriter4.Close();
                    SetFile4.Dispose();
                    SetFile4.Close();
                    i = 1;
                }catch(Exception ex)
                {
                    MessageBox.Show("OpenFile4 Error!");
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            int i = 1;
            try
            {
                FileStream SetFile5 = new FileStream(address, FileMode.Open);
                TextWriter Setwrite5 = new StreamWriter(SetFile5);
                SetFile5.SetLength(0);
                for (i = 1; i < cmd.Length; i++)
                {
                    if (cmd[i] != null)
                    {
                        //MessageBox.Show(i.ToString());
                        //MessageBox.Show(cmd[i]);
                        if (cmd[i].Contains("cmdVersionTest")) { cmdVersionTest = SofewaretextBox.Text; cmd[i] = "cmdVersionTest = " + SofewaretextBox.Text; }
                        //if (cmd[i].Contains("cmdSetVersion")) {cmdVersion = SVersiontextBox.Text; cmd[i] = "cmdSetVersion = " + SVersiontextBox.Text; }
                        if (cmd[i].Contains("cmdFlashTest")) { cmdFlashTest = FlashSizetextBox.Text; cmd[i] = "cmdFlashTest = " + FlashSizetextBox.Text; }
                        //if (cmd[i].Contains("cmdFlashSize")) { cmdFlashSize = FSizetextBox.Text; cmd[i] = "cmdFlashSize = " + FSizetextBox.Text; }
                        if (cmd[i].Contains("cmdDdrTest")) { cmdDdrTest = DDRSizetextBox.Text; cmd[i] = "cmdDdrTest = " + DDRSizetextBox.Text; }
                        //if (cmd[i].Contains("cmdDdrSize")) { cmdDdrSize = DSizetextBox.Text; cmd[i] = "cmdDdrSize = " + DSizetextBox.Text; }
                        if (cmd[i].Contains("cmdWifiConnectTest")) { cmdWifiConnectTest = WIFITesttextBox.Text; cmd[i] = "cmdWifiConnectTest = " + WIFITesttextBox.Text; }
                        //if (cmd[i].Contains("cmdWifiNameAndPWD")) { cmdWifiNameAndPWD = WIFINameAndPWDtextBox.Text; cmd[i] = "cmdWifiNameAndPWD = " + WIFINameAndPWDtextBox.Text; }
                        if (cmd[i].Contains("cmdBtMacTest")) { cmdBtMacTest = BTTesttextBox.Text; cmd[i] = "cmdBtMacTest = " + BTTesttextBox.Text; }
                        //if (cmd[i].Contains("cmdBtName")) { cmdBtName = BTNametextBox.Text; cmd[i] = "cmdBtName = " + BTNametextBox.Text; }
                        if (cmd[i].Contains("cmdKeyTest")) { cmdKeyTest = KeyTesttextBox.Text; cmd[i] = "cmdKeyTest = " + KeyTesttextBox.Text; }
                        //if (cmd[i].Contains("cmdKeyAnswerGPIO")) { cmdKeyAnswerGPIO = KeyAnswertextBox.Text; cmd[i] = "cmdKeyAnswerGPIO = " + KeyAnswertextBox.Text; }
                        if (cmd[i].Contains("cmdAudioTest")) { cmdAudioTest = AmpTesttextBox.Text; cmd[i] = "cmdAudioTest = " + AmpTesttextBox.Text; }
                        if (cmd[i].Contains("cmdLEDTest")) { cmdLEDTest = LEDTesttextBox.Text; cmd[i] = "cmdLEDTest = " + LEDTesttextBox.Text; }
                        if (cmd[i].Contains("cmdrecord")) { cmdrecord = RecordtextBox.Text; cmd[i] = "cmdrecord = " + RecordtextBox.Text; }
                        if (cmd[i].Contains("cmdPushAudio")) { cmdPushAudio = AdbPushtextBox.Text; cmd[i] = "cmdPushAudio = " + AdbPushtextBox.Text; }
                        if (cmd[i].Contains("cmdPullrecord")) { cmdPullrecord = AdbPulltextBox.Text; cmd[i] = "cmdPullrecord = " + AdbPulltextBox.Text; }
                        if (cmd[i].Contains("cmdBurnSN")) { cmdBurnSN = BurnSNtextBox.Text; cmd[i] = "cmdBurnSN = " + BurnSNtextBox.Text; }
                        if (cmd[i].Contains("cmdBurnSeed")) { cmdBurnSeed = BurnSeedtextBox.Text; cmd[i] = "cmdBurnSeed = " + BurnSeedtextBox.Text; }
                        Setwrite5.WriteLine(cmd[i]);
                    }
                }
                Setwrite5.Dispose();
                Setwrite5.Close();
                SetFile5.Dispose();
                SetFile5.Close();
                i = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("OpenFile5 Error!");
                MessageBox.Show(ex.Message);
            }
        }
        private void Quitbutton_Click(object sender, EventArgs e)
        {
            this.Dispose();           
        }

        private void KeyTesttextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SettingCommand_Load(object sender, EventArgs e)
        {
 
        }

        private void Keylabel_Click(object sender, EventArgs e)
        {

        }
    }
}
