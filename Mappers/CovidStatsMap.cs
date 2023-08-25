using CoronaStatsAustria.Models;
using CsvHelper.Configuration;

namespace CoronaStatsAustria.Mappers
{
    public sealed class CovidStatsMap : ClassMap<CovidStats>
    {
        public CovidStatsMap()
        {
            Map(m => m.District.Name).Name("district");
            Map(m => m.District.Code).Name("code");
            Map(m => m.CovidCasesNumber).Name("number of cases");
            Map(m => m.CovidDeathsNumber).Name("deaths");
            Map(m => m.DateOfImport).Name("date");
        }
    }
}
