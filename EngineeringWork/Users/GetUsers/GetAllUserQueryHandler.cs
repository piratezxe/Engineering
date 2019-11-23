﻿using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Query.UserQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.QueryHandlers.UserHandler
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }
    }
}