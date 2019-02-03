using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister.License;
using System.Collections.Generic;

namespace UnitTests.License
{
    [TestClass]
    [UsesOSS(packageName: "testPackage", URL: "http://hicts.nl", InternalTextFile: "BCrypt.txt")]
    public class LicenseTest
    {
        [TestMethod]
        public void TestDefaultAttributesForAllowanceOfMultipleInstancesAndTargetClasses()
        {
            

            var attributes = (IList<AttributeUsageAttribute>)typeof(UsesOSS).GetCustomAttributes(typeof(AttributeUsageAttribute), false);
            Assert.AreEqual(1, attributes.Count);

            var attribute = attributes[0];

            Assert.IsTrue(attribute.AllowMultiple);

            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.All));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Assembly));
            Assert.IsTrue(attribute.ValidOn.HasFlag(AttributeTargets.Class));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Constructor));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Delegate));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Enum));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Event));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Field));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.GenericParameter));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Interface));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Method));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Module));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Parameter));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Property));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.ReturnValue));
            Assert.IsFalse(attribute.ValidOn.HasFlag(AttributeTargets.Struct));
        }

        [TestMethod]
        public void TestLicense()
        {
            var lijst = CashRegister.License.License.Registration.GetPackages();
            Assert.AreEqual(1, lijst.Count);
            Assert.AreEqual("http://hicts.nl", CashRegister.License.License.Registration.GetURLForPackage(lijst[0]));
            //Assert.AreEqual("dsf", CashRegister.License.License.Registration.GetEmbeddedLicenseFile(lijst[0]));
            //Assert.AreEqual("dsf", CashRegister.License.License.Registration.GetAssembly());
        }
    }
}
