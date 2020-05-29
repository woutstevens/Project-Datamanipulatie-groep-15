using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Monopoly_Model;

namespace Project_Monopoly
{
    /// <summary>
    /// Interaction logic for Spelbord.xaml
    /// </summary>
    public partial class Spelbord : Window
    {
        List<Spelvak> spelvakken = new List<Spelvak>();
        private const int V = 70;
        private const int stapGrootte = 70;
        List<Speler> spelerslijst;
        bool dubbelGegooid;
        int pot;
        Speler huidigeSpeler;
        SpelLogica spelLogica;
        SpelbordDatabaseOperaties spelbordDatabase;
        public int aantalgegooid;
        List<Ellipse> ellipses;
        Startscherm startscherm;
        public Spelbord(List<Speler> spelers,Startscherm startscherm)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            spelerslijst = spelers;
            pot = 0;
            spelbordDatabase = new SpelbordDatabaseOperaties();
            ToevoegenKaarten();
            spelLogica = new SpelLogica(spelvakken);
            aantalgegooid = 0;
            ellipses = new List<Ellipse>();
            this.startscherm = startscherm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeSpelbord();
            SetOverzichtSaldi();
            StartSpel();
            startscherm.Close();
        }

        private void StartSpel()
        {
            tekenPionnen();
            int aantalSpelers = spelerslijst.Count;

            while (aantalSpelers > 1)
            {
                foreach (Speler speler in spelerslijst)
                {
                    huidigeSpeler = speler;
                    spelLogica.setHuidigeSpeler(huidigeSpeler);

                    if (!huidigeSpeler.IsFailliet())
                    {
                        do
                        {
                            SpeelMetSpeler(speler);
                            if (huidigeSpeler.IsFailliet())
                            {
                                MessageBox.Show("Sorry " + huidigeSpeler.Naam + ",je mag niet meer verder spelen want je bent failliet", "Je bent failliet!", MessageBoxButton.OK, MessageBoxImage.Warning);
                                speler.Rangschrikking = spelerslijst.Count;
                                aantalSpelers--;
                            }
                            SetOverzichtSaldi();
                        } while (dubbelGegooid && !speler.IsFailliet());
                    }
                }
            }

            Eindscherm eindscherm = new Eindscherm();
            eindscherm.ShowDialog();
            this.Close();
        }

        

        public Speler getHuidigeSpeler()
        {
            return huidigeSpeler;
        }

        private void SpeelMetSpeler(Speler speler)
        {
            //Gooien gooien = new Gooien(this);
            //gooien.ShowDialog();
            Random gooien = new Random();
            int Dobbelsteen1 = gooien.Next(1, 7);
            int Dobbelsteen2 = gooien.Next(1, 7);
            if(Dobbelsteen1 == Dobbelsteen2)
            {
                dubbelGegooid = true;
            }

            else
            {
                dubbelGegooid = false;
            }
            aantalgegooid = Dobbelsteen1 + Dobbelsteen2;
            MessageBox.Show("Dobbelsteen 1: " + Dobbelsteen1 + "\nDobbelsteen 2: " + Dobbelsteen2 + "\nTotaal: " + aantalgegooid,"Gooien voor speler " + huidigeSpeler.Naam,MessageBoxButton.OK,MessageBoxImage.Information);
            VerzetSpeler(aantalgegooid);

            Spelvak spelvak = spelLogica.HaalSpelvakOp(speler.VakID);

            if(speler.VakID == 0)
            {
                Ellipse ellipse = getEllipseByID(speler.SpelerID);
                ellipse.Margin = new Thickness(45, 850, 0, 0);
            }
            
            if(spelvak != null)
            {
                if (spelvak.Type == "eigendom")
                {
                    EigendomVak eigendom = (EigendomVak)spelvak;
                    Infrastructuur infrastructuur = new Infrastructuur(eigendom, this);
                    infrastructuur.ShowDialog();
                }



                else if (spelvak.GetType() == typeof(KanskaartVak))
                {
                    Kans kans = new Kans(this);
                    kans.ShowDialog();
                }

                else if (spelvak.GetType() == typeof(AlgemeenFondsKaartVak))
                {
                    //AlgemeenFonds algemeenFonds = new AlgemeenFonds(this);
                    WijzigSaldo(-50);
                    pot += (50);
                }

                else if (spelvak.GetType() == typeof(Belangstingvak))
                {
                    Belangstingvak belangstingvak = (Belangstingvak)spelvak;
                    WijzigSaldo(belangstingvak.Prijs * -1);
                    pot += belangstingvak.Prijs;
                }

                else if (spelvak.GetType() == typeof(HoekVak) && spelvak.Positie == 30)
                {
                    NaarDeGevangenis();
                }

                else if (spelvak.GetType() == typeof(HoekVak) && spelvak.Positie == 20)
                {
                    WijzigSaldo(pot);
                    pot = 0;
                }


                else if (spelvak.GetType() == typeof(GevangenisVak))
                {
                    if (huidigeSpeler.Gevangenis == true)
                    {

                    }
                }
                verzetPion(huidigeSpeler);
            }
            
        }
        public void WijzigPot(int bedrag)
        {
            pot += bedrag;
        }
        private void SetOverzichtSaldi()
        {
            string overzicht="";
            foreach(Monopoly_Model.Speler speler in spelerslijst)
            {
                overzicht += speler.Naam + " : €" + speler.HuidigSaldo +" Vakid: " + speler.VakID +"\n";
            }
            overzicht += "Pot:" + pot;
            lblOverzicht.Content = overzicht;
        }

