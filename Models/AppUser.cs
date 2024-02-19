namespace API.Models;

using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    public List<Portfolio> Portfolios { get; set; }
}
