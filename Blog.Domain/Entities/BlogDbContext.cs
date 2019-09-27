using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class BlogDbContext :DbContext
    {
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Address> Addresses{ get; set; }
        public DbSet<Post> Posts{ get; set; }
        public DbSet<User> Users{ get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options):base(options)
        {

        }
    }
}
