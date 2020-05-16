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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Monopoly
{
    /// <summary>
    /// Interaction logic for Startscherm.xaml
    /// </summary>
    public partial class Startscherm : Window
    {
        Spelbord spelbord = new Spelbord();
        Instellingen instellingen = new Instellingen();
        

        public Startscherm()
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            spelbord.Show();
            this.Close();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            instellingen.Show();
            this.Close();
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
