using Application.Interfaces.Repositories;
using AutoMapper;
using Common.Models.RequestModels.Update.UpdateVoteCommand;
using Domain.Vote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Update.VoteCommand
{
    public abstract class BaseUpdateVoteCommandHandler<TCommand, TEntity> : BaseUpdateCommandHandler<TCommand, TEntity>
        where TCommand : BaseUpdateVoteCommand
        where TEntity : BaseVote, new()
    {
        protected BaseUpdateVoteCommandHandler(IReadRepository<TEntity> readRepository, IUserReadRepository userReadRepository, IWriteRepository<TEntity> writeRepository, IMapper mapper) : base(readRepository, userReadRepository, writeRepository, mapper)
        {
        }
    }
} 