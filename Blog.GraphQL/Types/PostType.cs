using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GraphQL.Types
{
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Field(a => a.PostId).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.Title).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.Content).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.PostedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(a => a.UserId).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.User)
            .Type<NonNullType<UserType>>()
                .Resolver(context => context.Service<IUserRepository>()
                .GetUser(context.Parent<Post>().UserId));


        }
    }

}

