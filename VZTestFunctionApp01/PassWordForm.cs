using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VZTestFunctionApp01
{
    public partial class PassWordForm : Form
    {
        public PassWordForm()
        {
            InitializeComponent();
        }

        private void PassWordbutton_Click(object sender, EventArgs e)
        {
            if (PassWordtextBox.Text == "123456")
            {
                SettingCommand settingCommand = new SettingCommand();
                this.Dispose();
                settingCommand.Focus();
                settingCommand.WindowState = FormWindowState.Normal;
                settingCommand.ShowDialog();
            }
            else
            {
                MessageBox.Show("密码错误");
                this.Dispose();
            }
        }

        private void PassWordtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PassWordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
