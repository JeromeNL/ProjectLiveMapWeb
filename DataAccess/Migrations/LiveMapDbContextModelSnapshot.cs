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
                            Latitude = 51.688403441591433,
                            Longitude = 5.2859250150824995,
                            Name = "Sportveld",
                            Type = "Sport"
                        },
                        new
                        {
                            Id = -2,
                            Description = "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.",
                            IconUrl = "https://cdn-icons-png.freepik.com/512/50/50004.png",
                            Latitude = 51.688673302068032,
                            Longitude = 5.284670979381513,
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

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("FacilityReports");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreatedAt = new DateTime(2024, 3, 10, 19, 53, 28, 841, DateTimeKind.Local).AddTicks(339),
                            Description = "Het sportveld is in goede staat.",
                            FacilityId = -1,
                            Status = 0
                        },
                        new
                        {
                            Id = -2,
                            CreatedAt = new DateTime(2024, 3, 10, 19, 53, 28, 841, DateTimeKind.Local).AddTicks(395),
                            Description = "Het zwemmeer is in goede staat.",
                            FacilityId = -2,
                            Status = 0
                        });
                });

            modelBuilder.Entity("DataAccess.Models.FacilityReport", b =>
                {
                    b.HasOne("DataAccess.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");
                });
#pragma warning restore 612, 618
        }
    }
}
