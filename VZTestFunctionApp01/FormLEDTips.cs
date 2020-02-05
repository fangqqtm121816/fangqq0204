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
    public partial class FormLEDTips : Form
    {
        public int LEDResult;
        public FormLEDTips()
        {
            InitializeComponent();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            LEDResult = 1;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LEDResult = 0;
            Close();
        }
    }
}
