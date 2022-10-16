using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppWeather.Models.Places
{
    public class Region
    {
        [Key]   
        public int Id { get; set; }
        public string RuName { get; set; }
        public string? EnName { get; set; }
        [InverseProperty("Region")]
        [NotMapped]
        public virtual ICollection<City> Citys { get; set; }
        public string CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Regions")]
        public Country? Country { get; set; }
    }
}
