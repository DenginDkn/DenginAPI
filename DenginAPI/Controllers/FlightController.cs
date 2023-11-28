using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly FlightRepository _flightRepository;
    private readonly TicketRepository _ticketRepository;

    public FlightController(FlightRepository flightRepository, TicketRepository ticketRepository)
    {
        _flightRepository = flightRepository;
        _ticketRepository = ticketRepository;
    }

    [HttpGet]
    public IActionResult GetFlights(DateTime fromDate, DateTime toDate, int numberOfPeople, int pageIndex = 0, int pageSize = 10)
    {
        var flights = _flightRepository.GetFlights(fromDate, toDate, numberOfPeople, pageIndex, pageSize);
        return Ok(flights);
    }

    [HttpPost("buy")]
    public IActionResult BuyTicket(int flightId, string passengerName, string username, string password)
    {
        var success = _flightRepository.BuyTicket(flightId, passengerName, username, password);

        if (success)
        {
            return Ok(new { Status = "Ticket purchased successfully." });
        }
        else
        {
            return BadRequest(new { Status = "Failed to purchase ticket. Check availability or authentication." });
        }
    }

}
