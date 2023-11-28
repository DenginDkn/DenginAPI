﻿using System;
namespace DenginAPI.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime Date { get; set; }
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
    }
}

