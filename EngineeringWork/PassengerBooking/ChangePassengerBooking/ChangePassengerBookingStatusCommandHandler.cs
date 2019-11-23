using EngineeringWork.Infrastructure.Commands.PassengerBooking;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.CommandHandlers.PassengerBookingHandler
{
    public class ChangePassengerBookingStatusCommandHandler : IRequestHandler<ChangePassengerBooking>
    {
        public Task<Unit> Handle(ChangePassengerBooking request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
