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
using Monopoly_Model;
using Project_Monopoly_Models;

namespace Project_Monopoly
{
    /// <summary>
    /// Interaction logic for Startscherm.xaml
    /// </summary>
    public partial class Startscherm : Window
    {
        
        Settings settings = new Settings();        
        Instellingen instellingen = new Instellingen();
        List<Speler> spelerslijst = new List<Speler>();
        Spelbord spelbord;
        int aantal = 2;
        List<Pion> pionnen = new List<Pion>();
        
        public Startscherm()
        {
            InitializeComponent();
        }
        
        public Startscherm(Settings settings)
        {
            this.settings = settings;
            InitializeComponent();
        }

        private void setPionnenLijst()
        {
            pionnen.Add(new Pion("Rood"));
            pionnen.Add(new Pion("Blauw"));
            pionnen.Add(new Pion("groen"));
            pionnen.Add(new Pion("Paars"));
            pionnen.Add(new Pion("Zwart"));
            pionnen.Add(new Pion("Geel"));
        }

        private void SetComboBox()
        {
            setPionnenLijst();
            foreach (Pion pion in pionnen)
            {
                CbxPionnen.Items.Add(pion);
            }
            CbxPionnen.SelectedItem = CbxPionnen.Items[0];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            spelbord = new Spelbord(spelerslijst);
            btnStart.IsEnabled = false;
            SetComboBox();
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
            Speler huidigeSpeler = new Speler(txtNaamSpeler.Text);
            huidigeSpeler.Pion = pionnen[CbxPionnen.SelectedIndex];
            spelerslijst.Add(huidigeSpeler);
            CbxPionnen.Items.Remove(CbxPionnen.SelectedItem);
            if (spelerslijst.Count == aantal)
            {
                btnToevoegen.IsEnabled = false;
                btnStart.IsEnabled = true;
            }
            CbxPionnen.SelectedItem = CbxPionnen.Items[0];
            txtNaamSpeler.Text = "";
        }

        private void CbxPionnen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
