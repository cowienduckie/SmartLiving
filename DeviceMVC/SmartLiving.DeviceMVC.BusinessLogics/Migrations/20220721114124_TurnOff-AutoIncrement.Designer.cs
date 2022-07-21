﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartLiving.DeviceMVC.BusinessLogics.DataContext;

namespace SmartLiving.DeviceMVC.BusinessLogics.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220721114124_TurnOff-AutoIncrement")]
    partial class TurnOffAutoIncrement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SmartLiving.DeviceMVC.Data.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("ColumnOrder", 997);

                    b.Property<int>("HouseId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean")
                        .HasAnnotation("ColumnOrder", 999);

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("ColumnOrder", 998);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Area","dbo");
                });

            modelBuilder.Entity("SmartLiving.DeviceMVC.Data.Entities.Device", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("AreaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("ColumnOrder", 997);

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("HouseId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean")
                        .HasAnnotation("ColumnOrder", 999);

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("ColumnOrder", 998);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Params")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("HouseId");

                    b.ToTable("Device","dbo");
                });

            modelBuilder.Entity("SmartLiving.DeviceMVC.Data.Entities.DeviceType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("ColumnOrder", 997);

                    b.Property<string>("DefaultParams")
                        .HasColumnType("text");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean")
                        .HasAnnotation("ColumnOrder", 999);

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("ColumnOrder", 998);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeviceType","dbo");
                });

            modelBuilder.Entity("SmartLiving.DeviceMVC.Data.Entities.House", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("ColumnOrder", 997);

                    b.Property<int>("HouseTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean")
                        .HasAnnotation("ColumnOrder", 999);

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("ColumnOrder", 998);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("HouseTypeId");

                    b.ToTable("House","dbo");
                });

            modelBuilder.Entity("SmartLiving.DeviceMVC.Data.Entities.HouseType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("ColumnOrder", 997);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean")
                        .HasAnnotation("ColumnOrder", 999);

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("ColumnOrder", 998);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HouseType","dbo");
                });

            modelBuilder.Entity("SmartLiving.DeviceMVC.Data.Entities.Area", b =>
                {
                    b.HasOne("SmartLiving.DeviceMVC.Data.Entities.House", "House")
                        .WithMany("Areas")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartLiving.DeviceMVC.Data.Entities.Device", b =>
                {
                    b.HasOne("SmartLiving.DeviceMVC.Data.Entities.Area", "Area")
                        .WithMany("Devices")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartLiving.DeviceMVC.Data.Entities.DeviceType", "DeviceType")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartLiving.DeviceMVC.Data.Entities.House", "House")
                        .WithMany("Devices")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartLiving.DeviceMVC.Data.Entities.House", b =>
                {
                    b.HasOne("SmartLiving.DeviceMVC.Data.Entities.HouseType", "HouseType")
                        .WithMany("Houses")
                        .HasForeignKey("HouseTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
