
namespace CashRegister.Forms.Usercontrols
{
    partial class ucStatusbar
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
            this.tlStatusbar = new System.Windows.Forms.TableLayoutPanel();
            this.tlStatusbarVersion = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatusbarVersie = new System.Windows.Forms.Label();
            this.lblStatusbarBranchename = new System.Windows.Forms.Label();
            this.tlStatusbar.SuspendLayout();
            this.tlStatusbarVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlStatusbar
            // 
            this.tlStatusbar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlStatusbar.ColumnCount = 3;
            this.tlStatusbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlStatusbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlStatusbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlStatusbar.Controls.Add(this.tlStatusbarVersion, 0, 0);
            this.tlStatusbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlStatusbar.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlStatusbar.Location = new System.Drawing.Point(0, 0);
            this.tlStatusbar.Margin = new System.Windows.Forms.Padding(0);
            this.tlStatusbar.Name = "tlStatusbar";
            this.tlStatusbar.RowCount = 1;
            this.tlStatusbar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlStatusbar.Size = new System.Drawing.Size(756, 60);
            this.tlStatusbar.TabIndex = 0;
            // 
            // tlStatusbarVersion
            // 
            this.tlStatusbarVersion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlStatusbarVersion.ColumnCount = 1;
            this.tlStatusbarVersion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlStatusbarVersion.Controls.Add(this.lblTitle, 0, 0);
            this.tlStatusbarVersion.Controls.Add(this.lblStatusbarVersie, 0, 1);
            this.tlStatusbarVersion.Controls.Add(this.lblStatusbarBranchename, 0, 2);
            this.tlStatusbarVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlStatusbarVersion.Location = new System.Drawing.Point(0, 0);
            this.tlStatusbarVersion.Margin = new System.Windows.Forms.Padding(0);
            this.tlStatusbarVersion.Name = "tlStatusbarVersion";
            this.tlStatusbarVersion.RowCount = 4;
            this.tlStatusbarVersion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlStatusbarVersion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tlStatusbarVersion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tlStatusbarVersion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlStatusbarVersion.Size = new System.Drawing.Size(368, 100);
            this.tlStatusbarVersion.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(368, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CashRegister";
            // 
            // lblStatusbarVersie
            // 
            this.lblStatusbarVersie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusbarVersie.Location = new System.Drawing.Point(0, 24);
            this.lblStatusbarVersie.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatusbarVersie.Name = "lblStatusbarVersie";
            this.lblStatusbarVersie.Size = new System.Drawing.Size(368, 17);
            this.lblStatusbarVersie.TabIndex = 1;
            this.lblStatusbarVersie.Text = "Versie 0.0";
            // 
            // lblStatusbarBranchename
            // 
            this.lblStatusbarBranchename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusbarBranchename.Location = new System.Drawing.Point(0, 41);
            this.lblStatusbarBranchename.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatusbarBranchename.Name = "lblStatusbarBranchename";
            this.lblStatusbarBranchename.Size = new System.Drawing.Size(368, 17);
            this.lblStatusbarBranchename.TabIndex = 2;
            this.lblStatusbarBranchename.Text = "label1";
            // 
            // ucStatusbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlStatusbar);
            this.Name = "ucStatusbar";
            this.Size = new System.Drawing.Size(756, 60);
            this.tlStatusbar.ResumeLayout(false);
            this.tlStatusbarVersion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlStatusbar;
        private System.Windows.Forms.TableLayoutPanel tlStatusbarVersion;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatusbarVersie;
        private System.Windows.Forms.Label lblStatusbarBranchename;
    }
}
