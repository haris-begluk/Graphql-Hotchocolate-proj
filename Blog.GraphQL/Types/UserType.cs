using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using GreenDonut;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;

namespace Blog.GraphQL.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(a => a.UserId).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.UserName).Type<StringType>();
            descriptor.Field(a => a.Email).Type<StringType>();
            descriptor.Field(a => a.FullName).Type<StringType>();
            descriptor.Field(a => a.Password).Type<StringType>();
            descriptor.Field(a => a.AddressId).Type<IdType>();

            descriptor.Field(a => a.Address).Type<AddressType>().Resolver(ctx =>
            {
                IAddressRepository repository = ctx.Service<IAddressRepository>();
                IDataLoader<Guid, Address> dataLoader = ctx.BatchDataLoader<Guid, Address>(
                    "AddressById", repository.GetAddressesAsync);
                return dataLoader.LoadAsync(ctx.Parent<User>().AddressId);
            });
        }
    }
}
