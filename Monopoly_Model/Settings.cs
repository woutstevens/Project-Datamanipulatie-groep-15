using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class Settings
    {
        //Attributen
        private int _bedrag;
        private int _spelers;
        private bool _gevangenis;
        private bool _parking;

        //Properties
        public int Bedrag
        {
            get { return _bedrag; }
            set
            {
                if (value > 100)
                {
                    _bedrag = value;
                }
                else
                {
                    _bedrag = 2000;
                }
            }
        }
        public int Spelers {
            get { return _spelers; }
            set
            {
                if(value > 6 || value < 2)
                {
                    _spelers = 2;
                }
                else
                {
                    _spelers = value;
                }
            }
        }
        public bool Gevangenis { get => _gevangenis; set => _gevangenis = value; }
        public bool Parking { get => _parking; set => _parking = value; }

        //constructor
        public Settings()
        {
            Bedrag = 2000;
            Spelers = 2;
            Gevangenis = false;
            Parking = false;
        }

        public Settings(int bedrag, int spelers, bool gevangenis, bool parking)
        {
            Bedrag = bedrag;
            Spelers = spelers;
            Gevangenis = gevangenis;
            Parking = parking;
        }

    }
}
