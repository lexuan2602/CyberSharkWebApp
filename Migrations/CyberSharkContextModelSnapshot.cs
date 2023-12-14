﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEST_CRUD.Data;

#nullable disable

namespace TEST_CRUD.Migrations
{
    [DbContext(typeof(CyberSharkContext))]
    partial class CyberSharkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TEST_CRUD.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address_City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("address_city");

                    b.Property<string>("Address_Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("address_country");

                    b.Property<string>("Address_District")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("address_district");

                    b.Property<string>("Address_Street")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("address_street");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<DateTime?>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime?>("Date_Modified")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_modied");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Is_Default")
                        .HasColumnType("int")
                        .HasColumnName("is_default");

                    b.Property<string>("Receiver_Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("receiver_name");

                    b.Property<string>("Receiver_Telephone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("receiver_telephone");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Admin_Images")
                        .HasColumnType("longtext")
                        .HasColumnName("admin_images");

                    b.Property<string>("Admin_Type")
                        .HasColumnType("longtext")
                        .HasColumnName("admin_type");

                    b.Property<DateTime?>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime?>("Date_Modified")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_modied");

                    b.Property<DateTime?>("Date_Of_Birth")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("Sex")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("sex");

                    b.Property<string>("Telephone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telephone");

                    b.HasKey("Id");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Blog_Images")
                        .HasColumnType("longtext")
                        .HasColumnName("blog_images");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("content");

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

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("Blog");
                });

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

            modelBuilder.Entity("TEST_CRUD.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Cart_Detail")
                        .HasColumnType("longtext")
                        .HasColumnName("cart_detail");

                    b.Property<double?>("Cart_Number_Item")
                        .HasColumnType("double")
                        .HasColumnName("cart_number_item");

                    b.Property<double?>("Cart_Total")
                        .HasColumnType("double")
                        .HasColumnName("cart_total");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<DateTime?>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime?>("Date_Modified")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_modied");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("Customer_Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Category_Images")
                        .HasColumnType("longtext")
                        .HasColumnName("category_images");

                    b.Property<DateTime?>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime?>("Date_Modified")
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

            modelBuilder.Entity("TEST_CRUD.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("Accumulate_Point")
                        .HasColumnType("int")
                        .HasColumnName("accumulate_point");

                    b.Property<string>("Customer_Images")
                        .HasColumnType("longtext")
                        .HasColumnName("customer_images");

                    b.Property<DateTime>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime>("Date_Modified")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_modied");

                    b.Property<DateTime?>("Date_Of_Birth")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("Sex")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("sex");

                    b.Property<string>("Telephone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telephone");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Address_Id")
                        .HasColumnType("int")
                        .HasColumnName("address_id");

                    b.Property<double?>("Cost")
                        .HasColumnType("double")
                        .HasColumnName("cost");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<DateTime?>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime?>("Date_Modified")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_modied");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Order_Detail")
                        .HasColumnType("longtext")
                        .HasColumnName("order_detail");

                    b.Property<string>("Order_Number")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("order_number");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("Address_Id");

                    b.HasIndex("Customer_Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<double?>("Amount")
                        .HasColumnType("double")
                        .HasColumnName("amount");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<DateTime?>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime?>("Date_Modified")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_modied");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Order_Number")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("order_number");

                    b.Property<string>("Payment_Id")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("payment_id");

                    b.Property<string>("Payment_Url")
                        .HasColumnType("longtext")
                        .HasColumnName("payment_url");

                    b.Property<string>("Status")
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
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

                    b.Property<DateTime?>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime?>("Date_Modified")
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

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<double?>("Sale_Price")
                        .HasColumnType("double")
                        .HasColumnName("sale_price");

                    b.HasKey("Id");

                    b.HasIndex("Brand_Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("content");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

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

                    b.Property<int>("Product_Id")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<string>("Review_Images")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("review_images");

                    b.HasKey("Id");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Review");
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

            modelBuilder.Entity("TEST_CRUD.Models.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date_Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_deleted");

                    b.Property<DateTime?>("Date_Expired")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_expired");

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

                    b.Property<double>("Percent")
                        .HasColumnType("double")
                        .HasColumnName("percent");

                    b.HasKey("Id");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("TEST_CRUD.Models.VoucherOrders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

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

                    b.Property<int>("Order_Id")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("Voucher_Id")
                        .HasColumnType("int")
                        .HasColumnName("voucher_id");

                    b.HasKey("Id");

                    b.HasIndex("Order_Id");

                    b.HasIndex("Voucher_Id");

                    b.ToTable("VoucherOrder");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Cart", b =>
                {
                    b.HasOne("TEST_CRUD.Models.Customer", "Customer")
                        .WithMany("Carts")
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Order", b =>
                {
                    b.HasOne("TEST_CRUD.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("Address_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEST_CRUD.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Payment", b =>
                {
                    b.HasOne("TEST_CRUD.Models.Customer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEST_CRUD.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Product", b =>
                {
                    b.HasOne("TEST_CRUD.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("Brand_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEST_CRUD.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Review", b =>
                {
                    b.HasOne("TEST_CRUD.Models.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEST_CRUD.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TEST_CRUD.Models.VoucherOrders", b =>
                {
                    b.HasOne("TEST_CRUD.Models.Order", "Order")
                        .WithMany("VoucherOrders")
                        .HasForeignKey("Order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEST_CRUD.Models.Voucher", "Voucher")
                        .WithMany("VoucherOrders")
                        .HasForeignKey("Voucher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Customer", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Payments");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Order", b =>
                {
                    b.Navigation("VoucherOrders");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Product", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TEST_CRUD.Models.Voucher", b =>
                {
                    b.Navigation("VoucherOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
