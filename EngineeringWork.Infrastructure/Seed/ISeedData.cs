using System.Threading.Tasks;

namespace Passenger.Infrastructure.Seed
{
    public interface ISeedData
    {
        Task Init();
    }
}