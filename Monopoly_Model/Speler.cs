﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class Speler
    {
        private int spelerID;
        private string _naam;
        int _vakID;
        int _huidigSaldo;
        bool _gevangenis;
        int _verlaatGevangenis;
        int rangschrikking;
        Pion _pion;

        public string Naam { get => _naam; set => _naam = value; }
        public int VakID { get => _vakID; set => _vakID = value; }
        public int HuidigSaldo { get => _huidigSaldo; set => _huidigSaldo = value; }
        public int VerlaatGevangenis { get => _verlaatGevangenis; set => _verlaatGevangenis = value; }
        public Pion Pion { get => _pion; set => _pion = value; }
        public bool Gevangenis { get => _gevangenis; set => _gevangenis = value; }
        public int SpelerID { get => spelerID; set => spelerID = value; }
        public int Rangschrikking { get => rangschrikking; set => rangschrikking = value; }

        public Speler(string naam)
        {
            _naam = naam;
            _vakID = 0;
            _huidigSaldo = 1500;
            _gevangenis = false;
            _verlaatGevangenis = 0;
            rangschrikking = 1;
        }

        public void aanpassingSaldo(int aanpassing)
        {
            _huidigSaldo += aanpassing;
        }

        public bool IsFailliet()
        {
            return HuidigSaldo <= 0;
        }
    }
}
