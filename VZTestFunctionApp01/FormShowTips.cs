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
    public partial class FormShowTips : Form
    {
        public string ShowItemState;
        public FormShowTips()
        {
            InitializeComponent();
            
        }

        private void FormShowTips_Load(object sender, EventArgs e)
        {
            ShowTipstextBox.Text = ShowItemState;
        }

        private void FormShowTips_Activated(object sender, EventArgs e)
        {
            //ShowTipstextBox.Text = ShowItemState;
        }

        private void FormShowTips_VisibleChanged(object sender, EventArgs e)
        {
            ShowTipstextBox.Text = ShowItemState;
        }
    }
}
