using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication_Shop_API.Models;

namespace E_Commerce_API.Models
{
    public class EC_Context:DbContext
    {
        public EC_Context(DbContextOptions<EC_Context> options) : base(options) { }
        public DbSet<color_info> color_info { get; set; }
        public DbSet<customer_inf> customer_inf { get; set; }
        public DbSet<customer_login> customer_login { get; set; }
        public DbSet<order_cart> order_cart { get; set; }
        public DbSet<order_detail> order_detail { get; set; }
        public DbSet<order_master> order_master { get; set; }
        public DbSet<product_info> product_info { get; set; }
        public DbSet<productpicinfo> productpicinfo { get; set; }
        public DbSet<warehouse_product> warehouse_product { get; set; }
       

    }
}
