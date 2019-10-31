using Microsoft.AspNetCore.Identity;

namespace EngineeringWork.Infrastructure.Services.Password
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<IPasswordService> _passwordHasher;

        public PasswordService(IPasswordHasher<IPasswordService> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public bool VerifedPasswordHash(string hash, string password)
            => _passwordHasher.VerifyHashedPassword(this, hash, password) != PasswordVerificationResult.Failed;

        public string HashPassword(string value)
            => _passwordHasher.HashPassword(this, value);
    }
}