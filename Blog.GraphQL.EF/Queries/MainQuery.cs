using Blog.Domain.Entities;
using GraphQL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GraphQL.EF.Queries
{
    public class MainQuery : QueryGraphType<BlogDbContext>
    {
        public MainQuery(IEfGraphQLService<BlogDbContext> graphService) :
           base(graphService)
        {
            AddQueryField(
               name: "Countries",
               resolve: context => context.DbContext.Countries);

            AddQueryField(
                name: "Addresses",
                resolve: context => context.DbContext.Addresses);
            AddQueryField(
                name: "Users",
                resolve: context => context.DbContext.Users);
            AddQueryField(
                name: "Posts",
                resolve: context => context.DbContext.Posts);
        }

    }
}
