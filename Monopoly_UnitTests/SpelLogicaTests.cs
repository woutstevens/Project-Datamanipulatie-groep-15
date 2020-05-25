using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly_Model;
using Project_Monopoly;

namespace Monopoly_UnitTests
{
    [TestClass]
    public class SpelLogicaTests
    {
        private List<Spelvak> spelvakken = new List<Spelvak>();
        
        [TestMethod]
        public void TestHaalSpelvakOp()
        {
            InitializeVakken();
            SpelLogica spelLogica = new SpelLogica(spelvakken);
            Spelvak spelvak = spelLogica.HaalSpelvakOp(37);
            Assert.AreEqual(spelvak.Naam, "Meir\nAntwerpen");
        }

        private void InitializeVakken()
        {
            spelvakken.Add(new StraatVak("donkerblauw", "Nieuwstraat\nBrussel", 50, 200, 600, 1400, 1700, 2000, 200, 200, 400, 142, 39));
            spelvakken.Add(new Belangstingvak("Extra\nBelasting", 38, 213, 100));
            spelvakken.Add(new StraatVak("donkerblauw", "Meir\nAntwerpen", 35, 175, 500, 1100, 1300, 1500, 200, 175, 350, 283, 37));
            spelvakken.Add(new KanskaartVak(36, 360));
            spelvakken.Add(new StationVak(200, 25, 100, 440, 35, "Zuid\nStation"));
            spelvakken.Add(new StraatVak("groen", "Boulevard\nD'Avroy\nLiège", 28, 150, 450, 1000, 1200, 1400, 200, 160, 320, 505, 34));
            spelvakken.Add(new AlgemeenFondsKaartVak(33, 570));
            spelvakken.Add(new StraatVak("groen", "Boulevard\nTirou\nCharleroi", 26, 130, 390, 900, 1100, 1275, 200, 150, 300, 645, 32));
            spelvakken.Add(new StraatVak("groen", "Veldstraat\nGent", 26, 130, 390, 900, 1100, 1275, 200, 150, 300, 720, 31));

            spelvakken.Add(new HoekVak("Naar de\ngevangenis", 30, 790));

            spelvakken.Add(new StraatVak("geel", "Hoogstraat\nBrussel", 24, 120, 360, 850, 1025, 1200, 150, 140, 280, 820, 29));
            spelvakken.Add(new Energievak(150, 75, 28, 750, "Water-\nMaatschappij", "Water"));
            spelvakken.Add(new StraatVak("geel", "Place\nDe l'ange\nNamur", 22, 110, 330, 800, 975, 1150, 150, 130, 260, 680, 27));
            spelvakken.Add(new StraatVak("geel", "Grote Markt\nHasselt", 22, 110, 330, 800, 975, 1150, 150, 130, 260, 610, 26));
            spelvakken.Add(new StationVak(200, 25, 100, 540, 25, "Buurt\nSpoorwegen"));
            spelvakken.Add(new StraatVak("rood", "Grand Place\nMons", 20, 100, 300, 750, 925, 1100, 150, 100, 240, 470, 24));
            spelvakken.Add(new StraatVak("rood", "Lange\nSteenstraat\nKortrijk", 18, 90, 250, 700, 875, 1050, 150, 110, 220, 395, 23));
            spelvakken.Add(new KanskaartVak(22, 320));
            spelvakken.Add(new StraatVak("rood", "Rue\nSt.Léonard\nLiège", 18, 90, 250, 700, 875, 1050, 150, 110, 220, 250, 21));

            spelvakken.Add(new HoekVak("Gratis\nParking", 20, 180));

            spelvakken.Add(new StraatVak("oranje", "Groenplaats\nAntwerpen", 16, 80, 220, 600, 800, 1000, 100, 100, 200, 780, 19));
            spelvakken.Add(new StraatVak("oranje", "Rue Royale\nTournai", 14, 70, 200, 550, 750, 1000, 100, 90, 180, 705, 18));
            spelvakken.Add(new AlgemeenFondsKaartVak(17, 630));
            spelvakken.Add(new StraatVak("oranje", "Lippenslaan\nKnokke", 14, 70, 200, 550, 750, 950, 100, 90, 180, 563, 16));
            spelvakken.Add(new StationVak(200, 25, 100, 490, 15, "Centraal\nStation"));
            spelvakken.Add(new StraatVak("roze", "Place Verte\nVerviers", 12, 60, 180, 500, 700, 900, 100, 80, 160, 420, 14));
            spelvakken.Add(new StraatVak("roze", "Bruul\nMechelen", 10, 50, 150, 450, 625, 750, 100, 70, 140, 350, 13));
            spelvakken.Add(new Energievak(150, 75, 12, 280, "Elektriciteits-\ncentrale", "Elektriciteit"));
            spelvakken.Add(new StraatVak("roze", "Rue de\nDiekirch\nArlon", 10, 50, 150, 450, 625, 750, 100, 70, 140, 200, 11));

            spelvakken.Add(new GevangenisVak(10, 160));

            spelvakken.Add(new StraatVak("lichtblauw", "Kapelle-\nstraat\nOostende", 8, 40, 100, 300, 450, 600, 50, 60, 120, 190, 9));
            spelvakken.Add(new StraatVak("lichtblauw", "Place du\nMonument\nSpa", 6, 30, 90, 270, 400, 550, 50, 50, 100, 260, 8));
            spelvakken.Add(new KanskaartVak(7, 335));
            spelvakken.Add(new StraatVak("lichtblauw", "Steenstraat\nBrugge", 6, 30, 90, 270, 400, 550, 50, 50, 100, 400, 6));
            spelvakken.Add(new StationVak(200, 25, 100, 480, 5, "Noord\nStation"));
            spelvakken.Add(new Belangstingvak("Inkomsten\nBelasting", 4, 550, 200));
            spelvakken.Add(new StraatVak("bruin", "Diestse-\nstraat\nLeuven", 4, 20, 60, 180, 320, 450, 50, 30, 60, 615, 3));
            spelvakken.Add(new AlgemeenFondsKaartVak(2, 695));
            spelvakken.Add(new StraatVak("bruin", "Rue\nGrande\nDinant", 2, 10, 30, 90, 160, 250, 50, 30, 60, 765, 1));
        }

