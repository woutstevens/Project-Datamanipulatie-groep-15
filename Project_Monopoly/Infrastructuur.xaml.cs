using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Monopoly_Model;

namespace Project_Monopoly
{
    /// <summary>
    /// Interaction logic for Infrastructuur.xaml
    /// </summary>
    public partial class Infrastructuur : Window
    {
        EigendomVak huidigVak;
        StraatVak huidigStraatVak;
        Spelbord spelbord;
        Speler huidigeSpeler;
        public Infrastructuur(EigendomVak eigendomVak,Spelbord spelBord)
        {
            InitializeComponent();
            huidigVak = eigendomVak;
            spelbord = spelBord;
            EnableDisableButtons();
            this.Title = "Infrastructuur - " + spelbord.getHuidigeSpeler().Naam;
            huidigeSpeler = spelbord.getHuidigeSpeler();
        }

        private void EnableDisableButtons()
        {
            

            if(huidigVak.Eigenaar != null && huidigVak.Eigenaar != spelbord.getHuidigeSpeler())
            {
                btnHuisKopen.IsEnabled = false;
                btnKopen.IsEnabled = false;
                btnNietKopen.IsEnabled = false;
                btnBetalen.IsEnabled = true;
            }

            else if(huidigVak.Eigenaar != null && huidigVak.Eigenaar == spelbord.getHuidigeSpeler())
            {
                if(huidigVak.GetType() == typeof(StraatVak))
                {
                    huidigStraatVak = (StraatVak)huidigVak;
                    if(spelbord.getHuidigeSpeler().HuidigSaldo > huidigStraatVak.PrijsPerHuis)
                    {
                        btnHuisKopen.IsEnabled = true;
                        btnKopen.IsEnabled = false;
                        btnNietKopen.IsEnabled = false;
                        btnBetalen.IsEnabled = false;
                    }
                }
                else
                {
                    btnHuisKopen.IsEnabled = false;
                    btnKopen.IsEnabled = false;
                    btnNietKopen.IsEnabled = false;
                    btnBetalen.IsEnabled = false;
                }
            }
            else
            {
                btnHuisKopen.IsEnabled = false;
                btnKopen.IsEnabled = true;
                btnNietKopen.IsEnabled = true;
                btnBetalen.IsEnabled = false;
            }
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            Kaart.Stroke = Brushes.Black;
            Color.Stroke = Brushes.Black;
            
            setKleur();
            setLabels();
        }

