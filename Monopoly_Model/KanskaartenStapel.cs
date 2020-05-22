using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class KanskaartenStapel
    {
        private List<KansKaart> kanskaarten = new List<KansKaart>();
        Random random = new Random();
        public KanskaartenStapel()
        {
            kanskaarten.Add(new KansKaart(150, 0, "Betaal schoolgeld €150", false));
            kanskaarten.Add(new KansKaart(0, 3, "Ga drie plaatsen terug", false));
            kanskaarten.Add(new KansKaart(-15, 0, "Boete voor te snel rijden: €15", false));
            kanskaarten.Add(new KansKaart(0, 0, "Verlaat de gevangenis zonder betalen", true));
            kanskaarten.Add(new KansKaart(0, 0, "Ga direct naar de gevangenis.\nGa niet langs \"start\",\nu ontvangt geen €200", false));
            kanskaarten.Add(new KansKaart(150, 0, "Uw bouwverzekering vervalt,\nU ontvangt €150", false));
            kanskaarten.Add(new KansKaart(-20, 0, "Opgepakt wegens dronkenschap:\n€ 20 boete", false));
            kanskaarten.Add(new KansKaart(0, 0, "Herstel uw huizen.\nBetaal voor elk huis €25", false));
            kanskaarten.Add(new KansKaart(50, 0, "De bank betaald u\n€50 dividend", false));
            kanskaarten.Add(new KansKaart(0, 0, "Reis naar centraal station.\nindien u langs start komt,\nontvangt u €200", false));
            kanskaarten.Add(new KansKaart(0, 0, "Ga verder naar Grand place (Mons).\nindien u langs start komt,\nontvangt u €200", false));
            kanskaarten.Add(new KansKaart(0, 0, "Ga verder naar Rue de Diekirch (Arlon).\nindien u langs start komt,\nontvangt u €200", false));
            kanskaarten.Add(new KansKaart(0, 0, "Ga verder naar Nieuwstraat (Brussel)", false));
            kanskaarten.Add(new KansKaart(0, 0, "Ga verder naar Start", false));
            kanskaarten.Add(new KansKaart(0, 0, "U wordt aangeslagen voor straatgeld\nbetaal €40 per huis", false));
            kanskaarten = kanskaarten.OrderBy(x => random.Next(0, 15)).ToList();
        }

        public KansKaart neemKansKaart()
        {
            return kanskaarten[0];
        }

         
    }
}
