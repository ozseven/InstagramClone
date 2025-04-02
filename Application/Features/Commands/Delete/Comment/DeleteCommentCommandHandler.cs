using Application.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Common.Models.RequestModels.Delete;
using Common.Infrastructure.ExistsDatabase;
using Common.Infrastructure.Exceptions;

namespace Application.Features.Commands.Delete
{
        public class DeleteCommentCommandHandler : BaseDeleteCommandHandler<Comment,ICommentWriteRepository,DeleteCommentCommand>
    {
        public DeleteCommentCommandHandler(
            ICommentWriteRepository repository,
            ICommentReadRepository commentReadRepository,
            IUserReadRepository userReadRepository) : base(repository,userReadRepository,commentReadRepository)
        {
        }
    }
}
