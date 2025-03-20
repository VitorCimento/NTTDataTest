﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTTDataTest.Domain.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NTTDataTest.Domain.Migrations
{
    [DbContext(typeof(NTTContext))]
    partial class NTTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NTTDataTest.Domain.Entities.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("number")
                        .HasColumnType("integer");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("zipcode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.HasKey("id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("NTTDataTest.Domain.Entities.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("NTTDataTest.Domain.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("price")
                        .HasPrecision(10, 2)
                        .HasColumnType("double precision");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("NTTDataTest.Domain.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("addressid")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("role")
                        .HasColumnType("integer");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("id");

                    b.HasIndex("addressid")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NTTDataTest.Domain.Entities.Address", b =>
                {
                    b.OwnsOne("NTTDataTest.Domain.Entities.Geolocation", "geolocation", b1 =>
                        {
                            b1.Property<int>("Addressid")
                                .HasColumnType("integer");

                            b1.Property<string>("lat")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("lng")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("Addressid");

                            b1.ToTable("Addresses");

                            b1.WithOwner()
                                .HasForeignKey("Addressid");
                        });

                    b.Navigation("geolocation")
                        .IsRequired();
                });

            modelBuilder.Entity("NTTDataTest.Domain.Entities.Product", b =>
                {
                    b.OwnsOne("NTTDataTest.Domain.Entities.Rating", "rating", b1 =>
                        {
                            b1.Property<int>("Productid")
                                .HasColumnType("integer");

                            b1.Property<int>("count")
                                .HasColumnType("integer");

                            b1.Property<double>("rate")
                                .HasPrecision(5, 2)
                                .HasColumnType("double precision");

                            b1.HasKey("Productid");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("Productid");
                        });

                    b.Navigation("rating")
                        .IsRequired();
                });

            modelBuilder.Entity("NTTDataTest.Domain.Entities.User", b =>
                {
                    b.HasOne("NTTDataTest.Domain.Entities.Address", "address")
                        .WithOne("user")
                        .HasForeignKey("NTTDataTest.Domain.Entities.User", "addressid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("NTTDataTest.Domain.Entities.Name", "name", b1 =>
                        {
                            b1.Property<int>("Userid")
                                .HasColumnType("integer");

                            b1.Property<string>("firstname")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("lastname")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("Userid");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("Userid");
                        });

                    b.Navigation("address");

                    b.Navigation("name")
                        .IsRequired();
                });

            modelBuilder.Entity("NTTDataTest.Domain.Entities.Address", b =>
                {
                    b.Navigation("user")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
