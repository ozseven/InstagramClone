using Application.Interfaces.Repositories;
using AutoMapper;
using Common;
using Common.Infrastructure;
using Common.Infrastructure.Exceptions;
using Common.Infrastructure.ExistsDatabase;
using Common.Models.RequestModels.Create;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository,IMapper mapper)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var IsExist= await ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository,
                i => i.UserName == request.UserName ||
                i.Email == request.Email);
            if (IsExist)
            {
                throw new DatabaseExistingValueException("User already exists");
            }
            var user = _mapper.Map<User>(request);
            await _userWriteRepository.AddAsync(user);
            await _userWriteRepository.SaveChangesAsync();
            var obj = new { request.Email, request.UserName };
            QueueFactory.SendMessageToExchange(ApplicationConstants.UserExchangeName, ApplicationConstants.DefaultExchangeType, ApplicationConstants.UserCreateQueueName, obj);
            return user.Id;
        }
    }
}

/*
 UserName is uniqued
Email is uniqued
createUserCommand to User
save to database
send validation email with rabbitmq*/