using System.ComponentModel.DataAnnotations;

namespace MusicalEvents.Dto.Request;

public class RegisterUserDtoRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public int Age { get; set; }
    public int TypeDocument { get; set; }
    
    [Required]
    public string DocumentNumber { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }

    [Required]
    public string UserCode { get; set; }
}