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
    public partial class TestItemForm : Form
    {
        string address = ".\\config\\ItemSet.txt";
        string Version;
        
        string BurnWorkShop;
        public string SetBurnWorkShop
        {
            get { return BurnWorkShop; }
        }
        string BoardTestWorkShop;
        public string SetBoardTestWorkShop
        {
            get { return BoardTestWorkShop; }
        }
        string ProductTestWorkShop;
        public string SetProductTestWorkShop
        {
            get { return ProductTestWorkShop; }
        }
        public string SetVersion
        {
            get { return Version; }
        }
        string FlashSize;
        public string SetFlashSize
        {
            get { return FlashSize; }
        }
        string DdrSize;
        public string SetDdrSize
        {
            get { return DdrSize; }
        }
        string WIFIName;
        public string SetWIFIName
        {
            get { return WIFIName; }
        }
        string BTName;
        public string SetBTName
        {
            get { return BTName; }
        }
        string WebAddress;
        public string SetWebAddress
        {
            get { return WebAddress; }
        }
        string TestaudioAdd;
        public string SetTestaudioAdd
        {
            get { return TestaudioAdd; }
        }
        string KeyAnswer;
        public string SetKeyAnswer
        {
            get { return KeyAnswer; }
        }
        string AudacityAddress;
        public string SetAuAddress
        {
            get { return AudacityAddress; }
        }
        string RecordaudioAdd;
        public string SetRecordaudioAdd
        {
            get { return RecordaudioAdd; }
        }
        string VersionTest;
        public string SetVersionTest
        {
            get { return VersionTest; }
        }
        string LQWebServer;
        public string CLQWebServer
        {
            get { return LQWebServer; }
        }
        public string CVersionTest
        {
            get { return VersionTest; }
        }
        string FlashSizeTest;
        public string CFlashSizeTest
        {
            get { return FlashSizeTest; }
        }
        string DDRSizeTest;
        public string CDDRSizeTest
        {
            get { return DDRSizeTest; }
        }
        string UARTSizeTest;
        public string CUARTSizeTest
        {
            get { return UARTSizeTest; }
        }
        string WIFITest;
        public string CWIFITest
        {
            get { return WIFITest; }
        }
        string BTTest;
        public string CBTTest
        {
            get { return BTTest; }
        }
        string KeyTest;
        public string CKeyTest
        {
            get { return KeyTest; }
        }
        string LedTest;
        public string CLedTest
        {
            get { return LedTest; }
        }
        string AMPTest;
        public string CAMPTest
        {
            get { return AMPTest; }
        }
        string MICTest;
        public string CMICTest
        {
            get { return MICTest; }
        }
        string SEEDBurn;
        public string CSEEDBurn
        {
            get { return SEEDBurn; }
        }
        string SNBurn;
        public string CSNBurn
        {
            get { return SNBurn; }
        }
        string AutoTest;
        public string CAutoTest
        {
            get { return AutoTest; }
        }
        string TypeIDBurn;
        public string CTypeIDBurn
        {
            get { return TypeIDBurn; }
        }
        string AutoBurn;
        public string CAutoBurn
        {
            get { return AutoBurn; }
        }

        int i = 1;
        string[] Config = new string[70];
        public TestItemForm()
        {
            InitializeComponent();

            //无文件创建文件-----------------------------------------
            if (File.Exists(address) == false)
            {
                try
                {
                    FileStream SetFile1 = new FileStream(address, FileMode.Create, FileAccess.Write);
                    StreamWriter streamWriter = new StreamWriter(SetFile1);
                    streamWriter.WriteLine("BurnWorkShop = ");
                    streamWriter.WriteLine("BoardTestWorkShop = ");
                    streamWriter.WriteLine("ProductTestWorkShop = ");
                    streamWriter.WriteLine("SetVersion = ");
                    streamWriter.WriteLine("SetFlashSize = ");
                    streamWriter.WriteLine("SetDdrSize = ");
                    streamWriter.WriteLine("WIFINameAndPWD = ");
                    streamWriter.WriteLine("BTName = ");
                    streamWriter.WriteLine("WebAddress = ");
                    streamWriter.WriteLine("Testaudio = ");
                    streamWriter.WriteLine("recordaudio = ");
                    streamWriter.WriteLine("KeyAnswer = ");
                    streamWriter.WriteLine("AudacityAddress = ");
                    streamWriter.WriteLine("LQWebServer = ");//----------
                    streamWriter.WriteLine("VersionTest = ");
                    streamWriter.WriteLine("FlashSizeTest =");
                    streamWriter.WriteLine("DDRSizeTest =");
                    streamWriter.WriteLine("UARTSizeTest = ");
                    streamWriter.WriteLine("WIFITest = ");
                    streamWriter.WriteLine("BTTest = ");
                    streamWriter.WriteLine("KeyTest = ");
                    streamWriter.WriteLine("LedTest = ");
                    streamWriter.WriteLine("AMPTest = ");
                    streamWriter.WriteLine("MICTest = ");
                    streamWriter.WriteLine("SEEDBurn = ");
                    streamWriter.WriteLine("SNBurn = ");
                    streamWriter.WriteLine("TypeIDBurn = ");
                    streamWriter.WriteLine("AutoTest = ");
                    streamWriter.WriteLine("AutoBurn = ");
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
            try
            {
                FileStream SetFile2 = new FileStream(address, FileMode.Open);
                TextReader Setread2 = new StreamReader(SetFile2);
                //string strin = Setread1.ReadToEnd();
                string SetContent;
                //获取配置表信息----------------------------------------
                while (null != (SetContent = Setread2.ReadLine()))
                {
                    SetContent = SetContent.Trim().ToString();
                    char split = '=';
                    string[] sArray = SetContent.Split(split);
                    if (sArray[0].Trim().ToString().Equals("BurnWorkShop"))
                    {
                        if (sArray[1].Trim() == "True")
                        {
                            BurnWorkShopradioButton.Checked = true;
                            BurnWorkShop = "True";
                            //BurnWorkShopradioButton.Refresh();
                        }
                        else
                        { BurnWorkShopradioButton.Checked = false; BurnWorkShop = "False"; }
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("BoardTestWorkShop"))
                    {
                        if (sArray[1].Trim() == "True")
                        {
                            BoardTestradioButton.Checked = true;
                            BoardTestWorkShop = "True";
                        }
                        else
                        {
                            BoardTestradioButton.Checked = false; BoardTestWorkShop = "False";
                        }
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("ProductTestWorkShop"))
                    {
                        if (sArray[1].Trim() == "True")
                        {
                            ProductTestradioButton.Checked = true;
                            ProductTestWorkShop = "True";
                        }
                        else
                        {
                            BurnWorkShopradioButton.Checked = false; ProductTestWorkShop = "False";
                        }
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("SetVersion")) { VersiontextBox.Text = Version = sArray[1].Trim(); Config[i] = SetContent; }
                    if (sArray[0].Trim().ToString().Equals("SetFlashSize")) { FlashSizetextBox.Text = FlashSize = sArray[1].Trim(); Config[i] = SetContent; }
                    if (sArray[0].Trim().ToString().Equals("SetDdrSize")) { DDRSizetextBox.Text = DdrSize = sArray[1].Trim(); Config[i] = SetContent; }
                    if (sArray[0].Trim().ToString().Equals("WIFINameAndPWD")) { WIFINametextBox.Text = WIFIName = sArray[1].Trim(); Config[i] = SetContent; }
                    if (sArray[0].Trim().ToString().Equals("BTName")) { BTNametextBox.Text = BTName = sArray[1].Trim(); Config[i] = SetContent; }
                    if (sArray[0].Trim().ToString().Equals("WebAddress")) { WebAddresstextBox.Text = WebAddress = sArray[1].Trim(); Config[i] = SetContent; }
                    if (sArray[0].Trim().ToString().Equals("Testaudio")) { TestwavAddtextBox.Text = TestaudioAdd = sArray[1].Trim(); Config[i] = SetContent; }
                    if (sArray[0].Trim().ToString().Equals("recordaudio")) { RecordAddtextBox.Text = RecordaudioAdd = sArray[1].Trim(); Config[i] = SetContent; }
                    if (sArray[0].Trim().ToString().Equals("KeyAnswer")) { KeyAnswertextBox.Text = KeyAnswer = sArray[1].Trim(); Config[i] = SetContent; }
                    if (sArray[0].Trim().ToString().Equals("AudacityAddress")) { AudacityAddresstextBox.Text = AudacityAddress = sArray[1].Trim(); Config[i] = SetContent; }

                    if (sArray[0].Trim().ToString().Equals("LQWebServer"))
                    {
                        if (sArray[1].Trim() == "Checked") { LQWebservercheckBox.CheckState = CheckState.Checked; LQWebServer = "Checked"; }
                        else LQWebServer = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("VersionTest"))
                    {
                        if (sArray[1].Trim() == "Checked") { VersioncheckBox.CheckState = CheckState.Checked; VersionTest = "Checked"; }
                        else VersionTest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("FlashSizeTest"))
                    {
                        if (sArray[1].Trim() == "Checked") { FlashcheckBox.CheckState = CheckState.Checked; FlashSizeTest = "Checked"; }
                        else FlashSizeTest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("DDRSizeTest"))
                    {
                        if (sArray[1].Trim() == "Checked") { DDRcheckBox.CheckState = CheckState.Checked; DDRSizeTest = "Checked"; }
                        else DDRSizeTest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("UARTSizeTest"))
                    {
                        if (sArray[1].Trim() == "Checked") { UARTcheckBox.CheckState = CheckState.Checked; UARTSizeTest = "Checked"; }
                        else UARTSizeTest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("WIFITest"))
                    {
                        if (sArray[1].Trim() == "Checked") { WIFIcheckBox.CheckState = CheckState.Checked; WIFITest = "Checked"; }
                        else WIFITest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("BTTest"))
                    {
                        if (sArray[1].Trim() == "Checked") { BTcheckBox.CheckState = CheckState.Checked; BTTest = "Checked"; }
                        else BTTest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("KeyTest"))
                    {
                        if (sArray[1].Trim() == "Checked") { KeycheckBox.CheckState = CheckState.Checked; KeyTest = "Checked"; }
                        else KeyTest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("LedTest"))
                    {
                        if (sArray[1].Trim() == "Checked") { LEDcheckBox.CheckState = CheckState.Checked; LedTest = "Checked"; }
                        else LedTest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("AMPTest"))
                    {
                        if (sArray[1].Trim() == "Checked") { AMPcheckBox.CheckState = CheckState.Checked; AMPTest = "Checked"; }
                        else AMPTest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("MICTest"))
                    {
                        if (sArray[1].Trim() == "Checked") { MICcheckBox.CheckState = CheckState.Checked; MICTest = "Checked"; }
                        else MICTest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("SEEDBurn"))
                    {
                        if (sArray[1].Trim() == "Checked") { SeedBurncheckBox.CheckState = CheckState.Checked; SEEDBurn = "Checked"; }
                        else SEEDBurn = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("SNBurn"))
                    {
                        if (sArray[1].Trim() == "Checked") { SNBurncheckBox.CheckState = CheckState.Checked; SNBurn = "Checked"; }
                        else SNBurn = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("TypeIDBurn"))
                    {
                        if (sArray[1].Trim() == "Checked") { TypeIDBurncheckbox.CheckState = CheckState.Checked; TypeIDBurn = "Checked"; }
                        else TypeIDBurn = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("AutoTest"))
                    {
                        if (sArray[1].Trim() == "Checked") { AutoTestcheckBox.CheckState = CheckState.Checked; AutoTest = "Checked"; }
                        else AutoTest = "Unchecked";
                        Config[i] = SetContent;
                    }
                    if (sArray[0].Trim().ToString().Equals("AutoBurn"))
                    {
                        if (sArray[1].Trim() == "Checked") { AutoBurncheckBox.CheckState = CheckState.Checked; AutoBurn = "Checked"; }
                        else AutoBurn = "Unchecked";
                        Config[i] = SetContent;
                    }
                    i++;
                }
                SetFile2.Dispose();
                SetFile2.Close();
                Setread2.Dispose();
                Setread2.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("OpenFile2 Error!");
                MessageBox.Show(ex.Message);
            }
            
            try
            {
                string Configstr;
                FileStream SetFile3 = new FileStream(address, FileMode.Open);
                TextReader Setread3 = new StreamReader(SetFile3);
                Configstr = Setread3.ReadToEnd();
                Setread3.Dispose();
                Setread3.Close();
                SetFile3.Dispose();
                SetFile3.Close();

                //添加缺少项

                FileStream SetFile4 = new FileStream(address, FileMode.Append);
                StreamWriter streamWriter4 = new StreamWriter(SetFile4);
                if (!Configstr.Contains("BurnWorkShop"))
                { Config[++i] = "BurnWorkShop = "; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("BoardTestWorkShop"))
                { Config[++i] = "BoardTestWorkShop = "; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("ProductTestWorkShop"))
                { Config[++i] = "ProductTestWorkShop = "; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("SetVersion"))
                { Config[++i] = "SetVersion = "; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("SetFlashSize"))
                { Config[++i] = "SetFlashSize = "; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("SetDdrSize"))
                { Config[++i] = "SetDdrSize ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("WIFINameAndPWD"))
                { Config[++i] = "WIFINameAndPWD ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("BTName"))
                { Config[++i] = "BTName ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("WebAddress"))
                { Config[++i] = "WebAddress ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("Testaudio"))
                { Config[++i] = "Testaudio ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("recordaudio"))
                { Config[++i] = "recordaudio ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("KeyAnswer"))
                { Config[++i] = "KeyAnswer ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("AudacityAddress"))
                { Config[++i] = "AudacityAddress ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("LQWebServer"))
                { Config[++i] = "LQWebServer ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("VersionTest"))
                { Config[++i] = "VersionTest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("FlashSizeTest"))
                { Config[++i] = "FlashSizeTest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("DDRSizeTest"))
                { Config[++i] = "DDRSizeTest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("UARTSizeTest"))
                { Config[++i] = "UARTSizeTest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("WIFITest"))
                { Config[++i] = "WIFITest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("BTTest"))
                { Config[++i] = "BTTest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("KeyTest"))
                { Config[++i] = "KeyTest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("LedTest"))
                { Config[++i] = "LedTest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("AMPTest"))
                { Config[++i] = "AMPTest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("MICTest"))
                { Config[++i] = "MICTest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("SEEDBurn"))
                { Config[++i] = "SEEDBurn ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("SNBurn"))
                { Config[++i] = "SNBurn ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("TypeIDBurn"))
                { Config[++i] = "TypeIDBurn ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("AutoTest"))
                { Config[++i] = "AutoTest ="; streamWriter4.WriteLine(Config[i]); }
                if (!Configstr.Contains("AutoBurn"))
                { Config[++i] = "AutoBurn ="; streamWriter4.WriteLine(Config[i]); }
                streamWriter4.Dispose();
                streamWriter4.Close();
                SetFile4.Dispose();
                SetFile4.Close();
                i = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("OpenFile3/4 Error!");
                MessageBox.Show(ex.Message);

            }
            
            
        }
    

        private void Quitbutton_Click(object sender, EventArgs e)
        {
                this.Dispose();
            //if (TestItem.SetBurnWorkShop == "True")
            //{
            //    WorkshopShowtextBox.Text = "烧录工位";
            //}
            //if (TestItem.SetBoardTestWorkShop == "True")
            //{
            //    WorkshopShowtextBox.Text = "板卡功能测试工位";
            //}
            //if (TestItem.SetProductTestWorkShop == "True")
            //{
            //    WorkshopShowtextBox.Text = "整机功能测试工位";
            //}
        }

        private void TestItemForm_Load(object sender, EventArgs e)
        {
            if (BurnWorkShop == "True")
            { BurnWorkShopradioButton.Checked = true; }
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            i = 1;
            try
            {
                FileStream SetFile5 = new FileStream(address, FileMode.Open);
                TextWriter Setwrite5 = new StreamWriter(SetFile5);
                SetFile5.SetLength(0);
                for (i = 1; i < Config.Length; i++)
                {
                    if (Config[i] != null)
                    {
                        //MessageBox.Show(i.ToString());
                        //MessageBox.Show(cmd[i]);
                        //MessageBox.Show(Config[i]);
                        if (Config[i].Contains("BurnWorkShop"))
                        { /*MessageBox.Show(BurnWorkShopradioButton.Checked.ToString()); */BurnWorkShop = BurnWorkShopradioButton.Checked.ToString(); Config[i] = "BurnWorkShop = " + BurnWorkShop; }
                        if (Config[i].Contains("BoardTestWorkShop"))
                        { BoardTestWorkShop = BoardTestradioButton.Checked.ToString(); Config[i] = "BoardTestWorkShop = " + BoardTestWorkShop; }
                        if (Config[i].Contains("ProductTestWorkShop"))
                        { ProductTestWorkShop = ProductTestradioButton.Checked.ToString(); Config[i] = "ProductTestWorkShop = " + ProductTestWorkShop; }
                        if (Config[i].Contains("SetVersion"))
                        { Version = VersiontextBox.Text; Config[i] = "SetVersion = " + VersiontextBox.Text; }
                        if (Config[i].Contains("SetFlashSize")) { FlashSize = FlashSizetextBox.Text; Config[i] = "SetFlashSize = " + FlashSizetextBox.Text; }
                        if (Config[i].Contains("SetDdrSize")) { DdrSize = DDRSizetextBox.Text; Config[i] = "SetDdrSize = " + DDRSizetextBox.Text; }
                        if (Config[i].Contains("WIFINameAndPWD")) { WIFIName = WIFINametextBox.Text; Config[i] = "WIFINameAndPWD = " + WIFINametextBox.Text; }
                        if (Config[i].Contains("BTName")) { BTName = BTNametextBox.Text; Config[i] = "BTName = " + BTNametextBox.Text; }
                        if (Config[i].Contains("WebAddress")) { WebAddress = WebAddresstextBox.Text; Config[i] = "WebAddress = " + WebAddresstextBox.Text; }
                        if (Config[i].Contains("Testaudio")) { TestaudioAdd = TestwavAddtextBox.Text; Config[i] = "Testaudio = " + TestwavAddtextBox.Text; }
                        if (Config[i].Contains("recordaudio")) { RecordaudioAdd = RecordAddtextBox.Text; Config[i] = "recordaudio = " + RecordAddtextBox.Text; }
                        if (Config[i].Contains("KeyAnswer")) { KeyAnswer = KeyAnswertextBox.Text; Config[i] = "KeyAnswer = " + KeyAnswertextBox.Text; }
                        if (Config[i].Contains("AudacityAddress")) { AudacityAddress = AudacityAddresstextBox.Text; Config[i] = "AudacityAddress = " + AudacityAddresstextBox.Text; }
                        if (Config[i].Contains("LQWebServer")) { LQWebServer = LQWebservercheckBox.CheckState.ToString(); Config[i] = "LQWebServer = " + LQWebservercheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("VersionTest")) { VersionTest = VersioncheckBox.CheckState.ToString(); Config[i] = "VersionTest = " + VersioncheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("FlashSizeTest")) { FlashSizeTest = FlashcheckBox.CheckState.ToString(); Config[i] = "FlashSizeTest = " + FlashcheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("DDRSizeTest")) { DDRSizeTest = DDRcheckBox.CheckState.ToString(); Config[i] = "DDRSizeTest = " + DDRcheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("UARTSizeTest")) { UARTSizeTest = UARTcheckBox.CheckState.ToString(); Config[i] = "UARTSizeTest = " + UARTcheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("WIFITest")) { WIFITest = WIFIcheckBox.CheckState.ToString(); Config[i] = "WIFITest = " + WIFIcheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("BTTest")) { BTTest = BTcheckBox.CheckState.ToString(); Config[i] = "BTTest = " + BTcheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("KeyTest")) { KeyTest = KeycheckBox.CheckState.ToString(); Config[i] = "KeyTest = " + KeycheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("LedTest")) { LedTest = LEDcheckBox.CheckState.ToString(); Config[i] = "LedTest = " + LEDcheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("AMPTest")) { AMPTest = AMPcheckBox.CheckState.ToString(); Config[i] = "AMPTest = " + AMPcheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("MICTest")) { MICTest = MICcheckBox.CheckState.ToString(); Config[i] = "MICTest = " + MICcheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("SEEDBurn")) { SEEDBurn = SeedBurncheckBox.CheckState.ToString(); Config[i] = "SEEDBurn = " + SeedBurncheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("SNBurn")) { SNBurn = SNBurncheckBox.CheckState.ToString(); Config[i] = "SNBurn = " + SNBurncheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("TypeIDBurn")) { TypeIDBurn = TypeIDBurncheckbox.CheckState.ToString(); Config[i] = "TypeIDBurn = " + TypeIDBurncheckbox.CheckState.ToString(); }
                        if (Config[i].Contains("AutoTest")) { AutoTest = AutoTestcheckBox.CheckState.ToString(); Config[i] = "AutoTest = " + AutoTestcheckBox.CheckState.ToString(); }
                        if (Config[i].Contains("AutoBurn")) { AutoBurn = AutoBurncheckBox.CheckState.ToString(); Config[i] = "AutoBurn = " + AutoBurncheckBox.CheckState.ToString(); }
                        Setwrite5.WriteLine(Config[i]);
                    }
                }
                //Setwrite5.Dispose();
                Setwrite5.Close();
                //SetFile5.Dispose();
                SetFile5.Close();
                i = 1;
            }catch(Exception ex)
            {
                MessageBox.Show("OpenFile5 Error!");
                MessageBox.Show(ex.Message);
            }

        }

        private void WebAddresstextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTcheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TypeIDBurncheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
