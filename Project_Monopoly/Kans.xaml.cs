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
using Monopoly_DAL;

namespace Project_Monopoly
{
    /// <summary>
    /// Interaction logic for Kans.xaml
    /// </summary>
    public partial class Kans : Window
    {
        Spelbord spelbord;
        Monopoly_DAL.Kans kans = null;
        public Kans(Spelbord spelbord)
        {
            InitializeComponent();
            this.spelbord = spelbord;
            List<Monopoly_DAL.Kans> kanskaarten = DatabaseOperations.OphalenKanskaarten();
            
            Random rand = new Random();
            kans = kanskaarten[rand.Next(0,kanskaarten.Count())];

            lblKansKaart.Content = VervangBackslash(kans.omschrijving);

            
        }

        private string VervangBackslash(string naam)
        {

            string vervangNaam = naam;

            if (naam != null)
            {
                vervangNaam = naam.Replace("\\n", "\n");
            }
            return vervangNaam;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnDoorgaan_Click(object sender, RoutedEventArgs e)
        {
            spelbord.WijzigSaldo(Convert.ToInt32(kans.bedrag));
            if(Convert.ToInt32(kans.bedrag) < 0)
            {
                spelbord.WijzigPot(Convert.ToInt32(kans.bedrag) * -1);
            }

            if (kans.omschrijving.Contains("naar")) 
            {
                spelbord.VerzetSpelerNaarVak(Convert.ToInt32(kans.aantalPosities));
            } else
            {
                spelbord.VerzetSpeler(Convert.ToInt32(kans.aantalPosities));
            }
                

            this.Close();
        }
    }
}
