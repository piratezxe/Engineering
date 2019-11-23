using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Query.UserQuery;
using MediatR;

namespace EngineeringWork.Infrastructure.QueryHandlers.UserHandler
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);
            return _mapper.Map<User,UserDto>(user);
        }
    }
}