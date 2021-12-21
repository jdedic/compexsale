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
                new Category { Id = 1, Name = "Poljoprivreda i šumarstvo" },
                new Category { Id = 2, Name = "Životinje" },
                new Category { Id = 3, Name = "Prehrambeni proizvodi" },
                new Category { Id = 4, Name = "Rudarstvo" },
                new Category { Id = 5, Name = "Građevinarstvo" },
                new Category { Id = 6, Name = "Nekretnine" },
                new Category { Id = 7, Name = "Mašine" },
                new Category { Id = 8, Name = "Oprema i alati" },
                new Category { Id = 9, Name = "Vozila" },
                new Category { Id = 10, Name = "Plovni objekti i sredstva" },
                new Category { Id = 11, Name = "Goriva" },
                new Category { Id = 12, Name = "Razni proizvodi i oprema" },
                new Category { Id = 13, Name = "Kancelarijske mašine" },
                new Category { Id = 14, Name = "Mobilni uređaji, tehnika (aparati i uređaji)" },
                new Category { Id = 15, Name = "Električne mašine i alati" },
                new Category { Id = 16, Name = "Odeća, obuća i tekstil" },
                new Category { Id = 17, Name = "Nameštaj" },
                new Category { Id = 18, Name = "Hemijski proizvodi" },
                new Category { Id = 19, Name = "Bebi oprema i dečije stvari" },
                new Category { Id = 20, Name = "Aksesoari" },
                new Category { Id = 21, Name = "Sportska oprema i rekviziti" },
                new Category { Id = 22, Name = "Umetnost i razonoda" },
                new Category { Id = 23, Name = "Obrazovanje" }
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Add> Adds { get; set; }
        public DbSet<ProfileCategory> ProfileCategories { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
