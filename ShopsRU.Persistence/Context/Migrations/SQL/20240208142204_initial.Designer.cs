﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopsRU.Persistence.Context.EntityFramework;

#nullable disable

namespace ShopsRU.Persistence.Context.Migrations.SQL
{
    [DbContext(typeof(ShopsRUContext))]
    [Migration("20240208142204_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopsRU.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(2658));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(3406),
                            IsDeleted = false,
                            Name = "Mutfak"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(3412),
                            IsDeleted = false,
                            Name = "Mobilya"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(3414),
                            IsDeleted = false,
                            Name = "Market"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(3415),
                            IsDeleted = false,
                            Name = "Aydınlatma"
                        });
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(4316));

                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5226),
                            CustomerTypeId = 1,
                            FirstName = "EVREN",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5233),
                            LastName = "AKTAŞ"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5234),
                            CustomerTypeId = 2,
                            FirstName = "ECE",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5235),
                            LastName = "DAĞDELEN"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5236),
                            CustomerTypeId = 1,
                            FirstName = "İBRAHİM",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5237),
                            LastName = "AKIŞIK"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5238),
                            CustomerTypeId = 2,
                            FirstName = "GİZEM",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5239),
                            LastName = "KURTCUOĞLU"
                        });
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.CustomerDiscount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 8, 17, 22, 4, 338, DateTimeKind.Local).AddTicks(8419));

                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("RuleJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("CustomerDiscounts");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.CustomerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(8241));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(9051),
                            IsDeleted = false,
                            Type = "Mağaza Çalışanı"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(9058),
                            IsDeleted = false,
                            Type = "Mağaza Üyesi"
                        });
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(4052));

                    b.Property<int>("DiscountRate")
                        .HasColumnType("int");

                    b.Property<string>("DiscountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(4825),
                            DiscountRate = 30,
                            DiscountType = "Yüzde",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(4830),
                            DiscountRate = 10,
                            DiscountType = "Yüzde",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(4832),
                            DiscountRate = 5,
                            DiscountType = "Yüzde",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BillingUserId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(8570));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal>("NetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 8, 17, 22, 4, 341, DateTimeKind.Local).AddTicks(2841));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 8, 17, 22, 4, 341, DateTimeKind.Local).AddTicks(5890));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 8, 17, 22, 4, 341, DateTimeKind.Local).AddTicks(9675));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(542),
                            IsDeleted = false,
                            Name = "Gardırop",
                            Price = 3000m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(547),
                            IsDeleted = false,
                            Name = "Fırın",
                            Price = 4000m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(549),
                            IsDeleted = false,
                            Name = "Fıstık Ezmesi",
                            Price = 85m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(550),
                            IsDeleted = false,
                            Name = "ModeLight Işıl 3'lü Avize",
                            Price = 4000m
                        });
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Customer", b =>
                {
                    b.HasOne("ShopsRU.Domain.Entities.CustomerType", "CustomerType")
                        .WithMany("Customers")
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerType");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.CustomerDiscount", b =>
                {
                    b.HasOne("ShopsRU.Domain.Entities.CustomerType", "CustomerType")
                        .WithMany("CustomerDiscounts")
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopsRU.Domain.Entities.Discount", "Discounts")
                        .WithMany("CustomerDiscounts")
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerType");

                    b.Navigation("Discounts");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Invoice", b =>
                {
                    b.HasOne("ShopsRU.Domain.Entities.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopsRU.Domain.Entities.Order", "Order")
                        .WithMany("Invoices")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("ShopsRU.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopsRU.Domain.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Product", b =>
                {
                    b.HasOne("ShopsRU.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.CustomerType", b =>
                {
                    b.Navigation("CustomerDiscounts");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Discount", b =>
                {
                    b.Navigation("CustomerDiscounts");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Order", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Product", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}