using CourseBooking.Models;
using Microsoft.AspNet.Identity;

namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CourseBooking.Models.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CourseBooking.Models.CourseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Locations.AddOrUpdate(
                l=>l.Id,
                new Location{Id = 1, City = "Niedergösgen", Street = "Mühledorf 30", Zip = "5013", Name = "Niedergösgen"});

            context.CourseTemplates.AddOrUpdate(
                t=>t.Id,
                new CourseTemplate{Id=1,LocationId = 1,MaxParticipants = 12, Name = "VKU",Price = "240"},
                new CourseTemplate { Id = 2, LocationId = 1, MaxParticipants = 12, Name = "Motorrad Grundkurs 1", Price = "175", NumberOfHours = 4 },
                new CourseTemplate{Id=3,LocationId = 1,MaxParticipants = 12, Name = "Motorrad Grundkurs 2",Price = "175", NumberOfHours = 4},
                new CourseTemplate { Id = 4, LocationId = 1, MaxParticipants = 12, Name = "Motorrad Grundkurs 3", Price = "175", NumberOfHours = 4 },
                new CourseTemplate { Id = 5, LocationId = 1, MaxParticipants = 12, Name = "Motorrad Grundkurs 2a", Price = "175", NumberOfHours = 4 }
                );

            CreateDefaultUser();
        }

        private void CreateDefaultUser()
        {
            var context = new ApplicationDbContext();
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("wangor99");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "matt",
                    PasswordHash = password
                });
        }
    }
}
