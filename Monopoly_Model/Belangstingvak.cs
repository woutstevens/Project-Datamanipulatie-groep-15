using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class Belangstingvak:Spelvak 
    {
        private int _teBetalen;
        public Belangstingvak(string belastingNaam,int positie,int variabeleWaarde,int teBetalen):base(belastingNaam,"Belasting",positie,variabeleWaarde,teBetalen)
        {
            _teBetalen = teBetalen;
        }
    }
}
