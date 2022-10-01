using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppWeather.Models.Places
{
    public class City
    {
        public int Id { get; set; }
        public string RuName { get; set; }
        public string? EnName { get; set; }
        public decimal Lon { get; set; }
        public decimal Lat { get; set; }
        [ForeignKey("RegionId")]
        public int RegionId { get; set; }
        [NotMapped]
        public Region? Region { get; set; }
    }
}
