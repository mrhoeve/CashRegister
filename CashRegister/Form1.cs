using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashRegister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            IList<string> lijst = License.License.Registration.GetPackages();
            foreach(string item in lijst)
            {
                //this.Controls.Add(new Label() { Text=item } );
                //this.Controls.Add(new Label() { Text = "\n" });
                this.Controls.Add(new Label() { Text = "|" + License.License.Registration.GetEmbeddedLicenseFile(item) });
            }
            //Assert.AreEqual("https://opensource.org/", CashRegister.License.License.Registration.GetURLForPackage(lijst[1]));

        }
    }
}
