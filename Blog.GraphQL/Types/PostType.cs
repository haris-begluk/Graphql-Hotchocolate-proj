using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using GreenDonut;
using HotChocolate.Resolvers;
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
            descriptor.Field(a => a.Title).Type<StringType>();
            descriptor.Field(a => a.Content).Type<StringType>();
            descriptor.Field(a => a.PostedAt).Type<DateTimeType>();
            descriptor.Field(a => a.UserId).Type<IdType>();
            descriptor.Field(a => a.User).Type<UserType>().Resolver(ctx =>
            {
                IUserRepository repository = ctx.Service<IUserRepository>();
                IDataLoader<Guid, User> dataLoader = ctx.BatchDataLoader<Guid, User>(
                    "UserById", repository.GetUsersAsync);
                return dataLoader.LoadAsync(ctx.Parent<Post>().UserId);
            });
        }
    }
}

