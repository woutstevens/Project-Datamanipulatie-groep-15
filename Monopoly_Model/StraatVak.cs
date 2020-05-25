using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class StraatVak:EigendomVak
    {
        private int _prijsZonderHuis;
        private int _prijsMet1Huis;
        private int _prijsMet2Huizen;
        private int _prijsMet3Huizen;
        private int _prijsMet4Huizen;
        private int _prijsMet1Hotel;
        private int _prijsPerHuis;
        private int _aantalHuizen;
        private int _aantalHotels;
        

        public int PrijsZonderHuis { get => _prijsZonderHuis; set => _prijsZonderHuis = value; }
        public int PrijsMet1Huis { get => _prijsMet1Huis; set => _prijsMet1Huis = value; }
        public int PrijsMet2Huizen { get => _prijsMet2Huizen; set => _prijsMet2Huizen = value; }
        public int PrijsMet3Huizen { get => _prijsMet3Huizen; set => _prijsMet3Huizen = value; }
        public int PrijsMet4Huizen { get => _prijsMet4Huizen; set => _prijsMet4Huizen = value; }
        public int PrijsMet1Hotel { get => _prijsMet1Hotel; set => _prijsMet1Hotel = value; }
        public int PrijsPerHuis { get => _prijsPerHuis; set => _prijsPerHuis = value; }
        public int AantalHuizen { get => _aantalHuizen; set => _aantalHuizen = value; }
        public int AantalHotels { get => _aantalHotels; set => _aantalHotels = value; }

        public StraatVak()
        {
            
        }

        public StraatVak(string kleur, string straatNaam, int prijsZonderHuis, int prijsMet1Huis, int prijsMet2Huizen, int prijsMet3Huizen, int prijsMet4Huizen, int prijsMet1Hotel, int prijsPerHuis, int hypotheekWaarde, int aankoopWaarde, int variabeleWaarde,int positie) : base(null, kleur, "straat", aankoopWaarde, hypotheekWaarde,positie, variabeleWaarde,straatNaam)
        {
            _prijsZonderHuis = prijsZonderHuis;
            _prijsMet1Huis = prijsMet1Huis;
            _prijsMet2Huizen = prijsMet2Huizen;
            _prijsMet3Huizen = prijsMet3Huizen;
            _prijsMet4Huizen = prijsMet4Huizen;
            _prijsMet1Hotel = prijsMet1Hotel;
            _prijsPerHuis = prijsPerHuis;
        }

        public int GetTeBetalen()
        {
            int bedrag = 0;
            if(AantalHotels == 0)
            {
                if(AantalHuizen == 0)
                {
                    bedrag = PrijsZonderHuis;
                }

                else if(AantalHuizen == 1)
                {
                    bedrag = PrijsMet1Huis;
                }

                else if (AantalHuizen == 2)
                {
                    bedrag = PrijsMet2Huizen;
                }

                else if (AantalHuizen == 3)
                {
                    bedrag = PrijsMet3Huizen;
                }

                else
                {
                    bedrag = PrijsMet4Huizen;
                }
            }

            else
            {
                bedrag = PrijsMet1Hotel;
            }

            return bedrag;
        }
    }
}
