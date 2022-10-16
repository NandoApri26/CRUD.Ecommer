﻿// <auto-generated />
using Ecommer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommer.Models.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221012164414_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ecommer.Models.Entities.Barang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("Harga")
                        .HasColumnType("numeric");

                    b.Property<int>("IdPenjual")
                        .HasColumnType("integer");

                    b.Property<string>("Kode")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Nama")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Stok")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdPenjual");

                    b.ToTable("Barangs");
                });

            modelBuilder.Entity("Ecommer.Models.Entities.Penjual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Alamat")
                        .HasColumnType("text");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("NamaToko")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Penjuals");
                });

            modelBuilder.Entity("Ecommer.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Tipe")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ecommer.Models.Entities.Barang", b =>
                {
                    b.HasOne("Ecommer.Models.Entities.Penjual", "Penjual")
                        .WithMany("Barangs")
                        .HasForeignKey("IdPenjual")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Penjual");
                });

            modelBuilder.Entity("Ecommer.Models.Entities.Penjual", b =>
                {
                    b.HasOne("Ecommer.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecommer.Models.Entities.Penjual", b =>
                {
                    b.Navigation("Barangs");
                });
#pragma warning restore 612, 618
        }
    }
}
