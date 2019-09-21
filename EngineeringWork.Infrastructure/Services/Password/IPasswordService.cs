namespace Passenger.Infrastructure.Services.Password
{
    public interface IPasswordService : IService
    {
        bool VerifedPasswordHash(string hash, string password);
        string HashPassword(string value);
    }
}