﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductDemoMvc.Context;

namespace ProductDemoMvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181114055849_Frist")]
    partial class Frist
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductDemoMvc.DataModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new { Id = 1, CreatedOn = new DateTime(2018, 11, 14, 10, 58, 49, 270, DateTimeKind.Local), Name = "Order1" },
                        new { Id = 2, CreatedOn = new DateTime(2018, 11, 14, 10, 58, 49, 271, DateTimeKind.Local), Name = "Order1" },
                        new { Id = 3, CreatedOn = new DateTime(2018, 11, 14, 5, 58, 49, 271, DateTimeKind.Utc), Name = "Order2" }
                    );
                });

            modelBuilder.Entity("ProductDemoMvc.DataModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("OrderId");

                    b.Property<string>("PhysicalPath");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, Name = "Apple", OrderId = 1, Price = 1.2m },
                        new { Id = 2, Name = "Orange", OrderId = 1, Price = 2.4m },
                        new { Id = 3, Name = "Graphes", OrderId = 2, Price = 3.4m }
                    );
                });

            modelBuilder.Entity("ProductDemoMvc.DataModels.Product", b =>
                {
                    b.HasOne("ProductDemoMvc.DataModels.Order", "Orders")
                        .WithMany("Product")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
