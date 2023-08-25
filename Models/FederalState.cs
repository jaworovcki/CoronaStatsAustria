using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoronaStatsAustria.Models
{
    public class FederalState
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; } = string.Empty;

        public List<District> Districts { get; set; } = new();
    }
}
