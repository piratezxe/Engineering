using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Repository.Repositories.Interface;

namespace EngineeringWork.Repository.Repositories
{
    public class PassengerBookingRepository : IPassengerBookingRepository
    {
        private readonly IPassengerBookingRepository _bookingRepository;

        public PassengerBookingRepository(IPassengerBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task CreateAsync(PassengerBooking passengerBooking)
        {
            await _bookingRepository.CreateAsync(passengerBooking);
        }
    }
}