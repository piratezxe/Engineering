using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Core.Interface.Repositories
{
    public interface IPassengerBookingProposalRepository
    {
        Task<PassengerBookingProposal> GetByIdAsync(Guid id);
        Task AddAsync(PassengerBookingProposal passengerBookingProposal);
    }
}