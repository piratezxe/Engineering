using System;

namespace EngineeringWork.Web.Application.Auth
{
    public class AuthCommandBase : IAuthCommand
    {
        public Guid UserId { get; set; }
    }
}