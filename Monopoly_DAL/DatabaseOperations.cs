using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_DAL
{
    public static class DatabaseOperations
    {
        public static List<Speler> OphalenBesteSpelers()
        {
            using (Data_r0718763Entities entities = new Data_r0718763Entities())
            {
                var query = entities.Speler.OrderByDescending(x => x.huidigSaldo);
                return query.ToList();
            }
        }

        public static List<Spelvak> OphalenStraten(string naam)
        {
            using (Data_r0718763Entities entities = new Data_r0718763Entities())
            {
                var query = entities.Spelvak
                    .Where(x => x.naam.Contains(naam))
                    .OrderBy(x => x.hypotheekwaarde);
                return query.ToList();
            }
        }

        public static List<Kans> OphalenKanskaarten()
        {
            using(Data_r0718763Entities entities = new Data_r0718763Entities())
            {
                var query = entities.Kans;
                return query.ToList();
            }
        }
    }
}
