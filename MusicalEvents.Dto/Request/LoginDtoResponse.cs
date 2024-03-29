﻿namespace MusicalEvents.Dto.Request;

public record LoginDtoResponse
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
    public string Token { get; set; }
    public DateTime ExpiredTime { get; set; }
    public string UserId { get; set; }
    public string UserCode { get; set; }
    public string FullName { get; set; }
}