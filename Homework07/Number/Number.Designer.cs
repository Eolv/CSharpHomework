namespace Number
{
    partial class Number
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
            this.lbInformer = new System.Windows.Forms.Label();
            this.lbTries = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbInformer
            // 
            this.lbInformer.AutoSize = true;
            this.lbInformer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInformer.Location = new System.Drawing.Point(22, 31);
            this.lbInformer.Name = "lbInformer";
            this.lbInformer.Size = new System.Drawing.Size(641, 40);
            this.lbInformer.TabIndex = 0;
            this.lbInformer.Text = "Попробуйте угадать число от 0 до 99";
            // 
            // lbTries
            // 
            this.lbTries.AutoSize = true;
            this.lbTries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTries.ForeColor = System.Drawing.Color.Red;
            this.lbTries.Location = new System.Drawing.Point(24, 96);
            this.lbTries.Name = "lbTries";
            this.lbTries.Size = new System.Drawing.Size(216, 29);
            this.lbTries.TabIndex = 1;
            this.lbTries.Text = "Число попыток: 0";
            // 
            // Number
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 194);
            this.Controls.Add(this.lbTries);
            this.Controls.Add(this.lbInformer);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 250);
            this.Name = "Number";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Угадай число";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInformer;
        private System.Windows.Forms.Label lbTries;
    }
}

