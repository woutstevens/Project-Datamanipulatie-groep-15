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
            huidigeSpeler.aanpassingSaldo(straat.PrijsPerHuis * -1);
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

        public void VerzetSpelerNaarVak(int vakID)
        {
            if (huidigeSpeler.VakID > vakID)
            {
                huidigeSpeler.aanpassingSaldo(200);
            }
            huidigeSpeler.VakID = vakID;
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
            huidigeSpeler.aanpassingSaldo(huidigVak.Prijs * -1);
            huidigVak.Eigenaar = huidigeSpeler;
        }

        public void Betalen(EigendomVak huidigVak,int aantalGegooid)
        {
            int prijs = BerekenPrijs(huidigVak,aantalGegooid);
            huidigeSpeler.aanpassingSaldo(prijs * -1);
            huidigVak.Eigenaar.aanpassingSaldo(prijs);
        }

        public int BerekenPrijs(EigendomVak huidigVak,int aantalGegooid)
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
                int aantal = aantalInBezit(huidigVak.Eigenaar, stationVak.TypeEigendomVak);
                if(aantal == 1)
                {
                    prijs = stationVak.Huur;
                }

                else if(aantal == 2)
                {
                    prijs = stationVak.Prijs2Stations;
                }

                else if (aantal == 3)
                {
                    prijs = stationVak.Prijs3Stations;
                }

                else if (aantal == 4)
                {
                    prijs = stationVak.Prijs4Stations;
                }
            }

            else if (huidigVak.GetType() == typeof(Energievak))
            {
                energievak = (Energievak)huidigVak;
                int aantal = aantalInBezit(energievak.Eigenaar, energievak.TypeEigendomVak);
                if(aantal == 1)
                {
                    prijs = 4 * aantalGegooid;
                }

                else if(aantal == 2)
                {
                    prijs = 10 * aantalGegooid;
                }
            }

            return prijs;
        }

        private int aantalInBezit(Speler eigenaarHuidigVak, string type)
        {
            int aantal = 0;
            foreach(Spelvak spelvak in spelvakken)
            {
                if(spelvak.GetType() == typeof(EigendomVak))
                {
                    EigendomVak eigendom = (EigendomVak)spelvak;
                    if(eigendom.TypeEigendomVak == type && eigendom.Eigenaar == eigenaarHuidigVak)
                    {
                        aantal++;
                    }
                }
            }

            return aantal;
        }

        
    }
}
