using Application.Interfaces.Repositories;
using AutoMapper;
using Common.Infrastructure.Exceptions;
using Common.Infrastructure.ExistsDatabase;
using Common.Infrastructure;
using Common.Models.RequestModels.Update;
using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Update
{
    public class UpdateUserCommandHandler : BaseUpdateCommandHandler<UpdateUserCommand,User>
    {
        private readonly IMapper _mapper;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UpdateUserCommandHandler(IUserReadRepository readRepository, IUserReadRepository userReadRepository, IUserWriteRepository writeRepository, IMapper mapper) : base(readRepository, userReadRepository, writeRepository, mapper)
        {
            _mapper = mapper;
            _userReadRepository = userReadRepository;
            _userWriteRepository = writeRepository;
        }


        //I have to think a bit about the rewriting of this function
        public override async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var IsExisting = await ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository,
                i => i.UserName == request.UserName);
            if (IsExisting)
            {
                throw new DatabaseExistingValueException();
            }
            User user = await _userReadRepository.GetSingleAsync(i => i.Id == request.Id);
            user = _mapper.Map<User>(request);
            var obj = new { user.Email, request.UserName };
            QueueFactory.SendMessageToExchange(ApplicationConstants.UserExchangeName, ApplicationConstants.DefaultExchangeType, ApplicationConstants.UserUpdateQueueName, obj);
            _userWriteRepository.Update(user);
            return user.Id;
        }
    }
}
