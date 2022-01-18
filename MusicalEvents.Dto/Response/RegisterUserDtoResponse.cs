namespace MusicalEvents.Dto.Response;

public record RegisterUserDtoResponse
{
    public bool Success { get; set; }
    public string UserId { get; set; }
    public List<string> ValidationErrors { get; set; }
}