using System.Threading.Tasks;

namespace EngineeringWork.Core.Interface.Services.UserService
{
    public interface IUserService : IService
    {
        Task LoginAsync(string email, string password);
    }
}