﻿using System.Data.Entity;

namespace CourseBooking.Models
{
  public class CourseContext : DbContext
    {
        public CourseContext()
            : base("CourseConnection")
        {
            
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseTemplate> CourseTemplates { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<CourseSet> CourseSets { get; set; }

        public DbSet<CourseSetEntry> CourseSetEntries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseSet>()
                .HasMany(cs => cs.Entries)
                .WithRequired(cs => cs.CourseSet)
                .Map(x => x.MapKey("CourseSetId"));

          modelBuilder.Entity<Registration>().HasMany(c => c.Courses).WithMany(r=>r.Registrations).Map(
            x =>
              {
                x.MapLeftKey("RegistrationId");
                x.MapRightKey("Course_Id");
                x.ToTable("CourseRegistrations");
              });

          modelBuilder.Entity<Customer>()
             .HasMany(cs => cs.Registrations)
             .WithOptional(cs => cs.Customer)
             .Map(x => x.MapKey("CustomerId"));

          //modelBuilder.Entity<Customer>().HasMany(c => c.Registrations).WithMany().Map(
          //  x =>
          //  {
          //    x.MapLeftKey("CustomerId");
          //    x.MapRightKey("RegistrationId");
          //    x.ToTable("CustomerRegistrations");
          //  });

            base.OnModelCreating(modelBuilder);
        }
    }
}