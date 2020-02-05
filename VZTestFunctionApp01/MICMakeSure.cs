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
    public partial class MICMakeSure : Form
    {
        int nMICResult = 0;
        public int MICResult
        {
            get { return nMICResult; }
        }
        public MICMakeSure()
        {
            InitializeComponent();
        }

        private void MICOKbutton_Click(object sender, EventArgs e)
        {
            nMICResult = 1;
            this.Close();
        }

        private void MICNCbutton_Click(object sender, EventArgs e)
        {
            nMICResult = 0;
            this.Close();
        }
    }
}
