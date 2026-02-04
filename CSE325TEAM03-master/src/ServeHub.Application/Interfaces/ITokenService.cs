namespace ServeHub.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(int userId, string email, string name);
}
