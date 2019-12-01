using EngineeringWork.Web.Controller;
using MediatR;

namespace EngineeringWork.Web.Domain.PassengerBooking
{

    public class PassengerBookingController : ApiControllerBase
    {
        public PassengerBookingController(IMediator mediator) : base(mediator)
        {
        }
    }
}
