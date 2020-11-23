namespace kırtasiyemalzemem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<kırtasiyemalzemem.Models.Model>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(kırtasiyemalzemem.Models.Model context)
        {
            context.Category.AddOrUpdate(x => x.Id,
                new Models.Category { Id = 1, Name = "Test" },
                new Models.Category { Id = 2, Name = "Test" },
                new Models.Category { Id = 3, Name = "Test" },
                new Models.Category { Id = 4, Name = "Test" },
                new Models.Category { Id = 5, Name = "Test" },
                new Models.Category { Id = 6, Name = "Test" },
                new Models.Category { Id = 7, Name = "Test" },
                new Models.Category { Id = 8, Name = "Test" },
                new Models.Category { Id = 9, Name = "Test" },
                new Models.Category { Id = 10, Name = "Test" }
                );

            context.Users.AddOrUpdate(x => x.Id,
                new Models.Users { Id = 1, Name = "C.B.A.", UserName = "can", Password = "can" },
                new Models.Users { Id = 2, Name = "Direnen Boğa", UserName = "boga", Password = "boga" }
                );


        }
    }
}
