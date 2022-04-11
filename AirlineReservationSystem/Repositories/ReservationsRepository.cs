using AirlineReservationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineReservationSystem.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {
        private readonly AirlineDBContext DB = new AirlineDBContext();

        public string BookTicket(string FlightID, DateTime JourneyDate, string PassengerName, long ContactNo, string Email, int NoOftickets)
        {
            var BookingsMade = DB.Reservations.Where(x => x.FlightID == FlightID && x.JourneyDate == JourneyDate && x.Status == "Booked").Select(x => x.NoOfTickets).Sum();
            var NoOfSeats = DB.Flights.Where(x => x.FlightID == FlightID).Select(x => x.NoOfSeats).ToList()[0];
            if (BookingsMade + NoOftickets > NoOfSeats)
                return "SeatsNotAvailable";
            else
            {
                Reservation reservation = new Reservation();

                reservation.FlightID = FlightID;
                reservation.DateOfBooking = DateTime.Today;
                reservation.JourneyDate = JourneyDate;
                reservation.PassengerName = PassengerName;
                reservation.ContactNo = ContactNo;
                reservation.Email = Email;
                reservation.NoOfTickets = NoOftickets;
                reservation.TotalFare = DB.Flights.Where(x => x.FlightID == FlightID).Select(x => x.Fare).ToList()[0] * NoOftickets;
                reservation.Status = "Booked";

                DB.Reservations.Add(reservation);
                DB.SaveChanges();

                return "BookingSucccesful";
            }
        }

        public List<Reservation> CancelTicket(int TicketNo)
        {
            DB.Reservations.Where(x => x.TicketNo == TicketNo)
                            .ToList()
                            .ForEach(f => f.Status = "Cancelled");

            DB.SaveChanges();

            return DB.Reservations.ToList();
        }
        public float GenerateRevenue(string FlightID)
        {
            var TotalRevenue = DB.Reservations.Where(x => x.FlightID == FlightID
            && x.Status == "Booked").Sum(s => s.TotalFare);

            return TotalRevenue;


        }

        public float GenerateRevenue(string FlightID, DateTime RevenueStartDate, DateTime RevenueEndDate)
        {
            var t = DB.Reservations.Where(x => x.FlightID == FlightID && x.Status == "Booked" && (x.JourneyDate >= RevenueStartDate && x.JourneyDate <= RevenueEndDate)).Sum(s => s.TotalFare);
            return t;
        }

        public float TotalRevenueOfAirLine()
        {
            var t = DB.Reservations.Where(x => x.Status == "Booked").Sum(s => s.TotalFare);

            return t;

        }

        public float TotalRevenueOfAirLine(DateTime RevenueStartDate, DateTime RevenueEndDate)
        {
            var t = DB.Reservations.Where(x => x.Status == "Booked" && (x.JourneyDate >= RevenueStartDate && x.JourneyDate <= RevenueEndDate)).Sum(s => s.TotalFare);

            return t;
        }
        public List<Reservation> ViewTickets(string PassengerName)
        {
            return DB.Reservations.Where(x => x.PassengerName == PassengerName).ToList();
        }
    }
}
