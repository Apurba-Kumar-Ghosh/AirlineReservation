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
        Reservation CancelTicket(int TicketNo);
        List<Reservation> ViewTickets(string PassengerName);
    }
}
