using CashRegister.Forms;
using CashRegister.License;
using System.Windows.Forms;

namespace CashRegister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.table.Controls.Add(new ucLicenseForm() { Dock=DockStyle.Fill });
            formUsesOSS form = new formUsesOSS();
            form.ShowDialog();
            //Assert.AreEqual("https://opensource.org/", CashRegister.License.License.Registration.GetURLForPackage(lijst[1]));

        }
    }
}
