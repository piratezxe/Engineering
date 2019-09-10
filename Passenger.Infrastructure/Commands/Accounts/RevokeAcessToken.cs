namespace Passenger.Infrastructure.Commands.Accounts
{
    public class RevokeAcessToken : ICommand
    {
        public string Token { get; set; }
    }
}