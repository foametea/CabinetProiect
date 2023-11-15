﻿// <auto-generated />
using System;
using CabinetVeterinar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CabinetVeterinar.Migrations
{
    [DbContext(typeof(CabinetVeterinarContext))]
    [Migration("20231113193904_FirstTest")]
    partial class FirstTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CabinetVeterinar.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("CabinetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CabinetId");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("CabinetVeterinar.Models.Cabinet", b =>
                {
                    b.Property<int>("CabinetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CabinetId"), 1L, 1);

                    b.Property<string>("CabinetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CabinetId");

                    b.ToTable("Cabinet");
                });

            modelBuilder.Entity("CabinetVeterinar.Models.Animal", b =>
                {
                    b.HasOne("CabinetVeterinar.Models.Cabinet", null)
                        .WithMany("Lista_Animale")
                        .HasForeignKey("CabinetId");
                });

            modelBuilder.Entity("CabinetVeterinar.Models.Cabinet", b =>
                {
                    b.Navigation("Lista_Animale");
                });
#pragma warning restore 612, 618
        }
    }
}