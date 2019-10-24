using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Persistance.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        User GetUser(Guid id);
        Task<IReadOnlyDictionary<Guid, User>> GetUsersAsync(
          IReadOnlyCollection<Guid> userIds,
          CancellationToken cancellationToken);
    }
}
