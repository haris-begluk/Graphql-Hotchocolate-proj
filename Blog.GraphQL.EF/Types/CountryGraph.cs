using Blog.Domain.Entities;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Blog.GraphQL.EF.Types
{
    public class CountryGraph : EfObjectGraphType<BlogDbContext, Country>
    {
        public CountryGraph(IEfGraphQLService<BlogDbContext> graphService) : base(graphService)
        {
            Field(x => x.CountryId, type: typeof(IdGraphType));
            Field(x => x.Name, nullable: true);
            
        }
    }
}
