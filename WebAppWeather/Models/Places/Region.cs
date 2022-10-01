using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppWeather.Models.Places
{
    public class Region
    {
        public int Id { get; set; }
        public string RuName { get; set; }
        public string? EnName { get; set; }
        [NotMapped]
        public virtual ICollection<City> Citys { get; set; }
        [ForeignKey("CountryId")]
        public string CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
