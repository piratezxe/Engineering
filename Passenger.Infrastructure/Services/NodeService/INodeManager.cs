using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services.NodeService
{
    public interface INodeManager
    {
        Task<string> GetAdrressAsync(double x, double y);
    }
}