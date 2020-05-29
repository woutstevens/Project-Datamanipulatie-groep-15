using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly_Model;

namespace Monopoly_UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class SpelerTests
    {
        [TestMethod]
        public void TestIsFailliet()
        {
            Speler speler = new Speler("Speler1");
            speler.HuidigSaldo = 300;
            Assert.AreEqual(false, speler.IsFailliet());

            speler.HuidigSaldo = 0;
            Assert.AreEqual(true, speler.IsFailliet());

            speler.HuidigSaldo = -100;
            Assert.AreEqual(true, speler.IsFailliet());
        }
    }
}
