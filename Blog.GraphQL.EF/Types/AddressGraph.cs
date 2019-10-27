using Blog.Domain.Entities;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Blog.GraphQL.EF.Types
{
    public class AddressGraph : EfObjectGraphType<BlogDbContext, Address>
    {
        public AddressGraph(IEfGraphQLService<BlogDbContext> graphService) : base(graphService)
        {
            Field(x => x.AddressId, type: typeof(IdGraphType));
            Field(x => x.Name, nullable: true); 
            Field(x => x.PostalNumber, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CountryId, nullable: true, type: typeof(IdGraphType));
           
            AddNavigationField(name: "Country", resolve: context => context.Source.Country);
        }
    }
}
