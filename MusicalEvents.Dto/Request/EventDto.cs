namespace MusicalEvents.Dto.Request;

public class EventDto
{
    public string? Title { get; set; }

    public string? Description { get; set; }
    public DateTime EventDate { get; set; }
    public int TicketQuantity { get; set; }

    public decimal Price { get; set; }

    public int GenreId { get; set; }
}