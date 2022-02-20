namespace Number
{
    partial class InputForm
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
            this.tbInputNumber = new System.Windows.Forms.TextBox();
            this.lbComment = new System.Windows.Forms.Label();
            this.btnConfirmInput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbInputNumber
            // 
            this.tbInputNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInputNumber.Location = new System.Drawing.Point(13, 14);
            this.tbInputNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInputNumber.Name = "tbInputNumber";
            this.tbInputNumber.Size = new System.Drawing.Size(219, 39);
            this.tbInputNumber.TabIndex = 1;
            // 
            // lbComment
            // 
            this.lbComment.AutoSize = true;
            this.lbComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbComment.Location = new System.Drawing.Point(78, 62);
            this.lbComment.Name = "lbComment";
            this.lbComment.Size = new System.Drawing.Size(187, 29);
            this.lbComment.TabIndex = 2;
            this.lbComment.Text = "Введите число";
            // 
            // btnConfirmInput
            // 
            this.btnConfirmInput.Location = new System.Drawing.Point(239, 12);
            this.btnConfirmInput.Name = "btnConfirmInput";
            this.btnConfirmInput.Size = new System.Drawing.Size(82, 47);
            this.btnConfirmInput.TabIndex = 3;
            this.btnConfirmInput.Text = "Ввод";
            this.btnConfirmInput.UseVisualStyleBackColor = true;
            this.btnConfirmInput.Click += new System.EventHandler(this.btnConfirmInput_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(332, 99);
            this.Controls.Add(this.btnConfirmInput);
            this.Controls.Add(this.lbComment);
            this.Controls.Add(this.tbInputNumber);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(354, 155);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(354, 155);
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Угадай число";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInputNumber;
        private System.Windows.Forms.Label lbComment;
        private System.Windows.Forms.Button btnConfirmInput;
    }
}