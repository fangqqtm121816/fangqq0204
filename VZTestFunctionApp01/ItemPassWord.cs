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
    public partial class ItemPassWord : Form
    {
        public ItemPassWord()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "111111")
            {

                TestItemForm testItemForm = new TestItemForm();
                this.Dispose();
                testItemForm.Focus();
                testItemForm.WindowState = FormWindowState.Normal;
                testItemForm.ShowDialog();             
            }
            else
            {
                MessageBox.Show("密码错误");
                this.Dispose();
            }
            
        }

        private void ItemPassWord_Load(object sender, EventArgs e)
        {

        }
    }
}
