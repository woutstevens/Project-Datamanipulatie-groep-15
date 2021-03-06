﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public abstract class Spelvak
    {
        private string _naam;
        private int _positie;
        private string _type;
        private int _left;
        private int _top;
        private int _graden;
        private int _variabeleWaarde;
        private int _prijs;
        private int _middelLeft;
        private int _middelTop;


        public int Positie
        {
            get { return _positie; }
            set { _positie = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Left { get => _left; set => _left = value; }
        public int Top { get => _top; set => _top = value; }
        public int Graden { get => _graden; set => _graden = value; }
        public int VariabeleWaarde { get => _variabeleWaarde; set => _variabeleWaarde = value; }
        public string Naam { get => _naam; set => _naam = value; }
        public int Prijs { get => _prijs; set => _prijs = value; }
        public int MiddelLeft { get => _middelLeft; set => _middelLeft = value; }
        public int MiddelTop { get => _middelTop; set => _middelTop = value; }

        public Spelvak()
        {

        }

        public Spelvak(string naam,string type, int positie,int variabeleWaarde,int prijs)
        {
            _naam = naam;
            _positie = positie;
            _type = type;
            _variabeleWaarde = variabeleWaarde;
            _prijs = prijs;
            setVasteWaarden();
        }

        public void setVasteWaarden()
        {
            if(_positie > 0 && _positie < 10)
            {
                _left = 45;
                _top = _variabeleWaarde;
                _graden = 90;
                _middelLeft = _left;
                _middelTop = _top + 5;
            }

            else if(_positie > 10 && _positie < 20)
            {
                _top = 92;
                _left = _variabeleWaarde;
                _graden = 180;
                _middelLeft = _left - 40;
                _middelTop = _top;
            }

            else if (_positie > 20 && _positie < 30)
            {
                _left = 875;
                _top = _variabeleWaarde;
                _graden = 270;
                _middelLeft = _left - 20;
                _middelTop = _top -50;
            }

            else if (_positie > 30 && _positie < 40)
            {
                _top = 924;
                _left = _variabeleWaarde;
                _graden = 0;
                _middelLeft = _left;
                _middelTop = _top - 20;
            }

            else if (_positie == 30)
            {
                _top = 840;
                _left = _variabeleWaarde;
                _graden = 0;
                _middelLeft = _left;
                _middelTop = _top;
            }

            else if (_positie == 20)
            {
                _top = _variabeleWaarde;
                _left = 870;
                _graden = 225;
                _middelLeft = _left - 20;
                _middelTop = _top - 50;
            }

            else if (_positie == 10)
            {
                _top = _variabeleWaarde;
                _left = 100;
                _graden = 176;
                _middelLeft = 20;
                _middelTop = 140;
            }
        }
    }
}
