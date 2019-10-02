using Blog.GraphQL.Types;
using HotChocolate.Types;
using HotChocolate.Types.Filters;
using HotChocolate.Types.Relay;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GraphQL.Queries
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            // Note: I have added paging, sorting and filtering support here
            descriptor.Field(t => t.GetAddresses(default))
                // .Type<NonNullType<ListType<AddressType>>>()
                .UsePaging<AddressType>()
                .UseFiltering()
                .UseSorting();

            // Note: This one is with filtering and sorting but without paging
            descriptor.Field(t => t.GetCountries(default))
                .Type<NonNullType<ListType<CountryType>>>()
                .UseFiltering()
                .UseSorting();

            descriptor.Field(t => t.GetPosts(default))
                .Type<NonNullType<ListType<PostType>>>();

            descriptor.Field(t => t.GetUsers(default))
                .Type<NonNullType<ListType<UserType>>>();
        }
    }
}
