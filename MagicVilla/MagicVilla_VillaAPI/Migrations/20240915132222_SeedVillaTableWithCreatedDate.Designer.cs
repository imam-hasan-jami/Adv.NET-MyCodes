﻿// <auto-generated />
using System;
using MagicVilla_VillaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240915132222_SeedVillaTableWithCreatedDate")]
    partial class SeedVillaTableWithCreatedDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_VillaAPI.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 9, 15, 19, 22, 22, 462, DateTimeKind.Local).AddTicks(5031),
                            Details = "Luxury Villa with private pool",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                            Name = "Royal Villa",
                            Occupancy = 4,
                            Rate = 200.0,
                            Sqft = 550,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 9, 15, 19, 22, 22, 462, DateTimeKind.Local).AddTicks(5041),
                            Details = "Villa with beach view",
                            ImageUrl = "https://balesin.com/wp-content/uploads/elementor/thumbs/The-Balesin-Royal-Villa-Main-Deck_edited-scaled-qazh3d2czzwzp6bozfkerp9ekf95twqmw41hvl9xgs.jpg",
                            Name = "Beach Villa",
                            Occupancy = 3,
                            Rate = 150.0,
                            Sqft = 450,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 9, 15, 19, 22, 22, 462, DateTimeKind.Local).AddTicks(5042),
                            Details = "Villa with pool view",
                            ImageUrl = "https://www.villaseminyak.net/images/royal-villa-2-bedroom-b.jpg?x",
                            Name = "Pool Villa",
                            Occupancy = 4,
                            Rate = 180.0,
                            Sqft = 500,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 9, 15, 19, 22, 22, 462, DateTimeKind.Local).AddTicks(5043),
                            Details = "Villa with garden view",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRmgo_9YY6N9i3RPYwR2f8PE0or4f1OM_RbRw&s",
                            Name = "Garden Villa",
                            Occupancy = 3,
                            Rate = 160.0,
                            Sqft = 400,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 9, 15, 19, 22, 22, 462, DateTimeKind.Local).AddTicks(5044),
                            Details = "Villa with sea view",
                            ImageUrl = "https://www.ghmhotels.com/wp-content/uploads/5bedroom-exterior-villa.jpg",
                            Name = "Sea View Villa",
                            Occupancy = 4,
                            Rate = 220.0,
                            Sqft = 600,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
