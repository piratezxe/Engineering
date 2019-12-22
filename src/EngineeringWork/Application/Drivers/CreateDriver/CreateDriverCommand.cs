using EngineeringWork.Web.Application.Auth;

namespace EngineeringWork.Web.Application.Drivers.CreateDriver
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