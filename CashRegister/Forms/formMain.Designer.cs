namespace CashRegister.Forms
{
    partial class formMain
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.mainRightLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ucNumericKeypad1 = new CashRegister.Forms.Usercontrols.ucNumericKeypad();
            this.mainLayout.SuspendLayout();
            this.mainRightLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.AutoSize = true;
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 262F));
            this.mainLayout.Controls.Add(this.mainRightLayout, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.Size = new System.Drawing.Size(800, 450);
            this.mainLayout.TabIndex = 0;
            // 
            // mainRightLayout
            // 
            this.mainRightLayout.ColumnCount = 1;
            this.mainRightLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainRightLayout.Controls.Add(this.ucNumericKeypad1, 0, 1);
            this.mainRightLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainRightLayout.Location = new System.Drawing.Point(538, 0);
            this.mainRightLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainRightLayout.Name = "mainRightLayout";
            this.mainRightLayout.RowCount = 3;
            this.mainRightLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainRightLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.mainRightLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainRightLayout.Size = new System.Drawing.Size(262, 450);
            this.mainRightLayout.TabIndex = 0;
            // 
            // ucNumericKeypad1
            // 
            this.ucNumericKeypad1.BackColor = System.Drawing.SystemColors.Control;
            this.ucNumericKeypad1.Location = new System.Drawing.Point(3, 23);
            this.ucNumericKeypad1.Name = "ucNumericKeypad1";
            this.ucNumericKeypad1.Size = new System.Drawing.Size(256, 274);
            this.ucNumericKeypad1.TabIndex = 0;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainLayout);
            this.Name = "formMain";
            this.Text = "formMain";
            this.mainLayout.ResumeLayout(false);
            this.mainRightLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel mainRightLayout;
        private Usercontrols.ucNumericKeypad ucNumericKeypad1;
    }
}