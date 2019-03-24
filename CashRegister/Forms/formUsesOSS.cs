using CashRegister.License;
using System;
using System.Text;
using System.Windows.Forms;

namespace CashRegister.Forms
{
    public partial class formUsesOSS : Form
    {
        public formUsesOSS()
        {
            InitializeComponent();

            // Build the uses string
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Deze applicatie gebruikt diverse Open Source software.\n\n");
            stringBuilder.Append("Hieronder is een opsomming van de gebruikte software gneoemd. Klik op de titel om meer informatie te bekijken.");
            lblHeaderTitleSub.Text = stringBuilder.ToString();

            // Add the control
            tableLayoutMain.Controls.Add(new ucLicenseForm() { Dock = DockStyle.Fill },0,2);

            this.Text = "Gebruikte Open Source software";

            // Close the form when the Close button is clicked
            this.btnClose.Click += (object sender, EventArgs e) => this.Close();
        }

    }
}
