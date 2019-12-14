using System;
using EngineeringWork.Core.Domain;
using EngineeringWork.Web.Application.Auth;
using MediatR;

namespace EngineeringWork.Web.Application.PassengerBooking.ChangePassengerBooking
{
    public class ChangePassengerBooking : AuthCommandBase, IRequest
    {
        public Guid PassengerBookingId { get; set; }

        public BookingStatus BookingStatus { get; set; }
    }
}
