﻿// <auto-generated />
using CoreFitness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreFitness.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190808053214_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreFitness.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Availability");

                    b.Property<string>("Description");

                    b.Property<string>("ImageURL");

                    b.Property<string>("Name");

                    b.Property<string>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CoreFitness.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderQty");

                    b.Property<int>("ProductID");

                    b.Property<string>("ProductName");

                    b.Property<int>("SessionID");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCart");
                });
#pragma warning restore 612, 618
        }
    }
}