﻿// <auto-generated />
using System;
using JSJMExoticCarsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JSJMExoticCarsWebApp.Migrations
{
    [DbContext(typeof(CarDbContext))]
    partial class CarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JSJMExoticCarsWebApp.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("car_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_brand");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_description");

                    b.Property<int>("Fuel")
                        .HasColumnType("int")
                        .HasColumnName("car_fueltype");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_image_url");

                    b.Property<bool>("Listed")
                        .HasColumnType("bit")
                        .HasColumnName("car_listed");

                    b.Property<int>("Mileage")
                        .HasColumnType("int")
                        .HasColumnName("car_milage");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_model");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int")
                        .HasColumnName("car_model_year");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("car_price");

                    b.Property<int>("Transmission")
                        .HasColumnType("int")
                        .HasColumnName("car_transmission");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CarTable");
                });

            modelBuilder.Entity("JSJMExoticCarsWebApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Funds")
                        .HasColumnType("int")
                        .HasColumnName("user_funds");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_password");

                    b.HasKey("Id");

                    b.ToTable("UsersTable");
                });

            modelBuilder.Entity("JSJMExoticCarsWebApp.Models.Car", b =>
                {
                    b.HasOne("JSJMExoticCarsWebApp.Models.User", null)
                        .WithMany("Cars")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("JSJMExoticCarsWebApp.Models.User", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
