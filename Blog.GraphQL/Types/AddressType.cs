using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using GreenDonut;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;

namespace Blog.GraphQL.Types
{
    public class AddressType : ObjectType<Address>
    {
        protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
        {
            descriptor.Field(a => a.AddressId).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.PostalNumber).Type<IntType>();
            descriptor.Field(a => a.CountryId).Type<IdType>();
            
            descriptor.Field(a => a.Country).Type<CountryType>().Resolver(ctx =>
              {
                  ICountryRepository repository = ctx.Service<ICountryRepository>();
                  IDataLoader<Guid, Country> dataLoader = ctx.BatchDataLoader<Guid, Country>(
                      "CountryById", repository.GetCountriesAsync); 
                  return dataLoader.LoadAsync(ctx.Parent<Address>().CountryId);
              });


           

        }
    }
}