        public void SetDubbelGegooid(bool dubbel)
        {
            dubbelGegooid = dubbel;
        }

        public void VerzetSpeler(int aantalVakjes)
        {
            spelLogica.VerzetSpeler(aantalVakjes);
        }

        public void VerzetSpelerNaarVak(int vakID)
        {
            spelLogica.VerzetSpelerNaarVak(vakID);
        }


        public void WijzigSaldo(int bedrag)
        {
            spelLogica.WijzigSaldo(bedrag);
        }

        public void NaarDeGevangenis()
        {
            spelLogica.NaarDeGevangenis();
        }

        public void Kopen(EigendomVak eigendom)
        {
            spelLogica.Kopen(eigendom);
        }

        public void Betalen(EigendomVak eigendom,int aantalGegooid)
        {
            spelLogica.Betalen(eigendom,aantalGegooid);
        }

        private void VolgendeRonde()
        {
            if(spelerslijst[spelerslijst.Count -1] == huidigeSpeler)
            {
                StartSpel();
            }
        }

        public int Berekenprijs(EigendomVak eigendom, int aantalGegooid)
        {
            return spelLogica.BerekenPrijs(eigendom, aantalGegooid);
        }

        public void KoopHuis(StraatVak straat)
        {
            spelLogica.huisKopen(straat);
        }

        private void InitializeSpelbord()
        {
            KanskaartenStapel kanskaarten = new KanskaartenStapel();
            lblTest.Content = kanskaarten.neemKansKaart().Omschrijving;
            foreach (Spelvak huidigvak in spelvakken)
            {
                SetCardText(huidigvak);
            }
        }

        private void tekenPionnen()
        {
            foreach(Speler speler in spelerslijst)
            {
                Pion pion = speler.Pion;
                Color color = Colors.White;
                if (pion.Kleur.ToLower() == "rood")
                {
                    color = Colors.Red;
                }

                else if (pion.Kleur.ToLower() == "blauw")
                {
                    color = Colors.Blue;
                }

                else if (pion.Kleur.ToLower() == "groen")
                {
                    color = Colors.Green;
                }

                else if (pion.Kleur.ToLower() == "paars")
                {
                    color = Colors.Purple;
                }

                else if (pion.Kleur.ToLower() == "zwart")
                {
                    color = Colors.Black;
                }

                else if (pion.Kleur.ToLower() == "geel")
                {
                    color = Colors.Yellow;
                }

                
                Ellipse ellipse = new Ellipse();
                ellipse.Width = pion.Grootte;
                ellipse.Height = pion.Grootte;
                ellipse.Fill = new SolidColorBrush(color);
                ellipse.Margin = new Thickness(45, 850, 0, 0);
                ellipse.VerticalAlignment = VerticalAlignment.Top;
                ellipse.HorizontalAlignment = HorizontalAlignment.Left;
                ellipse.Stroke = new SolidColorBrush(Colors.Black);
                ellipse.StrokeThickness = 2;
                testgrid.Children.Add (ellipse);
                ellipses.Add(ellipse);
            }
            
        }

        private Ellipse getEllipseByID(int id)
        {
            return ellipses[id - 1];
        }

        private void verzetPion(Speler speler)
        {
            Ellipse ellipse = getEllipseByID(speler.SpelerID);
            Spelvak huidigvak = spelLogica.HaalSpelvakOp(speler.VakID);
            int vakLeft = 0;
            int vakTop = 0;
            if (huidigvak == null)
            {
                vakLeft = 50;
                vakTop = 450;
            }

            else
            {
                vakLeft = huidigvak.MiddelLeft;
                vakTop = huidigvak.MiddelTop;
            }

            if (speler.Gevangenis == false)
            {
                ellipse.Margin = new Thickness(vakLeft, vakTop, 0, 0);
            }

            else
            {
                ellipse.Margin = new Thickness(90, 130, 0, 0);
            }
            

        }

