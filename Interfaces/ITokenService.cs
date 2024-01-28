namespace API.Interfaces;

using Models;

public interface ITokenService
{
    string CreateToken(AppUser user);
}