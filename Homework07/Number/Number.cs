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
    public partial class Number : Form
    {
        InputForm InputForm;
        int Turns;
        Random random = new Random();
        public int GuessedNumber { get; set; }

        public Number()
        {
            InitializeComponent();            
            GuessedNumber = random.Next(0, 100);            
            lbInformer.Text = "Попробуйте угадать число от 0 до 99";
            InputForm = new InputForm();
            InputForm.Show();
            InputForm.parentForm = this;
            Turns = 0;
        }

        public void Result(int userInput)
        {
            if (userInput == GuessedNumber)
            {             
                lbTries.Text = $"Число попыток: {++Turns}";
                lbInformer.Text = $"Вы угадали за {Turns} попыток";

                if (MessageBox.Show($"Вы угадали число за {Turns} попыток. Желаете сыграть еще раз?", "Угадай число",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lbTries.Text = $"Число попыток: 0";
                    lbInformer.Text = "Попробуйте угадать число от 0 до 99";
                    GuessedNumber = random.Next(0, 100);
                    Turns = 0;                    
                }
                else
                {
                    Close();
                }

            }
            else if (userInput < GuessedNumber)
            {                
                lbTries.Text = $"Число попыток: {++Turns}";
                lbInformer.Text = $"Загаданное число больше";
            }
            else
            {
                lbTries.Text = $"Число попыток: {++Turns}";
                lbInformer.Text = $"Загаданное число меньше";
            }
             
        }
    }
}
