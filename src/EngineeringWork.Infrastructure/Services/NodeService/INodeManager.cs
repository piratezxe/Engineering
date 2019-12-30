using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.Services.NodeService
{
    public interface INodeManager
    {
        Task<string> GetAdrressAsync(double x, double y);
    }
}