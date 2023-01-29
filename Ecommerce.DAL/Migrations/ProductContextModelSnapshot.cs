﻿// <auto-generated />
using System;
using Ecommerce.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecommerce.DAL.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ecommerce.DAL.Entities.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CountyId");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.District", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CityId");

                    b.ToTable("districts");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderTime")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.OrderProduct", b =>
                {
                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.HasKey("orderId", "productId");

                    b.HasIndex("productId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Describ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<string>("productUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.Supplier", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Fileurl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photourl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("DistrictId");

                    b.ToTable("suppliers");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.City", b =>
                {
                    b.HasOne("Ecommerce.DAL.Entities.Country", "country")
                        .WithMany()
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.District", b =>
                {
                    b.HasOne("Ecommerce.DAL.Entities.City", "city")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.Order", b =>
                {
                    b.HasOne("Ecommerce.DAL.Entities.Customer", "Customer")
                        .WithOne("order")
                        .HasForeignKey("Ecommerce.DAL.Entities.Order", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.OrderProduct", b =>
                {
                    b.HasOne("Ecommerce.DAL.Entities.Order", "order")
                        .WithMany("OrderProduct")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.DAL.Entities.Product", "Product")
                        .WithMany("OrderProduct")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.Supplier", b =>
                {
                    b.HasOne("Ecommerce.DAL.Entities.District", "district")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("district");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.Customer", b =>
                {
                    b.Navigation("order");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderProduct");
                });

            modelBuilder.Entity("Ecommerce.DAL.Entities.Product", b =>
                {
                    b.Navigation("OrderProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
