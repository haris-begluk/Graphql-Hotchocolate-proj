using Blog.GraphQL.Types;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GraphQL.Queries
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetAddresses()).Name("Addresses")
                .Type<ListType<AddressType>>();
            descriptor.Field(t => t.GetCountries()).Name("Countries")
                .Type<ListType<CountryType>>();
            descriptor.Field(t => t.GetPosts()).Name("Posts")
                .Type<ListType<PostType>>();
            descriptor.Field(t => t.GetUsers()).Name("Users")
                .Type<ListType<UserType>>();

        }
    }
}
