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
    /// Interaction logic for Kans.xaml
    /// </summary>
    public partial class Kans : Window
    {
        Speler speler = new Speler();

        public Kans(Speler speler)
        {
            this.speler = speler;

            KanskaartenStapel kanskaart = new KanskaartenStapel();
            lblKansKaart.Content = kanskaart.neemKansKaart().Omschrijving;

            this.speler.aanpassingSaldo(kanskaart.neemKansKaart().Bedrag);

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnDoorgaan_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
