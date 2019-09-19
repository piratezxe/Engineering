using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Auth;

namespace EngineeringWork.Web.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher CommandDispatcher;

        protected Guid UserId => User.Identity.IsAuthenticated ? Guid.Parse(User.Identity.Name) : Guid.Empty;
        
        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }   
        
        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command is IAuthCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }
            await CommandDispatcher.DispatchAsync(command);
        }
    }
}