using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineReservationSystem.Entities;

namespace AirlineReservationSystem.Repositories
{
    public interface IReservationsRepository
    {
        string BookTicket(string FlightID, DateTime JourneyDate, string PassengerName, long ContactNo, string Email, int NoOftickets);
        List<Reservation> CancelTicket(int TicketNo);
        List<Reservation> ViewTickets(string PassengerName);
        float GenerateRevenue(string FlightID);
        float TotalRevenueOfAirLine();
        float GenerateRevenue(string FlightID, DateTime RevenueStartDate, DateTime RevenueEndDate);
        float TotalRevenueOfAirLine(DateTime RevenueStartDate, DateTime RevenueEndDate);
    }
}
