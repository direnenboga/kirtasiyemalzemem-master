using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kırtasiyemalzemem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace kırtasiyemalzemem.Data
{

    public class Model : System.Data.Entity.DbContext
    {
        public Model() : base(@"Server=(localdb)\mssqllocaldb;Database=BogaDb")
        {

        }
        public System.Data.Entity.DbSet<Order> Order { get; set; }
        public System.Data.Entity.DbSet<Product> Product { get; set; }
        public System.Data.Entity.DbSet<Category> Category { get; set; }
        public System.Data.Entity.DbSet<User> Users { get; set; }
    }

    public class UserContext : IdentityDbContext<User>
    {

        public UserContext(Microsoft.EntityFrameworkCore.DbContextOptions<UserContext> options) : base(options)
        {

        }



        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BogaDb");
        }
    }
}




