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
using Monopoly_DAL;

namespace Project_Monopoly
{
    /// <summary>
    /// Interaction logic for KansVerwijderen.xaml
    /// </summary>
    public partial class KansVerwijderen : Window
    {
        public KansVerwijderen()
        {
            InitializeComponent();
            List<Monopoly_DAL.Kans> kanskaarten = DatabaseOperations.OphalenKanskaarten();
            if (kanskaarten != null)
            {
                datagridKanskaarten.ItemsSource = kanskaarten;
            }
            else
            {
                MessageBox.Show("Er zijn geen kanskaarten gevonden");
            }
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Kanskaart");

            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                Monopoly_DAL.Kans kans = datagridKanskaarten.SelectedItem as Monopoly_DAL.Kans;
                int ok = DatabaseOperations.VerwijderenKanskaart(kans);

                if (ok > 0)
                {
                    datagridKanskaarten.ItemsSource = DatabaseOperations.OphalenKanskaarten();
                }
                else
                {
                    MessageBox.Show("Kanskaart is niet verwijderd.");
                }
            }

            else
            {
                MessageBox.Show(foutmeldingen);
            }
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string Valideer (string column)
        {
            if(column == "Kanskaart" && datagridKanskaarten.SelectedItem == null)
            {
                return "Selecteer een kanskaart!" + Environment.NewLine;
            }
            return "";
        }
    }
}
