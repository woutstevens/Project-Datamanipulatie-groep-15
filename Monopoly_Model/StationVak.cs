using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public class StationVak:EigendomVak
    {
        private int _huur;
        private int _2Stations;
        private int _3Stations;
        private int _4Stations;

        public StationVak(int aankoopWaarde, int huur, int hypotheekWaarde, int variabeleWaarde, int positie, string naam) : base(null,"Wit","Station",aankoopWaarde,hypotheekWaarde,positie,variabeleWaarde, naam)
        {
            _huur = huur;
            _2Stations = _huur * 2;
            _3Stations = _2Stations * 2;
            _4Stations = _3Stations * 2;
        }
    }
}
