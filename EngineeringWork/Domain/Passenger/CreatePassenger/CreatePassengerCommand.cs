using EngineeringWork.Web.Domain.Auth;

namespace EngineeringWork.Web.Domain.Passenger.CreatePassenger
{
    public class CreatePassengerCommand : AuthCommandBase
    {
        public PassengerAdres Adress { get; set; }
        public class PassengerAdres
        {
            public string ZipCode { get; set; }
        
            public string City { get; set; }
        
            public string Street { get; set; }
        }
    }
}