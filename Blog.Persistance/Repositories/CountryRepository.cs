using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Persistance.Repositories
{
    public class CountryRepository :ICountryRepository
    {
        public CountryRepository(BlogDbContext context)
        {
            _context = context;
        }

        public BlogDbContext _context { get; }

        public Country GetCountry(Guid id)
        {
            return _context.Countries.FirstOrDefault(a => a.CountryId == id);
        }

        public IQueryable<Country> GetCountries()
        {
            return _context.Countries.AsQueryable();
        }

    }
}
