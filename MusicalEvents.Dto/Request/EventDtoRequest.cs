namespace MusicalEvents.Dto.Request;

public record EventDtoRequest
{
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime EventDate { get; init; } 
    public int TicketQuantity { get; init; }
    public decimal Price { get; init; }
    public int GenreId { get; init; }
    public string? ImageUrl { get; init; }
}