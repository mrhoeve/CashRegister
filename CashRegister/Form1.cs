using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CashRegister.Forms;
using CashRegister.License;
using CashRegister.Model;

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
