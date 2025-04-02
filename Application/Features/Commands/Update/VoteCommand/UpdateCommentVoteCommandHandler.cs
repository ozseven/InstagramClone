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
    public class UpdateCommentVoteCommandHandler : BaseUpdateVoteCommandHandler<UpdateCommentVoteCommand, CommentVote>
    {
        public UpdateCommentVoteCommandHandler(ICommentVoteReadRepository readRepository, IUserReadRepository userReadRepository, ICommentVoteWriteRepository writeRepository, IMapper mapper) 
            : base(readRepository, userReadRepository, writeRepository, mapper)
        {
        }
    }
} 