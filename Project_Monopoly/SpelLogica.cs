using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly_Model;

namespace Project_Monopoly
{
    public class SpelLogica
    {
        List<Spelvak> spelvakken;
        Speler huidigeSpeler;
        public SpelLogica(List<Spelvak> spelvakken)
        {
            this.spelvakken = spelvakken;

        }

        public void huisKopen(StraatVak straat)
        {
            huidigeSpeler.aanpassingSaldo(straat.PrijsPerHuis);
            straat.AantalHuizen++;
        }

        public Spelvak HaalSpelvakOp(int vakID)
        {
            Spelvak huidigVak = null;
            foreach (Spelvak spelvak in spelvakken)
            {
                if (spelvak.Positie == vakID)
                {
                    huidigVak = spelvak;
                    return huidigVak;
                }
            }

            return huidigVak;
        }

        public void GaLangsStart()
        {
            huidigeSpeler.VakID = huidigeSpeler.VakID - (spelvakken.Count + 1);
            huidigeSpeler.aanpassingSaldo(200);
        }

        public void setHuidigeSpeler(Speler speler)
        {
            huidigeSpeler = speler;
        }

        public void VerzetSpeler(int aantalVakjes)
        {
            huidigeSpeler.VakID += aantalVakjes;
            if (huidigeSpeler.VakID >= spelvakken.Count)
            {
                GaLangsStart();
            }
        }

        public void WijzigSaldo(int bedrag)
        {
            huidigeSpeler.aanpassingSaldo(bedrag);
        }

        public void NaarDeGevangenis()
        {
            huidigeSpeler.VakID = 10;
            huidigeSpeler.Gevangenis = true;
        }


        public void Kopen(EigendomVak huidigVak)
        {
            huidigeSpeler.aanpassingSaldo(huidigVak.Prijs);
            huidigVak.Eigenaar = huidigeSpeler;
        }

        public void Betalen(EigendomVak huidigVak)
        {
            int prijs = BerekenPrijs(huidigVak);
            huidigeSpeler.aanpassingSaldo(prijs * -1);
            huidigVak.Eigenaar.aanpassingSaldo(prijs);
        }

        private int BerekenPrijs(EigendomVak huidigVak)
        {
            int prijs = 0;
            StraatVak straatVak;
            StationVak stationVak;
            Energievak energievak;
            if (huidigVak.GetType() == typeof(StraatVak))
            {
                straatVak = (StraatVak)huidigVak;
                prijs =  straatVak.GetTeBetalen();

            }

            else if (huidigVak.GetType() == typeof(StationVak))
            {
                stationVak = (StationVak)huidigVak;

            }

            else if (huidigVak.GetType() == typeof(Energievak))
            {
                energievak = (Energievak)huidigVak;




            }

            return prijs;
        }
    }
}
