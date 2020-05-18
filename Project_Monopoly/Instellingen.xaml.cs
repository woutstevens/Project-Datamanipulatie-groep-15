using Project_Monopoly_Models;
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

namespace Project_Monopoly
{
    /// <summary>
    /// Interaction logic for Instellingen.xaml
    /// </summary>
    public partial class Instellingen : Window
    {
        Settings instellingen = new Settings(2000, 2, false, false);

        public Instellingen()
        {
            InitializeComponent();
        }

        private void knopInstellingenTerug_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void knopInstellingenDoorgaan_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(spelerBedrag.Text, out int bedrag))
            {
                instellingen.Bedrag = int.Parse(spelerBedrag.Text);
                instellingen.Spelers = spelerAantal.Value;
                instellingen.Gevangenis = geldGevangenis.IsEnabled;
                instellingen.Parking = geldParking.IsEnabled;

                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
