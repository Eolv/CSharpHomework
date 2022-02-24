using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = numericUpDown1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int number) == true)
                if (number >= -100 && number <= 100) numericUpDown1.Value = number;
                else MessageBox.Show("Введите число от -100 до 100");            
            else
                if (textBox1.Text != "-" && textBox1.Text != "")
                MessageBox.Show("Введите число, а не текст");            
        }
    }
}
