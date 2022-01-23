using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicalEvents.Entities;

public class Concert : BaseEntity
{
    [StringLength(50)]
    [Required]
    public string? Title { get; set; }

    [StringLength(500)]
    [Required]
    public string? Description { get; set; }
    
    public DateTime EventDate { get; set; }
    public int TicketQuantity { get; set; }

    public decimal Price { get; set; }

    public int GenreId { get; set; }
    
    [JsonIgnore]
    public Genre? Genre { get; set; }
    public string? ImageUrl { get; set; }
}