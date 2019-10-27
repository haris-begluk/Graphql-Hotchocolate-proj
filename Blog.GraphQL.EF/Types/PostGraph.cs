using Blog.Domain.Entities;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Blog.GraphQL.EF.Types
{
    public class PostGraph : EfObjectGraphType<BlogDbContext, Post>
    {
        public PostGraph(IEfGraphQLService<BlogDbContext> graphService) : base(graphService)
        {
            Field(x => x.PostId, type: typeof(IdGraphType));
            Field(x => x.Title, nullable: true);
            Field(x => x.PostedAt, nullable: true);
            Field(x => x.UserId, nullable: true, type: typeof(IdGraphType));
            AddNavigationField(name: "User", resolve: context => context.Source.User);

        }
    }
}
