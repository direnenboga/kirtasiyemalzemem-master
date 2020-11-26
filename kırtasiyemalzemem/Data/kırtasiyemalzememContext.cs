using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kırtasiyemalzemem.Models;

namespace kırtasiyemalzemem.Data
{
    public class kırtasiyemalzememContext : DbContext
    {
        public kırtasiyemalzememContext (DbContextOptions<kırtasiyemalzememContext> options)
            : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BogaDb");
        }


        public DbSet<kırtasiyemalzemem.Models.Users> Users { get; set; }

    }
}
