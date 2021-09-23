﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ShopsDBContext))]
    [Migration("20210827122819_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CurrentShopId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentShopId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("DAL.Entities.ManagerWorkingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedWorkingAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StoppedWorkingAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ShopId");

                    b.ToTable("ManagersWorkingHistory");
                });

            modelBuilder.Entity("DAL.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("DAL.Entities.Manager", b =>
                {
                    b.HasOne("DAL.Entities.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("CurrentShopId");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("DAL.Entities.ManagerWorkingHistory", b =>
                {
                    b.HasOne("DAL.Entities.Manager", "Manager")
                        .WithMany("WorkingHistories")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("DAL.Entities.Manager", b =>
                {
                    b.Navigation("WorkingHistories");
                });
#pragma warning restore 612, 618
        }
    }
}