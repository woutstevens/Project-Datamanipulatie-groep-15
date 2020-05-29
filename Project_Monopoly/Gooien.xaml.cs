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
    /// Interaction logic for Gooien.xaml
    /// </summary>
    public partial class Gooien : Window
    {
        int Dobbelsteen1 = 0;
        int Dobbelsteen2 = 0;
        int AantalStappen = 0;
        int AantalKeerDubbel = 0;

        public Gooien()
        {


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnGooien.IsEnabled = true;

        }

        private void btnGooien_Click(object sender, RoutedEventArgs e)
        {


            Random gooien = new Random();

            Dobbelsteen1 = gooien.Next(1, 7);
            Dobbelsteen2 = gooien.Next(1, 7);
            lblDobbelsteen1.Content = Dobbelsteen1.ToString();
            lblDobbelsteen2.Content = Dobbelsteen2.ToString();
            AantalStappen += Dobbelsteen1 + Dobbelsteen2;
            AantalKeerDubbel += 1;

            if (AantalKeerDubbel == 3)
            {
                btnGooien.IsEnabled = false;
                MessageBox.Show("u moet naar de gevangenis");
            }

            if (Dobbelsteen1 != Dobbelsteen2)
            {
                btnGooien.IsEnabled = false;
            }


        }

        private void btnDoorgaan_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
