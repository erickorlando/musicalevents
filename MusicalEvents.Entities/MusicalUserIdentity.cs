using Microsoft.AspNetCore.Identity;

namespace MusicalEvents.Entities;

public class MusicalUserIdentity : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int TypeDocument { get; set; }
    public string DocumentNumber { get; set; }
}