using System.Threading.Tasks;

namespace EngineeringWork.Core.Interface.Services.NodeService
{
    public interface INodeManager
    {
        Task<string> GetAdrressAsync(double x, double y);
    }
}