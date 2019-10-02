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
            descriptor.Field(t => t.GetAddresses(default))
                .Type<NonNullType<ListType<AddressType>>>();
            descriptor.Field(t => t.GetCountries(default))
                .Type<NonNullType<ListType<CountryType>>>();
            descriptor.Field(t => t.GetPosts(default))
                .Type<NonNullType<ListType<PostType>>>();
            descriptor.Field(t => t.GetUsers(default))
                .Type<NonNullType<ListType<UserType>>>();
        }
    }
}
