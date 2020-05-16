using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class Speler
    {
        private string _naam;
        private string _figuur;
        int _vakID;
        int _huidigSaldo;
        bool _gevangenis;
        int _verlaatGevangenis;

        public string Naam { get => _naam; set => _naam = value; }
        public string Figuur { get => _figuur; set => _figuur = value; }
        public int VakID { get => _vakID; set => _vakID = value; }
        public int HuidigSaldo { get => _huidigSaldo; set => _huidigSaldo = value; }
        public int VerlaatGevangenis { get => _verlaatGevangenis; set => _verlaatGevangenis = value; }

        public void aanpassingSaldo(int aanpassing)
        {
            _huidigSaldo += aanpassing;
        }
    }
}
