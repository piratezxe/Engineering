using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using MediatR;

namespace EngineeringWork.Web.Domain.BookingProposal.RequestPassengerBookingProposalVerification
{
    public class RequestPassengerBookingProposalVerificationCommandHandler : IRequestHandler<RequestPassengerBookingProposalVerificationCommand>
    {
        private readonly IPassengerBookingProposalRepository _passengerBookingProposalRepository;

        public RequestPassengerBookingProposalVerificationCommandHandler(IPassengerBookingProposalRepository passengerBookingProposalRepository)
        {
            _passengerBookingProposalRepository = passengerBookingProposalRepository;
        }

        public async Task<Unit> Handle(RequestPassengerBookingProposalVerificationCommand request, CancellationToken cancellationToken)
        {
            var passengerBookingProposal = PassengerBookingProposal.CreateToVerify(
                request.ProposalId,
                request.ProposalDate,
                request.ProposalUserId
            );
            
            await _passengerBookingProposalRepository.AddAsync(passengerBookingProposal);
            return Unit.Value;;
        }
    }
}