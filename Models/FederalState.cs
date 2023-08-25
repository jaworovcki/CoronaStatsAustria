using System.ComponentModel.DataAnnotations;

namespace CoronaStatsAustria.Models
{
    public class FederalState
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
    }
}
