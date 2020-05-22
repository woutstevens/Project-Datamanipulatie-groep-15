using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class Kaart
    {
        private int _bedrag;
        private int _aantalPosities;
        private string _type;
        private string _omschrijving;
        bool _houBij;

        public Kaart(int bedrag,int aantalPosities,string type,string omschrijving,bool houBij)
        {
            _bedrag = bedrag;
            _aantalPosities = aantalPosities;
            _type = type;
            _omschrijving = omschrijving;
            _houBij = houBij;
        }

        public int Bedrag { get => _bedrag; set => _bedrag = value; }
        public int AantalPosities { get => _aantalPosities; set => _aantalPosities = value; }
        public string Type { get => _type; set => _type = value; }
        public string Omschrijving { get => _omschrijving; set => _omschrijving = value; }
        public bool HouBij { get => _houBij; set => _houBij = value; }
    }
}
