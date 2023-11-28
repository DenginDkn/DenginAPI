using System.Collections.Generic;

public class TicketRepository
{
    private static List<Ticket> tickets = new List<Ticket>();
    private static int ticketIdCounter = 1;

    public IEnumerable<Ticket> GetTickets(int flightId)
    {
        return tickets.FindAll(t => t.FlightId == flightId);
    }

    public Ticket CreateTicket(int flightId, string passengerName)
    {
        var ticket = new Ticket
        {
            TicketId = ticketIdCounter++,
            FlightId = flightId,
            PassengerName = passengerName
        };

        tickets.Add(ticket);
        return ticket;
    }

    public void DeleteTicket(int ticketId)
    {
        tickets.RemoveAll(t => t.TicketId == ticketId);
    }
    public Ticket GetTicketById(int ticketId)
    {
        return tickets.FirstOrDefault(t => t.TicketId == ticketId);
    }
}
