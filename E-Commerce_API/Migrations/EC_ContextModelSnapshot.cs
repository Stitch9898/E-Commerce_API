﻿// <auto-generated />
using System;
using E_Commerce_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_Commerce_API.Migrations
{
    [DbContext(typeof(EC_Context))]
    partial class EC_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_Commerce_API.Models.TimeSeckill", b =>
                {
                    b.Property<int>("seckill_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("end_seckillTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("is_seckill")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("start_seckillTime")
                        .HasColumnType("datetime2");

                    b.HasKey("seckill_id");

                    b.ToTable("TimeSeckill");
                });

            modelBuilder.Entity("WebApplication_Shop_API.Models.color_info", b =>
                {
                    b.Property<int>("color_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("color_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("color_id");

                    b.ToTable("color_info");
                });

            modelBuilder.Entity("WebApplication_Shop_API.Models.customer_inf", b =>
                {
                    b.Property<int>("customer_inf_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<string>("customer_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.Property<string>("identity_card_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("identity_card_type")
                        .HasColumnType("int");

                    b.Property<string>("mobile_phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("register_time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("user_money")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("customer_inf_id");

                    b.ToTable("customer_inf");
                });

            modelBuilder.Entity("WebApplication_Shop_API.Models.customer_login", b =>
                {
                    b.Property<int>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("login_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_stats")
                        .HasColumnType("int");

                    b.HasKey("customer_id");

                    b.ToTable("customer_login");
                });

            modelBuilder.Entity("WebApplication_Shop_API.Models.order_cart", b =>
                {
                    b.Property<int>("cart_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("add_time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("product_amount")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.HasKey("cart_id");

                    b.ToTable("order_cart");
                });

            modelBuilder.Entity("WebApplication_Shop_API.Models.order_detail", b =>
                {
                    b.Property<int>("order_detail_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<int>("product_cnt")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<string>("product_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("product_price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("order_detail_id");

                    b.ToTable("order_detail");
                });

            modelBuilder.Entity("WebApplication_Shop_API.Models.order_master", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("create_time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<decimal>("order_money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("order_sn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("payment_method")
                        .HasColumnType("int");

                    b.HasKey("order_id");

                    b.ToTable("order_master");
                });

            modelBuilder.Entity("WebApplication_Shop_API.Models.product_info", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("brand_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("color_type")
                        .HasColumnType("int");

                    b.Property<string>("descript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("height")
                        .HasColumnType("real");

                    b.Property<string>("indate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("length")
                        .HasColumnType("real");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("product_core")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("publish_status")
                        .HasColumnType("int");

                    b.Property<float>("weight")
                        .HasColumnType("real");

                    b.Property<float>("width")
                        .HasColumnType("real");

                    b.HasKey("product_id");

                    b.ToTable("product_info");
                });

            modelBuilder.Entity("WebApplication_Shop_API.Models.productpicinfo", b =>
                {
                    b.Property<int>("product_pic_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("pic_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.HasKey("product_pic_id");

                    b.ToTable("productpicinfo");
                });

            modelBuilder.Entity("WebApplication_Shop_API.Models.warehouse_product", b =>
                {
                    b.Property<int>("wp_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("current_cnt")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.HasKey("wp_id");

                    b.ToTable("warehouse_product");
                });
#pragma warning restore 612, 618
        }
    }
}
