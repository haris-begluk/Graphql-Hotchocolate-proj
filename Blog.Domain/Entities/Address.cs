using System;
using System.Collections.Generic;


namespace Blog.Domain.Entities
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public int PostalNumber { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}
