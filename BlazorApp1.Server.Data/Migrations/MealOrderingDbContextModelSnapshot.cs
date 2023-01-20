﻿// <auto-generated />
using System;
using BlazorApp1.Server.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlazorApp1.Server.Data.Migrations
{
    [DbContext(typeof(MealOrderingDbContext))]
    partial class MealOrderingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BlazorApp1.Server.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("public.uuid_generate_v4()");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("createdate")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("created_user_id");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying")
                        .HasColumnName("description");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("expire_date");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uuid")
                        .HasColumnName("supplier_id");

                    b.HasKey("Id")
                        .HasName("pk_order_id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("SupplierId");

                    b.ToTable("orders", "public");
                });

            modelBuilder.Entity("BlazorApp1.Server.Data.Models.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("public.uuid_generate_v4()");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("createdate")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("created_user_id");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying")
                        .HasColumnName("description");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.HasKey("Id")
                        .HasName("pk_orderItem_id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_items", "public");
                });

            modelBuilder.Entity("BlazorApp1.Server.Data.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("public.uuid_generate_v4()");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("createDate")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("isActive")
                        .HasDefaultValueSql("true");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("WebURL")
                        .HasMaxLength(500)
                        .HasColumnType("character varying")
                        .HasColumnName("web_url");

                    b.HasKey("Id")
                        .HasName("pk_supplier_id");

                    b.ToTable("suppliers", "public");
                });

            modelBuilder.Entity("BlazorApp1.Server.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("public.uuid_generate_v4()");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(100)
                        .HasColumnType("character varying")
                        .HasColumnName("email_address");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("isActive")
                        .HasDefaultValueSql("true");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .HasColumnType("character varying")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("pk_user_id");

                    b.ToTable("user", "public");
                });

            modelBuilder.Entity("BlazorApp1.Server.Data.Models.Order", b =>
                {
                    b.HasOne("BlazorApp1.Server.Data.Models.User", "CreatedUser")
                        .WithMany("Orders")
                        .HasForeignKey("CreatedUserId")
                        .HasConstraintName("fk_user_order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorApp1.Server.Data.Models.Supplier", "Supplier")
                        .WithMany("Orders")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("fk_supplier_order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("BlazorApp1.Server.Data.Models.OrderItem", b =>
                {
                    b.HasOne("BlazorApp1.Server.Data.Models.User", "CreatedUser")
                        .WithMany("CreatedOrderItems")
                        .HasForeignKey("CreatedUserId")
                        .HasConstraintName("fk_orderitems_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorApp1.Server.Data.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_orderitems_order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BlazorApp1.Server.Data.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BlazorApp1.Server.Data.Models.Supplier", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BlazorApp1.Server.Data.Models.User", b =>
                {
                    b.Navigation("CreatedOrderItems");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
