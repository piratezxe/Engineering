using System;
using System.ComponentModel.DataAnnotations;

namespace Passenger.Core.Domain
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        public string Token { get; set; }
        
        public bool Revoke { get; set; }
        public Guid UserId { get; set; }
    }
}