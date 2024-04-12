﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(LiveMapDbContext))]
    [Migration("20240412095820_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Models.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Facilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Restaurant de Kom is een gezellig restaurant",
                            IconName = "trash",
                            Latitude = 51.647970807304127,
                            Longitude = 5.0468584734210191,
                            Name = "Restaurant de Kom",
                            Type = "Restaurant"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.",
                            IconName = "chef-hat",
                            Latitude = 51.647223135629211,
                            Longitude = 5.05165372379847,
                            Name = "Zwemmeer",
                            Type = "Recreatie"
                        },
                        new
                        {
                            Id = 3,
                            Description = "De speeltuin is een leuke plek voor kinderen om te spelen.",
                            IconName = "horse-toy",
                            Latitude = 51.651976894252684,
                            Longitude = 5.0534545833544868,
                            Name = "Speeltuin",
                            Type = "Recreatie"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.FacilityReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProposedFacilityId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("ProposedFacilityId");

                    b.ToTable("FacilityReports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(529),
                            Description = "Seed",
                            ProposedFacilityId = 1,
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(586),
                            Description = "Seed",
                            ProposedFacilityId = 2,
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(588),
                            Description = "Seed",
                            ProposedFacilityId = 3,
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(589),
                            Description = "Seed",
                            ProposedFacilityId = 4,
                            Status = 0
                        });
                });

            modelBuilder.Entity("DataAccess.Models.ProposedFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("IconName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("ProposedFacilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Restaurant de Kom is een gezellig restaurant",
                            FacilityId = 1,
                            IconName = "trash",
                            Latitude = 51.647970807304127,
                            Longitude = 5.0468584734210191,
                            Name = "Restaurant de Kom",
                            Type = "Restaurant"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.",
                            FacilityId = 2,
                            IconName = "chef-hat",
                            Latitude = 51.647223135629211,
                            Longitude = 5.05165372379847,
                            Name = "Zwemmeer",
                            Type = "Recreatie"
                        },
                        new
                        {
                            Id = 3,
                            Description = "De speeltuin is een leuke plek voor kinderen om te spelen.",
                            FacilityId = 3,
                            IconName = "horse-toy",
                            Latitude = 51.651976894252684,
                            Longitude = 5.0534545833544868,
                            Name = "Speeltuin",
                            Type = "Recreatie"
                        },
                        new
                        {
                            Id = 4,
                            Description = "De nieuwe zwemzee",
                            IconName = "trash",
                            Latitude = 51.651976894252684,
                            Longitude = 5.0534545833544868,
                            Name = "Zwemzee",
                            Type = "Recreatie"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.ServiceReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceReportCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.HasIndex("ServiceReportCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("ServiceReports");
                });

            modelBuilder.Entity("DataAccess.Models.ServiceReportCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceReportCategories");
                });

            modelBuilder.Entity("DataAccess.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Almior"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Joram"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Thieme"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mauro"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Imke"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Lamine"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.FacilityReport", b =>
                {
                    b.HasOne("DataAccess.Models.ProposedFacility", "ProposedFacility")
                        .WithMany()
                        .HasForeignKey("ProposedFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProposedFacility");
                });

            modelBuilder.Entity("DataAccess.Models.ProposedFacility", b =>
                {
                    b.HasOne("DataAccess.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("DataAccess.Models.ServiceReport", b =>
                {
                    b.HasOne("DataAccess.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.ServiceReportCategory", "ServiceReportCategory")
                        .WithMany()
                        .HasForeignKey("ServiceReportCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");

                    b.Navigation("ServiceReportCategory");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
