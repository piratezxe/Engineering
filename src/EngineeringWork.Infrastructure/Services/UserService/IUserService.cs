using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.Services.UserService
{
    public interface IUserService : IService
    {
        Task LoginAsync(string email, string password);
    }
}