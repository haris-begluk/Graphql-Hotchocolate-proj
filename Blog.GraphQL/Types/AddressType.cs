using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using HotChocolate.Types;

namespace Blog.GraphQL.Types
{
    public class AddressType : ObjectType<Address>
    {
        protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
        {
            descriptor.Field(a => a.AddressId).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.Name).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.PostalNumber).Type<NonNullType<IntType>>();
            descriptor.Field(a => a.CountryId).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.Country)
                .Type<NonNullType<CountryType>>()
                .Resolver(context => context
                    .Service<ICountryRepository>()
                    .GetCountry(context.Parent<Address>().CountryId));
        }
    }
}
