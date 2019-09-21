
namespace Passenger.Infrastructure.Commands.Accounts
{
    public class ResfreshAcessToken : ICommand
    {
        public string token { get; set; }
        public string Email { get; set; }
    }
}