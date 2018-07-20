namespace Capstone.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Capstone.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Capstone.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Roles.AddOrUpdate(
                s => s.Name,
                    new IdentityRole { Name = "Admin" },
                    new IdentityRole { Name = "Volunteer" }
                );

            context.Weeks.AddOrUpdate(
                w => w.Day,
                    new Models.Week { Day = "Monday" },
                    new Models.Week { Day = "Tuesday" },
                    new Models.Week { Day = "Wednesday" },
                    new Models.Week { Day = "Thursday" },
                    new Models.Week { Day = "Friday" },
                    new Models.Week { Day = "Saturday" },
                    new Models.Week { Day = "Sunday" }
                );

            context.Programs.AddOrUpdate(
                p => p.Service,
                    new Models.Program { Service = "9 AM ESL Class"},
                    new Models.Program { Service = "11:30 AM ESL Class" },
                    new Models.Program { Service = "Individual Tutoring" },
                    new Models.Program { Service = "Home Work Help" },
                    new Models.Program { Service = "Sewing Classes" },
                    new Models.Program { Service = "Immigration Services" }
                );
        }
    }
}
