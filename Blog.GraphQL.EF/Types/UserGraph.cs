using Blog.Domain.Entities;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Blog.GraphQL.EF.Types
{
    public class UserGraph : EfObjectGraphType<BlogDbContext, User>
    {
        public UserGraph(IEfGraphQLService<BlogDbContext> graphService) : base(graphService)
        {
            Field(x => x.UserId, type: typeof(IdGraphType));
            Field(x => x.FullName, nullable: true);
            Field(x => x.UserName, nullable: true);
            Field(x => x.Email, nullable: true);
            Field(x => x.Password, nullable: true);
            Field(x => x.AddressId, nullable: true, type: typeof(IdGraphType));
            AddNavigationField(name: "Address", resolve: context => context.Source.Address);

        }
    }
}
