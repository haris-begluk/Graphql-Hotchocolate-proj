using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class BlogDbContextEfFactory
    {
      
            public static BlogDbContext CreateDbContext(IConfiguration configuration)
            {
                var builder = new DbContextOptionsBuilder<BlogDbContext>();
                var connectionString = configuration.GetConnectionString("MainDatabase");
                builder.UseSqlServer(connectionString);

                return new BlogDbContext(builder.Options);
            }
        
    }
}
