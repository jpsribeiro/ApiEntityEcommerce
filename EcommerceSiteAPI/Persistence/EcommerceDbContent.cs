using EcommerceSiteAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSiteAPI.Persistence
{
    public class EcommerceDbContent : DbContext
    {
        public EcommerceDbContent(DbContextOptions<EcommerceDbContent> options) : base(options) 
        {
            
        }

        public DbSet<Products> Products { get; set; }
    }
}
