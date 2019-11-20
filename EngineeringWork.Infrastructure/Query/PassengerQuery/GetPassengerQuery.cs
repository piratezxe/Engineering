using System;
using EngineeringWork.Core.Domain;
using MediatR;

namespace EngineeringWork.Infrastructure.Query.PassengerQuery
{
    public class GetPassengerByIdQuery : IRequest<Passenger>
    {
        public Guid PassengerId { get; set; }
    }
} 