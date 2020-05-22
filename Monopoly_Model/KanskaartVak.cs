using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class KanskaartVak:Spelvak
    {
        private string _naam;
        public KanskaartVak(int positie,int variabeleWaarde):base("Kans","Kans",positie,variabeleWaarde,0)
        {
            _naam = "Kans";
        }

        public string Naam { get => _naam; set => _naam = value; }
    }
}
