using System;
using EngineeringWork.Core.Domain;
using EngineeringWork.Web.Domain.Auth;
using MediatR;

namespace EngineeringWork.Web.Domain.PassengerBooking.ChangePassengerBooking
{
    public class ChangePassengerBooking : AuthCommandBase, IRequest
    {
        public Guid PassengerBookingId { get; set; }

        public BookingStatus BookingStatus { get; set; }
    }
}
