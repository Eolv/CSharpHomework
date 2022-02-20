using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doubler
{
    public partial class Main : Form
    {        
        private Random random = new Random();
        private int computerNumber;
        private int userNumber;
        private int turnsPassed;
        private int maxTurn;
        Stack<int> TurnSave = new Stack<int>();

        private void ResetGame()
        {
            TurnSave.Clear();
            userNumber = 0;
            turnsPassed = 0;
            int target = random.Next(49) + 1;
            maxTurn = GetMaxTurns(target);
            DoSave();
            UpdateGameState(userNumber, turnsPassed, maxTurn, target);
        }

        public Main()
        {
            InitializeComponent();
            ResetGame();            
        }

        private int GetMaxTurns(int x)
        {
            maxTurn = 0;
            while (x > 0)
            {
                if (x % 2 == 0)
                {
                    x /= 2;
                    maxTurn++;
                }
                else
                {
                    x--;
                    maxTurn++;
                }
            }
            return maxTurn;
        }
        
        private void DoSave()
        {
            TurnSave.Push(userNumber);
        }

        private void UpdateGameState(int userNumber, int turnsPassed)
        {
            lbUserNumber.Text = $"Текущее число: {userNumber}";
            lbTurns.Text = $"Число ходов: {turnsPassed}";
            lbTurnsRemaining.Text = $"Осталось ходов: {maxTurn - turnsPassed}";
            lbLastTurn.Text = $"Предыдущее число: {TurnSave.Peek()}";
        }

        private void UpdateGameState(int userNumber, int turnsPassed, int maxTurn, int computerNumber)
        {
            UpdateGameState(userNumber, turnsPassed);
            this.computerNumber = computerNumber;            
            lbComputerNumber.Text = $"Получите число: {computerNumber}";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            DoSave();
            UpdateGameState(++userNumber, ++turnsPassed);
            CheckWin();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            DoSave();
            UpdateGameState(userNumber *= 2, ++turnsPassed);
            CheckWin();
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (turnsPassed > 0)
            {
                userNumber = TurnSave.Peek();
                TurnSave.Pop();
                turnsPassed--;
                UpdateGameState(userNumber, turnsPassed);
            }
        }

        private void CheckWin()
        {
            if (computerNumber == userNumber)
            {
                MessageBox.Show("Вы успешно завершили игру", "Удвоитель",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Желаете сыграть еще раз?", "Удвоитель",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ResetGame();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                if (maxTurn - turnsPassed <= 0)
                {
                if (MessageBox.Show("Вы не справились за минимальное количество ходов. Сыграем снова?", "Удвоитель",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ResetGame();
                    }
                else
                    {
                        Close();
                    }
                }
            }
        }
    }
}
