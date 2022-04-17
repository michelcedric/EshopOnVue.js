﻿// <auto-generated />
using System;
using EshopOnVue.js.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EshopOnVue.js.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EshopContext))]
    [Migration("20220417080650_Basket")]
    partial class Basket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EshopOnVue.js.Core.Entities.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("EshopOnVue.js.Core.Entities.BasketItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<Guid?>("BasketId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CatalogItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BasketId1");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("EshopOnVue.js.Core.Entities.CatalogItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CatalogItems");
                });

            modelBuilder.Entity("EshopOnVue.js.Core.Entities.BasketItem", b =>
                {
                    b.HasOne("EshopOnVue.js.Core.Entities.Basket", null)
                        .WithMany("Items")
                        .HasForeignKey("BasketId1");
                });

            modelBuilder.Entity("EshopOnVue.js.Core.Entities.Basket", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
