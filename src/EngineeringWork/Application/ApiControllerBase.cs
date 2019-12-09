using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Web.Domain.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringWork.Web.Application
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Microsoft.AspNetCore.Mvc.Controller
    {
        public readonly IMediator mediator;
        protected Guid UserId => User.Identity.IsAuthenticated ? Guid.Parse(User.Identity.Name) : Guid.Empty;

        protected ApiControllerBase(IMediator Mediator)
        {
            mediator = Mediator;
        }

        protected async Task<TResponse> Send<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request is IAuthCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }

            return await mediator.Send(request, cancellationToken);
        }
    }
}