namespace Passenger.Infrastructure.Services
{
    public interface IEncrypter
    {
        /// <summary>
        /// later use IPasswordHashe<T> value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string GetSalt(string value);
        string GetHash(string value, string salt);
    }
}