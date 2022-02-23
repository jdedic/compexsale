﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RetailPlatform.Infrastructure.Data;

namespace RetailPlatform.Infrastructure.Migrations
{
    [DbContext(typeof(RetailContext))]
    partial class RetailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RetailPlatform.Common.Entities.Add", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsComepnsation")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDiscontSale")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExchange")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMailSent")
                        .HasColumnType("bit");

                    b.Property<long>("JobTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<long>("ProfileId")
                        .HasColumnType("bigint");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<string>("ReasonForRefusal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SubCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("UniqueId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UnitTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("JobTypeId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("Adds");
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            IsAssigned = false,
                            Name = "Poljoprivreda"
                        },
                        new
                        {
                            Id = 2L,
                            IsAssigned = false,
                            Name = "Nekretnine"
                        });
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.JobType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Ponuda"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Tražnja"
                        });
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.ProfileCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProfileId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileCategories");
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.ProfileModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AgreeWithTermsAndConditions")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interests")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCustomer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVendor")
                        .HasColumnType("bit");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LegalEntity")
                        .HasColumnType("bit");

                    b.Property<string>("PIB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Controller"
                        });
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.SubCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CategoryId = 1L,
                            Name = "Poljoprivreda i šumarstvo"
                        },
                        new
                        {
                            Id = 2L,
                            CategoryId = 1L,
                            Name = "Životinje"
                        },
                        new
                        {
                            Id = 3L,
                            CategoryId = 1L,
                            Name = "Prehrambeni proizvodi"
                        },
                        new
                        {
                            Id = 5L,
                            CategoryId = 2L,
                            Name = "Građevinarstvo"
                        },
                        new
                        {
                            Id = 6L,
                            CategoryId = 2L,
                            Name = "Nekretnine"
                        },
                        new
                        {
                            Id = 10L,
                            CategoryId = 2L,
                            Name = "Plovni objekti i sredstva"
                        });
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.UnitType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnitTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "komad"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "m"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "m²"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "m3"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "t"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "l"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "kg"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "pal (paleta)"
                        });
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForgotPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Active = true,
                            Address = "Augusta Cesarca 17",
                            City = "Novi Sad",
                            Email = "jovanna.deddic@gmail.com",
                            FirstName = "Jovana",
                            LastName = "Dedic",
                            Password = "$2a$12$mSRDmGVv.FFskW4e8XD1eehfSBYFcilJmeHiQeKqpIZ786QmYB0GO",
                            RegistrationDate = new DateTime(2022, 2, 23, 22, 21, 12, 699, DateTimeKind.Local).AddTicks(6533),
                            RoleId = 1L,
                            Telephone = "069 5485 156",
                            WorkingPosition = "Business Manager",
                            ZipCode = "21000"
                        },
                        new
                        {
                            Id = 2L,
                            Active = true,
                            Address = "Radnicka 8",
                            City = "Novi Sad",
                            Email = "marko.jankovic@gmail.test",
                            FirstName = "Marko",
                            LastName = "Jankovic",
                            Password = "$2a$12$mSRDmGVv.FFskW4e8XD1eehfSBYFcilJmeHiQeKqpIZ786QmYB0GO",
                            RegistrationDate = new DateTime(2022, 2, 23, 22, 21, 12, 706, DateTimeKind.Local).AddTicks(2666),
                            RoleId = 2L,
                            Telephone = "069 5485 156",
                            WorkingPosition = "Business Manager",
                            ZipCode = "21000"
                        });
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.Add", b =>
                {
                    b.HasOne("RetailPlatform.Common.Entities.JobType", "JobType")
                        .WithMany()
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailPlatform.Common.Entities.ProfileModel", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailPlatform.Common.Entities.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailPlatform.Common.Entities.UnitType", "UnitType")
                        .WithMany()
                        .HasForeignKey("UnitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobType");

                    b.Navigation("Profile");

                    b.Navigation("SubCategory");

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.ProfileCategory", b =>
                {
                    b.HasOne("RetailPlatform.Common.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailPlatform.Common.Entities.ProfileModel", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.SubCategory", b =>
                {
                    b.HasOne("RetailPlatform.Common.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RetailPlatform.Common.Entities.User", b =>
                {
                    b.HasOne("RetailPlatform.Common.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
