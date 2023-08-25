using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoronaStatsAustria.Models
{
    public class District
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; } = string.Empty;

        public int Code { get; set; }

        [JsonIgnore]
        public FederalState State { get; set; } = null!;

        [JsonIgnore]
        public int StateId { get; set; }

        [JsonIgnore]
        public CovidStats CovidStatistics { get; set; } = null!;

    }
}
