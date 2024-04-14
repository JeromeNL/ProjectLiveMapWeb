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
    [Migration("20240414171348_Seeddata_Changed3")]
    partial class Seeddata_Changed3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Models.DefaultOpeningHours", b =>
                {
                    b.Property<int>("WeekDay")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("CloseTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("OpenTime")
                        .HasColumnType("time");

                    b.Property<int?>("ProposedFacilityId")
                        .HasColumnType("int");

                    b.HasKey("WeekDay", "FacilityId");

                    b.HasIndex("FacilityId");

                    b.HasIndex("ProposedFacilityId");

                    b.ToTable("DefaultOpeningHours");

                    b.HasData(
                        new
                        {
                            WeekDay = 1,
                            FacilityId = 1,
                            CloseTime = new TimeOnly(20, 0, 0),
                            OpenTime = new TimeOnly(14, 0, 0)
                        },
                        new
                        {
                            WeekDay = 2,
                            FacilityId = 1,
                            CloseTime = new TimeOnly(20, 0, 0),
                            OpenTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            WeekDay = 3,
                            FacilityId = 1,
                            CloseTime = new TimeOnly(21, 0, 0),
                            OpenTime = new TimeOnly(11, 0, 0)
                        },
                        new
                        {
                            WeekDay = 4,
                            FacilityId = 1,
                            CloseTime = new TimeOnly(21, 0, 0),
                            OpenTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            WeekDay = 5,
                            FacilityId = 1,
                            CloseTime = new TimeOnly(21, 0, 0),
                            OpenTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            WeekDay = 6,
                            FacilityId = 1,
                            CloseTime = new TimeOnly(23, 0, 0),
                            OpenTime = new TimeOnly(9, 0, 0)
                        },
                        new
                        {
                            WeekDay = 0,
                            FacilityId = 1,
                            CloseTime = new TimeOnly(23, 59, 0),
                            OpenTime = new TimeOnly(0, 0, 0)
                        },
                        new
                        {
                            WeekDay = 1,
                            FacilityId = 2,
                            CloseTime = new TimeOnly(20, 0, 0),
                            OpenTime = new TimeOnly(14, 0, 0)
                        },
                        new
                        {
                            WeekDay = 2,
                            FacilityId = 2,
                            CloseTime = new TimeOnly(20, 0, 0),
                            OpenTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            WeekDay = 3,
                            FacilityId = 2,
                            CloseTime = new TimeOnly(21, 0, 0),
                            OpenTime = new TimeOnly(11, 0, 0)
                        },
                        new
                        {
                            WeekDay = 4,
                            FacilityId = 2,
                            CloseTime = new TimeOnly(21, 0, 0),
                            OpenTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            WeekDay = 5,
                            FacilityId = 2,
                            CloseTime = new TimeOnly(21, 0, 0),
                            OpenTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            WeekDay = 6,
                            FacilityId = 2,
                            CloseTime = new TimeOnly(23, 0, 0),
                            OpenTime = new TimeOnly(9, 0, 0)
                        },
                        new
                        {
                            WeekDay = 0,
                            FacilityId = 2,
                            CloseTime = new TimeOnly(23, 59, 0),
                            OpenTime = new TimeOnly(0, 0, 0)
                        },
                        new
                        {
                            WeekDay = 1,
                            FacilityId = 3,
                            CloseTime = new TimeOnly(20, 0, 0),
                            OpenTime = new TimeOnly(14, 0, 0)
                        },
                        new
                        {
                            WeekDay = 2,
                            FacilityId = 3,
                            CloseTime = new TimeOnly(20, 0, 0),
                            OpenTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            WeekDay = 3,
                            FacilityId = 3,
                            CloseTime = new TimeOnly(21, 0, 0),
                            OpenTime = new TimeOnly(11, 0, 0)
                        },
                        new
                        {
                            WeekDay = 4,
                            FacilityId = 3,
                            CloseTime = new TimeOnly(21, 0, 0),
                            OpenTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            WeekDay = 5,
                            FacilityId = 3,
                            CloseTime = new TimeOnly(21, 0, 0),
                            OpenTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            WeekDay = 6,
                            FacilityId = 3,
                            CloseTime = new TimeOnly(23, 0, 0),
                            OpenTime = new TimeOnly(9, 0, 0)
                        },
                        new
                        {
                            WeekDay = 0,
                            FacilityId = 3,
                            CloseTime = new TimeOnly(23, 59, 0),
                            OpenTime = new TimeOnly(0, 0, 0)
                        });
                });

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
                            CreatedAt = new DateTime(2024, 4, 14, 19, 13, 47, 488, DateTimeKind.Local).AddTicks(3060),
                            Description = "Seed",
                            ProposedFacilityId = 1,
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 4, 14, 19, 13, 47, 488, DateTimeKind.Local).AddTicks(3150),
                            Description = "Seed",
                            ProposedFacilityId = 2,
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 4, 14, 19, 13, 47, 488, DateTimeKind.Local).AddTicks(3150),
                            Description = "Seed",
                            ProposedFacilityId = 3,
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 4, 14, 19, 13, 47, 488, DateTimeKind.Local).AddTicks(3160),
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

            modelBuilder.Entity("DataAccess.Models.SpecialOpeningHours", b =>
                {
                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("CloseTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("OpenTime")
                        .HasColumnType("time");

                    b.Property<int?>("ProposedFacilityId")
                        .HasColumnType("int");

                    b.HasKey("Date", "FacilityId");

                    b.HasIndex("FacilityId");

                    b.HasIndex("ProposedFacilityId");

                    b.ToTable("SpecialOpeningHours");

                    b.HasData(
                        new
                        {
                            Date = new DateOnly(2024, 4, 16),
                            FacilityId = 1,
                            CloseTime = new TimeOnly(23, 30, 0),
                            OpenTime = new TimeOnly(6, 0, 0)
                        },
                        new
                        {
                            Date = new DateOnly(2024, 4, 19),
                            FacilityId = 1,
                            CloseTime = new TimeOnly(14, 0, 0),
                            OpenTime = new TimeOnly(9, 0, 0)
                        },
                        new
                        {
                            Date = new DateOnly(2024, 4, 29),
                            FacilityId = 1,
                            CloseTime = new TimeOnly(22, 0, 0),
                            OpenTime = new TimeOnly(15, 0, 0)
                        });
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
                        });
                });

            modelBuilder.Entity("DataAccess.Models.DefaultOpeningHours", b =>
                {
                    b.HasOne("DataAccess.Models.Facility", "Facility")
                        .WithMany("DefaultOpeningHours")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.ProposedFacility", null)
                        .WithMany("DefaultOpeningHours")
                        .HasForeignKey("ProposedFacilityId");

                    b.Navigation("Facility");
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

            modelBuilder.Entity("DataAccess.Models.SpecialOpeningHours", b =>
                {
                    b.HasOne("DataAccess.Models.Facility", "Facility")
                        .WithMany("SpecialOpeningHours")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.ProposedFacility", null)
                        .WithMany("SpecialOpeningHours")
                        .HasForeignKey("ProposedFacilityId");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("DataAccess.Models.Facility", b =>
                {
                    b.Navigation("DefaultOpeningHours");

                    b.Navigation("SpecialOpeningHours");
                });

            modelBuilder.Entity("DataAccess.Models.ProposedFacility", b =>
                {
                    b.Navigation("DefaultOpeningHours");

                    b.Navigation("SpecialOpeningHours");
                });
#pragma warning restore 612, 618
        }
    }
}