        private void ToevoegenKaarten()
        {
            spelvakken = spelbordDatabase.getSpelvakken();

            //spelvakken.Add(new StraatVak("donkerblauw", "Nieuwstraat\nBrussel", 50, 200, 600, 1400, 1700, 2000, 200, 200, 400, 142, 39));
            //spelvakken.Add(new Belangstingvak("Extra\nBelasting", 38, 213, 100));
            //spelvakken.Add(new StraatVak("donkerblauw", "Meir\nAntwerpen", 35, 175, 500, 1100, 1300, 1500, 200, 175, 350, 283, 37));
            //spelvakken.Add(new KanskaartVak(36, 360));
            //spelvakken.Add(new StationVak(200, 25, 100, 440, 35, "Zuid\nStation"));
            //spelvakken.Add(new StraatVak("groen", "Boulevard\nD'Avroy\nLiège", 28, 150, 450, 1000, 1200, 1400, 200, 160, 320, 505, 34));
            //spelvakken.Add(new AlgemeenFondsKaartVak(33, 570));
            //spelvakken.Add(new StraatVak("groen", "Boulevard\nTirou\nCharleroi", 26, 130, 390, 900, 1100, 1275, 200, 150, 300, 645, 32));
            //spelvakken.Add(new StraatVak("groen", "Veldstraat\nGent", 26, 130, 390, 900, 1100, 1275, 200, 150, 300, 720, 31));

            //spelvakken.Add(new HoekVak("Naar de\ngevangenis", 30, 790));

            //spelvakken.Add(new StraatVak("geel", "Hoogstraat\nBrussel", 24, 120, 360, 850, 1025, 1200, 150, 140, 280, 820, 29));
            //spelvakken.Add(new Energievak(150, 75, 28, 750, "Water-\nMaatschappij", "Water"));
            //spelvakken.Add(new StraatVak("geel", "Place\nDe l'ange\nNamur", 22, 110, 330, 800, 975, 1150, 150, 130, 260, 680, 27));
            //spelvakken.Add(new StraatVak("geel", "Grote Markt\nHasselt", 22, 110, 330, 800, 975, 1150, 150, 130, 260, 610, 26));
            //spelvakken.Add(new StationVak(200, 25, 100, 540, 25, "Buurt\nSpoorwegen"));
            //spelvakken.Add(new StraatVak("rood", "Grand Place\nMons", 20, 100, 300, 750, 925, 1100, 150, 100, 240, 470, 24));
            //spelvakken.Add(new StraatVak("rood", "Lange\nSteenstraat\nKortrijk", 18, 90, 250, 700, 875, 1050, 150, 110, 220, 395, 23));
            //spelvakken.Add(new KanskaartVak(22, 320));
            //spelvakken.Add(new StraatVak("rood", "Rue\nSt.Léonard\nLiège", 18, 90, 250, 700, 875, 1050, 150, 110, 220, 250, 21));

            //spelvakken.Add(new HoekVak("Gratis\nParking", 20, 180));

            //spelvakken.Add(new StraatVak("oranje", "Groenplaats\nAntwerpen", 16, 80, 220, 600, 800, 1000, 100, 100, 200, 780, 19));
            //spelvakken.Add(new StraatVak("oranje", "Rue Royale\nTournai", 14, 70, 200, 550, 750, 1000, 100, 90, 180, 705, 18));
            //spelvakken.Add(new AlgemeenFondsKaartVak(17, 630));
            //spelvakken.Add(new StraatVak("oranje", "Lippenslaan\nKnokke", 14, 70, 200, 550, 750, 950, 100, 90, 180, 563, 16));
            //spelvakken.Add(new StationVak(200, 25, 100, 490, 15, "Centraal\nStation"));
            //spelvakken.Add(new StraatVak("roze", "Place Verte\nVerviers", 12, 60, 180, 500, 700, 900, 100, 80, 160, 420, 14));
            //spelvakken.Add(new StraatVak("roze", "Bruul\nMechelen", 10, 50, 150, 450, 625, 750, 100, 70, 140, 350, 13));
            //spelvakken.Add(new Energievak(150, 75, 12, 280, "Elektriciteits-\ncentrale", "Elektriciteit"));
            //spelvakken.Add(new StraatVak("roze", "Rue de\nDiekirch\nArlon", 10, 50, 150, 450, 625, 750, 100, 70, 140, 200, 11));

            //spelvakken.Add(new GevangenisVak(10, 160));

            //spelvakken.Add(new StraatVak("lichtblauw", "Kapelle-\nstraat\nOostende", 8, 40, 100, 300, 450, 600, 50, 60, 120, 190, 9));
            //spelvakken.Add(new StraatVak("lichtblauw", "Place du\nMonument\nSpa", 6, 30, 90, 270, 400, 550, 50, 50, 100, 260, 8));
            //spelvakken.Add(new KanskaartVak(7, 335));
            //spelvakken.Add(new StraatVak("lichtblauw", "Steenstraat\nBrugge", 6, 30, 90, 270, 400, 550, 50, 50, 100, 400, 6));
            //spelvakken.Add(new StationVak(200, 25, 100, 480, 5, "Noord\nStation"));
            //spelvakken.Add(new Belangstingvak("Inkomsten\nBelasting", 4, 550, 200));
            //spelvakken.Add(new StraatVak("bruin", "Diestse-\nstraat\nLeuven", 4, 20, 60, 180, 320, 450, 50, 30, 60, 615, 3));
            //spelvakken.Add(new AlgemeenFondsKaartVak(2, 695));
            //spelvakken.Add(new StraatVak("bruin", "Rue\nGrande\nDinant", 2, 10, 30, 90, 160, 250, 50, 30, 60, 765, 1));

        }

