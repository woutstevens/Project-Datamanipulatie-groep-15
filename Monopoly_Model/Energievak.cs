using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class Energievak:EigendomVak
    {
        private int _aantalKeerOgen;
        private string _typeEnergie;

        public Energievak(int aankoopWaarde,int hypotheekWaarde,int positie,int variabeleWaarde,string naam,string typeEnergie):base(null,"Wit","Energie",aankoopWaarde,hypotheekWaarde,positie,variabeleWaarde,naam)
        {
            _typeEnergie = typeEnergie;
        }

        public int AantalKeerOgen { get => _aantalKeerOgen; set => _aantalKeerOgen = value; }
        public string TypeEnergie { get => _typeEnergie; set => _typeEnergie = value; }
    }
}
