using System;

namespace EngineeringWork.Web.Domain.Auth
{
    public class AuthCommandBase : IAuthCommand
    {
        public Guid UserId { get; set; }
    }
}