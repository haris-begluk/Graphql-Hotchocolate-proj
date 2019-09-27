using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Persistance.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public AddressRepository(BlogDbContext context)
        {
            _context = context;
        }

        public BlogDbContext _context { get; }

        public Address GetAddress(Guid id)
        {
            return _context.Addresses.FirstOrDefault(a => a.AddressId == id);
        }

        public IQueryable<Address> GetAddresses()
        {
            return _context.Addresses.AsQueryable();
        }
    }
}
