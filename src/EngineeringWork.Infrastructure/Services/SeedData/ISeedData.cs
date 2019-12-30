using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.Services.SeedData
{
    public interface ISeedData : IService
    {
        Task Init();
    }
    
}