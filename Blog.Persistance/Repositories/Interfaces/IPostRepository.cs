using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Persistance.Repositories.Interfaces
{
    public interface IPostRepository
    {
        IQueryable<Post> GetPosts();
        Post GetPost(Guid id);
       Task<IReadOnlyDictionary<Guid, Post>> GetPostsAsync(
          IReadOnlyCollection<Guid> postIds,
          CancellationToken cancellationToken);
    }
}
