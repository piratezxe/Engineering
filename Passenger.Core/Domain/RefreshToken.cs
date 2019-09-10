using System;

namespace Passenger.Core.Domain
{
    public class RefreshToken
    {
        public string Token { get; set; }
        
        public bool Revoke { get; set; }

        public string UserEmail { get; set; }
    }
}