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
    /// Interaction logic for Eindscherm.xaml
    /// </summary>
    public partial class Eindscherm : Window
    {
        Speler eerst = null;
        Speler tweede = null;
        Speler derde = null;

        public Eindscherm(List<Speler> spelers)
        {
            BepaalRang(spelers);
            GegevensPrinten();
            InitializeComponent();
        }

        private void BepaalRang(List<Speler> spelers)
        {
            List<Speler> lijst = spelers;
            lijst = lijst.OrderByDescending(speler => speler.HuidigSaldo).ToList();

            eerst = lijst[0];
            tweede = lijst[1];
            if(lijst.Count > 2)
            {
                derde = lijst[2];
            }           
            
        }

        private void GegevensPrinten()
        {
            if (eerst != null)
            {
                eersteNaam.Text = eerst.Naam;
                eersteOverschot.Text = eerst.HuidigSaldo.ToString();
                eersteGevangenis.Text = eerst.VerlaatGevangenis.ToString();
            } else
            {
                eersteNaam.Text = "Niet Beschikbaar";
                eersteOverschot.Text = "";
                eersteStraten.Text = "";
                eersteHypotheek.Text = "";
                eersteGevangenis.Text = "";
                eersteVerzameld.Text = "";
            }

            if (tweede != null)
            {
                tweedeNaam.Text = tweede.Naam;
                tweedeOverschot.Text = tweede.HuidigSaldo.ToString();
                tweedeGevangenis.Text = tweede.VerlaatGevangenis.ToString();
            } else
            {
                tweedeNaam.Text = "Niet Beschikbaar";
                tweedeOverschot.Text = "";
                tweedeStraten.Text = "";
                tweedeHypotheek.Text = "";
                tweedeGevangenis.Text = "";
                tweedeVerzameld.Text = "";
            }

            if (derde != null)
            {
                derdeNaam.Text = derde.Naam;
                derdeOverschot.Text = derde.HuidigSaldo.ToString();
                derdeGevangenis.Text = derde.VerlaatGevangenis.ToString();
            } else
            {
                derdeNaam.Text = "Niet Beschikbaar";
                derdeOverschot.Text = "";
                derdeStraten.Text = "";
                derdeHypotheek.Text = "";
                derdeGevangenis.Text = "";
                derdeVerzameld.Text = "";
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
