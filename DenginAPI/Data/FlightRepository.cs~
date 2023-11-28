using System;
using System.Collections.Generic;
using DenginAPI.Models;

public class FlightRepository
{
    private static List<Flight> flights = new List<Flight>();

    static FlightRepository()
    {
        // Initialize with some sample data
        flights.Add(new Flight { FlightId = 1, Date = DateTime.Now.Date, FlightNumber = "ABC123", Price = 300.00m });
        flights.Add(new Flight { FlightId = 2, Date = DateTime.Now.Date.AddDays(1), FlightNumber = "XYZ456", Price = 250.00m });
        // Add more sample data as needed
    }

    public IEnumerable<Flight> GetFlights(DateTime fromDate, DateTime toDate, int numberOfPeople, int pageIndex, int pageSize)
    {
        // Implement your logic for querying flights here (filter by date, from, to, and number of people)
        var filteredFlights = flights
            .Where(f => f.Date >= fromDate && f.Date <= toDate)
            .OrderBy(f => f.Date)
            .Skip(pageIndex * pageSize)
            .Take(pageSize);

        return filteredFlights;
    }

    public bool BuyTicket(int flightId, string passengerName, string username, string password)
    {
        var flight = flights.FirstOrDefault(f => f.FlightId == flightId);

        // Check if the flight exists
        if (flight == null)
        {
            return false;
        }

        // Check authentication
        if (!AuthenticateUser(username, password))
        {
            return false;
        }

        // Check if there are available seats
        if (flight.AvailableSeats <= 0)
        {
            return false;
        }

        // Book a seat
        flight.AvailableSeats--;

        // Additional logic for storing passenger information, generating a ticket, etc.

        return true;
    }

    private bool AuthenticateUser(string username, string password)
    {
        // Implement your authentication logic here (e.g., check against a user database)
        // For simplicity, this example uses hardcoded credentials
        return username == "your_username" && password == "your_password";
    }
}
