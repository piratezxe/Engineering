using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace EngineeringWork.Core.Domain
{
    public class DailyRoute
    {
        [Key]
        public Guid Id { get; private set; }
        public Guid DriverId { get; set; }
        public DateTime CrateDate { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public Route Route { get; protected set; }
        public int FreeSeats { get; private set; }
        public MoneyValue MoneyValue { get; private set; } 
        
        private IList<PassengerBookingProposal> _passengerBookings = new List<PassengerBookingProposal>();

        public IEnumerable<PassengerBookingProposal> PassengerBookings => _passengerBookings;

        protected DailyRoute()
        {
        }

        public void AddPassengerBookingProposal(DateTime createTime, Guid proposalId, Guid userProposalId, int seats)
        {
            if (_passengerBookings.Any(x => x.Id == proposalId))
            {
                throw new ArgumentException($"Proposal with id {proposalId} actual exist in dailyRoute");
            }

            var proposal = PassengerBookingProposal.CreateToVerify(proposalId, createTime, userProposalId, Id, seats);
            proposal.Verify();
            
            _passengerBookings.Add(proposal);
        }

        public void AcceptedPassengerBookingProposal(Guid bookingProposal)
        {
            var passengerBookingProposal = GetOrFailPassengerBookingProposal(bookingProposal);
            
            if (FreeSeats < passengerBookingProposal.SeatsQuantity)
            {
                throw new ArgumentException($"Daily route have only {FreeSeats} seats");
            }

            passengerBookingProposal.Accept();
            FreeSeats -= passengerBookingProposal.SeatsQuantity;
        }
        
        public void RejectedPassengerBookingProposal(string rejectedReason, Guid bookingProposal)
        {
            var passengerBookingProposal = GetOrFailPassengerBookingProposal(bookingProposal);
            passengerBookingProposal.Rejected(rejectedReason);
        }

        private DailyRoute(DateTime createDate, DateTime startDate,  Route route, Guid id, int freeSeats, MoneyValue moneyValue)
        {
            Id = id;
            Route = route;
            CrateDate = createDate;
            StartDate = startDate;
            FreeSeats = freeSeats;
            MoneyValue = moneyValue;
        }

        public static DailyRoute CreateDailyRoute(DateTime createDate,DateTime startDate,  Route route, Guid id, int freeSeats, MoneyValue moneyValue)
            => new DailyRoute(createDate, startDate,  route,  id, freeSeats, moneyValue);

        private PassengerBookingProposal GetOrFailPassengerBookingProposal(Guid proposalId)
        {
            var passengerBookingProposal = _passengerBookings.SingleOrDefault(x => x.Id == proposalId);
            if (passengerBookingProposal == null)
            {
                throw new ArgumentException($"Passenger booking with id: {proposalId} not exist");
            }

            return passengerBookingProposal;
        }
    }
}