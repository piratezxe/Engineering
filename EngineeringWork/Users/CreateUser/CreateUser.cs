using System;
using MediatR;

namespace EngineeringWork.Infrastructure.Commands.Users
{
    public class CreateUser : IRequest  
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }    
    }
}