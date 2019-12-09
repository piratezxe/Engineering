using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Repositories;
using MediatR;

namespace EngineeringWork.Web.Domain.BookingProposal.AcceptPassengerBookingProposal
{
    public class AcceptPassengerBookingProposalCommandHandler : IRequestHandler<AcceptPassengerBookingProposalCommand>
    {
        private readonly IPassengerBookingProposalRepository _passengerBookingProposalRepository;

        public AcceptPassengerBookingProposalCommandHandler(IPassengerBookingProposalRepository passengerBookingProposalRepository)
        {
            _passengerBookingProposalRepository = passengerBookingProposalRepository;
        }

        public async Task<Unit> Handle(AcceptPassengerBookingProposalCommand request, CancellationToken cancellationToken)
        {
            var proposal = await _passengerBookingProposalRepository.GetByIdAsync(request.PassengerBookingProposalId);
            if(proposal is null)
                throw new ArgumentNullException($"Proposal with  {request.PassengerBookingProposalId} not exist");
            
            proposal.Accept(request.UserId);
            return await Unit.Task;
        }
    }
}