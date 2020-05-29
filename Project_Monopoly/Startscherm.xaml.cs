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
        List<Pion> pionnen = new List<Pion>();
        int spelerID = 1;
        StartschermDatabaseOperaties startschermOperaties;

        public Startscherm()
        {
            InitializeComponent();
            startschermOperaties = new StartschermDatabaseOperaties();
        }
        
        public Startscherm(Settings settings)
        {
            InitializeComponent();
            lblNaamSpeler.Content = "Naam speler " + spelerID + "/" + settings.Spelers;
            this.settings = settings;
            startschermOperaties = new StartschermDatabaseOperaties();
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
            spelbord = new Spelbord(spelerslijst,this);
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
            SpelerToevoegen();

        }

        private void SpelerToevoegen()
        {
            Speler huidigeSpeler = new Speler(txtNaamSpeler.Text);
            huidigeSpeler.Pion = (Pion)CbxPionnen.SelectedItem;
            huidigeSpeler.HuidigSaldo = settings.Bedrag;
            huidigeSpeler.SpelerID = spelerID;
            int resultaat = startschermOperaties.updateSpeler(huidigeSpeler);
            if (resultaat < 0)
            {
                MessageBox.Show(startschermOperaties.getErrorMessage(), "Fout in de DAL", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            spelerslijst.Add(huidigeSpeler);
            CbxPionnen.Items.Remove(CbxPionnen.SelectedItem);
            if (spelerslijst.Count == settings.Spelers)
            {
                btnToevoegen.IsEnabled = false;
                btnStart.IsEnabled = true;
                btnStart.IsDefault = true;
                btnToevoegen.IsDefault = false;
            }
            if (CbxPionnen.Items.Count > 0)
            {
                CbxPionnen.SelectedItem = CbxPionnen.Items[0];
            }

            txtNaamSpeler.Text = "";
            spelerID++;
            if (spelerID <= settings.Spelers)
            {
                lblNaamSpeler.Content = "Naam speler " + spelerID + "/" + settings.Spelers + ":";
            }
        }

        private void CbxPionnen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtNaamSpeler_KeyUp(object sender, KeyEventArgs e)
        {
        //    if(e.Key == Key.Enter)
        //    {
        //        if(spelerslijst.Count == settings.Spelers)
        //        {

        //        }
        //        SpelerToevoegen();
        //    }
        }
    }
}
