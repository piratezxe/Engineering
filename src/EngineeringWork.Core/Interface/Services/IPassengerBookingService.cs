using System;
using System.Threading.Tasks;

namespace EngineeringWork.Core.Interface.Services
{
    public interface IPassengerBookingService : IService
    {
        Task CreateAsync(Guid id, Guid proposalId);
    }
}