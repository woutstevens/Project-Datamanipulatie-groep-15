using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly_Model;
using Project_Monopoly;

namespace Monopoly_UnitTests
{
    [TestClass]
    public class StraatVakTest
    {
        [TestMethod]
        public void TestTeBetalen()
        {
            StraatVak straatVak = new StraatVak();
            straatVak.PrijsZonderHuis = 2;
            straatVak.PrijsMet1Huis = 10;
            straatVak.PrijsMet2Huizen = 30;
            straatVak.PrijsMet3Huizen = 90;
            straatVak.PrijsMet4Huizen = 160;
            straatVak.PrijsMet1Hotel = 250;
            straatVak.AantalHotels = 0;

            straatVak.AantalHuizen = 0;
            Assert.AreEqual(2, straatVak.GetTeBetalen());

            straatVak.AantalHuizen = 1;
            Assert.AreEqual(10, straatVak.GetTeBetalen());

            straatVak.AantalHuizen = 2;
            Assert.AreEqual(30, straatVak.GetTeBetalen());

            straatVak.AantalHuizen = 3;
            Assert.AreEqual(90, straatVak.GetTeBetalen());

            straatVak.AantalHuizen = 4;
            Assert.AreEqual(160, straatVak.GetTeBetalen());

            straatVak.AantalHotels = 1;
            Assert.AreEqual(250, straatVak.GetTeBetalen());
        }
    }
}
