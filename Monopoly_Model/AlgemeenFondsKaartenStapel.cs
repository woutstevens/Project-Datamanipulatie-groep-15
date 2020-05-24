using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class AlgemeenFondsKaartenStapel
    {
        List<AlgemeenFondsKaart> algemeenFondsKaarten = new List<AlgemeenFondsKaart>();
        Random random = new Random();
        public AlgemeenFondsKaartenStapel()
        {
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(200, 0, "Een vergissing van de bank in uw voordeel,\nu ontvangt €200", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(-10, 0, "Betaal €10 boete", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(-50, 0, "Betaal uw doktersrekening\n€50", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(-50, 0, "Betaal uw verzekeringspremie\n€50", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(-10, 0, "Betaal het hospitaal\n€100", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(-10, 0, "Ga terug naar Rue Grande (Dinant)", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(-100, 0, "Lijfrente vervalt,\nu ontvangt €100", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(100, 0, "U erft €100", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(10, 0, "U bent jarig en ontvangt van elke speler €10", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(0, 0, "Verlaat de gevangenis zonder betalen", true));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(20, 0, "Terugbetaling inkomstenbelasting,\nu ontvangt €20", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(-50, 0, "Door verkoop van effecten\nontvangt u €50", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(100, 0, "Een vergissing van de bank in uw voordeel,\nu ontvangt €100", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(0, 0, "Ga verder naar Start", false));
            algemeenFondsKaarten.Add(new AlgemeenFondsKaart(0, 0, "Ga direct naar de gevangenis.\nGa niet langs \"start\",\nu ontvangt geen €200", false));
            algemeenFondsKaarten = algemeenFondsKaarten.OrderBy(x => random.Next(0, 15)).ToList();
        }

        public string generateSQL()
        {
            string sqlString = "";
            foreach (AlgemeenFondsKaart algemeenfondskaart in algemeenFondsKaarten)
            {
                sqlString += "insert into Kans(type,omschrijving,bedrag,aantalPosities,houbij) values (";
                sqlString += "'Algemeen Fonds'" + ",";
                sqlString += "'" + algemeenfondskaart.Omschrijving + "',";
                sqlString += algemeenfondskaart.Bedrag + ",";
                sqlString += algemeenfondskaart.AantalPosities + ",";
                if (algemeenfondskaart.HouBij == false)
                {
                    sqlString += 0;
                }

                else
                {
                    sqlString += 1;
                }
                sqlString += ");\n";
            }

            return sqlString;
        }
    }
}
