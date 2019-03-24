namespace CashRegister.License
{
    partial class ucLicenseForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutSelected = new System.Windows.Forms.TableLayoutPanel();
            this.textLicense = new System.Windows.Forms.TextBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.llblSource = new System.Windows.Forms.LinkLabel();
            this.layoutPanelMain.SuspendLayout();
            this.tableLayoutSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutPanelMain
            // 
            this.layoutPanelMain.ColumnCount = 2;
            this.layoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.layoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanelMain.Controls.Add(this.label1, 1, 0);
            this.layoutPanelMain.Controls.Add(this.label2, 0, 0);
            this.layoutPanelMain.Controls.Add(this.tableLayoutSelected, 1, 1);
            this.layoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.layoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanelMain.MinimumSize = new System.Drawing.Size(400, 300);
            this.layoutPanelMain.Name = "layoutPanelMain";
            this.layoutPanelMain.RowCount = 2;
            this.layoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelMain.Size = new System.Drawing.Size(400, 300);
            this.layoutPanelMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gegevens geselecteerd project:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gebruikte Open Source Software:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutSelected
            // 
            this.tableLayoutSelected.ColumnCount = 1;
            this.tableLayoutSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSelected.Controls.Add(this.textLicense, 0, 2);
            this.tableLayoutSelected.Controls.Add(this.lblSource, 0, 0);
            this.tableLayoutSelected.Controls.Add(this.llblSource, 0, 1);
            this.tableLayoutSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSelected.Location = new System.Drawing.Point(200, 25);
            this.tableLayoutSelected.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutSelected.Name = "tableLayoutSelected";
            this.tableLayoutSelected.RowCount = 3;
            this.tableLayoutSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutSelected.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSelected.Size = new System.Drawing.Size(200, 275);
            this.tableLayoutSelected.TabIndex = 3;
            // 
            // textLicense
            // 
            this.textLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLicense.Location = new System.Drawing.Point(0, 50);
            this.textLicense.Margin = new System.Windows.Forms.Padding(0);
            this.textLicense.Multiline = true;
            this.textLicense.Name = "textLicense";
            this.textLicense.ReadOnly = true;
            this.textLicense.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textLicense.Size = new System.Drawing.Size(200, 225);
            this.textLicense.TabIndex = 0;
            this.textLicense.Visible = false;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSource.Location = new System.Drawing.Point(3, 0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(194, 25);
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "Source:";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSource.Visible = false;
            // 
            // llblSource
            // 
            this.llblSource.AutoSize = true;
            this.llblSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llblSource.Location = new System.Drawing.Point(3, 25);
            this.llblSource.Name = "llblSource";
            this.llblSource.Size = new System.Drawing.Size(194, 25);
            this.llblSource.TabIndex = 2;
            this.llblSource.TabStop = true;
            this.llblSource.Text = "linkLabel1";
            this.llblSource.Visible = false;
            // 
            // ucLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutPanelMain);
            this.Name = "ucLicenseForm";
            this.Size = new System.Drawing.Size(400, 300);
            this.layoutPanelMain.ResumeLayout(false);
            this.layoutPanelMain.PerformLayout();
            this.tableLayoutSelected.ResumeLayout(false);
            this.tableLayoutSelected.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutPanelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSelected;
        private System.Windows.Forms.TextBox textLicense;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.LinkLabel llblSource;
    }
}
