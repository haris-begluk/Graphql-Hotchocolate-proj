using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class Country
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}
