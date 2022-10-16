using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppWeather.Models.Places
{
    public class Country
    {
        [Key]
        public string Id { get; set; }
        public string RuName { get; set; }
        public string? EnName { get; set; }
        [NotMapped]
        public ICollection<Region>? Regions { get; set; }
    }
}
