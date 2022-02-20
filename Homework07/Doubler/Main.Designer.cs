namespace Doubler
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.lbComputerNumber = new System.Windows.Forms.Label();
            this.lbUserNumber = new System.Windows.Forms.Label();
            this.lbTurns = new System.Windows.Forms.Label();
            this.lbTurnsRemaining = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.lbLastTurn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.Location = new System.Drawing.Point(272, 41);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(310, 60);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Новая игра";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlus.Location = new System.Drawing.Point(526, 131);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(160, 60);
            this.btnPlus.TabIndex = 1;
            this.btnPlus.Text = "+1";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMultiply.Location = new System.Drawing.Point(526, 201);
            this.btnMultiply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(160, 60);
            this.btnMultiply.TabIndex = 2;
            this.btnMultiply.Text = "x2";
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new System.EventHandler(this.btnMultiply_Click);
            // 
            // lbComputerNumber
            // 
            this.lbComputerNumber.AutoSize = true;
            this.lbComputerNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbComputerNumber.Location = new System.Drawing.Point(146, 162);
            this.lbComputerNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbComputerNumber.Name = "lbComputerNumber";
            this.lbComputerNumber.Size = new System.Drawing.Size(222, 29);
            this.lbComputerNumber.TabIndex = 3;
            this.lbComputerNumber.Text = "Получите число:";
            // 
            // lbUserNumber
            // 
            this.lbUserNumber.AutoSize = true;
            this.lbUserNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUserNumber.Location = new System.Drawing.Point(158, 201);
            this.lbUserNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUserNumber.Name = "lbUserNumber";
            this.lbUserNumber.Size = new System.Drawing.Size(210, 29);
            this.lbUserNumber.TabIndex = 4;
            this.lbUserNumber.Text = "Текущее число:";
            // 
            // lbTurns
            // 
            this.lbTurns.AutoSize = true;
            this.lbTurns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTurns.Location = new System.Drawing.Point(192, 289);
            this.lbTurns.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTurns.Name = "lbTurns";
            this.lbTurns.Size = new System.Drawing.Size(176, 29);
            this.lbTurns.TabIndex = 5;
            this.lbTurns.Text = "Число ходов:";
            // 
            // lbTurnsRemaining
            // 
            this.lbTurnsRemaining.AutoSize = true;
            this.lbTurnsRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTurnsRemaining.Location = new System.Drawing.Point(152, 334);
            this.lbTurnsRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTurnsRemaining.Name = "lbTurnsRemaining";
            this.lbTurnsRemaining.Size = new System.Drawing.Size(216, 29);
            this.lbTurnsRemaining.TabIndex = 6;
            this.lbTurnsRemaining.Text = "Осталось ходов:";
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.Orange;
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUndo.Location = new System.Drawing.Point(496, 384);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(225, 42);
            this.btnUndo.TabIndex = 7;
            this.btnUndo.Text = "Отменить ход";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lbLastTurn
            // 
            this.lbLastTurn.AutoSize = true;
            this.lbLastTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLastTurn.Location = new System.Drawing.Point(107, 388);
            this.lbLastTurn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLastTurn.Name = "lbLastTurn";
            this.lbLastTurn.Size = new System.Drawing.Size(261, 29);
            this.lbLastTurn.TabIndex = 8;
            this.lbLastTurn.Text = "Предыдущее число:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(778, 444);
            this.Controls.Add(this.lbLastTurn);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.lbTurnsRemaining);
            this.Controls.Add(this.lbTurns);
            this.Controls.Add(this.lbUserNumber);
            this.Controls.Add(this.lbComputerNumber);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnReset);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удвоитель";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Label lbComputerNumber;
        private System.Windows.Forms.Label lbUserNumber;
        private System.Windows.Forms.Label lbTurns;
        private System.Windows.Forms.Label lbTurnsRemaining;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lbLastTurn;
    }
}

