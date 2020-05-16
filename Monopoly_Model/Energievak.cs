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

        public Energievak(int aankoopWaarde,int hypotheekWaarde,int positie,int variabeleWaarde,string naam):base(null,"Wit","Energie",aankoopWaarde,hypotheekWaarde,positie,variabeleWaarde,naam)
        {

        }

        public int AantalKeerOgen { get => _aantalKeerOgen; set => _aantalKeerOgen = value; }
    }
}
