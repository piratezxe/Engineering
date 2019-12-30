using System.Threading.Tasks;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Repository.Repositories.Interface
{
    public interface IPassengerBookingRepository : IRepository
    {
        Task CreateAsync(PassengerBooking passengerBooking);
    }
}