using EngineeringWork.Core.Interface.Services;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.Seed
{
    public interface ISeedData 
    {
        Task Init();
    }
}