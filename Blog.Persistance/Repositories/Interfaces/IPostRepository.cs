using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Persistance.Repositories.Interfaces
{
    public interface IPostRepository
    {
        IQueryable<Post> GetPosts();
        Post GetPost(Guid id);
    }
}
