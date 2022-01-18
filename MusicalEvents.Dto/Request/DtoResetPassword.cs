namespace MusicalEvents.Dto.Request;

public record DtoResetPassword(string Email);

public record DtoConfirmReset(string Email, string Token, string NewPassword);

public record DtoChangePassword(string Email, string OldPassword, string NewPassword);