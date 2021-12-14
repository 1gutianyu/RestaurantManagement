﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantManageEntity;

namespace RestaurantManageEntity.Migrations
{
    [DbContext(typeof(ManegeDbContext))]
    partial class ManegeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaurantManageEntity.ApplyInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<decimal>("ApplyMoney")
                        .HasColumnType("decimal(38,17)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobPerson")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Reason")
                        .HasColumnType("varchar(100)");

                    b.HasKey("ID");

                    b.ToTable("ApplyInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.DepartmentInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LeaderID")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ParentID")
                        .HasColumnType("varchar(36)");

                    b.HasKey("ID");

                    b.ToTable("DepartmentInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.IncomeInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("OrderId")
                        .HasColumnType("varchar(36)");

                    b.Property<decimal>("PutMoney")
                        .HasColumnType("decimal(38,17)");

                    b.HasKey("ID");

                    b.ToTable("IncomeInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.InventoryInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(36)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<double>("Number")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Unit")
                        .HasColumnType("varchar(36)");

                    b.Property<int>("Warming")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("InventoryInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.MealInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("ID");

                    b.ToTable("MealInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.MenuClassifyInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(36)");

                    b.HasKey("ID");

                    b.ToTable("MenuClassifyInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.MenuInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Href")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Icon")
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("ParentId")
                        .HasColumnType("varchar(36)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<string>("Target")
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.HasKey("ID");

                    b.ToTable("MenuInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.MenuSheetInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("CategoryID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisheName")
                        .HasColumnType("varchar(36)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(38,17)");

                    b.HasKey("ID");

                    b.ToTable("MenuSheetInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.Menu_RoleInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MenuId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("ID");

                    b.ToTable("Menu_RoleInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.OrderInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DishesId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("JobId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("PayMethod")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("TableNumber")
                        .HasColumnType("varchar(36)");

                    b.Property<decimal>("TotalMoney")
                        .HasColumnType("decimal(38,17)");

                    b.HasKey("ID");

                    b.ToTable("OrderInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.OutlayInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("CheckPerson")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("OutlayInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.PurchaseInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Buyer")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MaterialId")
                        .HasColumnType("varchar(36)");

                    b.Property<double>("Number")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("PurchaseInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.RoleInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(36)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("RoleInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.StaffInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentID")
                        .HasColumnType("varchar(36)");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("JobID")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("PassWord")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(36)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("ID");

                    b.ToTable("StaffInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.Stasff_RoleInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Stasff_RoleInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.UserInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Account")
                        .HasColumnType("varchar(16)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("PassWord")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("ID");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("RestaurantManageEntity.User_RoleInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("ID");

                    b.ToTable("User_RoleInfo");
                });
#pragma warning restore 612, 618
        }
    }
}