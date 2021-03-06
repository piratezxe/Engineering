using System;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Users.CreateUser
{
    public class CreateUserCommand : IRequest  
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }    
    }
}