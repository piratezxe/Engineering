using System.Threading.Tasks;
using EngineeringWork.Web.Application.PassengerBookingProposal.AcceptedPassengerBookingProposal;
using EngineeringWork.Web.Application.PassengerBookingProposal.CreatePassengerBookingProposal;
using EngineeringWork.Web.Application.PassengerBookingProposal.RejectedPassengerBookingProposal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Application.PassengerBookingProposal
{

    public class PassengerBookingProposalController : ApiControllerBase
    {
        public PassengerBookingProposalController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreatePassengerBookingProposalCommand proposal)
        {
            await Send(proposal);
            return Ok(null);
        }

        [HttpPost("Rejected")]
        public async Task<IActionResult> Rejected([FromBody] RejectedPassengerBookingCommand proposal)
        {
            await Send(proposal);
            return Ok(null);
        }
        [HttpPost("Accepted")]
        public async Task<IActionResult> Accepted([FromBody] AcceptedPassengerBookingProposalCommand proposal)
        {
            await Send(proposal);
            return Ok(null);
        }
    }
}
