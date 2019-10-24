using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Persistance.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public CountryRepository(BlogDbContext context)
        {
            _context = context;
        }

        public BlogDbContext _context { get; }

        public async Task<Country> GetCountry(Guid id)
        {
            return await _context.Countries.FirstOrDefaultAsync(a => a.CountryId == id);
        }

        public IQueryable<Country> GetCountries()
        {
            return _context.Countries;
        }
        public async Task<IReadOnlyDictionary<Guid, Country>> GetCountriesAsync(
            IReadOnlyCollection<Guid> countryIds,
            CancellationToken cancellationToken)
        {
            List<Country> countries = await _context.Countries.Where(c => countryIds.Contains(c.CountryId)).ToListAsync();
            return countries.ToDictionary(t => t.CountryId);
        }
    }
}
