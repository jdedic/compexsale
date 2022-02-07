using Microsoft.EntityFrameworkCore;
using RetailPlatform.Common.Entities;
using System;

namespace RetailPlatform.Infrastructure.Data
{
    public class RetailContext : DbContext
    {
        public RetailContext(DbContextOptions<RetailContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Administrator" },
                new Role { Id = 2, Name = "Controller" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Jovana", LastName = "Dedic", RegistrationDate = DateTime.Now, Address = "Augusta Cesarca 17", City = "Novi Sad", ZipCode = "21000", Email = "jovanna.deddic@gmail.com", Telephone = "069 5485 156", Password = "$2a$12$mSRDmGVv.FFskW4e8XD1eehfSBYFcilJmeHiQeKqpIZ786QmYB0GO", ForgotPasswordToken = null, Active = true, WorkingPosition = "Business Manager", RoleId = 1 },
                new User { Id = 2, FirstName = "Marko", LastName = "Jankovic", RegistrationDate = DateTime.Now, Address = "Radnicka 8", City = "Novi Sad", ZipCode = "21000", Email = "marko.jankovic@gmail.test", Telephone = "069 5485 156", Password = "$2a$12$mSRDmGVv.FFskW4e8XD1eehfSBYFcilJmeHiQeKqpIZ786QmYB0GO", ForgotPasswordToken = null, Active = true, WorkingPosition = "Business Manager", RoleId = 2 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Poljoprivreda" },
                new Category { Id = 2, Name = "Nekretnine" }
            );

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory { Id = 1, Name = "Poljoprivreda i šumarstvo", CategoryId = 1 },
                new SubCategory { Id = 2, Name = "Životinje", CategoryId = 1 },
                new SubCategory { Id = 3, Name = "Prehrambeni proizvodi", CategoryId = 1 },
                new SubCategory { Id = 5, Name = "Građevinarstvo", CategoryId = 2 },
                new SubCategory { Id = 6, Name = "Nekretnine", CategoryId = 2 },
                new SubCategory { Id = 10, Name = "Plovni objekti i sredstva", CategoryId = 2 }
            );

            modelBuilder.Entity<UnitType>().HasData(
               new UnitType { Id = 1, Name = "komad" },
               new UnitType { Id = 2, Name = "m" },
               new UnitType { Id = 3, Name = "m²" },
               new UnitType { Id = 4, Name = "m3" },
               new UnitType { Id = 5, Name = "t"},
               new UnitType { Id = 6, Name = "l" },
               new UnitType { Id = 7, Name = "kg" }
           );

            modelBuilder.Entity<JobType>().HasData(
              new JobType { Id = 1, Name = "Ponuda" },
              new JobType { Id = 2, Name = "Tražnja" }
          );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Add> Adds { get; set; }
        public DbSet<ProfileCategory> ProfileCategories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
    }
}
