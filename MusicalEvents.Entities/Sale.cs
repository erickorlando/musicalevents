namespace MusicalEvents.Entities;

public class Sale : BaseEntity
{
    public string OperationNumber { get; set; }
    public int EventId { get; set; }
    public string UserId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalSales { get; set; }
    public DateTime BuyDate { get; set; }
    
}