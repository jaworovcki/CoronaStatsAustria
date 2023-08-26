using System.Text.Json.Serialization;

namespace CoronaStatsAustria.Models
{
    public class CovidStats
    {
        public int Id { get; set; }

        public DateTime DateOfImport { get; set; }

        public int DistrictPopulation { get; set; }

        public int CovidCasesNumber { get; set; }

        public int CovidDeathsNumber { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public District District { get; set; } = null!;

        [JsonIgnore]
        public int DistrictId { get; set; }
    }
}
