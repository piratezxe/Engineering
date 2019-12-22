using System;
using System.Threading.Tasks;
using EngineeringWork.Core.Database;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EngineeringWork.Infrastructure.Repositories
{
    public class PassengerBookingProposalRepository : IPassengerBookingProposalRepository
    {
        private readonly PassengerContext _passengerContext;

        public PassengerBookingProposalRepository(PassengerContext passengerContext)
        {
            _passengerContext = passengerContext;
        }
        public async Task AddAsync(PassengerBookingProposal proposal)
        {
            await _passengerContext.PassengerBookingProposals.AddAsync(proposal);
        }

        public Task<PassengerBookingProposal> GetAsync(Guid id)
        {
            return _passengerContext.PassengerBookingProposals.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(PassengerBookingProposal proposal)
        {
            _passengerContext.PassengerBookingProposals.Update(proposal);
            await _passengerContext.SaveChangesAsync();
        }
    }
}