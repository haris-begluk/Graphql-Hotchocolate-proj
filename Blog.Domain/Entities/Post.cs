using System;

namespace Blog.Domain.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedAt { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
