using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Domain.Entities;

namespace Blog.Persistance.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        IQueryable<Address> GetAddresses();
        Address GetAddress(Guid id);
    }
}
