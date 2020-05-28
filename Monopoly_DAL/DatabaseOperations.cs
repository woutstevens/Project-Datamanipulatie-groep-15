using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Monopoly_DAL
{
    public static class DatabaseOperations
    {
        static string results = "";

        public static string Results { get => results; set => results = value; }

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

        public static List<Spelvak> OphalenSpelvakken()
        {
            using (Data_r0718763Entities entities = new Data_r0718763Entities())
            {
                var query = entities.Spelvak;
                return query.ToList();
            }
        }

        public static int AanpassenSpeler(Speler speler)
        {
            using (Data_r0718763Entities entities = new Data_r0718763Entities())
            {
                try
                {
                    entities.Entry(speler).State = EntityState.Modified;
                    return entities.SaveChanges();
                }
                catch(DbEntityValidationException e)
                {
                    foreach(DbEntityValidationResult result in e.EntityValidationErrors)
                    {
                        foreach (DbValidationError error in result.ValidationErrors) {
                            results += error.ErrorMessage + "\n";
                        }
                    }
                    return -1;
                }
            }
        }
    }
}
