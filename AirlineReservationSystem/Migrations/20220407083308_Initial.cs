﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineReservationSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightID = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    LaunchDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Origin = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Destination = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    DeptTime = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    ArrivalTime = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    NoOfSeats = table.Column<int>(type: "int", nullable: false),
                    Fare = table.Column<decimal>(type: "decimal(38,17)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightID);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    TicketNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightID = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    DateOfBooking = table.Column<DateTime>(type: "Date", nullable: false),
                    JourneyDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PassengerName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ContactNo = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    NoOfTickets = table.Column<int>(type: "int", nullable: false),
                    TotalFare = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.TicketNo);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
