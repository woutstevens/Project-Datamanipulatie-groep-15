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
    /// Interaction logic for Eindscherm.xaml
    /// </summary>
    public partial class Eindscherm : Window
    {
        


        public Eindscherm()
        {
            List<Monopoly_DAL.Speler> spelers = DatabaseOperations.OphalenBesteSpelers();
            GegevensPrinten(spelers);
            InitializeComponent();
        }

        private void GegevensPrinten(List<Monopoly_DAL.Speler> spelers)
        {
            if (spelers[0] != null)
            {
                List<Monopoly_DAL.Spelvak> straten = DatabaseOperations.OphalenStraten(spelers[0].naam);
                int hypotheek = 0;
                foreach(Monopoly_DAL.Spelvak spelvak in straten)
                {
                    hypotheek += spelvak.hypotheekwaarde;
                }

                eersteNaam.Text = spelers[0].naam;
                eersteOverschot.Text = spelers[0].huidigSaldo.ToString();
                eersteGevangenis.Text = spelers[0].verlaatGevangenis.ToString();
                eersteStraten.Text = straten.Count().ToString();
                eersteHypotheek.Text = hypotheek.ToString();
                
            } else
            {
                eersteNaam.Text = "Niet Beschikbaar";
                eersteOverschot.Text = "";
                eersteStraten.Text = "";
                eersteHypotheek.Text = "";
                eersteGevangenis.Text = "";
                eersteVerzameld.Text = "";
            }

            if (spelers[1] != null)
            {
                List<Monopoly_DAL.Spelvak> straten = DatabaseOperations.OphalenStraten(spelers[1].naam);
                int hypotheek = 0;
                foreach (Monopoly_DAL.Spelvak spelvak in straten)
                {
                    hypotheek += spelvak.hypotheekwaarde;
                }

                tweedeNaam.Text = spelers[1].naam;
                tweedeOverschot.Text = spelers[1].huidigSaldo.ToString();
                tweedeGevangenis.Text = spelers[1].verlaatGevangenis.ToString();
                tweedeStraten.Text = straten.Count().ToString();
                tweedeHypotheek.Text = hypotheek.ToString();

            }
            else
            {
                tweedeNaam.Text = "Niet Beschikbaar";
                tweedeOverschot.Text = "";
                tweedeStraten.Text = "";
                tweedeHypotheek.Text = "";
                tweedeGevangenis.Text = "";
                tweedeVerzameld.Text = "";
            }

            if (spelers[2] != null)
            {
                List<Monopoly_DAL.Spelvak> straten = DatabaseOperations.OphalenStraten(spelers[2].naam);
                int hypotheek = 0;
                foreach (Monopoly_DAL.Spelvak spelvak in straten)
                {
                    hypotheek += spelvak.hypotheekwaarde;
                }

                derdeNaam.Text = spelers[2].naam;
                derdeOverschot.Text = spelers[2].huidigSaldo.ToString();
                derdeGevangenis.Text = spelers[2].verlaatGevangenis.ToString();
                derdeStraten.Text = straten.Count().ToString();
                derdeHypotheek.Text = hypotheek.ToString();

            }
            else
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
