﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaxiDetails.Context;

#nullable disable

namespace TaxiDetails.Migrations
{
    [DbContext(typeof(TaxiDetailsDbContext))]
    [Migration("20241129082605_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TaxiDetails.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<string>("Model")
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<string>("Plate")
                        .HasColumnType("text")
                        .HasColumnName("plate");

                    b.Property<int>("assigned_driver")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("assigned_driver");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("TaxiDetails.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Passport")
                        .HasColumnType("text")
                        .HasColumnName("passport");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text")
                        .HasColumnName("patronymic");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id");

                    b.ToTable("drivers");
                });

            modelBuilder.Entity("TaxiDetails.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Cost")
                        .HasColumnType("numeric")
                        .HasColumnName("cost");

                    b.Property<string>("DeparturePoint")
                        .HasColumnType("text")
                        .HasColumnName("departure_point");

                    b.Property<string>("DestinationPoint")
                        .HasColumnType("text")
                        .HasColumnName("destination_point");

                    b.Property<TimeSpan?>("TravelTime")
                        .HasColumnType("interval")
                        .HasColumnName("trip_time");

                    b.Property<DateTime?>("TripDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("trip_date");

                    b.Property<int>("assigned_car")
                        .HasColumnType("integer");

                    b.Property<int>("client")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("assigned_car");

                    b.HasIndex("client");

                    b.ToTable("travels");
                });

            modelBuilder.Entity("TaxiDetails.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("TaxiDetails.Car", b =>
                {
                    b.HasOne("TaxiDetails.Driver", "AssignedDriver")
                        .WithMany()
                        .HasForeignKey("assigned_driver")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedDriver");
                });

            modelBuilder.Entity("TaxiDetails.Travel", b =>
                {
                    b.HasOne("TaxiDetails.Car", "AssignedCar")
                        .WithMany()
                        .HasForeignKey("assigned_car")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxiDetails.User", "Client")
                        .WithMany()
                        .HasForeignKey("client")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedCar");

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
