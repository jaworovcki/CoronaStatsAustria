using System.ComponentModel.DataAnnotations;

namespace CoronaStatsAustria.Models
{
    public class District
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; } = string.Empty;

        public int Code { get; set; }

        public FederalState State { get; set; } = new();

    }
}
