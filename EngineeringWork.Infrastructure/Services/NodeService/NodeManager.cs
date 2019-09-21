using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services.NodeService
{
    public class NodeManager : INodeManager
    {
        private string[] city = new string[]
            {"Biala Podlaska"};
        public async Task<string> GetAdrressAsync(double lat, double lng)
        {
            var word = city[new Random().Next(0, city.Length)];
            return await Task.FromResult(word);
        }
        
    }
}