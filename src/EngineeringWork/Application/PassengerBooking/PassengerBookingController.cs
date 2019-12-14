using MediatR;

namespace EngineeringWork.Web.Application.PassengerBooking
{

    public class PassengerBookingController : ApiControllerBase
    {
        public PassengerBookingController(IMediator mediator) : base(mediator)
        {
        }
    }
}
