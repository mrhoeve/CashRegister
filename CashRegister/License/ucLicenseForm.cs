using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CashRegister.License
{
    public partial class ucLicenseForm : UserControl
    {
        Label _current;

        public ucLicenseForm()
        {
            InitializeComponent();
            layoutPanelMain.Controls.Add(FillLayoutPanelOSS(), 0, 1);
            llblSource.LinkClicked += LlblSource_LinkClicked;
        }

        private void LlblSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel _sender = (LinkLabel)sender;
            System.Diagnostics.Process.Start(_sender.Text);
        }

        private TableLayoutPanel FillLayoutPanelOSS()
        {
            IList<string> lijst = License.Registration.GetPackages();
            // Create tablelayout and initialise it
            TableLayoutPanel layoutPanelOSS = new TableLayoutPanel();
            layoutPanelOSS.Margin = new Padding(0);
            layoutPanelOSS.Dock = DockStyle.Fill;
            layoutPanelOSS.AutoSize = false;
            layoutPanelOSS.AutoScroll = true;
            layoutPanelOSS.ColumnCount = 1;
            layoutPanelOSS.RowCount = 0;
            // Get each OSS entry
            foreach (string item in lijst)
            {
                Label Label = new Label() { Text = item, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
                Label.MouseClick += Label_MouseClick;
                layoutPanelOSS.RowCount++;
                layoutPanelOSS.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                layoutPanelOSS.Controls.Add(Label, 1, layoutPanelOSS.RowCount - 1);
            }
            // Add one autosized row at the end
            layoutPanelOSS.RowCount++;
            layoutPanelOSS.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            return layoutPanelOSS;
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            Label _sender= (Label)sender;
            if (_current != null)
            {
                _current.ForeColor = SystemColors.WindowText;
                _current.BackColor = SystemColors.Control;
            } else
            {
                lblSource.Visible = true;
                llblSource.Visible = true;
                textLicense.Visible = true;
            }
            if (_current == _sender)
            {
                lblSource.Visible = false;
                llblSource.Visible = false;
                textLicense.Visible = false;
                _current = null;
            }
            else
            {
                _current = _sender;
                string _clicked = _current.Text;
                llblSource.Text = License.Registration.GetURLForPackage(_clicked);
                textLicense.Text = License.Registration.GetEmbeddedLicenseFile(_clicked);
                _current.ForeColor = SystemColors.ActiveCaptionText;
                _current.BackColor = SystemColors.ActiveCaption;
            }
        }
    }
}
