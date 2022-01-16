namespace MusicalEvents.Dto.Response;

public class BaseResponse<TData>
where TData : class
{
    public bool Success { get; set; }

    public string[]? Errors { get; set; }

    public TData? Result { get; set; }

}