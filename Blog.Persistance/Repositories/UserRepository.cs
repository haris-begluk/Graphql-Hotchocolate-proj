using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using System;
using System.Linq;

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
    }
}
