namespace CoronaStatsAustria.Models
{
    public class CovidStats
    {
        public int Id { get; set; }

        public DateTime DateOfImport { get; set; }

        public int DistrictPopulation { get; set; }

        public int CovidCasesNumber { get; set; }

        public int CovidDeathsNumber { get; set; }

        public int SevenDaysIncidence { get; set; }

        public District District { get; set; } = new();

        public int DistrictId { get; set; }
    }
}
