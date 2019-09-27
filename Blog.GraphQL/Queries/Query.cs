using Blog.Domain.Entities;
using Blog.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.GraphQL.Queries
{
    public class Query
    {
        private readonly IAddressRepository _addressRepo;
        

        public Query(ICountryRepository countryRepo, 
            IAddressRepository addressRepo, 
            IPostRepository postRepo, 
            IUserRepository userRepo)
        {
            _countryRepo = countryRepo;
            _addressRepo = addressRepo;
            _postRepo = postRepo;
            _userRepo = userRepo;
        }

        public ICountryRepository _countryRepo { get; }
        public IPostRepository _postRepo { get; }
        public IUserRepository _userRepo { get; }

        public IQueryable<Country> GetCountries()
        {

            return _countryRepo.GetCountries();
        }
        public IQueryable<Address> GetAddresses()
        {
           
            return _addressRepo.GetAddresses();
        }
        public IQueryable<Post> GetPosts()
        {

            return _postRepo.GetPosts();
        }
        public IQueryable<User> GetUsers()
        {
           
            return _userRepo.GetUsers();
        }
        
        

    }
}
