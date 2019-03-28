namespace CashRegister.Forms
{
    partial class formUsesOSS
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
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutHeader = new System.Windows.Forms.TableLayoutPanel();
            this.pictureLogoOSS = new System.Windows.Forms.PictureBox();
            this.tableLayoutHeaderTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeaderTitleCaption = new System.Windows.Forms.Label();
            this.lblHeaderTitleSub = new System.Windows.Forms.Label();
            this.tableLayoutClose = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogoOSS)).BeginInit();
            this.tableLayoutHeaderTitle.SuspendLayout();
            this.tableLayoutClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutMain.Controls.Add(this.tableLayoutHeader, 0, 0);
            this.tableLayoutMain.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutMain.Location = new System.Drawing.Point(9, 12);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 3;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMain.Size = new System.Drawing.Size(616, 453);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // tableLayoutHeader
            // 
            this.tableLayoutHeader.ColumnCount = 2;
            this.tableLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutHeader.Controls.Add(this.pictureLogoOSS, 0, 0);
            this.tableLayoutHeader.Controls.Add(this.tableLayoutHeaderTitle, 1, 0);
            this.tableLayoutHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutHeader.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutHeader.Name = "tableLayoutHeader";
            this.tableLayoutHeader.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutHeader.RowCount = 1;
            this.tableLayoutHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutHeader.Size = new System.Drawing.Size(616, 100);
            this.tableLayoutHeader.TabIndex = 0;
            // 
            // pictureLogoOSS
            // 
            this.pictureLogoOSS.BackColor = System.Drawing.Color.White;
            this.pictureLogoOSS.BackgroundImage = global::CashRegister.Properties.Resources.opensource;
            this.pictureLogoOSS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureLogoOSS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureLogoOSS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureLogoOSS.Location = new System.Drawing.Point(3, 0);
            this.pictureLogoOSS.Margin = new System.Windows.Forms.Padding(0);
            this.pictureLogoOSS.Name = "pictureLogoOSS";
            this.pictureLogoOSS.Size = new System.Drawing.Size(100, 100);
            this.pictureLogoOSS.TabIndex = 0;
            this.pictureLogoOSS.TabStop = false;
            // 
            // tableLayoutHeaderTitle
            // 
            this.tableLayoutHeaderTitle.ColumnCount = 1;
            this.tableLayoutHeaderTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutHeaderTitle.Controls.Add(this.lblHeaderTitleCaption, 0, 0);
            this.tableLayoutHeaderTitle.Controls.Add(this.lblHeaderTitleSub, 0, 1);
            this.tableLayoutHeaderTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutHeaderTitle.Location = new System.Drawing.Point(103, 0);
            this.tableLayoutHeaderTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutHeaderTitle.Name = "tableLayoutHeaderTitle";
            this.tableLayoutHeaderTitle.RowCount = 2;
            this.tableLayoutHeaderTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutHeaderTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutHeaderTitle.Size = new System.Drawing.Size(510, 100);
            this.tableLayoutHeaderTitle.TabIndex = 1;
            // 
            // lblHeaderTitleCaption
            // 
            this.lblHeaderTitleCaption.AutoSize = true;
            this.lblHeaderTitleCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitleCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitleCaption.Location = new System.Drawing.Point(3, 0);
            this.lblHeaderTitleCaption.Name = "lblHeaderTitleCaption";
            this.lblHeaderTitleCaption.Size = new System.Drawing.Size(504, 30);
            this.lblHeaderTitleCaption.TabIndex = 0;
            this.lblHeaderTitleCaption.Text = "Gebruikte Open Source software";
            // 
            // lblHeaderTitleSub
            // 
            this.lblHeaderTitleSub.AutoSize = true;
            this.lblHeaderTitleSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitleSub.Location = new System.Drawing.Point(3, 30);
            this.lblHeaderTitleSub.Name = "lblHeaderTitleSub";
            this.lblHeaderTitleSub.Size = new System.Drawing.Size(504, 70);
            this.lblHeaderTitleSub.TabIndex = 1;
            this.lblHeaderTitleSub.Text = "label1";
            // 
            // tableLayoutClose
            // 
            this.tableLayoutClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutClose.ColumnCount = 1;
            this.tableLayoutClose.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutClose.Controls.Add(this.btnClose, 0, 0);
            this.tableLayoutClose.Location = new System.Drawing.Point(544, 468);
            this.tableLayoutClose.Name = "tableLayoutClose";
            this.tableLayoutClose.RowCount = 1;
            this.tableLayoutClose.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutClose.Size = new System.Drawing.Size(81, 31);
            this.tableLayoutClose.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Sluiten";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // formUsesOSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.tableLayoutClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "formUsesOSS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formUsesOSS";
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogoOSS)).EndInit();
            this.tableLayoutHeaderTitle.ResumeLayout(false);
            this.tableLayoutHeaderTitle.PerformLayout();
            this.tableLayoutClose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutHeader;
        private System.Windows.Forms.PictureBox pictureLogoOSS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutClose;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutHeaderTitle;
        private System.Windows.Forms.Label lblHeaderTitleCaption;
        private System.Windows.Forms.Label lblHeaderTitleSub;
    }
}