        private void setLabels()
        {
            StraatVak straatVak;
            Energievak energievak;
            StationVak stationVak;
            if(huidigVak.Eigenaar == null)
            {
                lblBoodschap.Content = "Deze kaart is nog niet in iemands bezit.\nU kunt deze kaart dus kopen.";
            }
            
            else if(huidigVak.Eigenaar != spelbord.getHuidigeSpeler())
            {
                lblBoodschap.Content = "Deze kaart is van " + huidigVak.Eigenaar.Naam + ". Betaal €" + spelbord.Berekenprijs(huidigVak, spelbord.aantalgegooid); 
            }

            else
            {
                lblBoodschap.Content = "Deze kaart is van jou,\nals je wilt kan je huizen voor deze straat kopen.";
            }

            lblStraatnaam.Content = huidigVak.Naam;

            if (huidigVak.GetType() == typeof(StraatVak)) 
            {
                straatVak = (StraatVak)huidigVak;
                lblHuurPrijs.Content = straatVak.PrijsZonderHuis.ToString();
                lblPrijs1Huis.Content = straatVak.PrijsMet1Huis.ToString();
                lblPrijs2Huizen.Content = straatVak.PrijsMet2Huizen.ToString();
                lblPrijs3Huizen.Content = straatVak.PrijsMet3Huizen.ToString();
                lblPrijs4Huizen.Content = straatVak.PrijsMet4Huizen.ToString();
                lblPrijs1Hotel.Content = straatVak.PrijsMet1Hotel.ToString();
                lblPrijsHuis.Content = straatVak.PrijsPerHuis.ToString();
                lblPrijsHypotheek.Content = straatVak.HypotheekWaarde.ToString();
                if (straatVak.AantalHuizen == 4 && straatVak.AantalHotels == 1)
                {
                    btnHuisKopen.IsEnabled = false;
                }
            }

            else if(huidigVak.GetType() == typeof(StationVak))
            {
                stationVak = (StationVak)huidigVak;
                lblHuur.Content = "Huur";
                lblHuurPrijs.Content = stationVak.Huur.ToString();

                lblMet1Huis.Content = "2 stations in bezit";
                lblPrijs1Huis.Content = stationVak.Prijs2Stations.ToString();

                lblMet2Huizen.Content = "3 stations in bezit".ToString();
                lblPrijs2Huizen.Content = stationVak.Prijs3Stations;

                lblMet3Huizen.Content = "4 stations in bezit".ToString();
                lblPrijs3Huizen.Content = stationVak.Prijs4Stations;

                lblMet4Huizen.Content = "Hypotheekwaarde";
                lblPrijs4Huizen.Content = stationVak.HypotheekWaarde.ToString();

                lblHuis.Content = "";
                lblPrijsHuis.Content = "";
                lblMet1Hotel.Content = "";
                lblPrijs1Hotel.Content = "";
                lblHypotheekwaarde.Content = "";
                lblPrijsHypotheek.Content = "";
            }

            else if(huidigVak.GetType() == typeof(Energievak))
            {
                energievak = (Energievak)huidigVak;
                lblHuur.Content = "Huur";
                lblHuurPrijs.Content = "4 keer het aantal\nogen van de worp";
                lblHuur.Height = 100;
                lblHuurPrijs.Height = 100;

                lblMet1Huis.Content = "";
                lblPrijs1Huis.Content = "";

                lblMet3Huizen.Content = "";
                lblPrijs3Huizen.Content = "";

                lblMet4Huizen.Content = "";
                lblPrijs4Huizen.Content = "";

                lblHuis.Content = "";
                lblPrijsHuis.Content = "";
                lblMet1Hotel.Content = "";
                lblPrijs1Hotel.Content = "";
                lblHypotheekwaarde.Content = "";
                lblPrijsHypotheek.Content = "";

                lblPrijs2Huizen.Content = "10 keer het aantal\nogen van de worp";
                lblMet2Huizen.Height = 100;
                lblMet2Huizen.Width = 152;
                lblPrijs2Huizen.Height = 100;


                if (energievak.TypeEnergie.ToLower() == "water")
                {
                    lblMet2Huizen.Content = "Indien ook in het bezit\n elektriciteitscentrale";
                    
                }

                else if(energievak.TypeEnergie.ToLower() == "elektriciteit")
                {
                    lblMet2Huizen.Content = "Indien ook in het bezit\nvan watermaatschappij";
                }

            }
        }
        private void setKleur()
        {

            if (huidigVak.Kleur.ToLower() == "bruin")
            {
                Color.Fill = new SolidColorBrush(Colors.Brown);
            }

            else if (huidigVak.Kleur.ToLower() == "lichtblauw")
            {
                Color.Fill = new SolidColorBrush(Colors.LightBlue);
            }

            else if (huidigVak.Kleur.ToLower() == "roze")
            {
                Color.Fill = new SolidColorBrush(Colors.DeepPink);
            }

            else if (huidigVak.Kleur.ToLower() == "oranje")
            {
                Color.Fill = new SolidColorBrush(Colors.Orange);
            }

            else if (huidigVak.Kleur.ToLower() == "rood")
            {
                Color.Fill = new SolidColorBrush(Colors.Red);
            }

            else if (huidigVak.Kleur.ToLower() == "geel")
            {
                Color.Fill = new SolidColorBrush(Colors.Yellow);
            }

            else if (huidigVak.Kleur.ToLower() == "groen")
            {
                Color.Fill = new SolidColorBrush(Colors.Green);
            }

            else if (huidigVak.Kleur.ToLower() == "donkerblauw")
            {
                Color.Fill = new SolidColorBrush(Colors.DarkBlue); 
                lblStraatnaam.Foreground = new SolidColorBrush(Colors.White);
            }

            else if(huidigVak.Kleur.ToLower() == "wit")
            {
                Color.Fill = new SolidColorBrush(Colors.White);

            }
            }


        private void btnKopen_Click(object sender, RoutedEventArgs e)
        {
            
            spelbord.Kopen(huidigVak);
            this.Close();
        }

        private bool CheckSaldo(int bedrag)
        {
            bool kanKopen = true;
            if(bedrag >= huidigeSpeler.HuidigSaldo)
            {
                kanKopen = false;
            }
            return kanKopen;
        }

        private void btnNietKopen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBetalen_Click(object sender, RoutedEventArgs e)
        {
            spelbord.Betalen(huidigVak,spelbord.aantalgegooid);
            this.Close();
        }

        private void btnHuisKopen_Click(object sender, RoutedEventArgs e)
        {
            spelbord.KoopHuis(huidigStraatVak);
            if(huidigStraatVak.AantalHuizen == 4 && huidigStraatVak.AantalHotels == 1)
            {
                btnHuisKopen.IsEnabled = false;
            }
        }
    }
    }

