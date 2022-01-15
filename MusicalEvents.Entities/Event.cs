using System.ComponentModel.DataAnnotations;

namespace MusicalEvents.Entities;

public class Event : BaseEntity
{
    [StringLength(50)]
    [Required]
    public string? Title { get; set; }

    [StringLength(500)]
    [Required]
    public string? Description { get; set; }
    public DateOnly EventDate { get; set; }
    public TimeOnly EventTime { get; set; }
    public int TicketQuantity { get; set; }

    public decimal Price { get; set; }

    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public string? ImageUrl { get; set; }
}