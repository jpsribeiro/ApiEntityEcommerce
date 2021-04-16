using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSiteAPI.Models
{
    public class Products
    {
        public Products(string description, decimal price)
        {
            Description = description;
            Price = price;
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
