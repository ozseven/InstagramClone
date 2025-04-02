using Application.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.RequestModels.Delete;
using Common.Infrastructure.ExistsDatabase;
using Common.Infrastructure.Exceptions;

namespace Application.Features.Commands.Delete
{
    public class DeleteStoryCommandHandler : BaseDeleteCommandHandler<Story, IStoryWriteRepository, DeleteStoryCommand>
    {
        public DeleteStoryCommandHandler(
            IStoryWriteRepository repository,
            IStoryReadRepository storyReadRepository,
            IUserReadRepository userReadRepository) : base(repository, userReadRepository, storyReadRepository)
        {
        }
    }
}
