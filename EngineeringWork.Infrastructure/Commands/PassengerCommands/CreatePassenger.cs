using EngineeringWork.Infrastructure.Commands.Auth;

namespace EngineeringWork.Infrastructure.Commands.PassengerCommands
{
    public class CreatePassenger : AuthCommandBase
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