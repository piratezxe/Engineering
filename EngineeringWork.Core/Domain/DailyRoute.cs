using System;
using System.Collections.Generic;
using System.Linq;

namespace Passenger.Core.Domain
{
    public class DailyRoute
    {
        public Guid DriverId { get; set; }
        
        public Guid Id { get; set; }
        public DateTime DateTime { get; protected set; }
        
        private ISet<PassengerNode> _passengerNodes = new HashSet<PassengerNode>();
        
        public Route Route { get; protected set; }
        
        public IEnumerable<PassengerNode> PassengerNodes => _passengerNodes;

        public DailyRoute()
        {
        }
        
        protected DailyRoute(DateTime dateTime, Route route, Guid id)
        {
            Id = id;
            Route = route;
            DateTime = dateTime;
        }

        public void AddPassengerNode(Passenger passenger, Node node)
        {
            var passengerNode = GetPassengerNode(passenger);
            if(passengerNode != null)
            {
                throw new InvalidOperationException($"Node already exists for passenger: '{passenger.UserId}'.");
            }
            _passengerNodes.Add(PassengerNode.Create(passenger, node));
        }

        public void RemovePassengerNode(Passenger passenger)
        {
            var passengerNode = GetPassengerNode(passenger);
            if(passengerNode is null)
            {
                return;
            }
            _passengerNodes.Remove(passengerNode);
        } 

        private PassengerNode GetPassengerNode(Passenger passenger)
            => _passengerNodes.SingleOrDefault(x => x.Passenger.UserId == passenger.UserId);

        public static DailyRoute CreateDailyRoute(DateTime dateTime, Route route, Guid Id)
            => new DailyRoute(dateTime, route,  Id);
    }
}