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
    public class UserRepository : IUserRepository
    {
        public UserRepository(BlogDbContext context)
        {
            _context = context;
        }

        public BlogDbContext _context { get; }

        public User GetUser(Guid id)
        {
            return _context.Users.FirstOrDefault(a => a.UserId == id);
        }

        public IQueryable<User> GetUsers()
        {
            return _context.Users;
        }
        public async Task<IReadOnlyDictionary<Guid, User>> GetUsersAsync(
          IReadOnlyCollection<Guid> userIds,
          CancellationToken cancellationToken)
        {
            List<User> posts = await _context.Users.Where(c => userIds.Contains(c.UserId)).ToListAsync();
            return posts.ToDictionary(t => t.UserId);
        }
    }
}
