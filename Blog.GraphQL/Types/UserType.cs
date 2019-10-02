using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GraphQL.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(a => a.UserId).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.UserName).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.Email).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.FullName).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.Password).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.AddressId).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.Address)
                .Type<NonNullType<AddressType>>()
                .Resolver(context => context
                    .Service<IAddressRepository>()
                    .GetAddress(context.Parent<User>().AddressId));
        }
    }
}
