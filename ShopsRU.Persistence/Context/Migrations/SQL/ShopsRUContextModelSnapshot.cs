﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopsRU.Persistence.Context.EntityFramework;

#nullable disable

namespace ShopsRU.Persistence.Context.Migrations.SQL
{
    [DbContext(typeof(ShopsRUContext))]
    partial class ShopsRUContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasDefaultValue(new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(3562));

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
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(4323),
                            IsDeleted = false,
                            Name = "Mutfak"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(4331),
                            IsDeleted = false,
                            Name = "Mobilya"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(4332),
                            IsDeleted = false,
                            Name = "Market"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(4333),
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
                        .HasDefaultValue(new DateTime(2024, 2, 11, 18, 57, 53, 118, DateTimeKind.Local).AddTicks(9246));

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
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(162),
                            CustomerTypeId = 1,
                            FirstName = "EVREN",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(167),
                            LastName = "AKTAŞ"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(168),
                            CustomerTypeId = 2,
                            FirstName = "ECE",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(168),
                            LastName = "DAĞDELEN"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(169),
                            CustomerTypeId = 1,
                            FirstName = "İBRAHİM",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(170),
                            LastName = "AKIŞIK"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(171),
                            CustomerTypeId = 2,
                            FirstName = "GİZEM",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(172),
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
                        .HasDefaultValue(new DateTime(2024, 2, 11, 18, 57, 53, 118, DateTimeKind.Local).AddTicks(5037));

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
                        .HasDefaultValue(new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(2699));

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
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(3471),
                            IsDeleted = false,
                            Type = "Mağaza Çalışanı"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(3479),
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
                        .HasDefaultValue(new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(8263));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(9019),
                            Description = "Mağaza çalışanı için belirlenmiş indirim oranı",
                            DiscountRate = 30,
                            DiscountType = "%",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(9024),
                            Description = "Mağaza üyesi iiçin belirlenmiş indirim oranı",
                            DiscountRate = 10,
                            DiscountType = "%",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(9026),
                            Description = "Sadık müşteri  için belirlenmiş indirim oranı",
                            DiscountRate = 5,
                            DiscountType = "%",
                            IsDeleted = false
                        });
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
                        .HasDefaultValue(new DateTime(2024, 2, 11, 18, 57, 53, 120, DateTimeKind.Local).AddTicks(2540));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsFixedDiscountApplied")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal>("NetAmount")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalDiscountAmount")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("TotalFixedDiscountAmount")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("TotalOrderAmount")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

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
                        .HasDefaultValue(new DateTime(2024, 2, 11, 18, 57, 53, 120, DateTimeKind.Local).AddTicks(6109));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDiscountApplied")
                        .HasColumnType("bit");

                    b.Property<decimal>("LineAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LineDiscountAmount")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

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
                        .HasDefaultValue(new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(415));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(1332),
                            IsDeleted = false,
                            Name = "Gardırop",
                            Price = 3000m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(1338),
                            IsDeleted = false,
                            Name = "Fırın",
                            Price = 4000m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(1340),
                            IsDeleted = false,
                            Name = "Fıstık Ezmesi",
                            Price = 85m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(1342),
                            IsDeleted = false,
                            Name = "ModeLight Işıl 3'lü Avize",
                            Price = 4000m,
                            StockQuantity = 10
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
