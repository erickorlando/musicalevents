namespace MusicalEvents.Dto.Response;

public class BaseCollectionResponse<T>
where T : class
{
    public bool Success { get; set; }

    public string[]? Errors { get; set; }
 
    public List<T> Collection { get; set; }
    
    public int TotalPages { get; set; }

}