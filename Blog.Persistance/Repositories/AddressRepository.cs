using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Persistance.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BlogDbContext _context;

        public AddressRepository(BlogDbContext context)
        {
            _context = context;
           
        }

        

        public Address GetAddress(Guid id)
        {
            return _context.Addresses.FirstOrDefault(a => a.AddressId == id);
        }

        public IQueryable<Address> GetAddresses()
        {
            // Note: AsQueryable will make this an in-memory queryable.
            // The EF is already providing a IQueryable through IDbSet
            return _context.Addresses;
        }
        public async Task<IReadOnlyDictionary<Guid, Address>> GetAddressesAsync(
            IReadOnlyCollection<Guid> addressIds,
            CancellationToken cancellationToken)
        {
            List<Address> addresses = await _context.Addresses.Where(c => addressIds.Contains(c.AddressId)).ToListAsync();
            return addresses.ToDictionary(t => t.AddressId);
        }
    }
}
