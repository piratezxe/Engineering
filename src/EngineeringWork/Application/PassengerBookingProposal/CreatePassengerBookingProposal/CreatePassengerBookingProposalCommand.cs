using System;
using EngineeringWork.Web.Application.Auth;
using MediatR;

namespace EngineeringWork.Web.Application.PassengerBookingProposal.CreatePassengerBookingProposal
{
    public class CreatePassengerBookingProposalCommand : AuthCommandBase, IRequest
    {
        public Guid DailyRouteId { get; }
        
        public int SeatsQuantity { get; }

        public CreatePassengerBookingProposalCommand(Guid dailyRouteId, int seatsQuantity, Guid userId)
        {
            DailyRouteId = dailyRouteId;
            SeatsQuantity = seatsQuantity;
            UserId = userId;
        }
    }
}