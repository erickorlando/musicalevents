namespace MusicalEvents.Dto.Request;

public class DtoEvent
{
    public string? Title { get; set; }

    public string? Description { get; set; }
    public string EventDate { get; set; }
    public string EventTime { get; set; }
    public int TicketQuantity { get; set; }

    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int GenreId { get; set; }
}