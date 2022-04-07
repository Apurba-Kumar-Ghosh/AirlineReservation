﻿// <auto-generated />
using System;
using AirlineReservationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirlineReservationSystem.Migrations
{
    [DbContext(typeof(AirlineDBContext))]
    partial class AirlineDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirlineReservationSystem.Entities.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalTime")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("DeptTime")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("Fare")
                        .HasColumnType("decimal(38,17)");

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnType("Date");

                    b.Property<int>("NoOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("FlightID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirlineReservationSystem.Entities.Reservation", b =>
                {
                    b.Property<int>("TicketNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ContactNo")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfBooking")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<string>("FlightID")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("JourneyDate")
                        .HasColumnType("Date");

                    b.Property<int>("NoOfTickets")
                        .HasColumnType("int");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("TotalFare")
                        .HasColumnType("decimal(38,17)");

                    b.HasKey("TicketNo");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("AirlineReservationSystem.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
