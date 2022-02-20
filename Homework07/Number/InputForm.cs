using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number
{
    public partial class InputForm : Form
    {
        public Number parentForm;

        public InputForm()
        {
            InitializeComponent();            
        }

        private void btnConfirmInput_Click(object sender, EventArgs e)
        {
             parentForm.Result(int.Parse(tbInputNumber.Text));
        }
    }
}
