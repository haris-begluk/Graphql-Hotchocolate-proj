using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.GraphQL.Queries
{
    public class Query
    {
        public IQueryable<Country> GetCountries([Service]ICountryRepository repository)
        {
            return repository.GetCountries();
        }

        public IQueryable<Address> GetAddresses([Service]IAddressRepository repository)
        {
            return repository.GetAddresses();
        }

        public IQueryable<Post> GetPosts([Service]IPostRepository repository)
        {
            return repository.GetPosts();
        }

        public IQueryable<User> GetUsers([Service]IUserRepository repository)
        {
            return repository.GetUsers();
        }
    }
}
