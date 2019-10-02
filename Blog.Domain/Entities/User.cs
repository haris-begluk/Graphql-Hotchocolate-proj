using System;

namespace Blog.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
