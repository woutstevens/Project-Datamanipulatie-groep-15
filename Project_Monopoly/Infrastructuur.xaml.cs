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
        
        StraatVak straatVak = new StraatVak("donkerblauw", "Nieuwstraat\nBrussel", 50, 200, 600, 1400, 1700, 2000, 200, 200, 400, 142, 39);
        public Infrastructuur(EigendomVak eigendomVak)
        {
            InitializeComponent();
            huidigVak = eigendomVak;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            Kaart.Stroke = Brushes.Black;
            
            setKleur();
            setLabels();
        }

        private void setLabels()
        {
            if(huidigVak.TypeEigendomVak.ToLower() == "straat")
            {
                lblStraatnaam.Content = straatVak.Naam;
                lblHuurPrijs.Content = straatVak.PrijsZonderHuis.ToString();
                lblPrijs1Huis.Content = straatVak.PrijsMet1Huis.ToString();
                lblPrijs2Huizen.Content = straatVak.PrijsMet2Huizen.ToString();
                lblPrijs3Huizen.Content = straatVak.PrijsMet3Huizen.ToString();
                lblPrijs4Huizen.Content = straatVak.PrijsMet4Huizen.ToString();
                lblPrijs1Hotel.Content = straatVak.PrijsMet1Hotel.ToString();
                lblHypotheekwaarde.Content = straatVak.HypotheekWaarde.ToString();
            }
        }
        private void setKleur()
        {

            if (straatVak.Kleur == "Bruin")
            {
                Color.Fill = new SolidColorBrush(Colors.Brown);
            }

            else if (straatVak.Kleur == "Lichtblauw")
            {
                Color.Fill = new SolidColorBrush(Colors.LightBlue);
            }

            else if (straatVak.Kleur == "Roze")
            {
                Color.Fill = new SolidColorBrush(Colors.DeepPink);
            }

            else if (straatVak.Kleur == "Oranje")
            {
                Color.Fill = new SolidColorBrush(Colors.Orange);
            }

            else if (straatVak.Kleur == "Rood")
            {
                Color.Fill = new SolidColorBrush(Colors.Red);
            }

            else if (straatVak.Kleur == "Geel")
            {
                Color.Fill = new SolidColorBrush(Colors.Yellow);
            }

            else if (straatVak.Kleur == "Groen")
            {
                Color.Fill = new SolidColorBrush(Colors.Green);
            }

            else if (straatVak.Kleur.ToLower() == "donkerblauw")
            {
                Color.Fill = new SolidColorBrush(Colors.DarkBlue);
                lblStraatnaam.Foreground = new SolidColorBrush(Colors.White);
            }
            }
        }
    }