        [TestMethod]
        public void TestGaLangsStartSaldo()
        {
            Speler speler = new Speler("Speler1");
            speler.HuidigSaldo = 1000;
            speler.VakID = 47;
            SpelLogica spelLogica = new SpelLogica(spelvakken);
            spelLogica.setHuidigeSpeler(speler);
            spelLogica.GaLangsStart();
            Assert.AreEqual(1200, speler.HuidigSaldo);
        }

        [TestMethod]
        public void TestVerzetSpeler()
        {
            Speler speler = new Speler("Speler1");
            speler.VakID = 10;
            InitializeVakken();
            SpelLogica spelLogica = new SpelLogica(spelvakken);
            spelLogica.setHuidigeSpeler(speler);
            spelLogica.VerzetSpeler(5);
            Assert.AreEqual(15, speler.VakID);

            speler.VakID = 35;
            spelLogica.VerzetSpeler(10);
            Assert.AreEqual(5, speler.VakID);
        }

        [TestMethod]
        public void TestWijzigSaldo()
        {
            Speler speler = new Speler("Speler1");
            speler.HuidigSaldo = 0;
            SpelLogica spelLogica = new SpelLogica(spelvakken);
            spelLogica.setHuidigeSpeler(speler);
            spelLogica.WijzigSaldo(1000);
            spelLogica.WijzigSaldo(-200);
            Assert.AreEqual(800, speler.HuidigSaldo);
        }

        [TestMethod]
        public void TestNaarDeGevangenis()
        {
            Speler speler = new Speler("Speler1");
            SpelLogica spelLogica = new SpelLogica(spelvakken);
            spelLogica.setHuidigeSpeler(speler);
            spelLogica.NaarDeGevangenis();
            Assert.AreEqual(10, speler.VakID);
            Assert.AreEqual(true, speler.Gevangenis);
        }

        [TestMethod]
        public void TestBetalen()
        {
            StraatVak eigendom = new StraatVak("lichtblauw", "Steenstraat\nBrugge", 6, 30, 90, 270, 400, 550, 50, 50, 100, 400, 6);
            Speler huidigeSpeler = new Speler("Speler1");
            Speler eigenaar = new Speler("Speler2");
            eigendom.Eigenaar = eigenaar;
            SpelLogica spelLogica = new SpelLogica(spelvakken);
            spelLogica.setHuidigeSpeler(huidigeSpeler);
            spelLogica.Betalen(eigendom);

            Assert.AreEqual(1494, huidigeSpeler.HuidigSaldo);
            Assert.AreEqual(1506, eigenaar.HuidigSaldo);

            eigendom.AantalHuizen = 2;
            spelLogica.Betalen(eigendom);
            Assert.AreEqual(1404, huidigeSpeler.HuidigSaldo);
            Assert.AreEqual(1596, eigenaar.HuidigSaldo);
        }
    }
}
