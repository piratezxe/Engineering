using System;
using MediatR;

namespace EngineeringWork.Web.Domain.Passenger.GetPassenger
{
    public class GetPassengerByIdQuery : IRequest<Core.Domain.Passenger>
    {
        public Guid PassengerId { get; set; }
    }
} 