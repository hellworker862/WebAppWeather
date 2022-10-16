using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppWeather.Models.Places
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string RuName { get; set; }
        public string? EnName { get; set; }
        public decimal Lon { get; set; }
        public decimal Lat { get; set; }
        public int RegionId { get; set; }
        [ForeignKey(nameof(RegionId))]
        [InverseProperty("Citys")]
        public Region? Region { get; set; }
    }
}
