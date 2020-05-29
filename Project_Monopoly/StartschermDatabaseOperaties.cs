using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly_DAL;
using Monopoly_Model;
using Project_Monopoly;

namespace Project_Monopoly
{
    class StartschermDatabaseOperaties
    {
        public int updateSpeler(Monopoly_Model.Speler speler)
        {
            Monopoly_DAL.Speler aanTePassenSpeler = new Monopoly_DAL.Speler();
            aanTePassenSpeler.figuur = speler.Pion.Omschrijving;
            aanTePassenSpeler.naam = speler.Naam;
            aanTePassenSpeler.id = speler.SpelerID;
            aanTePassenSpeler.huidigSaldo = speler.HuidigSaldo;

            return DatabaseOperations.AanpassenSpeler(aanTePassenSpeler);
        }

        public string getErrorMessage()
        {
            return DatabaseOperations.Results;
        }
    }
}
