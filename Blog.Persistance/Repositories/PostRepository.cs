using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using System;
using System.Linq;

namespace Blog.Persistance.Repositories
{
    public class PostRepository : IPostRepository
    {
        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public BlogDbContext _context { get; }

        public Post GetPost(Guid id)
        {
            return _context.Posts.FirstOrDefault(a => a.PostId == id);
        }

        public IQueryable<Post> GetPosts()
        {
            return _context.Posts;
        }
    }
}
