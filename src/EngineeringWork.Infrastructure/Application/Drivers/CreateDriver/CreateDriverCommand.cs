using EngineeringWork.Infrastructure.Application.Auth;

namespace EngineeringWork.Infrastructure.Application.Drivers.CreateDriver
{
    public class CreateDriverCommand : AuthCommandBase
    {
        public CreateDriverCommand(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get;}
    }
}