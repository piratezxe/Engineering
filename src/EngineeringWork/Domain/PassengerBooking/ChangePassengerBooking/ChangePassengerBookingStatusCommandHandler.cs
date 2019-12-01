using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace EngineeringWork.Web.Domain.PassengerBooking.ChangePassengerBooking
{
    public class ChangePassengerBookingStatusCommandHandler : IRequestHandler<ChangePassengerBooking>
    {
        public Task<Unit> Handle(ChangePassengerBooking request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
