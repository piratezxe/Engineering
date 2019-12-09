using System.Threading.Tasks;
using EngineeringWork.Web.Application;
using EngineeringWork.Web.Domain.BookingProposal.AcceptPassengerBookingProposal;
using EngineeringWork.Web.Domain.BookingProposal.RejectPassengerBookingProposal;
using EngineeringWork.Web.Domain.BookingProposal.RequestPassengerBookingProposalVerification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Domain.BookingProposal
{
    public class BookingProposalController : ApiControllerBase
    {
        public BookingProposalController(IMediator Mediator) : base(Mediator)
        {
        }
        
        [HttpPost("/Accept")]
        public async Task<IActionResult> AcceptPassengerBookingProposal([FromBody] AcceptPassengerBookingProposalCommand acceptPassengerBookingProposalCommand)
        {
            await Send(acceptPassengerBookingProposalCommand);
            return Ok($"Accepted booking with id {acceptPassengerBookingProposalCommand.PassengerBookingProposalId} ");
        }

        [HttpPost("/Reject")]
        public async Task<IActionResult> RejectPassengerBookingProposal(
            [FromBody] RejectPassengerBookingProposalCommand rejectPassengerBookingProposalCommand)
        {
            await Send(rejectPassengerBookingProposalCommand);
            return Ok($"Rejected booking with id {rejectPassengerBookingProposalCommand}");
        }

        [HttpPost("Request")]
        public async Task<IActionResult> RequestPassengerBookingProposalVerification(
            [FromBody]
            RequestPassengerBookingProposalVerificationCommand requestPassengerBookingProposalVerificationCommand)
        {
            await Send(requestPassengerBookingProposalVerificationCommand);
            return Ok($"Request verification with id {requestPassengerBookingProposalVerificationCommand.ProposalId}");
        }
    }
}