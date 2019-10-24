using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Persistance.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IQueryable<Country> GetCountries();
        Task<Country> GetCountry(Guid id);
        Task<IReadOnlyDictionary<Guid, Country>> GetCountriesAsync(
            IReadOnlyCollection<Guid> countryIds,
            CancellationToken cancellationToken);
    }
}
