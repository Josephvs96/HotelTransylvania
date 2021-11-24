﻿// <auto-generated />
using System;
using HotelTransylvania.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelTransylvania.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20211124110404_Intitial-Mirgation")]
    partial class IntitialMirgation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelTransylvania.Models.ExtraBeds", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("HasExtraBeds")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfExtraBeds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ExtraBeds");
                });

            modelBuilder.Entity("HotelTransylvania.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsAvailble")
                        .HasColumnType("bit");

                    b.Property<decimal>("PricePerNight")
                        .HasPrecision(2)
                        .HasColumnType("decimal(2,2)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<int?>("RoomPropertiesId")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomPropertiesId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelTransylvania.Models.RoomProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExtraBedsId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfWindows")
                        .HasColumnType("int");

                    b.Property<decimal>("RoomSize")
                        .HasPrecision(2)
                        .HasColumnType("decimal(2,2)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraBedsId");

                    b.ToTable("RoomProperties");
                });

            modelBuilder.Entity("HotelTransylvania.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("HotelTransylvania.Models.Room", b =>
                {
                    b.HasOne("HotelTransylvania.Models.RoomProperties", "RoomProperties")
                        .WithMany()
                        .HasForeignKey("RoomPropertiesId");

                    b.HasOne("HotelTransylvania.Models.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomProperties");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HotelTransylvania.Models.RoomProperties", b =>
                {
                    b.HasOne("HotelTransylvania.Models.ExtraBeds", "ExtraBeds")
                        .WithMany()
                        .HasForeignKey("ExtraBedsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraBeds");
                });
#pragma warning restore 612, 618
        }
    }
}