﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEST_CRUD.Data;

#nullable disable

namespace TEST_CRUD.Migrations
{
    [DbContext(typeof(CyberSharkContext))]
    [Migration("20231124081451_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TEST_CRUD.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Brand_Image")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("brand_image");

                    b.Property<DateTime>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime>("Date_Modified")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_modied");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Category_Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime>("Date_Modified")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_modied");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Brand_Id")
                        .HasColumnType("int")
                        .HasColumnName("brand_id");

                    b.Property<int>("Category_Id")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<double?>("Cost_Price")
                        .HasColumnType("double")
                        .HasColumnName("cost_price");

                    b.Property<DateTime>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime>("Date_Modified")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_modied");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("Product_Images")
                        .HasColumnType("longtext")
                        .HasColumnName("product_images");

                    b.Property<string>("Quantity")
                        .HasColumnType("longtext")
                        .HasColumnName("quantity");

                    b.Property<double?>("Sale_Price")
                        .HasColumnType("double")
                        .HasColumnName("sale_price");

                    b.HasKey("Id");

                    b.HasIndex("Brand_Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("TEST_CRUD.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Email");

                    b.Property<string>("Hinhanh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Hinhanh");

                    b.Property<string>("Mat_khau")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Mat_khau");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Role");

                    b.Property<string>("So_dien_thoai")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("So_dien_thoai");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Ten");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Product", b =>
                {
                    b.HasOne("TEST_CRUD.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("Brand_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEST_CRUD.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
