using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class NodeManager : INodeManager
    {
        public async Task<string> GetAdrressAsync(double x, double y)
        {
            await Task.CompletedTask;
            return $"The adress is x: {x} y: {y}";
        }

        public async Task<string> GetRouteAdrressAsync(double startX, double startY, double endY, double endX)
        {
            await Task.CompletedTask;
            return $"The adress start is x: {startX} y: {startY} end is x: {endX} y: {endY}";
        }
    }
}