using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly_Model;
using Monopoly_DAL;

namespace Project_Monopoly
{
    class SpelbordDatabaseOperaties
    {
        public List<Monopoly_Model.Spelvak> getSpelvakken()
        {
            List<Monopoly_DAL.Spelvak> databaseVakken = DatabaseOperations.OphalenSpelvakken();
            List<Monopoly_Model.Spelvak> spelvakken = new List<Monopoly_Model.Spelvak>();
            
            foreach(Monopoly_DAL.Spelvak databasevak in databaseVakken)
            {
                if(databasevak.prijsMet1Huis != 0)
                {
                    spelvakken.Add(new StraatVak(databasevak.kleur, VervangBackslash(databasevak.naam), Convert.ToInt32(databasevak.prijsZonderHuis), Convert.ToInt32(databasevak.prijsMet1Huis), Convert.ToInt32(databasevak.prijsMet2Huizen), Convert.ToInt32(databasevak.prijsMet3Huizen), Convert.ToInt32(databasevak.prijsMet4Huizen), Convert.ToInt32(databasevak.prijsMet1Hotel), Convert.ToInt32(databasevak.prijsPerHuis), databasevak.hypotheekwaarde, databasevak.aankoopwaarde, getVariabeleWaarde(databasevak), databasevak.id));
                }

                else if(databasevak.prijs1Station != 0)
                {
                    spelvakken.Add(new StationVak(Convert.ToInt32(databasevak.aankoopwaarde), Convert.ToInt32(databasevak.prijs1Station), Convert.ToInt32(databasevak.hypotheekwaarde), getVariabeleWaarde(databasevak), databasevak.id, VervangBackslash(databasevak.naam)));
                }

                else if(databasevak.id == 7 || databasevak.id == 22 || databasevak.id == 36)
                {
                    spelvakken.Add(new KanskaartVak(databasevak.id, getVariabeleWaarde(databasevak)));
                }

                else if(databasevak.id == 2 || databasevak.id == 17 || databasevak.id == 33)
                {
                    spelvakken.Add(new AlgemeenFondsKaartVak(databasevak.id, getVariabeleWaarde(databasevak)));
                }

                else if(databasevak.id == 4 || databasevak.id == 38)
                {
                    spelvakken.Add(new Belangstingvak(VervangBackslash(databasevak.naam), databasevak.id, getVariabeleWaarde(databasevak), Convert.ToInt32(databasevak.aankoopwaarde)));
                }

                else if(databasevak.id == 12 || databasevak.id == 28)
                {

                    spelvakken.Add(new Energievak(Convert.ToInt32(databasevak.aankoopwaarde), Convert.ToInt32(databasevak.hypotheekwaarde), databasevak.id, getVariabeleWaarde(databasevak), VervangBackslash(databasevak.naam), getTypeEnergie(databasevak)));
                }

                else if(databasevak.id == 10)
                {
                    spelvakken.Add(new GevangenisVak(databasevak.id, getVariabeleWaarde(databasevak)));
                }

                else if(databasevak.id == 20 || databasevak.id == 30)
                {
                    spelvakken.Add(new HoekVak(VervangBackslash(databasevak.naam), databasevak.id, getVariabeleWaarde(databasevak)));
                }
            }
            return spelvakken;
        }

        private string VervangBackslash(string naam) {

            string vervangNaam = naam;

            if (naam != null)
            {
                vervangNaam = naam.Replace("\\n", "\n");
            }
            return vervangNaam;
        }

        private string getTypeEnergie(Monopoly_DAL.Spelvak databasevak)
        {
            string TypeEnergie = "";
            if(databasevak.id == 12)
            {
                TypeEnergie = "Elektriciteit";
            }

            else
            {
                TypeEnergie = "Water";
            }

            return TypeEnergie;
        }

        private int getVariabeleWaarde(Monopoly_DAL.Spelvak databasevak)
        {
            int variabeleWaarde = 0;
            int positie = databasevak.id;
            if (positie > 0 && positie < 10)
            {
                variabeleWaarde = Convert.ToInt32(databasevak.positionTop);

            }

            else if (positie > 10 && positie < 20)
            {
                variabeleWaarde = Convert.ToInt32(databasevak.positionLeft);
            }

            else if (positie > 20 && positie < 30)
            {
                variabeleWaarde = Convert.ToInt32(databasevak.positionTop);
            }

            else if (positie > 30 && positie < 40)
            {
                variabeleWaarde = Convert.ToInt32(databasevak.positionLeft);
            }
            else if (positie == 30)
            {
                variabeleWaarde = Convert.ToInt32(databasevak.positionLeft);
            }

            else if (positie == 20)
            {
                variabeleWaarde = Convert.ToInt32(databasevak.positionTop);
            }

            else if (positie == 10)
            {
                variabeleWaarde = Convert.ToInt32(databasevak.positionTop);
            }
            return variabeleWaarde;
        }
    }
}
