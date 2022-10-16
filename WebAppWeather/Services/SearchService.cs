using Microsoft.EntityFrameworkCore;
using System;
using WebAppWeather.Models.Places;

namespace WebAppWeather.Services
{
    public class SearchService
    {
        private readonly ApplicationContext _context;

        public SearchService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<City>> SearchCity(string searchString)
        {
            var test1 = _context.Cities.Where(item => item.RuName.ToLower().Contains(searchString)).ToArray();
            var aaa = test1.Where(item => item.RuName.ToLower().StartsWith(searchString)).ToArray();
            foreach (var item in test1)
            {
                var t = item.RuName.ToLower().Contains(searchString);
                var a = searchString.Contains(item.RuName.ToLower());
            }
            var result = await _context.Cities.Where(x => x.RuName
                                              .Contains(searchString))
                                              .Include(x => x!.Region!.Country)
                                              .ToArrayAsync();

            return result;
        }
    }
}
