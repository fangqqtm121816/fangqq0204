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
    public partial class AMPMakeSure : Form
    {
        public AMPMakeSure()
        {
            InitializeComponent();
        }
        int nAMPMakeSure = 0;
        public int AMPResult
        {
            get { return nAMPMakeSure; }
        }

        private void AMPOKbutton_Click(object sender, EventArgs e)
        {
            nAMPMakeSure = 1;
            this.Close();
            
        }

        private void AMPNCbutton_Click(object sender, EventArgs e)
        {
            nAMPMakeSure = 0;
            this.Close();
        }
    }
}
