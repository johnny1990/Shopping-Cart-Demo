using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceShoppingCartMVC.Web.Models
{
    public class ShoppingDBContext : DbContext
    {

        public ShoppingDBContext(DbContextOptions<ShoppingDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
