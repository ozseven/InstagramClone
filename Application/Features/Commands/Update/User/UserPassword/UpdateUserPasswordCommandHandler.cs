using Application.Interfaces.Repositories;
using AutoMapper;
using Common;
using Common.Infrastructure;
using Common.Models.RequestModels.Update;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Update
{
    public class UpdateUserPasswordCommandHandler:BaseUpdateCommandHandler<UpdateUserPasswordCommand,User>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;

        public UpdateUserPasswordCommandHandler(IUserReadRepository readRepository, IUserReadRepository userReadRepository, IUserWriteRepository writeRepository, IMapper mapper) : base(readRepository, userReadRepository, writeRepository, mapper)
        {
            _userWriteRepository = writeRepository;
            _userReadRepository = userReadRepository;
        }

        public async override Task<Guid> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
        {
            User user = await _userReadRepository.GetSingleAsync(i => i.Id == request.Id);
            user.Password = request.NewPassword;
            QueueFactory.SendMessageToExchange(ApplicationConstants.UserExchangeName, ApplicationConstants.DefaultExchangeType, ApplicationConstants.UserPasswordChangedQueueName, new { user.Email });
            return user.Id;
        }
    }
}
/*
 updateUserPasswordCommand to User.Password
send validation email with rabbitmq
save to database


 */
