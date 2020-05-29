using Project_Monopoly_Models;
using Monopoly_DAL;
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
        Settings instellingen = new Settings();

        public Instellingen()
        {
            InitializeComponent();
        }


        private void knopInstellingenDoorgaan_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(spelerBedrag.Text, out int bedrag))
            {
                instellingen.Bedrag = int.Parse(spelerBedrag.Text);
                instellingen.Spelers = (int)spelerAantal.Value;
                instellingen.Gevangenis = geldGevangenis.IsEnabled;
                instellingen.Parking = geldParking.IsEnabled;

                Startscherm startscherm = new Startscherm(instellingen);
                startscherm.Show();

                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void knopInstellingenTerug_Click(object sender, RoutedEventArgs e)
        {
            Startscherm startscherm = new Startscherm();
            startscherm.Show();
            this.Close();
        }

        private void btnKansToevoegen_Click(object sender, RoutedEventArgs e)
        {
            KansToevoegen kansToevoegen = new KansToevoegen();
            kansToevoegen.Show();
        }

        private void btnKansVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            KansVerwijderen kansVerwijderen = new KansVerwijderen();
            kansVerwijderen.Show();
        }
    }
}
