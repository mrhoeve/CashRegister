using CashRegister.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashRegister.Forms.Usercontrols
{
    public partial class ucStatusbar : UserControl
    {
        public ucStatusbar()
        {
            InitializeComponent();

            this.lblStatusbarVersie.Text = GitVersionHelper.GetFullVersionInformation();
            this.lblStatusbarBranchename.Text = GitVersionHelper.GetBrancheName();
        }
    }
}
