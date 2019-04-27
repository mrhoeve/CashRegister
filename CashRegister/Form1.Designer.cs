namespace CashRegister
{
    partial class Form1
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
            this.ucNumericKeypad1 = new CashRegister.Forms.Usercontrols.ucNumericKeypad();
            this.SuspendLayout();
            // 
            // ucNumericKeypad1
            // 
            this.ucNumericKeypad1.BackColor = System.Drawing.SystemColors.Control;
            this.ucNumericKeypad1.Location = new System.Drawing.Point(12, 12);
            this.ucNumericKeypad1.Name = "ucNumericKeypad1";
            this.ucNumericKeypad1.Size = new System.Drawing.Size(256, 274);
            this.ucNumericKeypad1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 296);
            this.Controls.Add(this.ucNumericKeypad1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private Forms.Usercontrols.ucNumericKeypad ucNumericKeypad1;
    }
}

