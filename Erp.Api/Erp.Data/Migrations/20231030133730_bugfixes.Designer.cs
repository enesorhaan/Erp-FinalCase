﻿// <auto-generated />
using System;
using Erp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Erp.Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231030133730_bugfixes")]
    partial class bugfixes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Erp.Data.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("LastActivityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PasswordRetryCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Company", "dbo");
                });

            modelBuilder.Entity("Erp.Data.Entities.CurrentAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<decimal?>("CreditLimit")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DealerId", "CompanyId")
                        .IsUnique();

                    b.ToTable("CurrentAccount", "dbo");
                });

            modelBuilder.Entity("Erp.Data.Entities.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("BillingAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentAccountId")
                        .HasColumnType("int");

                    b.Property<string>("DealerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("LastActivityDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("MarginPercentage")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PasswordRetryCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("TaxNumber")
                        .HasColumnType("int");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CurrentAccountId")
                        .IsUnique()
                        .HasFilter("[CurrentAccountId] IS NOT NULL");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Dealer", "dbo");
                });

            modelBuilder.Entity("Erp.Data.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Messages")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DealerId", "CompanyId")
                        .IsUnique();

                    b.ToTable("Message", "dbo");
                });

            modelBuilder.Entity("Erp.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BillingNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BillingNumber")
                        .IsUnique();

                    b.HasIndex("DealerId");

                    b.ToTable("Orders", "dbo");
                });

            modelBuilder.Entity("Erp.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<decimal>("MarginPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("OrderId", "ProductId")
                        .IsUnique();

                    b.ToTable("OrderItem", "dbo");
                });

            modelBuilder.Entity("Erp.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("ProductPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductStock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductName")
                        .IsUnique();

                    b.ToTable("Product", "dbo");
                });

            modelBuilder.Entity("Erp.Data.Entities.CurrentAccount", b =>
                {
                    b.HasOne("Erp.Data.Entities.Company", "Company")
                        .WithMany("CurrentAccounts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Erp.Data.Entities.Dealer", b =>
                {
                    b.HasOne("Erp.Data.Entities.Company", "Company")
                        .WithMany("Dealers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Erp.Data.Entities.CurrentAccount", "CurrentAccount")
                        .WithOne("Dealer")
                        .HasForeignKey("Erp.Data.Entities.Dealer", "CurrentAccountId");

                    b.Navigation("Company");

                    b.Navigation("CurrentAccount");
                });

            modelBuilder.Entity("Erp.Data.Entities.Message", b =>
                {
                    b.HasOne("Erp.Data.Entities.Company", "Company")
                        .WithMany("Messages")
                        .HasForeignKey("CompanyId")
                        .IsRequired();

                    b.HasOne("Erp.Data.Entities.Dealer", "Dealer")
                        .WithMany("Messages")
                        .HasForeignKey("DealerId")
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("Erp.Data.Entities.Order", b =>
                {
                    b.HasOne("Erp.Data.Entities.Dealer", "Dealer")
                        .WithMany("Orders")
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("Erp.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("Erp.Data.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .IsRequired();

                    b.HasOne("Erp.Data.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Erp.Data.Entities.Product", b =>
                {
                    b.HasOne("Erp.Data.Entities.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Erp.Data.Entities.Company", b =>
                {
                    b.Navigation("CurrentAccounts");

                    b.Navigation("Dealers");

                    b.Navigation("Messages");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Erp.Data.Entities.CurrentAccount", b =>
                {
                    b.Navigation("Dealer")
                        .IsRequired();
                });

            modelBuilder.Entity("Erp.Data.Entities.Dealer", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Erp.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Erp.Data.Entities.Product", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
