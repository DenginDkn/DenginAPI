using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly TicketRepository _ticketRepository;

    public TicketController(TicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    [HttpGet("{flightId}/tickets")]
    public IActionResult GetTickets(int flightId)
    {
        var tickets = _ticketRepository.GetTickets(flightId);
        return Ok(tickets);
    }

    [HttpPost("{flightId}/tickets")]
    public IActionResult CreateTicket(int flightId, string passengerName)
    {
        var ticket = _ticketRepository.CreateTicket(flightId, passengerName);
        return Ok(ticket);
    }

    [HttpDelete("tickets/{ticketId}")]
    public IActionResult DeleteTicket(int ticketId)
    {
        _ticketRepository.DeleteTicket(ticketId);
        return Ok(new { Status = "Ticket deleted successfully." });
    }

    [HttpGet("tickets/{ticketId}")]
    public IActionResult GetTicketById(int ticketId)
    {
        var ticket = _ticketRepository.GetTicketById(ticketId);

        if (ticket == null)
        {
            return NotFound(new { Status = $"Ticket with ID {ticketId} not found." });
        }

        return Ok(ticket);
    }
}
