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
        public async Task<IReadOnlyDictionary<Guid, Post>> GetPostsAsync(
           IReadOnlyCollection<Guid> postIds,
           CancellationToken cancellationToken)
        {
            List<Post> posts = await _context.Posts.Where(c => postIds.Contains(c.PostId)).ToListAsync();
            return posts.ToDictionary(t => t.PostId);
        }
    }
}
