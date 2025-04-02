using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete.DeleteVoteCommand;
using Domain.Vote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Delete.VoteCommand
{
    public abstract class BaseDeleteVoteCommandHandler<TRepository, Vote> : BaseDeleteCommandHandler<Vote,TRepository,BaseDeleteVoteCommand>
        where TRepository : IWriteRepository<Vote>
        where Vote : BaseVote, new()
    {
        public BaseDeleteVoteCommandHandler(TRepository repository,
                                            IUserReadRepository userReadRepository,
                                            IReadRepository<Vote> readRepository)
                                            :base(repository,userReadRepository,readRepository)
        {
        }
    }
}
