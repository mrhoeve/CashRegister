using CashRegister.Forms.Usercontrols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace UnitTests.Forms.Usercontrols
{
    [TestClass]
    public class ucNumericKeypadTest
    {

        [TestMethod]
        public void TestAllNumbersWithCAndCE_EverytingShouldPass()
        {
            // Setup test
            ucNumericKeypad keypad = new ucNumericKeypad();
            // Test all numbers
            for (int i = 1; i < 10; i++)
            {
                enterButtonClick(createButton(i.ToString()), keypad);
                Assert.AreEqual(i, keypad.getInteger());
                Assert.AreEqual((decimal)i, keypad.PerformRoundAndGetDecimal());
                enterButtonClick(createButton("CE"), keypad);
            }
        }

        [TestMethod]
        public void TestNearlyCompleteTestSerie()
        {
            // Setup test
            ucNumericKeypad keypad = new ucNumericKeypad();
            // Perform the test

            // Test dubble digits
            enterButtonClick(createButton("3"), keypad);
            enterButtonClick(createButton("7"), keypad);
            Assert.AreEqual(37, keypad.getInteger());
            enterButtonClick(createButton("0"), keypad);
            Assert.AreEqual(370, keypad.getInteger());

            // Continue with +
            enterButtonClick(createButton("+"), keypad);
            Assert.AreEqual(371, keypad.getInteger());
            enterButtonClick(createButton("+"), keypad);
            enterButtonClick(createButton("+"), keypad);
            enterButtonClick(createButton("+"), keypad);
            Assert.AreEqual(374, keypad.getInteger());

            // Continu with -
            enterButtonClick(createButton("-"), keypad);
            enterButtonClick(createButton("-"), keypad);
            Assert.AreEqual(372, keypad.getInteger());

            // Now test C
            enterButtonClick(createButton("C"), keypad);
            Assert.AreEqual(37, keypad.getInteger());
            enterButtonClick(createButton("C"), keypad);
            enterButtonClick(createButton("C"), keypad);
            Assert.AreEqual(1, keypad.getInteger());

            // Test euro sign
            enterButtonClick(createButton("€"), keypad);
            Assert.AreEqual((decimal)1, keypad.PerformRoundAndGetDecimal());
            enterButtonClick(createButton("C"), keypad);
            enterButtonClick(createButton("C"), keypad);
            enterButtonClick(createButton("2"), keypad);

            // Test Enter sign (alternate euro sign)
            enterButtonClick(createButton("ENTER"), keypad);
            Assert.AreEqual((decimal)1.20, keypad.PerformRoundAndGetDecimal());

            // Test rounding
            enterButtonClick(createButton("C"), keypad);
            enterButtonClick(createButton("2"), keypad);
            enterButtonClick(createButton("€"), keypad);
            Assert.AreEqual((decimal)1.20, keypad.PerformRoundAndGetDecimal());
            enterButtonClick(createButton("C"), keypad);
            enterButtonClick(createButton("3"), keypad);
            enterButtonClick(createButton("€"), keypad);
            Assert.AreEqual((decimal)1.25, keypad.PerformRoundAndGetDecimal());
        }

        [TestMethod]
        public void TestRoundingUpAboveFiveToNextDecimal()
        {
            // Setup test
            ucNumericKeypad keypad = new ucNumericKeypad();
            // Perform the test
            enterButtonClick(createButton("3"), keypad);
            enterButtonClick(createButton("."), keypad);
            enterButtonClick(createButton("8"), keypad);
            enterButtonClick(createButton("8"), keypad);
            enterButtonClick(createButton("€"), keypad);
            Assert.AreEqual((decimal)3.90, keypad.PerformRoundAndGetDecimal());
        }

        [TestMethod]
        public void TestRoundingUpAboveFiveToNextInteger()
        {
            // Setup test
            ucNumericKeypad keypad = new ucNumericKeypad();
            // Perform the test
            enterButtonClick(createButton("3"), keypad);
            enterButtonClick(createButton("."), keypad);
            enterButtonClick(createButton("9"), keypad);
            enterButtonClick(createButton("8"), keypad);
            enterButtonClick(createButton("€"), keypad);
            Assert.AreEqual((decimal)4.00, keypad.PerformRoundAndGetDecimal());
        }

        [TestMethod]
        public void TestRoundingToBelowAboveFive()
        {
            // Setup test
            ucNumericKeypad keypad = new ucNumericKeypad();
            // Perform the test
            enterButtonClick(createButton("3"), keypad);
            enterButtonClick(createButton("."), keypad);
            enterButtonClick(createButton("9"), keypad);
            enterButtonClick(createButton("7"), keypad);
            enterButtonClick(createButton("€"), keypad);
            Assert.AreEqual((decimal)3.95, keypad.PerformRoundAndGetDecimal());
        }

        [TestMethod]
        public void TestRoundingResettingTheNumbers()
        {
            // Setup test
            ucNumericKeypad keypad = new ucNumericKeypad();
            // Perform the test
            enterButtonClick(createButton("3"), keypad);
            enterButtonClick(createButton("."), keypad);
            enterButtonClick(createButton("9"), keypad);
            keypad.Reset();
            Assert.AreEqual(1, keypad.getInteger());
            Assert.AreEqual((decimal)1.00, keypad.PerformRoundAndGetDecimal());
        }

        private void enterButtonClick(Button buttonToClick, ucNumericKeypad keypad)
        {
            object o = keypad;
            var t = typeof(ucNumericKeypad);
            // Call the private (!!) method to click the specified button
            t.GetMethod("button_Click", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(o, new object[] { buttonToClick, new EventArgs() });
        }

        [TestMethod]
        public void TestMaximumAmountOfIntegers()
        {
            // Setup test
            ucNumericKeypad keypad = new ucNumericKeypad();
            // Test all numbers
            for (int i = 1; i < 15; i++)
            {
                enterButtonClick(createButton("9"), keypad);
            }
            Assert.AreEqual(99999999, keypad.getInteger());
            Assert.AreEqual((decimal)99999999, keypad.PerformRoundAndGetDecimal());
        }

        [TestMethod]
        public void TestMaximumAmountOfDecimals()
        {
            // Setup test
            ucNumericKeypad keypad = new ucNumericKeypad();
            // Test all numbers
            for (int i = 1; i < 15; i++)
            {
                enterButtonClick(createButton("9"), keypad);
            }
            enterButtonClick(createButton("."), keypad);
            for (int i = 1; i < 5; i++)
            {
                enterButtonClick(createButton("8"), keypad);
            }
            Assert.AreEqual((decimal)99999999.9, keypad.PerformRoundAndGetDecimal());
        }

        private Button createButton(String caption)
        {
            return new Button() { Text = caption };
        }
    }
}
