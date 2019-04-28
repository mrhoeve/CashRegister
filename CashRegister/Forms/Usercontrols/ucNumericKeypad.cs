using System;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CashRegister.Forms.Usercontrols
{
    public partial class ucNumericKeypad : UserControl
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();
        private String currentInput="1";
        private Boolean keyEntered = false;
        private Boolean decimalEntered = false;

        Font DigitalFont;

        public ucNumericKeypad()
        {
            InitializeComponent();

            byte[] fontData = Properties.Resources.DigitalFont;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.DigitalFont.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.DigitalFont.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            DigitalFont = new Font(fonts.Families[0], 16.0F);
        }

        public Boolean isInteger()
        {
            return decimalEntered && currentInput.Substring(currentInput.Length - 1) != ".";
        }

        public int getInteger()
        {
            if (!isInteger()) throw new FormatException("Input isn't a number");
            return Convert.ToInt32(currentInput);
        }

        public decimal PerformRoundAndGetDecimal()
        {
            ProcessEuro();
            return decimal.Parse(currentInput, CultureInfo.InvariantCulture);
        }

        public void Reset()
        {
            ResetNumber();
        }

#region "Private functions"
        private void ucNumericKeypad_Load(object sender, EventArgs e)
        {
            lblDisplay.Font = DigitalFont;
            lblDisplay.Text = currentInput;

            setToolTips();

            foreach (Button button in tableLayoutPanel1.Controls.OfType<Button>().ToList())
            {
                button.Click += button_Click;
            }
        }

        private void setToolTips()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(buttonEuro, "Creëert een correct geldbedrag van het ingevoerde getal (inclusief afronding)");
            toolTip.SetToolTip(buttonEnter, "Creëert een correct geldbedrag van het ingevoerde getal (inclusief afronding)");
            toolTip.SetToolTip(buttonC, "Verwijdert het meest rechtse item in het display");
            toolTip.SetToolTip(buttonCE, "Reset de invoer");
            toolTip.SetToolTip(buttonPlus, "Telt het getal 1 op bij de invoer (alleen als er geen decimaal is gebruikt)");
            toolTip.SetToolTip(buttonMin, "Trekt het getal 1 af van de invoer (alleen als er geen decimaal is gebruikt)");
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Text.ToUpper())
            {
                case "€":
                case "ENTER":
                    ProcessEuro();
                    break;
                case "C":
                    RemoveLastInput();
                    break;
                case "CE":
                    ResetNumber();
                    break;
                case "+":
                    ProcessUp();
                    break;
                case "-":
                    ProcessDown();
                    break;
                case ".":
                case ".00":
                    ProcessDecimal(button.Text);
                    break;
                default:
                    ProcessNumber(button.Text);
                    break;
            }
            Guard();
            EnableDisableButtons();
            lblDisplay.Text = currentInput;
        }

    #region "Process numbers"
        private void RemoveLastInput()
        {
            if (decimalEntered && currentInput.Substring(currentInput.Length-1, 1) == ".")
                decimalEntered = false;
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            if (string.IsNullOrEmpty(currentInput))
                ResetNumber();
        }

        private void ProcessNumber(String number)
        {
            if (decimalEntered && currentInput.Substring(currentInput.IndexOf('.')).Length == 3)
                return;
            if (String.IsNullOrEmpty(currentInput) || currentInput == "0" || (currentInput=="1" && !keyEntered))
                currentInput = "";
            keyEntered = true;
            currentInput += number;
        }

        private void ResetNumber()
        {
            keyEntered = false;
            decimalEntered = false;
            currentInput = "1";
        }

        private void ProcessUp()
        {
            if (decimalEntered) return;
            currentInput = ((Convert.ToInt32(currentInput)) + 1).ToString();
        }

        private void ProcessDown()
        {
            if (decimalEntered) return;
            currentInput = ((Convert.ToInt32(currentInput)) - 1).ToString();
            if (currentInput == "0")
                ResetNumber();
        }

        private void ProcessDecimal(String decToAdd)
        {
            if (decimalEntered && decToAdd == ".00" && currentInput.Substring(currentInput.IndexOf('.')).Length == 1)
                currentInput += "00";
            if (decimalEntered) return;
            decimalEntered = true;
            currentInput += decToAdd;
        }

        private void EnableDisableButtons()
        {
            buttonDot.Enabled = !decimalEntered;
            button00.Enabled = !decimalEntered || (decimalEntered && currentInput.Substring(currentInput.IndexOf('.')).Length == 1);
            buttonPlus.Enabled = !decimalEntered;
            buttonMin.Enabled = !decimalEntered;
        }

        private void ProcessEuro()
        {
            if (!decimalEntered)
            {
                ProcessDecimal(".00");
                return;
            }
            int DigitsEntered = currentInput.Substring(currentInput.IndexOf('.')).Length;
            switch (DigitsEntered)
            {
                case 1:
                    ProcessDecimal(".00");
                    break;
                case 2:
                    ProcessNumber("0");
                    break;
                default:
                    PerformRound();
                    break;
            }
        }

        private void PerformRound()
        {
            String lastNumber = currentInput.Substring(currentInput.Length - 1);
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            switch (lastNumber)
            {
                case "0":
                case "1":
                case "2":
                    ProcessNumber("0");
                    break;
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                    ProcessNumber("5");
                    break;
                default:
                    decimal d = decimal.Parse(currentInput, CultureInfo.InvariantCulture);
                    d += 0.1m;
                    currentInput = d.ToString("0.00").Replace(',', '.');
                    break;
            }
        }

        private void Guard()
        {
            if (decimalEntered && currentInput.Length > 13 || !decimalEntered && currentInput.Length > 10)
                currentInput = currentInput.Substring(0, (decimalEntered ? 13 : 10));
        }
        #endregion

        #endregion
    }
}
