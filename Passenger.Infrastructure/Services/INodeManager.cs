using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface INodeManager
    {
        Task<string> GetAdrressAsync(double x, double y);
        
        Task<string> GetRouteAdrressAsync(double startX, double startY , double endY, double endX);
    }
}