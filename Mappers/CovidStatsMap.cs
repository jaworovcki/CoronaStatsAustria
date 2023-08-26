using CoronaStatsAustria.DataAccess;
using CoronaStatsAustria.Models;
using CsvHelper.Configuration;

namespace CoronaStatsAustria.Mappers
{
    public sealed class CovidStatsMap : ClassMap<CovidStats>
    {
        public CovidStatsMap()
        {
            Map(m => m.District.Name).Name("Bezirk");
            Map(m => m.District.Code).Name("GKZ");
            Map(m => m.CovidCasesNumber).Name("Anzahl");
            Map(m => m.CovidDeathsNumber).Name("AnzahlTot");
            Map(m => m.DistrictPopulation).Name("AnzEinwohner");
        }
    }
}
