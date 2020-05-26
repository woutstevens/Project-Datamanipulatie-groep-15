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
        

        public Kans()
        {
            List<Monopoly_DAL.Kans> kanskaarten = DatabaseOperations.OphalenKanskaarten();
            Monopoly_DAL.Kans kans = null;
            Random rand = new Random();
            kans = kanskaarten[rand.Next(0,kanskaarten.Count())];

            lblKansKaart.Content = kans.omschrijving;

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
