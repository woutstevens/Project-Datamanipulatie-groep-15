using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class KansKaart:Kaart
    {
        public KansKaart(int bedrag,int aantalPosities,string omschrijving,bool houBij):base(bedrag,aantalPosities,"Kans",omschrijving,houBij)
        {

        }
    }
}
