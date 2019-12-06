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

        public async Task<PassengerBookingProposal> GetByIdAsync(Guid id)
        {
            return await _passengerContext.PassengerBookingProposals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(PassengerBookingProposal passengerBookingProposal)
        {
             _passengerContext.PassengerBookingProposals.Add(passengerBookingProposal);
             await _passengerContext.SaveChangesAsync();
        }
    }
}