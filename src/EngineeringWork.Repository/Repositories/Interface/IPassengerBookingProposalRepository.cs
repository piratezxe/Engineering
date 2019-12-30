using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;

namespace EngineeringWork.Repository.Repositories.Interface
{
    public interface IPassengerBookingProposalRepository : IRepository
    {
        Task AddAsync(PassengerBookingProposal proposal);

        Task<PassengerBookingProposal> GetAsync(Guid id);

        Task UpdateAsync(PassengerBookingProposal proposal);
    }
}