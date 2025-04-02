using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Delete
{
    public class DeleteUserCommandHandler : BaseDeleteCommandHandler<User,IUserWriteRepository,DeleteUserCommand>
    {
        public DeleteUserCommandHandler(IUserWriteRepository writeRepository,IUserReadRepository userReadRepository,IUserReadRepository userReadRepository1) : base(writeRepository,userReadRepository,userReadRepository1)
        {
        }
    }
}
