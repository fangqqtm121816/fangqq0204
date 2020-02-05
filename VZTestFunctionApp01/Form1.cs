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
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using WebServiceDll;


namespace VZTestFunctionApp01
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            RefreshLogText();
            addLogText();
            nFristTest = 1;
            nSNBackCorrect = 0;
            nAutoBurn = 0;
            nXmlSNBack = 0;
            nCheckStation = 0;
            nXmlPass = 0;
            nVersion = nFlash = nDDR = nUart = nWifi = nBT = nKey = nLed = nMic = nAMP = nSNBurnOK = nSEEDBurnOK = nTYPEIDBurnOK = 2;
            AllCheck();
            //检测按键是否Enable
            ReAbleLabelSN();
            ReVersionButton();
            ReDDRButton();
            ReFlashButton();
            ReWIFIButton();
            ReBTButton();
            ReUARTButton();
            ReLEDButton();
            ReMICButton();
            ReAMPButton();
            ReKEYButton();

        }
        private float X;//当前窗体的宽度
        private float Y;//当前窗体的高度

        int nMaxSize = 0;
        private const int GWL_STYLE = -16;
        private const int WS_CHILD = 0x40000000;
        public const int WM_CHAR = 256;
        [DllImportAttribute("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImportAttribute("user32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, Keys wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        //[DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        //public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        //[DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        //public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        static System.Diagnostics.Process AuProc = new System.Diagnostics.Process();
        SettingCommand SettingCommand = new SettingCommand();
        TestItemForm TestItem = new TestItemForm();
        private delegate void delegateAddText();
        private delegate void delegateEnableText();
        private delegate void delegatereflashpicture();
        private delegate void delegateButton();
        static Image WIFIOKimage = Image.FromFile(".\\config\\WIFIPicture\\OKMIN.png");
        static Image WIFINCimage = Image.FromFile(".\\config\\WIFIPicture\\NCMIN.png");
        static Image BTOKimage = Image.FromFile(".\\config\\BTPicture\\OKMIN.png");
        static Image BTNCimage = Image.FromFile(".\\config\\BTPicture\\NCMIN.png");
        static Image FlashOKimage = Image.FromFile(".\\config\\FlashPicture\\OKMIN.png");
        static Image FlashNCimage = Image.FromFile(".\\config\\FlashPicture\\NCMIN.png");
        static Image SoftOKimage = Image.FromFile(".\\config\\SoftPicture\\OKMIN.png");
        static Image SoftNCimage = Image.FromFile(".\\config\\SoftPicture\\NCMIN.png");
        static Image DDROKimage = Image.FromFile(".\\config\\DDRPicture\\OKMIN.png");
        static Image DDRNCimage = Image.FromFile(".\\config\\DDRPicture\\NCMIN.png");
        static Image UARTOKimage = Image.FromFile(".\\config\\UARTPicture\\OKMIN.png");
        static Image UARTNCimage = Image.FromFile(".\\config\\UARTPicture\\NCMIN.png");
        static Image KEYOKimage = Image.FromFile(".\\config\\KEYPicture\\OKMIN.png");
        static Image KEYNCimage = Image.FromFile(".\\config\\KEYPicture\\NCMIN.png");
        static Image MICOKimage = Image.FromFile(".\\config\\MICPicture\\OKMIN.png");
        static Image MICNCimage = Image.FromFile(".\\config\\MICPicture\\NCMIN.png");
        static Image AMPOKimage = Image.FromFile(".\\config\\AMPPicture\\OKMIN.png");
        static Image AMPNCimage = Image.FromFile(".\\config\\AMPPicture\\NCMIN.png");
        static Image LEDOKimage = Image.FromFile(".\\config\\LEDPicture\\OKMIN.png");
        static Image LEDNCimage = Image.FromFile(".\\config\\LEDPicture\\NCMIN.png");

        static Image OKBigimage = Image.FromFile(".\\config\\OKBIG.png");
        static Image NCBigimage = Image.FromFile(".\\config\\NCBIG.png");
        int nAllCheck = 2, nVersion = 2, nFlash = 2, nDDR = 2, nUart = 2, nWifi = 2, nBT = 2, nKey = 2, nLed = 2, nMic = 2, nAMP = 2, nSNBurnOK = 2, nSEEDBurnOK = 2, nTYPEIDBurnOK = 2;

        

        //cmd通讯---------------------------------
        public class ProcClass
        {
            string strExecute = string.Empty;
            string err = string.Empty;
            public string strall = string.Empty;
            string strcmd = string.Empty;
            string killcmd = "adb.exe kill-server";
            int a;
            public string CmdStr
            {
                set { strcmd = value; }
            }

            public string ExecuteCmd()
            {
                System.Diagnostics.Process Proc = new System.Diagnostics.Process();
                Proc.StartInfo.CreateNoWindow = true;
                Proc.StartInfo.UseShellExecute = false;
                Proc.StartInfo.FileName = "C:\\Windows\\System32\\cmd.exe";
                Proc.StartInfo.RedirectStandardError = true;
                Proc.StartInfo.RedirectStandardInput = true;
                Proc.StartInfo.RedirectStandardOutput = true;
                do
                {
                    Proc.Start();
                    Proc.StandardInput.WriteLine(strcmd + "&exit");
                    err = Proc.StandardError.ReadToEnd();
                    strExecute = Proc.StandardOutput.ReadToEnd();

                    strall = strExecute + err;
                    //MessageBox.Show(strall);
                    a = 0;
                    Proc.WaitForExit(500);
                    Proc.Close();
                    Thread.Sleep(500);
                    if (strall.Contains("offline"))
                    {
                        Proc.Start();
                        Proc.StandardInput.WriteLine(killcmd + "&exit");
                        err = Proc.StandardError.ReadToEnd();
                        strall += err;
                        //MessageBox.Show(strall);
                        Proc.WaitForExit(1000);
                        Proc.Close();
                        a = 1;
                    }

                } while (a == 1);

                //MessageBox.Show(strall);
                return strall;
            }
        }

        int nRecordFinash = 0;
        int nFristTest = 1;
        int nAutoTest01 = 0;
        int nAutoTest02 = 0;
        int nCheckStation = 0;
        int nProductSN = 0;
        int nXmlPass = 0;
        bool IsAutoTest01Begin = false;
        bool IsAutoTest02Begin = false;
        bool IsAutoBurnBegin = false;
        string resultOK = "Detect Connectted";
        string resultNC = "NOT Connectted";
        string cmdDetectDevices2 = string.Empty;
        string strMIC = string.Empty;
        static string strall = string.Empty;
        static bool nThreadDet = true;
        static bool nDet = false;
        string Audacityaddress;
        //string adbcmd = ".\\config\\adb.exe shell ";
        string adbcmd = "adb.exe shell ";
        string LabelSNIN;
        string XmlMesBack = string.Empty;
        string XmlProductSN;
        string XmlProductSEED;
        string XmlProductTypeID;
        string[] WorkShop = {"烧录","板卡功能测试","板卡声学测试","整机功能测试","整机声学测试"};
        string PSNRead;

        int nXmlSNBack = 0;
        int nSNBackCorrect = 0;
        int nAutoBurn;
        string strDUTSN;
        string DUTPSN;
        string url = "http://www.lingqidz.com:8088/DIPTestService/TestEquipmentService.asmx";
        private void addTipsOK()
        {
            ConTips.Text = resultOK;
            ConTips.BackColor = Color.Green;
        }
        private void addTipsNC()
        {
            ConTips.Text = resultNC;
            ConTips.BackColor = Color.Red;
        }
        private void ReFocusLabelLSN()
        {
            LabelSNtextBox.Focus();
        }
        private void ReAbleLabelSN()
        {
            if (nDet == false || nSNBackCorrect == 1 ||TestItem.SetProductTestWorkShop == "True" ||TestItem.CLQWebServer !="Checked")
            {
                LabelSNtextBox.Enabled = false;
            }
            else
            {
                //if (TestItem.CWebTest == "Checked")
                    LabelSNtextBox.Enabled = true;
            }
        }

        private void ReFreshPSNTextBox()
        {
            ProductSNtextBox.Text = DUTPSN;
        }

        private void addLogText()
        {
            //LogTextBox.Text += strall;
            LogTextBox.AppendText(strall);
            LogTextBox.ScrollToCaret();
            LogTextBox.Focus();
        }
        private void RefreshLogText()
        {
            LogTextBox.Text = string.Empty;
        }
        private void AutoTesttext()
        {
            if (nDet == true)
            {
                if (IsAutoTest01Begin == true || IsAutoTest02Begin == true)
                {
                    AutoTesttextBox.Text = "自动测试中...";
                }
                else
                    AutoTesttextBox.Text = null;
                if (IsAutoBurnBegin == true)
                { AutoTesttextBox.Text = "自动烧录中..."; };
            }
            else
            {
                AutoTesttextBox.Text = null;
            }
            
        }

        private void AllbuttonDisable()
        {
            SoftWareButton.Enabled = false;
            FlashSizeButton.Enabled = false;
            DDRSizeButton.Enabled = false;
            UARTTestButton.Enabled = false;
            WIFITestButton.Enabled = false;
            BTTestButton.Enabled = false;
            KeyTestButton.Enabled = false;
            LEDTestButton.Enabled = false;
            AMPTestButton.Enabled = false;
            MICTestButton.Enabled = false;
        }
        private void ReSureSNEtcBurn()
        {
            //无选择项默认置1表示已测试过
            if (TestItem.CSNBurn != "Checked")
            { nSNBurnOK = 1; }
            if (TestItem.CSEEDBurn != "Checked")
            { nSEEDBurnOK = 1; }
            if (TestItem.CTypeIDBurn != "Checked")
            { nTYPEIDBurnOK = 1; }
        }
        private void ReVersionButton()
        {
            if (nDet == false || IsAutoTest01Begin == true || IsAutoTest02Begin == true)
            {
                SoftWareButton.Enabled = false;
            }
            else
            {
                    if (TestItem.CVersionTest == "Checked")
                        SoftWareButton.Enabled = true;
                    else
                        nVersion = 1;
            }
        }
        private void ReDDRButton()
        {
            if (nDet == false || IsAutoTest01Begin == true || IsAutoTest02Begin == true)
            {
                DDRSizeButton.Enabled = false;
            }
            else
            {
                if (TestItem.CDDRSizeTest == "Checked")
                    DDRSizeButton.Enabled = true;
                else
                    nDDR = 1;
            }
        }
        private void ReFlashButton()
        {
            if (nDet == false || IsAutoTest01Begin == true || IsAutoTest02Begin == true)
            {
                FlashSizeButton.Enabled = false;
            }
            else
            {
                if (TestItem.CFlashSizeTest == "Checked")
                    FlashSizeButton.Enabled = true;
                else
                    nFlash = 1;
            }
        }
        private void ReWIFIButton()
        {
            if (nDet == false || IsAutoTest01Begin == true || IsAutoTest02Begin == true)
            {
                WIFITestButton.Enabled = false;
            }
            else
            {
                if (TestItem.CWIFITest == "Checked")
                    WIFITestButton.Enabled = true;
                else
                    nWifi = 1;
            }
        }
        private void ReBTButton()
        {
            if (nDet == false || IsAutoTest01Begin == true || IsAutoTest02Begin == true)
            {
                BTTestButton.Enabled = false;
            }
            else
            {
                if (TestItem.CBTTest == "Checked")
                    BTTestButton.Enabled = true;
                else
                    nBT = 1;
            }
        }
        private void ReUARTButton()
        {
            if (nDet == false || IsAutoTest01Begin == true || IsAutoTest02Begin == true)
            {
                UARTTestButton.Enabled = false;
            }
            else
            {
                if (TestItem.CUARTSizeTest == "Checked")
                    UARTTestButton.Enabled = true;
                else
                    nUart = 1;
            }
        }
        private void ReLEDButton()
        {
            if (nDet == false || IsAutoTest01Begin == true || IsAutoTest02Begin == true)
            {
                LEDTestButton.Enabled = false;
            }
            else
            {
                if (TestItem.CLedTest == "Checked")
                    LEDTestButton.Enabled = true;
                else
                    nLed = 1;
            }
        }
        private void ReMICButton()
        {
            if (nDet == false || IsAutoTest01Begin == true || IsAutoTest02Begin == true)
            {
                MICTestButton.Enabled = false;
            }
            else
            {
                if (TestItem.CMICTest == "Checked")
                    MICTestButton.Enabled = true;
                else
                    nMic = 1;
            }
        }
        private void ReAMPButton()
        {
            if (nDet == false || IsAutoTest01Begin == true || IsAutoTest02Begin == true)
            {
                AMPTestButton.Enabled = false;
            }
            else
            {
                if (TestItem.CAMPTest == "Checked")
                    AMPTestButton.Enabled = true;
                else
                    nAMP = 1;
            }
        }
        private void ReKEYButton()
        {
            if (nDet == false || IsAutoTest01Begin == true || IsAutoTest02Begin == true)
            {
                KeyTestButton.Enabled = false;
            }
            else
            {
                if (TestItem.CKeyTest == "Checked")
                    KeyTestButton.Enabled = true;
                else
                    nKey = 1;
            }
        }
    
        private void Reflashall()
        {
            if (nDet == false)
            {
                ConTips.Refresh();
                LabelSNtextBox.Text = null;
                LogTextBox.Text = null;
                SoftWarepictureBox.Image = null;
                FlashpictureBox.Image = null;
                DdrpictureBox.Image = null;
                UARTpictureBox.Image = null;
                WifipictureBox.Image = null;
                BTpictureBox.Image = null;
                KeypictureBox.Image = null;
                LedpictureBox.Image = null;
                AMPpictureBox.Image = null;
                MicpictureBox.Image = null;
                AllResultpictureBox.Image = null;
            }
            //else
            //{
 
        }

        //自动检测--------------------------------
        private void AllCheck()
        {
            try
            {
                ImageList imageList2 = new ImageList();
                imageList2.ColorDepth = ColorDepth.Depth32Bit;
                imageList2.ImageSize = new Size(82, 80);
                imageList2.Images.Add(OKBigimage);
                imageList2.Images.Add(NCBigimage);
                if (nAllCheck == 1 && nVersion == 1 && nFlash == 1 && nDDR == 1 && nUart == 1 && nWifi == 1 && nBT == 1 && nKey == 1 && nLed == 1 && nMic == 1 && nAMP == 1 && nSNBurnOK == 1 && nSEEDBurnOK == 1 && nTYPEIDBurnOK == 1)
                {
                    if (TestItem.CLQWebServer == "Checked")
                    {
                        //过站发送检测-----------------------------------------
                        OverStation();
                    }
                    if (nXmlPass == 1 || TestItem.CLQWebServer != "Checked")
                    {
                        AllResultpictureBox.Image = imageList2.Images[0];
                    }
                    nAllCheck = 0;
                }
                else if (nVersion == 0 || nFlash == 0 || nDDR == 0 || nUart == 0 || nWifi == 0 || nBT == 0 || nKey == 0 || nLed == 0 || nMic == 0 || nAMP == 0 || nSNBurnOK == 0 || nSEEDBurnOK == 0 || nTYPEIDBurnOK == 0)
                {
                    AllResultpictureBox.Image = imageList2.Images[1];
                }
                else
                {
                    if (nAllCheck != 0)
                        AllResultpictureBox.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AllCheck Error!");
                MessageBox.Show(ex.Message);
            }
            

        }

        //TestBox输入：凌启SN输入检测---------------------------------------------
        private void LabelSNtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string ProductIdXml;
                    LabelSNIN = LabelSNtextBox.Text;
                    ProductTestData productTestData = new ProductTestData();
                    productTestData.testProductRecord = new TestProductRecord();
                    productTestData.testProductRecord.ProductId = LabelSNIN;
                    //productTestData.testProductRecord.TestType = "板卡功能测试";
                    ProductIdXml = XmlSerializeHelper.XmlSerialize(productTestData);
                    object[] arg = new object[3];
                    arg[0] = "GetProductData";
                    arg[1] = ProductIdXml;
                    arg[2] = "";
                    //MessageBox.Show(TestItem.SetWebAddress);
                    XmlMesBack = WebServiceHelper.InvokeWebService(TestItem.SetWebAddress, "ProductData", arg).ToString();
                    LogTextBox.Text = XmlMesBack;
                    MessageBox.Show(XmlMesBack);
                    if (XmlMesBack.Contains("true"))
                    {
                        string[] sArray = XmlMesBack.Split(new char[2] { '=', '|' });
                        //输出格式：“true; ;PSN=123|IMEI=123|WIFIMAC=123”
                        XmlProductSN = sArray[1]; XmlProductSEED = sArray[5]; XmlProductTypeID = sArray[3];
                        if (XmlProductSN.Contains("HY") && XmlProductSEED.Contains("HonYar"))
                        { nXmlSNBack = 1; }
                        else
                        {
                            //nXmlSNBack = 0;
                            MessageBox.Show("SN,SEED,TYPEID不正确");
                        }

                        //MessageBox.Show(XmlProductSN);

                    }
                    else
                    {
                        MessageBox.Show("PSN下发不成功");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("LSN Key_Down Error");
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        //产品SN输入---------------------------------------------
        private void ProductSNtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nProductSN = 1;
                //    string ProductIdXml;
                //    LabelSNIN = LabelSNtextBox.Text;
                //    ProductTestData productTestData = new ProductTestData();
                //    productTestData.testProductRecord = new TestProductRecord();
                //    productTestData.testProductRecord.ProductId = strDUTSN;
                //    ProductIdXml = XmlSerializeHelper.XmlSerialize(productTestData);
                //    object[] arg = new object[3];
                //    arg[0] = "GetProductData";
                //    arg[1] = ProductIdXml;
                //    arg[2] = null;
                //    XmlMesBack = WebServiceHelper.InvokeWebService(url, "ProductData", arg).ToString();
                //    LogTextBox.Text = XmlMesBack;
                //}
            }
        }

        //音频推入------------------------------------------
        private void AudioPush()
        {

        }

        //插入检测------------------------------------------
        public void DetectThread()
        {
            try
            {
                ProcClass proc = new ProcClass();
                //proc.CmdStr = SettingCommand.MyCmdDetect;
                string NotFind01 = "device not found";
                string NotFind02 = "no device";
                string FTMMode = "adb.exe shell factory 0 0";
                proc.CmdStr = SettingCommand.MyCmdModTest;
                while (nThreadDet)
                {
                    proc.CmdStr = SettingCommand.MyCmdModTest;
                    strall = proc.ExecuteCmd();
                    //MessageBox.Show(strall);
                    if (strall.Contains(NotFind01) || strall.Contains(NotFind02))
                    {
                        nDet = false;
                        ConTips.Invoke(new delegateAddText(addTipsNC));
                        //ConTips.Invoke(new delegateButton(Reflashall));
                        ConTips.Invoke(new delegateAddText(Reflashall));
                        if (nFristTest == 0)
                        {
                            LogTextBox.Invoke(new delegateAddText(RefreshLogText));
                            LogTextBox.Invoke(new delegateAddText(addLogText));
                            nFristTest = 1;
                            nSNBackCorrect = 0;
                            nAutoBurn = 0;
                            nXmlSNBack = 0;
                            nCheckStation = 0;
                            nXmlPass = 0;
                            PSNRead = "";
                            nVersion = nFlash = nDDR = nUart = nWifi = nBT = nKey = nLed = nMic = nAMP = nSNBurnOK = nSEEDBurnOK = nTYPEIDBurnOK = 2;
                            AllResultpictureBox.Invoke(new delegatereflashpicture(AllCheck));
                            //检测按键是否Enable
                            SoftWareButton.Invoke(new delegateButton(ReVersionButton));
                            DDRSizeButton.Invoke(new delegateButton(ReDDRButton));
                            FlashSizeButton.Invoke(new delegateButton(ReFlashButton));
                            WIFITestButton.Invoke(new delegateButton(ReWIFIButton));
                            BTTestButton.Invoke(new delegateButton(ReBTButton));
                            UARTTestButton.Invoke(new delegateButton(ReUARTButton));
                            LEDTestButton.Invoke(new delegateButton(ReLEDButton));
                            MICTestButton.Invoke(new delegateButton(ReMICButton));
                            AMPTestButton.Invoke(new delegateButton(ReAMPButton));
                            KeyTestButton.Invoke(new delegateButton(ReKEYButton));
                            ReSureSNEtcBurn();
                        }
                        LabelSNtextBox.Invoke(new delegateEnableText(ReAbleLabelSN));

                    }
                    else if (strall.Contains("Normal"))
                    {
                        proc.CmdStr = FTMMode;
                        strall += proc.ExecuteCmd();
                        //MessageBox.Show(strall);
                    }
                    else
                    {
                        nDet = true;
                        nAutoTest01 = 0;
                        nAutoTest02 = 0;
                        ConTips.Invoke(new delegateAddText(addTipsOK));
                        ConTips.Invoke(new delegateAddText(Reflashall));
                        AllResultpictureBox.Invoke(new delegatereflashpicture(AllCheck));
                        Thread.Sleep(200);
                        LabelSNtextBox.Invoke(new delegateEnableText(ReFocusLabelLSN));
                        LabelSNtextBox.Invoke(new delegateEnableText(ReAbleLabelSN));

                        if (nFristTest == 1)
                        {

                            if (TestItem.SetProductTestWorkShop != "True" || TestItem.CLQWebServer != "Checked")//选择上传LSN还是PSN
                            {
                                if (nXmlSNBack == 1 || TestItem.CLQWebServer != "Checked")//检测有输入LSN-------------------------
                                {
                                    if (WorkshopShowtextBox.Text != "烧录" || TestItem.CLQWebServer != "Checked")
                                    {
                                        nFristTest = 0;
                                        string strSNRead = "adb.exe shell factory 9 2";
                                        proc.CmdStr = strSNRead;
                                        strDUTSN = proc.ExecuteCmd();
                                        //MessageBox.Show(strDUTSN);
                                        string[] Array = strDUTSN.Split(new string[] { "&exit" }, StringSplitOptions.None);
                                        DUTPSN = Array[1].Replace("\r\n", "");
                                        ProductSNtextBox.Invoke(new delegateAddText(ReFreshPSNTextBox));
                                        //MessageBox.Show(Array[1]);
                                        if (TestItem.CLQWebServer == "Checked")
                                        {
                                            //MessageBox.Show(XmlMesBack);
                                            //MessageBox.Show(DUTPSN);
                                            if (XmlMesBack.Contains(DUTPSN.ToString()))
                                            { nSNBackCorrect = 1; }
                                        }
                                        if (nSNBackCorrect == 1 || TestItem.CLQWebServer != "Checked")
                                        {
                                            //nSNBackCorrect = 1;
                                            LabelSNtextBox.Invoke(new delegateEnableText(ReAbleLabelSN));
                                            if (TestItem.CLQWebServer == "Checked")
                                            { CheckStation(); }//过站检测加音频推入开始测试线程-----------------------
                                            if (nCheckStation == 1 || TestItem.CLQWebServer != "Checked")
                                            {
                                                if (SettingCommand.MyCmdPush.Contains("adb.exe push"))
                                                {
                                                    Thread.Sleep(1000);
                                                    nRecordFinash = 0;
                                                    string stra = SettingCommand.MyCmdPush + " /data/factoryRokid/";
                                                    proc.CmdStr = stra;
                                                    strall += proc.ExecuteCmd();
                                                    if (strall.Contains("bytes in") == true)
                                                    {
                                                        nAutoTest01 = 1;
                                                        nAutoTest02 = 1;
                                                        Thread.Sleep(500);

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("音频推入不成功");
                                                    }
                                                    LogTextBox.Invoke(new delegateAddText(addLogText));
                                                    nAllCheck = 1;
                                                    //Thread.Sleep(500);
                                                }
                                                else
                                                    MessageBox.Show("无音频文件路径");
                                            }
                                            else
                                                MessageBox.Show("过站检测错误");
                                            nCheckStation = 0;
                                        }
                                        else
                                            MessageBox.Show("SN对比不正确");
                                    }
                                    else//烧录模式直接烧录------------------------
                                    {
                                        nAutoBurn = 1;
                                        Thread.Sleep(500);
                                        //nFristTest = 0;
                                        nAllCheck = 1;
                                        nFristTest = 0;
                                    }
                                }
                                //else
                                //    MessageBox.Show("无下发的ProductSN");
                                nXmlSNBack = 0;
                            }
                            else//整机模式直接上传PSN检测--------------------------------
                            {
                                CheckStation();
                                if (nCheckStation == 1)
                                {
                                    //DUTPSN = ;
                                    ProductSNtextBox.Invoke(new delegateAddText(ReFreshPSNTextBox));
                                    if (SettingCommand.MyCmdPush.Contains("adb.exe push"))
                                    {
                                        Thread.Sleep(1000);
                                        nRecordFinash = 0;
                                        string stra = SettingCommand.MyCmdPush + " /data/factoryRokid/";
                                        proc.CmdStr = stra;
                                        strall += proc.ExecuteCmd();
                                        if (strall.Contains("bytes in") == true)
                                        {
                                            nAutoTest01 = 1;
                                            nAutoTest02 = 1;
                                            Thread.Sleep(500);
                                            nFristTest = 0;
                                        }
                                        else
                                        {
                                            MessageBox.Show("音频推入不成功");
                                        }
                                        LogTextBox.Invoke(new delegateAddText(addLogText));
                                        nAllCheck = 1;
                                        //Thread.Sleep(500);
                                    }
                                    else
                                        MessageBox.Show("无音频文件路径");
                                }//过站检测加音频推入开始测试线程-----------------------
                                else
                                    MessageBox.Show("过站检测错误");
                            }
                        }
                        LabelSNtextBox.Invoke(new delegateEnableText(ReAbleLabelSN));
                        SoftWareButton.Invoke(new delegateButton(ReVersionButton));
                        DDRSizeButton.Invoke(new delegateButton(ReDDRButton));
                        FlashSizeButton.Invoke(new delegateButton(ReFlashButton));
                        WIFITestButton.Invoke(new delegateButton(ReWIFIButton));
                        BTTestButton.Invoke(new delegateButton(ReBTButton));
                        UARTTestButton.Invoke(new delegateButton(ReUARTButton));
                        LEDTestButton.Invoke(new delegateButton(ReLEDButton));
                        MICTestButton.Invoke(new delegateButton(ReMICButton));
                        AMPTestButton.Invoke(new delegateButton(ReAMPButton));
                        KeyTestButton.Invoke(new delegateButton(ReKEYButton));
                        ReSureSNEtcBurn();
                    }
                    //提示是否自动测试中 
                    AutoTesttextBox.Invoke(new delegateButton(AutoTesttext));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detect Error");
                MessageBox.Show(ex.Message);
            }
            return;
        }
        
        public void RecordMicThread()
        {
            nRecordFinash = 0;
            ProcClass procMIC = new ProcClass();
            procMIC.CmdStr = adbcmd + SettingCommand.MyCmdrecord;
            strMIC = procMIC.ExecuteCmd();
            nRecordFinash = 1;
            //MessageBox.Show("录音完成");
            //MessageBox.Show(nRecordFinash.ToString());
        }

        //备用：自动烧录------------------------------------------
        private void AutoBurnTest()
        {
            while (TestItem.CAutoBurn == "Checked" && XmlMesBack.Contains("true"))
            {
                Thread.Sleep(20);
                if (nDet == true && nAutoTest01 == 0 && nAutoTest02 == 0 && nAutoBurn == 1)
                {

                }
            }
        }

        //烧录SN，SEED，TYPEID------------------------------
        private void BurnSNINProduct()
        {
            try
            {
                string SNOK;
                ProcClass proc = new ProcClass();
                proc.CmdStr = "adb.exe shell factory 9 3 " + XmlProductSN;
                SNOK = proc.ExecuteCmd();
                strall += SNOK;
                if (SNOK.Contains("ok")) nSNBurnOK = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("BurnSN Error!");
                MessageBox.Show(ex.Message);
            }

        }
        private void BurnSEEDINProduct()
        {
            try
            {
                string SEEDOK;
                ProcClass proc = new ProcClass();
                proc.CmdStr = "adb.exe shell factory 9 1 " + XmlProductSEED;
                SEEDOK = proc.ExecuteCmd();
                strall += SEEDOK;
                if (SEEDOK.Contains("ok")) nSEEDBurnOK = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("BurnSeed Error! ");
                MessageBox.Show(ex.Message);
            }
        }
        private void BurnTypeIDINProduct()
        {
            try
            {
                string TYPEIDOK;
                ProcClass proc = new ProcClass();
                proc.CmdStr = "adb.exe shell factory 9 5 " + XmlProductTypeID;
                TYPEIDOK = proc.ExecuteCmd();
                strall += TYPEIDOK;
                if (TYPEIDOK.Contains("ok")) nTYPEIDBurnOK = 1;
            }catch(Exception ex)
            {
                MessageBox.Show("BurnTypeID Error!");
                MessageBox.Show(ex.Message);
            }
        }

        //产品过站------------------------------------------
        private void OverStation()
        {
            try
            {
                string ProductIdXml;
                LabelSNIN = LabelSNtextBox.Text;
                ProductTestData productTestData = new ProductTestData();
                productTestData.testProductRecord = new TestProductRecord();
                //productTestData.testProductRecord.ProductId = LabelSNIN;//确认是否是凌启SN还是产品SN
                if (WorkshopShowtextBox.Text != WorkShop[3])
                    productTestData.testProductRecord.ProductId = LabelSNIN;
                else
                {
                    //string SNRead;
                    //ProcClass proc = new ProcClass();
                    //proc.CmdStr = "adb.exe shell factory 9 2";
                    //SNRead = proc.ExecuteCmd();
                    //string[] Array = SNRead.Split(new string[] { "&exit" }, StringSplitOptions.None);
                    //string PSNRead = Array[1].Replace("\r\n", "");
                    productTestData.testProductRecord.ProductId = PSNRead;
                }
                productTestData.testProductRecord.TestResult = "PASS";
                productTestData.testProductRecord.TestType = WorkshopShowtextBox.Text;
                //productTestData.testProductRecord.TestType = "板卡功能测试";
                ProductIdXml = XmlSerializeHelper.XmlSerialize(productTestData);
                MessageBox.Show(ProductIdXml);
                object[] arg = new object[3];
                arg[0] = "OverStation";
                arg[1] = ProductIdXml;
                arg[2] = "";
                XmlMesBack = WebServiceHelper.InvokeWebService(TestItem.SetWebAddress, "ProductTestService", arg).ToString();
                LogTextBox.Text = XmlMesBack;
                //MessageBox.Show(XmlMesBack);
                if (XmlMesBack.Contains("true"))
                {
                    nXmlPass = 1;
                }
                else
                {
                    nXmlPass = 0;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("OverStation Error!");
                MessageBox.Show(ex.Message);
            }
        }

        //过站检测------------------------------------------
        private void CheckStation()
        {
            try
            {
                string ProductIdXml;
                LabelSNIN = LabelSNtextBox.Text;
                ProductTestData productTestData = new ProductTestData();
                productTestData.testProductRecord = new TestProductRecord();
                if (WorkshopShowtextBox.Text != WorkShop[3])
                    productTestData.testProductRecord.ProductId = LabelSNIN;
                else
                {
                    string SNRead;
                    string SeedRead;
                    ProcClass proc = new ProcClass();
                    proc.CmdStr = "adb.exe shell factory 9 2";
                    SNRead = proc.ExecuteCmd();
                    string[] Array01 = SNRead.Split(new string[] { "&exit" }, StringSplitOptions.None);
                    PSNRead = Array01[1].Replace("\r\n", "");
                    proc.CmdStr = "adb.exe shell factory 9 0";
                    SeedRead = proc.ExecuteCmd();
                    string[] Array02 = SeedRead.Split(new string[] { "&exit" }, StringSplitOptions.None);
                    SeedRead = Array02[1].Replace("\r\n", "");
                    productTestData.testProductRecord.ProductId = PSNRead;
                    DUTPSN = PSNRead;
                    //MessageBox.Show(PSNRead);
                    //productTestData.testProductRecord.DataType = "seed";
                    //productTestData.testProductRecord.DataValue = SeedRead;
                }
                //productTestData.testProductRecord.TestResult = "PASS";
                if (WorkshopShowtextBox.Text != WorkShop[0])
                {
                    //for (int i = 1; i < 5; i++)
                    //{
                    //    if (WorkshopShowtextBox.Text == WorkShop[i])
                    //        productTestData.testProductRecord.TestType = WorkShop[i - 1];
                    //}
                    productTestData.testProductRecord.TestType = WorkshopShowtextBox.Text;
                    //productTestData.testProductRecord.TestType = WorkshopShowtextBox.Text;
                    //productTestData.testProductRecord.TestType = "板卡功能测试";
                    ProductIdXml = XmlSerializeHelper.XmlSerialize(productTestData);
                    object[] arg = new object[3];
                    arg[0] = "CheckStation";
                    arg[1] = ProductIdXml;
                    arg[2] = "";
                    XmlMesBack = WebServiceHelper.InvokeWebService(TestItem.SetWebAddress, "ProductTestService", arg).ToString();
                    //LogTextBox.Text = XmlMesBack;
                    MessageBox.Show(XmlMesBack);
                    if (XmlMesBack.Contains("true"))
                    {
                        strall += XmlMesBack;
                        LogTextBox.Invoke(new delegateAddText(addLogText));
                        nCheckStation = 1;
                    }
                    else
                    {
                        nCheckStation = 0; strall += XmlMesBack;
                        LogTextBox.Invoke(new delegateAddText(addLogText));
                    }
                }

                else
                    nCheckStation = 1;
            }catch(Exception ex)
            {
                MessageBox.Show("CheckStation Error!");
                MessageBox.Show(ex.Message);
            }
        }

        //WIFI自动测试--------------------------------------
        private void AutoWIFIAndBTTest()
        {
            while (TestItem.CAutoTest == "Checked" )
            {
                Thread.Sleep(20);
                if (nDet == true /*&& nFristTest == 1 */&& nAutoTest01 == 1)
                //if (true)
                {
                    IsAutoTest01Begin = true;
                    if (nDet == true && TestItem.CVersionTest == "Checked")
                    {
                        SoftWareTest();
                    }
                    if (nDet == true && TestItem.CFlashSizeTest == "Checked")
                    {
                        FlashSizeTest();
                    }
                    if (nDet == true && TestItem.CDDRSizeTest == "Checked")
                    {
                        DDRSizeTest();
                    }
                    if (nDet == true && TestItem.CWIFITest == "Checked")
                    {
                        WIFITest();
                    }
                    if (nDet == true && TestItem.CBTTest == "Checked")
                    {
                        BTTest();
                    }
                    nAutoTest01 = 0;
                    IsAutoTest01Begin = false;
                    //WifipictureBox.Invoke(new delegatereflashpicture(WIFITest));
                    //BTpictureBox.Invoke(new delegatereflashpicture(BTTest));
                }
            }
        }

        //其余项自动测试------------------------------------
        private void AutoOtherTest()
        {
            while (TestItem.CAutoTest == "Checked" || TestItem.CAutoBurn == "Checked")
            {
                Thread.Sleep(20);
                //自动烧录----------------------------------------------
                if(nDet == true /*&& nAutoTest02 == 1 */&& nAutoBurn == 1)
                {
                    IsAutoBurnBegin = true;
                    if (TestItem.CSNBurn == "Checked") { BurnSNINProduct(); }
                    if (TestItem.CSEEDBurn == "Checked") { BurnSEEDINProduct(); }
                    if (TestItem.CTypeIDBurn == "Checked") { BurnTypeIDINProduct(); }
                    IsAutoBurnBegin = false;
                    nAutoBurn = 0;
                }
                if (nDet == true && nAutoTest02 == 1 && TestItem.CAutoTest == "Checked")
                //if (true)
                {
                    IsAutoTest02Begin = true;
                    if (nDet == true && TestItem.CLedTest == "Checked")
                    {
                        LEDTest();
                    }
                    if (nDet == true && TestItem.CAMPTest == "Checked")
                    {
                        AMPTest();
                    }
                    if (nDet == true && TestItem.CMICTest == "Checked")
                    {
                        MICtest();
                    }
                    if (nDet == true && TestItem.CKeyTest == "Checked")
                    {
                        KeyTest();
                    }
                    IsAutoTest02Begin = false;
                    //SoftWarepictureBox.Invoke(new delegatereflashpicture(SoftWareTest));
                    //FlashpictureBox.Invoke(new delegatereflashpicture(FlashSizeTest));
                    //DdrpictureBox.Invoke(new delegatereflashpicture(DDRSizeTest));
                    //LedpictureBox.Invoke(new delegatereflashpicture(LEDTest));
                    //AMPpictureBox.Invoke(new delegatereflashpicture(AMPTest));
                    //MicpictureBox.Invoke(new delegatereflashpicture(MICtest));
                    //KeypictureBox.Invoke(new delegatereflashpicture(KeyTest));
                }
                
            }
        }

        //软件版本测试--------------------------------------
        string strversion = string.Empty;
        private void SoftWareTest()
        {
            try
            {
                //SoftWareButton.Text = "测试中";
                //SoftWareButton.Enabled = false;
                ImageList imageListSoft = new ImageList();
                imageListSoft.ColorDepth = ColorDepth.Depth32Bit;
                imageListSoft.ImageSize = new Size(36, 37);
                imageListSoft.Images.Add(SoftOKimage);
                imageListSoft.Images.Add(SoftNCimage);
                ProcClass procVersion = new ProcClass();
                string Versioncmd = string.Empty;
                procVersion.CmdStr = Versioncmd = adbcmd + SettingCommand.MyCmdVersion;
                if (Versioncmd.Contains("factory") && Versioncmd.Contains("1"))
                {
                    int a = 0;
                    while (a < 2)
                    {
                        strversion = procVersion.ExecuteCmd();
                        if (strversion.Contains(TestItem.SetVersion))
                        {
                            nVersion = 1;
                            SoftWarepictureBox.Image = imageListSoft.Images[0];
                            a = 2;
                        }
                        else
                        {
                            SoftWarepictureBox.Image = imageListSoft.Images[1];
                            nVersion = 0;
                            a++;
                        }
                        Thread.Sleep(200);
                    }
                    //SoftWarepictureBox.Refresh();
                    //AllCheck();
                }
                else
                    MessageBox.Show("无测试命令或命令不正确");
                //SoftWareButton.ResetText();
                //SoftWareButton.Enabled = true;
            }catch(Exception ex)
            {
                MessageBox.Show("SofeTest Error!");
                MessageBox.Show(ex.Message);
            }
        }    
        private void SoftWareButton_Click(object sender, EventArgs e)
        {
            SoftWareButton.Enabled = false;
            SoftWareButton.Text = "测试中...";
            SoftWareTest();
            LogTextBox.Text += strversion;
            LogTextBox.Focus();
            LogTextBox.ScrollToCaret();
            SoftWareButton.Enabled = true;
            SoftWareButton.Text = "软件版本";
        }

        //Flash大小测试-------------------------------------
        string strFlash = string.Empty;
        private void FlashSizeTest()
        {
            try
            {
                ImageList imageListFlash = new ImageList();
                imageListFlash.ColorDepth = ColorDepth.Depth32Bit;
                imageListFlash.ImageSize = new Size(36, 37);
                imageListFlash.Images.Add(FlashOKimage);
                imageListFlash.Images.Add(FlashNCimage);

                ProcClass procFlash = new ProcClass();
                string Flashcmd = string.Empty;
                procFlash.CmdStr = Flashcmd = adbcmd + SettingCommand.MyCmdFlashTest;
                if (Flashcmd.Contains("factory") && Flashcmd.Contains("3"))
                {
                    int a = 0;
                    while (a < 2)
                    {
                        strFlash = procFlash.ExecuteCmd();

                        if (strFlash.Contains(TestItem.SetFlashSize))
                        {
                            nFlash = 1;
                            FlashpictureBox.Image = imageListFlash.Images[0];
                            a = 2;
                        }
                        else
                        {
                            FlashpictureBox.Image = imageListFlash.Images[1];
                            nFlash = 0;
                            a++;
                        }
                    }
                    //MessageBox.Show(strversion);
                    //FlashpictureBox.Refresh();
                    //AllCheck();
                }
                else
                    MessageBox.Show("无测试命令或命令不正确");
            }
            catch(Exception ex)
            {
                MessageBox.Show("FlashTest Error!");
                MessageBox.Show(ex.Message);
            }
        }
        private void FlashSizeButton_Click(object sender, EventArgs e)
        {
            FlashSizeButton.Enabled = false; ;
            FlashSizeButton.Text = "测试中...";
            FlashSizeTest();
            LogTextBox.Text += strFlash;
            LogTextBox.Focus();
            LogTextBox.ScrollToCaret();
            FlashSizeButton.Enabled = true; ;
            FlashSizeButton.Text = "Flash测试";
        }

        //DDR大小测试---------------------------------------
        string strDDR = string.Empty;
        private void DDRSizeTest()
        {
            try
            {
                ImageList imageListDDR = new ImageList();
                imageListDDR.ColorDepth = ColorDepth.Depth32Bit;
                imageListDDR.ImageSize = new Size(36, 37);
                imageListDDR.Images.Add(DDROKimage);
                imageListDDR.Images.Add(DDRNCimage);

                ProcClass procDDR = new ProcClass();
                string Ddrcmd = string.Empty;
                procDDR.CmdStr = Ddrcmd = adbcmd + SettingCommand.MyCmdDdrTest;
                if (Ddrcmd.Contains("factory") && Ddrcmd.Contains("3"))
                {
                    int a = 0;
                    while (a < 2)
                    {
                        strDDR = procDDR.ExecuteCmd();

                        if (strDDR.Contains(TestItem.SetDdrSize))
                        {
                            nDDR = 1;
                            DdrpictureBox.Image = imageListDDR.Images[0];
                            a = 2;
                        }
                        else
                        {
                            DdrpictureBox.Image = imageListDDR.Images[1];
                            nDDR = 0;
                            a++;
                        }
                    }
                    //MessageBox.Show(strversion);
                    //DdrpictureBox.Refresh();
                    //AllCheck();
                }
                else
                    MessageBox.Show("无测试命令或命令不正确");
            }catch(Exception ex)
            {
                MessageBox.Show("DdrTest Error!");
                MessageBox.Show(ex.Message);
            }
        }
        private void DDRSizeButton_Click(object sender, EventArgs e)
        {
            DDRSizeButton.Enabled = false; ;
            DDRSizeButton.Text = "测试中...";
            DDRSizeTest();
            LogTextBox.Text += strDDR;
            LogTextBox.Focus();
            LogTextBox.ScrollToCaret();
            DDRSizeButton.Enabled = true; ;
            DDRSizeButton.Text = "DDR测试";
        }

        //WIFI连接测试--------------------------------------
        string strWIFI = string.Empty;
        private void WIFITest()
        {
            //throw new NotImplementedException();
            //WIFITestButton.Text = "测试中";
            //WIFITestButton.Enabled = false;
            try
            {
                ImageList imageListWIFI = new ImageList();
                imageListWIFI.ColorDepth = ColorDepth.Depth32Bit;
                imageListWIFI.ImageSize = new Size(36, 37);
                imageListWIFI.Images.Add(WIFIOKimage);
                imageListWIFI.Images.Add(WIFINCimage);

                ProcClass procWIFI = new ProcClass();
                string stra = adbcmd + SettingCommand.MyCmdWifiConnectTest + " " + TestItem.SetWIFIName;
                procWIFI.CmdStr = stra;
                if (stra.Contains("factory") && stra.Contains("5"))
                {
                    //MessageBox.Show(stra);
                    int a = 0;
                    while (a < 2)
                    {
                        strWIFI = procWIFI.ExecuteCmd();
                        if (strWIFI.Contains("connect ok"))
                        {
                            nWifi = 1;
                            WifipictureBox.Image = imageListWIFI.Images[0];
                            a = 2;
                        }
                        else
                        {
                            WifipictureBox.Image = imageListWIFI.Images[1];
                            nWifi = 0;
                            a++;
                        }
                    }
                    //WifipictureBox.Refresh();
                    //AllCheck();
                }
                else
                    MessageBox.Show("无测试命令或命令不正确");
                //WIFITestButton.ResetText();
                //WIFITestButton.Enabled = false;
                //WIFITestButton.Text = "WIFI测试";
            }catch(Exception ex)
            {
                MessageBox.Show("WifiTest Error!");
                MessageBox.Show(ex.Message);
            }
        }
        private void WIFITestButton_Click(object sender, EventArgs e)
        {
            WIFITestButton.Text = "测试中...";
            WIFITestButton.Enabled = false;
            WIFITest();
            LogTextBox.Text += strWIFI;
            LogTextBox.Focus();
            LogTextBox.ScrollToCaret();
            WIFITestButton.Text = "WIFI测试";
            WIFITestButton.Enabled = false;
        }

        //BT连接测试----------------------------------------
        string strBT = string.Empty;
        private void BTTest()
        {
            try
            {
                ImageList imageListBT = new ImageList();
                imageListBT.ColorDepth = ColorDepth.Depth32Bit;
                imageListBT.ImageSize = new Size(36, 37);
                imageListBT.Images.Add(BTOKimage);
                imageListBT.Images.Add(BTNCimage);
                ProcClass procBT = new ProcClass();
                string stra = adbcmd + SettingCommand.MyCmdBtMacTest;
                procBT.CmdStr = stra;
                //MessageBox.Show(stra);

                if (stra.Contains("factory") && stra.Contains("grep"))
                {
                    int a = 0;
                    while (a < 2)
                    {
                        strBT = procBT.ExecuteCmd();
                        if (strBT.Contains(TestItem.SetBTName))
                        {
                            nBT = 1;
                            BTpictureBox.Image = imageListBT.Images[0];
                            a = 2;
                        }
                        else
                        {
                            BTpictureBox.Image = imageListBT.Images[1];
                            nBT = 0;
                            a++;
                        }
                        //MessageBox.Show(strversion);
                        //BTpictureBox.Refresh();
                        //AllCheck();
                    }
                }

                else
                    MessageBox.Show("无测试命令或命令不正确");
            }catch(Exception ex)
            {
                MessageBox.Show("BtTest Error!");
                MessageBox.Show(ex.Message);
            }
        }
        private void BTTestButton_Click(object sender, EventArgs e)
        {
            BTTestButton.Text = "测试中...";
            BTTestButton.Enabled = false;
            BTTest();
            LogTextBox.Text += strBT;
            LogTextBox.Focus();
            LogTextBox.ScrollToCaret();
            BTTestButton.Text = "蓝牙测试";
            BTTestButton.Enabled = true;

        }

        private void UARTTest()
        {
            AllCheck();
        }
        private void UARTTestButton_Click(object sender, EventArgs e)
        {

        }

        //功放测试------------------------------------------
        string strAMP = string.Empty;
        string strMICPull = string.Empty;
        private void AMPTest()
        {
            try
            {
                ImageList imageListAMP = new ImageList();
                imageListAMP.ColorDepth = ColorDepth.Depth32Bit;
                imageListAMP.ImageSize = new Size(36, 37);
                imageListAMP.Images.Add(AMPOKimage);
                imageListAMP.Images.Add(AMPNCimage);
                string AMPcmd = string.Empty;
                string MICPullcmd = string.Empty;
                if (TestItem.CMICTest == "Checked")
                {
                    Thread RecordThread = new Thread(new ThreadStart(RecordMicThread));
                    RecordThread.IsBackground = true;
                    RecordThread.Start();
                }
                else
                {
                    nRecordFinash = 1;
                }
                Thread.Sleep(500);
                ProcClass procAMP = new ProcClass();
                procAMP.CmdStr = AMPcmd = adbcmd + SettingCommand.MyCmdAudioTest;
                //MessageBox.Show(AMPcmd);
                ProcClass procMICPull = new ProcClass();
                procMICPull.CmdStr = MICPullcmd = SettingCommand.MyCmdPullrecord + " " + TestItem.SetRecordaudioAdd;
                //MessageBox.Show(MICPullcmd);
                if (AMPcmd.Contains("paplay") && AMPcmd.Contains("data") && MICPullcmd.Contains("pull") && MICPullcmd.Contains(".wav"))
                {
                    strAMP = procAMP.ExecuteCmd();
                    //MessageBox.Show("录音完成");
                    Thread.Sleep(500);
                    for (int a = 0; a < 3; a++)
                    {
                        if (nRecordFinash == 1)
                        {
                            //MessageBox.Show("录音成功");
                            a = 3;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    if (nRecordFinash == 0)
                        MessageBox.Show("录音不成功");
                    strMICPull = procMICPull.ExecuteCmd();
                    //if (strMICPull.Contains("KB/s"))
                    //{
                    //    MessageBox.Show("音频推出成功");
                    //}
                    //else
                    //{ MessageBox.Show("推出不成功"); }
                    Thread.Sleep(500);
                    AMPMakeSure AMPForm = new AMPMakeSure();
                    AMPForm.StartPosition = FormStartPosition.CenterParent;
                    //AMPForm.Focus();
                    AMPForm.ShowDialog();
                    if (AMPForm.AMPResult == 1)
                    {
                        nAMP = 1;
                        //Thread.Sleep(1000);
                        AMPpictureBox.Image = imageListAMP.Images[0];
                    }
                    else
                    {
                        nAMP = 0;
                        //Thread.Sleep(1000);0
                        AMPpictureBox.Image = imageListAMP.Images[1];
                    }
                    //MessageBox.Show(strMIC);
                    //AMPpictureBox.Refresh();
                    //AllCheck();

                }
                else
                    MessageBox.Show("无测试命令或命令不正确");
            }catch(Exception ex)
            {
                MessageBox.Show("AMPTest Error!");
                MessageBox.Show(ex.Message);
            }
        }
        private void AMPTestButton_Click(object sender, EventArgs e)
        {
            AMPTestButton.Text = "测试中...";
            AMPTestButton.Enabled = false;
            AMPTest();
            LogTextBox.Text += strMIC;
            LogTextBox.Text += strAMP;
            LogTextBox.Text += strMICPull;
            //RecordThread.Interrupt();
            LogTextBox.Focus();
            LogTextBox.ScrollToCaret();
            AMPTestButton.Text = "功放测试";
            AMPTestButton.Enabled = true;
        }

        //MIC测试-------------------------------------------
        string strpull = string.Empty;
        private void MICtest()
        {
            int a = 0;
            while (nRecordFinash == 0 && a < 8)
            {
                Thread.Sleep(500);
                a++;
            }
            if (a < 8)
            {
                try
                {
                    ImageList imageListMIC = new ImageList();
                    imageListMIC.ColorDepth = ColorDepth.Depth32Bit;
                    imageListMIC.ImageSize = new Size(36, 37);
                    imageListMIC.Images.Add(MICOKimage);
                    imageListMIC.Images.Add(MICNCimage);
                    string Pullcmd = string.Empty;
                    ProcClass procPull = new ProcClass();
                    procPull.CmdStr = Pullcmd = SettingCommand.MyCmdPullrecord;
                    //MessageBox.Show(Pullcmd);
                    //if (Pullcmd.Contains("pull") && Pullcmd.Contains(".wav"))
                    //{
                    //    strpull = procPull.ExecuteCmd();

                    PostMessage(AuProc.MainWindowHandle, 256, Keys.D, 1);
                    Thread.Sleep(500);
                    PostMessage(AuProc.MainWindowHandle, 256, Keys.A, 1);
                    PostMessage(AuProc.MainWindowHandle, 256, Keys.A, 1);
                    MICMakeSure MICForm = new MICMakeSure();
                    //MICForm.StartPosition = FormStartPosition.CenterParent;
                    MICForm.StartPosition = FormStartPosition.CenterScreen;
                    MICForm.ShowDialog();
                    if (MICForm.MICResult == 1)
                    {
                        nMic = 1;
                        MicpictureBox.Image = imageListMIC.Images[0];
                        PostMessage(AuProc.MainWindowHandle, 256, Keys.S, 1);
                        PostMessage(AuProc.MainWindowHandle, 256, Keys.S, 1);
                    }
                    else
                    {
                        nMic = 0;
                        MicpictureBox.Image = imageListMIC.Images[1];
                        PostMessage(AuProc.MainWindowHandle, 256, Keys.S, 1);
                        PostMessage(AuProc.MainWindowHandle, 256, Keys.S, 1);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("MicTest Error!");
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("没有完成正常录音");
            //MicpictureBox.Refresh();
            //AllCheck();
            //            }
            //else
            //    MessageBox.Show("无测试命令或命令不正确");
        }
        private void MICTestButton_Click(object sender, EventArgs e)
        {
            MICtest();
            LogTextBox.Text += strpull;
            LogTextBox.Focus();
            LogTextBox.ScrollToCaret();
        }

        //LED测试-------------------------------------------
        string strLED = string.Empty;
        private void LEDTest()
        {
            try
            {
                ImageList imageListLED = new ImageList();
                imageListLED.ColorDepth = ColorDepth.Depth32Bit;
                imageListLED.ImageSize = new Size(36, 37);
                imageListLED.Images.Add(LEDOKimage);
                imageListLED.Images.Add(LEDNCimage);

                string LEDcmd = string.Empty;
                //Thread.Sleep(1000);
                ProcClass procLED = new ProcClass();
                procLED.CmdStr = LEDcmd = adbcmd + SettingCommand.MyCmdLEDTest;
                //MessageBox.Show(adbcmd + SettingCommand.MyCmdLEDTest);
                if (LEDcmd.Contains("factory") && LEDcmd.Contains("7"))
                {
                    strLED = procLED.ExecuteCmd();
                    FormLEDTips formLEDTips = new FormLEDTips();
                    formLEDTips.StartPosition = FormStartPosition.CenterParent;
                    //AMPForm.Focus();
                    formLEDTips.ShowDialog();
                    if (formLEDTips.LEDResult == 1)
                    {
                        nLed = 1;
                        //Thread.Sleep(1000);
                        LedpictureBox.Image = imageListLED.Images[0];
                    }
                    else
                    {
                        nLed = 0;
                        //Thread.Sleep(1000);0
                        LedpictureBox.Image = imageListLED.Images[1];
                    }
                    //MessageBox.Show(strMIC);
                    //LedpictureBox.Refresh();
                    //AllCheck();
                }
                else
                    MessageBox.Show("无测试命令或命令不正确");
            }catch(Exception ex)
            {
                MessageBox.Show("LedTest Error!");
                MessageBox.Show(ex.Message);
            }
        }
        private void LEDTestButton_Click(object sender, EventArgs e)
        {
            LEDTestButton.Enabled = false;
            LEDTestButton.Text = "测试中...";
            LEDTest();
            LogTextBox.Text += strLED;
            //RecordThread.Interrupt();
            LogTextBox.Focus();
            LogTextBox.ScrollToCaret();
            LEDTestButton.Enabled = true;
            LEDTestButton.Text = "LED测试";
        }

        //按键测试----------------------------------------------
        string strKey = string.Empty;
        private void KeyTest()
        {
            try
            {
                //strall = null;
                ImageList imageListKEY = new ImageList();
                imageListKEY.ColorDepth = ColorDepth.Depth32Bit;
                imageListKEY.ImageSize = new Size(36, 37);
                imageListKEY.Images.Add(KEYOKimage);
                imageListKEY.Images.Add(KEYNCimage);
                //string cmdKeyTestKey01, cmdKeyTestKey02, cmdKeyTestKey03, cmdKeyTestKey04, cmdKeyTestKey05;
                //string cmdKeyAnswer01, cmdKeyAnswer02, cmdKeyAnswer03, cmdKeyAnswer04, cmdKeyAnswer05;           
                string strKeyTest = SettingCommand.MyCmdKeyTest;
                string strKeyAnswer = TestItem.SetKeyAnswer;
                string ShowTips = "按键测试中";
                FormShowTips formShowTips = new FormShowTips();
                ProcClass procKey = new ProcClass();
                //adbcmd;
                if (strKeyTest.Contains("factory") && strKeyTest.Contains("4"))
                {
                    char splitkey = ',';
                    string[] sArrayAnskey = strKeyAnswer.Split(splitkey);
                    string[] cmdKeyAnsKey = new string[sArrayAnskey.Length];
                    string[] sArraykey = strKeyTest.Split(splitkey);
                    string[] cmdKeyTestKey = new string[sArraykey.Length];
                    int j = 0, k = 0, ncount = 0, ntips = 1;
                    if (strKeyAnswer.Contains(','))
                    {
                        int i = 0;
                        foreach (string ArrAnsKey in sArrayAnskey)
                        {
                            cmdKeyAnsKey[i] = ArrAnsKey.Trim().ToString();
                            i++;
                        }
                    }

                    if (strKeyTest.Contains(','))
                    {
                        foreach (string ArrKey in sArraykey)
                        {
                            cmdKeyTestKey[j] = adbcmd + ArrKey.Trim().ToString();
                            ncount = 1;
                            formShowTips.ShowItemState = ntips.ToString() + ShowTips;
                            //formShowTips.Refresh();
                            //formShowTips.Hide();
                            //MessageBox.Show(formShowTips.ShowItemState);                                              
                            formShowTips.StartPosition = FormStartPosition.CenterScreen;
                            formShowTips.WindowState = FormWindowState.Normal;
                            formShowTips.Show();
                            //formShowTips.Focus();
                            //formShowTips.ShowDialog();
                            do
                            {
                                procKey.CmdStr = cmdKeyTestKey[j];
                                strKey = procKey.ExecuteCmd();
                                //strall += strKey;
                                //addLogText();
                                //LogTextBox.ScrollToCaret();
                                //LogTextBox.Refresh();
                                //LogTextBox.Show();
                                //LogTextBox.Focus();
                                ncount++;
                            }
                            while (strKey.Contains("Time out") == true && ncount < 3);
                            if (strKey.Contains(cmdKeyAnsKey[j]))
                            {
                                k += 1;
                            }
                            else
                                break;
                            j++;
                            formShowTips.Hide();
                            ntips++;
                        }
                    }
                    else
                    {
                        procKey.CmdStr = strKeyTest;
                        strKey = procKey.ExecuteCmd();
                        if (strKey.Contains(strKeyAnswer))
                        { k = 1; }
                    }
                    if (k == sArraykey.Length)
                    {
                        nKey = 1;
                        KeypictureBox.Image = imageListKEY.Images[0];
                    }
                    else
                    {
                        KeypictureBox.Image = imageListKEY.Images[1];
                        nKey = 0;
                    }
                    //KeypictureBox.Refresh();
                    //MessageBox.Show(strversion);
                    //AllCheck();
                }
                else
                    MessageBox.Show("无测试命令或命令不正确");
                formShowTips.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("KeyTest Error!");
                MessageBox.Show(ex.Message);
            }


            //if (strKeyAnswer.Contains(','))
            //{
            //    char splitkey = ',';
            //    string[] sArrayAnskey = strKeyAnswer.Split(splitkey);
            //    cmdKeyTestKey01 = sArrayAnskey[0].Trim().ToString();
            //    cmdKeyTestKey02 = sArrayAnskey[1].Trim().ToString();
            //    if (sArrayAnskey[2].Trim().ToString() != ""){cmdKeyTestKey03 = sArrayAnskey[2].Trim().ToString();}
            //    if (sArrayAnskey[3].Trim().ToString() != ""){cmdKeyTestKey04 = sArrayAnskey[3].Trim().ToString();}
            //    if (sArrayAnskey[4].Trim().ToString() != ""){cmdKeyTestKey05 = sArrayAnskey[4].Trim().ToString();}
            //}
            //else
            //{
            //    procKey.CmdStr = strKeyTest;
            //    strKey = procKey.ExecuteCmd();
            //}                       
        }

        private void KeyTestButton_Click(object sender, EventArgs e)
        {
            KeyTestButton.Enabled = false;
            KeyTestButton.Text = "测试中...";
            KeyTest();
            LogTextBox.Text += strKey;
            LogTextBox.Focus();
            LogTextBox.ScrollToCaret();
            KeyTestButton.Enabled = true;
            KeyTestButton.Text = "按键测试";

        }

        private void LabelSNtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //应用程序设置与初始化----------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            setTag(this);//调用窗体尺寸方法，加入尺寸信息
            //打开Au第三方软件
            Audacityaddress = TestItem.SetAuAddress;
            try
            {
                Process[] FindProcess = Process.GetProcesses();
                foreach (Process p in FindProcess)
                {
                    if (p.ProcessName.Contains("audacity"))
                    {
                        p.Kill();
                    }
                }
                if (File.Exists(Audacityaddress) == true)
                {
                    AuProc.StartInfo.FileName = Audacityaddress;
                    AuProc.StartInfo.CreateNoWindow = false;
                    AuProc.StartInfo.UseShellExecute = false;
                    AuProc.StartInfo.RedirectStandardOutput = true;
                    AuProc.StartInfo.RedirectStandardInput = true;
                    AuProc.Start();
                    Thread.Sleep(1000);//让程序停一会  
                    string str = AuProc.MainWindowHandle.ToString();
                    //MessageBox.Show(str);
                    while (AuProc.MainWindowHandle.ToString() == "0")
                    {
                        Thread.Sleep(500);
                    }
                    str = AuProc.MainWindowHandle.ToString();
                    var s = GetWindowLong(AuProc.MainWindowHandle, GWL_STYLE);//获取Au句柄
                    SetWindowLong(AuProc.Handle, GWL_STYLE, s | WS_CHILD);
                    SetParent(AuProc.MainWindowHandle, AudacitytextBox.Handle);
                    MoveWindow(AuProc.MainWindowHandle, 0, 0, AudacitytextBox.Width, AudacitytextBox.Height, true);

                }
                else
                    MessageBox.Show("录音测试软件：Audacity.exe不存在");
            }catch(Exception ex)
            {
                MessageBox.Show("OpenAudacity Error!");
                MessageBox.Show(ex.Message);
            }
            RefreshLogText();
            addLogText();
            //nVersion = nFlash = nDDR = nUart = nWifi = nBT = nKey = nLed = nMic = nAMP = 2;
            AllbuttonDisable();                   
            AllCheck();
            Thread DetectDevice = new Thread(new ThreadStart(DetectThread));
            DetectDevice.IsBackground = true;
            DetectDevice.Start();
            //Task DetectTask = new Task(DetectThread);
            //DetectTask.Start();
            //Task WIFIAndBTTask = new Task(AutoWIFIAndBTTest);
            //WIFIAndBTTask.Start();
            //Task OtherTest = new Task(AutoOtherTest);
            //OtherTest.Start();
            //DetectDevice.
            Thread AutoWIFIAndBTTestThread = new Thread(new ThreadStart(AutoWIFIAndBTTest));
            //Thread AutoWIFIAndBTTestThread = new Thread(AutoWIFIAndBTTest);
            AutoWIFIAndBTTestThread.IsBackground = true;
            AutoWIFIAndBTTestThread.Start();
            Thread AutoOtherTestThread = new Thread(new ThreadStart(AutoOtherTest));
            AutoOtherTestThread.IsBackground = true;
            AutoOtherTestThread.Start();
            //WorkShop[0] = "烧录";
            //WorkShop[1] = "板卡功能测试";
            //WorkShop[2] = "板卡声学测试";
            //WorkShop[3] = "整机功能测试";
            //WorkShop[4] = "整机声学测试";
            if (TestItem.SetBurnWorkShop == "True")
            {
                WorkshopShowtextBox.Text = WorkShop[0];
            }
            if (TestItem.SetBoardTestWorkShop == "True")
            {
                WorkshopShowtextBox.Text = WorkShop[1];
            }
            if (TestItem.SetProductTestWorkShop == "True")
            {
                WorkshopShowtextBox.Text = WorkShop[3];
            }
        }

        private void CloseAubutton_Click(object sender, EventArgs e)
        {
            //IntPtr ParenthWnd = new IntPtr(0);
            //string lpszParentWindow = "Test.txt - 记事本";                   
            //MessageBox.Show(ParenthWnd.ToString());
            //while (ParenthWnd.ToString() == "0")
            //{
            //    ParenthWnd = FindWindow(null, lpszParentWindow);
            //    //ParenthWnd = FindWindow("\"DirectUIHWND", null);
            //    Thread.Sleep(500);
            //}
            //IntPtr f1 = FindWindowEx(ParenthWnd, new IntPtr(0), "Edit", null);           
            //MessageBox.Show(AuProc.MainWindowHandle.ToString());
            //MessageBox.Show(ParenthWnd.ToString());
            //MoveWindow(ParenthWnd, 100, 100, 100, 100, true);
            //SendMessage(f1, 0x0100, new IntPtr(0), "N");
            //Thread.Sleep(500);
            //PostMessage(ParenthWnd, 0x0100, Keys.Y, 10);
            //keybd_event(Keys.Q, 0, 0, 0);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemPassWord itemPassWord = new ItemPassWord();
            itemPassWord.StartPosition = FormStartPosition.CenterParent;
            itemPassWord.Focus();
            itemPassWord.WindowState = FormWindowState.Normal;
            itemPassWord.ShowDialog();
        }

        private void setTag(Control cons) //调整窗口大小函数，将控件信息传入setTag
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }

        private void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//获取控件的Tag属性值，并分割后存储字符串数组
                float a = System.Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
                con.Width = (int)a;//宽度
                a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                con.Height = (int)(a);
                a = System.Convert.ToSingle(mytag[2]) * newx;//左边距离
                con.Left = (int)(a);
                a = System.Convert.ToSingle(mytag[3]) * newy;//上边缘距离
                con.Top = (int)(a);
                Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        } //等比例调整窗口

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            float newx = (this.Width) / X; //窗体宽度缩放比例
            float newy = (this.Height) / Y;//窗体高度缩放比例
            setControls(newx, newy, this);//随窗体改变控件大小  
            MoveWindow(AuProc.MainWindowHandle, 0, 0, AudacitytextBox.Width, AudacitytextBox.Height, true);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)//窗体最大化时
            {
                float newx = (this.Width) / X; //窗体宽度缩放比例
                float newy = (this.Height) / Y;//窗体高度缩放比例
                setControls(newx, newy, this);//随窗体改变控件大小 
                nMaxSize = 1;
                MoveWindow(AuProc.MainWindowHandle, 0, 0, AudacitytextBox.Width, AudacitytextBox.Height, true);
            }
            else if (this.WindowState != FormWindowState.Minimized && nMaxSize == 1)//窗体不是最小化同时窗体之前是最大化时
            {
                float newx = (this.Width) / X; //窗体宽度缩放比例
                float newy = (this.Height) / Y;//窗体高度缩放比例
                setControls(newx, newy, this);//随窗体改变控件大小 
                MoveWindow(AuProc.MainWindowHandle, 0, 0, AudacitytextBox.Width, AudacitytextBox.Height, true);
                nMaxSize = 0;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            int a = 0;
            Process[] FindProcess = Process.GetProcesses();
            foreach (Process p in FindProcess)
            {
                if (p.ProcessName.Contains("audacity"))
                {
                    a = 1;
                }
            }
            if (a == 1)
            {
                if (AuProc.MainWindowHandle != null)
                {
                    PostMessage(AuProc.MainWindowHandle, 256, Keys.Q, 1);
                    PostMessage(AuProc.MainWindowHandle, 256, Keys.Q, 1);
                    Thread.Sleep(3000);
                }
            }
            
        }

        private void ConTips_Click(object sender, EventArgs e)
        {

        }

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PassWordForm passWordForm = new PassWordForm();
            passWordForm.StartPosition = FormStartPosition.CenterParent;
            passWordForm.Focus();
            passWordForm.WindowState = FormWindowState.Normal;
            passWordForm.ShowDialog();
        }
    }
}
