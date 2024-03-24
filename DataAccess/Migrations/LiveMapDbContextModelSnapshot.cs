﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(LiveMapDbContext))]
    partial class LiveMapDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
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
                            Id = -1,
                            Description = "Op het sportveld kun je allerlei activiteiten doen. Denk aan voetballen, basketballen en tennissen.",
                            IconUrl = "https://cdn-icons-png.flaticon.com/512/4344/4344985.png",
                            Latitude = 51.343434225015848,
                            Longitude = 5.2462238073349008,
                            Name = "Sportveld",
                            Type = "Sport"
                        },
                        new
                        {
                            Id = -2,
                            Description = "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.",
                            IconUrl = "https://cdn-icons-png.freepik.com/512/50/50004.png",
                            Latitude = 51.341722544598902,
                            Longitude = 5.2455371618270883,
                            Name = "Zwemmeer",
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

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<int>("ProposedFacilityChangeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.HasIndex("ProposedFacilityChangeId");

                    b.ToTable("FacilityReports");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreatedAt = new DateTime(2024, 3, 19, 13, 40, 17, 199, DateTimeKind.Local).AddTicks(3970),

                            Description = "Het sportveld is in goede staat.",
                            FacilityId = -1,
                            ProposedFacilityChangeId = -1,
                            Status = 0
                        },
                        new
                        {
                            Id = -2,
                            CreatedAt = new DateTime(2024, 3, 19, 13, 40, 17, 199, DateTimeKind.Local).AddTicks(4010),

                            Description = "Het zwemmeer is in goede staat.",
                            FacilityId = -2,
                            ProposedFacilityChangeId = -2,
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

                    b.Property<string>("IconUrl")
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

                    b.ToTable("ProposedFacilities");
                });

            modelBuilder.Entity("DataAccess.Models.ProposedFacilityChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
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

                    b.ToTable("ProposedFacilityChanges");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "Op het sportveld kun je allerlei activiteiten doen. Denk aan voetballen, basketballen en tennissen.",
                            IconUrl = "https://cdn-icons-png.flaticon.com/512/4344/4344985.png",
                            Latitude = 51.343434225015848,
                            Longitude = 5.2462238073349008,
                            Name = "Sportveld Hoevelake",
                            Type = "Sport"
                        },
                        new
                        {
                            Id = -2,
                            Description = "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.",
                            IconUrl = "https://cdn-icons-png.freepik.com/512/50/50004.png",
                            Latitude = 51.341722544598902,
                            Longitude = 5.2455371618270883,
                            Name = "Zwemmeer JAKDKJLDUIIRUFJK",
                            Type = "Recreatie"
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
                            Id = -1,
                            Name = "Almior"
                        },
                        new
                        {
                            Id = -2,
                            Name = "Joram"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.FacilityReport", b =>
                {
                    b.HasOne("DataAccess.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.ProposedFacilityChange", "ProposedFacilityChange")
                        .WithMany()
                        .HasForeignKey("ProposedFacilityChangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");

                    b.Navigation("ProposedFacilityChange");
                });
#pragma warning restore 612, 618
        }
    }
}
