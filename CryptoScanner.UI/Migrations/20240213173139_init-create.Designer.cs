﻿// <auto-generated />
using System;
using CryptoScanner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CryptoScanner.UI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240213173139_init-create")]
    partial class initcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CryptoScanner.Data.Models.CryptoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApiId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Currency");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApiId = "bitcoin",
                            Name = "Bitcoin",
                            Price = 514135m
                        },
                        new
                        {
                            Id = 2,
                            ApiId = "dogecoin",
                            Name = "Dogecoin",
                            Price = 0.854076m
                        },
                        new
                        {
                            Id = 3,
                            ApiId = "tether",
                            Name = "Tether",
                            Price = 10.59m
                        },
                        new
                        {
                            Id = 4,
                            ApiId = "solana",
                            Name = "Solana",
                            Price = 1158.27m
                        },
                        new
                        {
                            Id = 5,
                            ApiId = "cardano",
                            Name = "Cardano",
                            Price = 5.7m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}