using Application.Features.Commands.Delete.VoteCommand;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete.DeleteVoteCommand;
using Domain.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Delete
{
    public class DeleteCommentVoteCommandHandler : BaseDeleteVoteCommandHandler<ICommentVoteWriteRepository, CommentVote>
    {
        public DeleteCommentVoteCommandHandler(ICommentVoteWriteRepository writeRepository, IUserReadRepository userReadRepository, ICommentVoteReadRepository readRepository) : base(writeRepository, userReadRepository, readRepository)
        {
        }
    }
} 