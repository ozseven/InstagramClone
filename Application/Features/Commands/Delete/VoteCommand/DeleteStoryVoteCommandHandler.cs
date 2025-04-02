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
    public class DeleteStoryVoteCommandHandler : BaseDeleteVoteCommandHandler<IStoryVoteWriteRepository, StoryVote>
    {
        public DeleteStoryVoteCommandHandler(IStoryVoteWriteRepository writeRepository, IUserReadRepository userReadRepository, IStoryVoteReadRepository readRepository) : base(writeRepository, userReadRepository, readRepository)
        {
        }
    }
} 