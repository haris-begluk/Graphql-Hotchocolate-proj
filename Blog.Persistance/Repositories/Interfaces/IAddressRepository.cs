using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.Entities;

namespace Blog.Persistance.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        IQueryable<Address> GetAddresses();
        Address GetAddress(Guid id);
        Task<IReadOnlyDictionary<Guid, Address>> GetAddressesAsync(
            IReadOnlyCollection<Guid> addressIds,
            CancellationToken cancellationToken);
    }
}
