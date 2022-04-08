using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineReservationSystem.Repositories;
using AirlineReservationSystem.Entities;

namespace AirlineReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsRepository reservationsRepository;

        public ReservationsController(IReservationsRepository reservationsRepository)
        {
            this.reservationsRepository = reservationsRepository;
        }

        [HttpPost]
        public string BookTicket(Reservation ticket)
        {
            return reservationsRepository.BookTicket(ticket.FlightID,  ticket.JourneyDate,  ticket.PassengerName,  ticket.ContactNo,  ticket.Email,  ticket.NoOfTickets);
        }

        [HttpPut]
        [Route("{TicketNo}")]
        public List<Reservation> CancelTicket(int TicketNo)
        {
            return reservationsRepository.CancelTicket(TicketNo);
        }
        
        [HttpGet]
        public List<Reservation> ViewTickets(string PassengerName)
        {
            return reservationsRepository.ViewTickets(PassengerName);
        }
    }
}
