using System;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.Services.PassengerBookingService
{
    public interface IPassengerBookingService : IService
    {
        Task CreateAsync(Guid id, Guid proposalId);
    }
}