        private void SetCardText(Spelvak huidigvak)
        {
            Label nameLabel = new Label();
            Label priceLabel = new Label();
            Image afbeelding = new Image();
            RotateTransform rotateTransform = new RotateTransform(huidigvak.Graden);
            nameLabel.RenderTransform = rotateTransform;

            int left = huidigvak.Left;
            int top = huidigvak.Top;

            int nameLeft = left;
            int nameTop = top;
            int imgCrdLeft = left;
            int imgCrdTop = top;
            int imgCanBuyLeft = left;
            int imgCanBuyTop = top;
            int imgCornerLeft = left;
            int imgCornerTop = top;

            if (huidigvak.Positie > 30 && huidigvak.Positie < 40)
            {
                nameTop = top - V;
                imgCrdLeft = nameLeft;
                imgCrdTop = nameTop + 20;
                imgCanBuyLeft = nameLeft - 10;
                imgCanBuyTop = nameTop + 20;
                if (IsSpecialCard(huidigvak.Naam))
                {
                    nameTop -= 20;
                }
            }

            else if (huidigvak.Graden == 90)
            {
                nameLeft = left + V;
                imgCrdLeft = nameLeft - 20;
                imgCrdTop = nameTop - 4;
                imgCanBuyLeft = nameLeft - 20;
                imgCanBuyTop = nameTop - 4;
                if (IsSpecialCard(huidigvak.Naam))
                {
                    nameLeft += 20;
                }
            }

            else if (huidigvak.Graden == 180)
            {
                nameTop = top + V;
                imgCrdTop = nameTop;
                imgCrdLeft = nameLeft;
                imgCanBuyTop = nameTop - 20;
                imgCanBuyLeft = nameLeft;
                if (IsSpecialCard(huidigvak.Naam))
                {
                    nameTop += 20;
                }
            }

            else if (huidigvak.Graden == 270)
            {
                nameLeft = left - V;
                imgCrdLeft = nameLeft + 20;
                imgCrdTop = nameTop + 2;
                imgCanBuyLeft = nameLeft + 20;
                imgCanBuyTop = nameTop - 3;
                if (IsSpecialCard(huidigvak.Naam))
                {
                    nameLeft -= 20;
                }
            }

            else if (huidigvak.Graden == 225)
            {
                imgCornerLeft = huidigvak.Left - 20;
                imgCornerTop = top - 15;
                nameLeft = left - V + 20;
            }

            else if (huidigvak.Graden == 176)
            {
                nameLeft = left - 110;
                nameTop = top - 90;
                RotateTransform rotate90 = new RotateTransform(90);
                nameLabel.RenderTransform = rotate90;
                nameLabel.FontSize = 35;
                

                imgCornerLeft = 70;
                imgCornerTop = 120;

            }

            else if(huidigvak.Positie == 30)
            {
                nameTop = 910;
                imgCrdLeft = nameLeft;
                imgCrdTop = nameTop + 20;
                imgCornerLeft = left;
                imgCornerTop = top;
                if (IsSpecialCard(huidigvak.Naam))
                {
                    nameTop -= 20;
                }
            }

            priceLabel.Width = 69;
            priceLabel.Content = "€" + huidigvak.Prijs;
            priceLabel.Margin = new Thickness(left, top, 0, 0);
            priceLabel.HorizontalAlignment = HorizontalAlignment.Left;
            priceLabel.VerticalAlignment = VerticalAlignment.Top;
            priceLabel.FontSize = 16;
            priceLabel.RenderTransform = rotateTransform;
            testgrid.Children.Add(priceLabel);

            nameLabel.Width = 70;
            nameLabel.Content = huidigvak.Naam;
            nameLabel.Margin = new Thickness(nameLeft, nameTop, 0, 0);
            nameLabel.HorizontalAlignment = HorizontalAlignment.Left;
            nameLabel.VerticalAlignment = VerticalAlignment.Top;
            nameLabel.FontSize = 11;

            afbeelding.Width = 60;

            afbeelding.HorizontalAlignment = HorizontalAlignment.Left;
            afbeelding.VerticalAlignment = VerticalAlignment.Top;
            afbeelding.RenderTransform = rotateTransform;
            if (huidigvak.Naam == "Kans")
            {
                nameLabel.FontSize = 20;

                afbeelding.Margin = new Thickness(imgCrdLeft, imgCrdTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/vraagteken.JPG", UriKind.Relative));

            }

            else if (huidigvak.Naam == "Algemeen\nFonds")
            {
                afbeelding.Margin = new Thickness(imgCrdLeft, imgCrdTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/proxy.JPG", UriKind.Relative));
                priceLabel.Content = "";

            }

            else if (huidigvak.Naam == "Algemeen\nFonds" && huidigvak.Positie == 17)
            {
                afbeelding.Margin = new Thickness(imgCrdLeft + 5, 40, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/proxy.JPG", UriKind.Relative));
                priceLabel.Content = "";

            }

            else if (huidigvak.Naam.Contains("centrale"))
            {
                afbeelding.Margin = new Thickness(imgCanBuyLeft - 5, imgCanBuyTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/elektriciteit.JPG", UriKind.Relative));
            }

            else if (huidigvak.Naam.Contains("Station") || huidigvak.Naam.Contains("Spoorwegen"))
            {
                
                afbeelding.Margin = new Thickness(imgCanBuyLeft, imgCanBuyTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/trein.JPG", UriKind.Relative));
            }

            else if (huidigvak.Naam.Contains("Maatschappij"))
            {
                nameLabel.FontSize = 10;
                afbeelding.Margin = new Thickness(imgCanBuyLeft - 5, imgCanBuyTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/Kraan.JPG", UriKind.Relative));
                afbeelding.Width = 58;
            }

            else if (huidigvak.Positie == 20)
            {
                nameLabel.FontSize = 10;
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/parking.gif", UriKind.Relative));
                afbeelding.Margin = new Thickness(imgCornerLeft, imgCornerTop, 0, 0);
                priceLabel.Content = "";
            }

            else if (huidigvak.Positie == 10)
            {
                afbeelding.Margin = new Thickness(imgCornerLeft, imgCornerTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/gevangenis.png", UriKind.Relative));
                RotateTransform rotate0 = new RotateTransform(0);
                afbeelding.RenderTransform = rotate0;
                nameLabel.FontSize = 20;
                nameLabel.Width = 120;
            }

            else if(huidigvak.Positie == 30)
            {
                afbeelding.Margin = new Thickness(imgCornerLeft, imgCornerTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/agent.jpg", UriKind.Relative));
                RotateTransform rotate0 = new RotateTransform(0);
                afbeelding.RenderTransform = rotate0;
                nameLabel.FontSize = 14;
                nameLabel.Width = 120;
                priceLabel.Content = "";
            }

            testgrid.Children.Add(nameLabel);
            testgrid.Children.Add(afbeelding);
        }

        

        private static bool IsSpecialCard(string name)
        {
            return name == "Kans" || name.Contains("Station") || name == "Algemeen\nFonds" || name.Contains("Belasting") || name.Contains("centrale") || name.Contains("Spoorwegen") || name.Contains("Maatschappij");
        }

        private void showInfrastructuur_Click(object sender, RoutedEventArgs e)
        {
            //Infrastructuur infrastructuur = new Infrastructuur(new StraatVak("donkerblauw", "Nieuwstraat\nBrussel", 50, 200, 600, 1400, 1700, 2000, 200, 200, 400, 142, 39), this);
            Infrastructuur infrastructuur = new Infrastructuur(new StationVak(200, 25, 100, 480, 5, "Noord\nStation"),this);
            //Infrastructuur infrastructuur = new Infrastructuur(new Energievak(150, 75, 12, 280, "Elektriciteits-\ncentrale", "Elektriciteit"), this);
            infrastructuur.Show();
        }
    }
}
