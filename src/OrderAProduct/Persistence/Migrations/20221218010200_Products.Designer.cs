// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20221218010200_Products")]
    partial class Products
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Corporate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CorporateName");

                    b.Property<DateTime>("EndOrderTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("EndOrderTime");

                    b.Property<bool>("OrderState")
                        .HasColumnType("bit")
                        .HasColumnName("OrderState");

                    b.Property<DateTime>("StartOrderTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartOrderTime");

                    b.HasKey("Id");

                    b.ToTable("Corporates", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorporateName = "Getir",
                            EndOrderTime = new DateTime(2022, 12, 18, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderState = true,
                            StartOrderTime = new DateTime(2022, 12, 18, 8, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CorporateName = "YemekSepeti",
                            EndOrderTime = new DateTime(2022, 12, 18, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            OrderState = true,
                            StartOrderTime = new DateTime(2022, 12, 18, 11, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CorporateName = "Trendyol",
                            EndOrderTime = new DateTime(2022, 12, 18, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderState = true,
                            StartOrderTime = new DateTime(2022, 12, 18, 13, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CorporateId")
                        .HasColumnType("int");

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CorporateName");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProductName");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("Stock");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float")
                        .HasColumnName("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("CorporateId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorporateName = "YemekSepeti",
                            ProductName = "Tantuni",
                            Stock = 5,
                            UnitPrice = 45.0
                        },
                        new
                        {
                            Id = 2,
                            CorporateName = "YemekSepeti",
                            ProductName = "Döner",
                            Stock = 5,
                            UnitPrice = 40.0
                        },
                        new
                        {
                            Id = 3,
                            CorporateName = "YemekSepeti",
                            ProductName = "Tavuklu Makarna",
                            Stock = 5,
                            UnitPrice = 40.0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Corporate", "Corporate")
                        .WithMany("Products")
                        .HasForeignKey("CorporateId");

                    b.Navigation("Corporate");
                });

            modelBuilder.Entity("Domain.Entities.Corporate", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
