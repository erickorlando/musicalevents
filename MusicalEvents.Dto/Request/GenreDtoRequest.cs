namespace MusicalEvents.Dto.Request;

public record GenreDtoRequest
{
    public string Name { get; init; }
    public bool Status { get; init; }
}
