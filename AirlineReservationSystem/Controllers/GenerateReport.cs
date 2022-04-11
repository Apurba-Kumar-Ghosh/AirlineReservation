
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineReservationSystem.Entities;
using AirlineReservationSystem.Repositories;

namespace AirLineReservationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateReport : ControllerBase
    {
        private readonly IReservationsRepository r;

        public GenerateReport(IReservationsRepository r)
        {
            this.r = r;
        }

        [HttpGet]
        public float GetRevenue(string FlightID)
        {
            return r.GenerateRevenue(FlightID);
        }

        [HttpGet]
        [Route("RevenueCGAirLine")]
        public float RevenueOfCGAirLine()
        {
            return r.TotalRevenueOfAirLine();

        }

        [HttpGet]
        [Route("RevenueOfFlightByDate")]
        public float GetRevenueOfFlightByDate(string FlightID, DateTime RevenueStartDate, DateTime RevenueEndDate)
        {
            return r.GenerateRevenue(FlightID, RevenueStartDate, RevenueEndDate);
        }

        [HttpGet]
        [Route("RevenueCGAirLineByDate")]
        public float RevenueOfCGAirLine(DateTime RevenueStartDate, DateTime RevenueEndDate)
        {
            return r.TotalRevenueOfAirLine(RevenueStartDate, RevenueEndDate);

        }
    }
}