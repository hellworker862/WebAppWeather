using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAppWeather.Models.Places;
namespace WebAppWeather
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Region> Regions => Set<Region>();
        public DbSet<City> Cities => Set<City>();

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var confBuilder = new ConfigurationBuilder();
            confBuilder.SetBasePath(Directory.GetCurrentDirectory());
            confBuilder.AddJsonFile("appsettings.json");
            var config = confBuilder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string filename = Path.Combine(Directory.GetCurrentDirectory(), "db.json");
            var result = JsonConvert.DeserializeObject<IEnumerable<Country>>(File.ReadAllText(filename))!;
            var regions = result.SelectMany(x => x.Regions).ToList();
            var cities = regions.SelectMany(x => x.Citys).ToList();
            modelBuilder.Entity<Country>().HasData(result);
            modelBuilder.Entity<Region>().HasData(regions!);
            modelBuilder.Entity<City>().HasData(cities!);
        }
    }
}
