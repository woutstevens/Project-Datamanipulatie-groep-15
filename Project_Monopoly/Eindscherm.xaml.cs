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
        List<Monopoly_Model.Speler> spelers;
        Monopoly_Model.Speler eerste = null;
        Monopoly_Model.Speler tweede = null;
        Monopoly_Model.Speler derde = null;
        List<Monopoly_Model.Spelvak> spelvakken;
        public Eindscherm(List<Monopoly_Model.Speler> spelers,List<Monopoly_Model.Spelvak> spelvakken)
        {
            this.spelers = spelers;
            this.spelvakken = spelvakken;
            InitializeComponent();
            GetPodiumPlaatsen();
            GegevensPrinten(spelers);
        }

        private void GetPodiumPlaatsen()
        {
            foreach(Monopoly_Model.Speler speler in spelers)
            {
                if(speler.Rangschrikking == 1)
                {
                    eerste = speler;
                }

                else if (speler.Rangschrikking == 2)
                {
                    tweede = speler;
                }

                else if (speler.Rangschrikking == 3)
                {
                    derde = speler;
                }
            }
        }

        private void GegevensPrinten(List<Monopoly_Model.Speler> spelers)
        {
            if (eerste != null)
            {
                int hypotheek = 0;
                int aantalStraten = 0;
                foreach(Monopoly_Model.Spelvak spelvak in spelvakken)
                {
                    if(spelvak.GetType() == typeof(StraatVak) || spelvak.GetType() == typeof(Energievak) || spelvak.GetType() == typeof(StationVak))
                    {
                        EigendomVak eigendom = (EigendomVak)spelvak;
                        if (eigendom.Eigenaar == eerste)
                        {
                            hypotheek += eigendom.HypotheekWaarde;
                            aantalStraten++;
                        }
                    }
                }

                eersteNaam.Text = eerste.Naam;
                eersteOverschot.Text = "Saldo bij afsluiten van het spel: "  + eerste.HuidigSaldo.ToString();
                eersteGevangenis.Text = "Verlaat de gevangenis: " +  eerste.VerlaatGevangenis.ToString();
                eersteStraten.Text = "Aantal straten: " + aantalStraten.ToString();
                eersteHypotheek.Text = "Totale hypotheekwaarde: " + hypotheek.ToString();
                
            } else
            {
                eersteNaam.Text = "Niet Beschikbaar";
                eersteOverschot.Text = "";
                eersteStraten.Text = "";
                eersteHypotheek.Text = "";
                eersteGevangenis.Text = "";
                
            }

            if (tweede != null)
            {
                int hypotheek = 0;
                int aantalStraten = 0;
                foreach (Monopoly_Model.Spelvak spelvak in spelvakken)
                {
                    if (spelvak.GetType() == typeof(StraatVak) || spelvak.GetType() == typeof(Energievak) || spelvak.GetType() == typeof(StationVak))
                    {
                        EigendomVak eigendom = (EigendomVak)spelvak;
                        if(eigendom.Eigenaar == tweede)
                        {
                            hypotheek += eigendom.HypotheekWaarde;
                            aantalStraten++;
                        }
                        
                    }
                }

                tweedeNaam.Text = tweede.Naam;
                tweedeOverschot.Text = "Saldo bij afsluiten van het spel: " + tweede.HuidigSaldo.ToString();
                tweedeGevangenis.Text = "Verlaat de gevangenis: " + tweede.VerlaatGevangenis.ToString();
                tweedeStraten.Text = "Aantal straten: " + aantalStraten.ToString();
                tweedeHypotheek.Text = "Totale hypotheekwaarde: " + hypotheek.ToString();

            }
            else
            {
                tweedeNaam.Text = "Niet Beschikbaar";
                tweedeOverschot.Text = "";
                tweedeStraten.Text = "";
                tweedeHypotheek.Text = "";
                tweedeGevangenis.Text = "";
            }

            if (derde != null)
            {
                int hypotheek = 0;
                int aantalStraten = 0;
                foreach (Monopoly_Model.Spelvak spelvak in spelvakken)
                {
                    if (spelvak.GetType() == typeof(StraatVak) || spelvak.GetType() == typeof(Energievak) || spelvak.GetType() == typeof(StationVak))
                    {
                        EigendomVak eigendom = (EigendomVak)spelvak;
                        if (eigendom.Eigenaar == derde)
                        {
                            hypotheek += eigendom.HypotheekWaarde;
                            aantalStraten++;
                        }
                    }
                }

                derdeNaam.Text = derde.Naam;
                derdeOverschot.Text = "Saldo bij afsluiten van het spel: " + derde.HuidigSaldo.ToString();
                derdeGevangenis.Text = "Verlaat de gevangenis: " + derde.VerlaatGevangenis.ToString();
                derdeStraten.Text = "Aantal straten: " + aantalStraten.ToString();
                derdeHypotheek.Text = "Totale hypotheekwaarde: " + hypotheek.ToString();

            }
            else
            {
                derdeNaam.Text = "Niet Beschikbaar";
                derdeOverschot.Text = "";
                derdeStraten.Text = "";
                derdeHypotheek.Text = "";
                derdeGevangenis.Text = "";
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
