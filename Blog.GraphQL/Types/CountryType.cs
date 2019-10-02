using Blog.Domain.Entities;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GraphQL.Types
{
    public class CountryType : ObjectType<Country>
    {
        protected override void Configure(IObjectTypeDescriptor<Country> descriptor)
        { 
            descriptor.Field(a => a.CountryId).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.Name).Type<NonNullType<StringType>>();
        }
    }
}
