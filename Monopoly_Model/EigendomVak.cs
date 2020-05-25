using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Model
{
    public abstract class EigendomVak:Spelvak
    {
        private Speler _eigenaar;
        private string _kleur;
        private string _typeEigendomvak;
        private int _hypotheekWaarde;

        public Speler Eigenaar { get => _eigenaar; set => _eigenaar = value; }
        public string Kleur { get => _kleur; set => _kleur = value; }
        public string TypeEigendomVak { get => _typeEigendomvak; set => _typeEigendomvak = value; }
        public int HypotheekWaarde { get => _hypotheekWaarde; set => _hypotheekWaarde = value; }

        public EigendomVak()
        {

        }

        public EigendomVak(Speler eigenaar, string kleur,string typeEigendomVak,int aankoopWaarde,int hypotheekWaarde,int positie,int variabeleWaarde,string naam):base(naam,"eigendom",positie,variabeleWaarde,aankoopWaarde)
        {
            _eigenaar = eigenaar;
            _kleur = kleur;
            _typeEigendomvak = typeEigendomVak;
            _hypotheekWaarde = hypotheekWaarde;
        }
    }
}
