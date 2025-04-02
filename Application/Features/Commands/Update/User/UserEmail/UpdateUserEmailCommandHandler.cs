using Application.Interfaces.Repositories;
using AutoMapper;
using Common;
using Common.Infrastructure;
using Common.Infrastructure.Exceptions;
using Common.Infrastructure.ExistsDatabase;
using Common.Models.RequestModels.Update;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class UpdateUserEmailCommandHandler : BaseUpdateCommandHandler<UpdateUserEmailCommand,User>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UpdateUserEmailCommandHandler(IUserReadRepository readRepository, IUserReadRepository userReadRepository, IUserWriteRepository writeRepository, IMapper mapper) : base(readRepository, userReadRepository, writeRepository, mapper)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = writeRepository;
        }
        //I have to think a bit about the rewriting of this function
        public override async Task<Guid> Handle(UpdateUserEmailCommand request,CancellationToken cancellationToken)
        {
            var IsExist = await ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository,i=>i.Email == request.NewEmail);
            if (IsExist)
            {
                throw new DatabaseExistingValueException(request.NewEmail);
            }
            User user = await _userReadRepository.GetSingleAsync(i => i.Id == request.Id);
            user.Email = request.NewEmail;
            var obj = new { user.Email };
            QueueFactory.SendMessageToExchange(ApplicationConstants.UserExchangeName, ApplicationConstants.DefaultExchangeType, ApplicationConstants.UserEmailChangedQueueName, obj);
            _userWriteRepository.Update(user);
            return user.Id;
        }
    }
}
/*
new Email is uniqued
updateUserEmailCommand to User.Email
send validation email with rabbitmq
save to database

*/