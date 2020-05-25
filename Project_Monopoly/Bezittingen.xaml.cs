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
    /// Interaction logic for Bezittingen.xaml
    /// </summary>
    public partial class Bezittingen : Window
    {
        public Bezittingen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Speler1_Click(object sender, RoutedEventArgs e)
        {
            BezittingenSpeler1 BezittingenSpeler1 = new BezittingenSpeler1();
            BezittingenSpeler1.Show();
        }

        private void Speler2_Click(object sender, RoutedEventArgs e)
        {
            BezittingenSpeler2 BezittingenSpeler2 = new BezittingenSpeler2();
            BezittingenSpeler2.Show();
        }

        private void Speler3_Click(object sender, RoutedEventArgs e)
        {
            BezittingenSpeler3 BezittingenSpeler3 = new BezittingenSpeler3();
            BezittingenSpeler3.Show();
        }

        private void Speler4_Click(object sender, RoutedEventArgs e)
        {
            BezittingenSpeler4 BezittingenSpeler4 = new BezittingenSpeler4();
            BezittingenSpeler4.Show();
        }
    }
}
