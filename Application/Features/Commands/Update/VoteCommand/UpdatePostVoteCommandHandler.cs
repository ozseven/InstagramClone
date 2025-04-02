using Application.Features.Commands.Update.VoteCommand;
using Application.Interfaces.Repositories;
using AutoMapper;
using Common.Models.RequestModels.Update.UpdateVoteCommand;
using Domain.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Update
{
    public class UpdatePostVoteCommandHandler : BaseUpdateVoteCommandHandler<UpdatePostVoteCommand, PostVote>
    {
        public UpdatePostVoteCommandHandler(IPostVoteReadRepository readRepository, IUserReadRepository userReadRepository, IPostVoteWriteRepository writeRepository, IMapper mapper) : base(readRepository, userReadRepository, writeRepository, mapper)
        {
        }
    }
} 