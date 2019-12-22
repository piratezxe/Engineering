using System.Threading.Tasks;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Core.Interface.Repositories
{
    public interface IPassengerBookingRepository : IRepository
    {
        Task CreateAsync(PassengerBooking passengerBooking);
    }
}