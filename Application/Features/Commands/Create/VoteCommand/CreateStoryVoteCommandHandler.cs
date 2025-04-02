using Application.Features.Commands.Create.VoteCommand;
using Application.Interfaces.Repositories;
using AutoMapper;
using Common.Infrastructure.Exceptions;
using Common.Infrastructure.ExistsDatabase;
using Common.Models.RequestModels.Create.Entities.CreateVoteCommand;
using Domain;
using Domain.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Create
{
    public class CreateStoryVoteCommandHandler : BaseCreateVoteCommandHandler<IStoryVoteWriteRepository,CreateStoryVoteCommand>
    {
        private readonly IMapper _mapper;
        private readonly IStoryReadRepository _storyReadRepository;
        private readonly IUserReadRepository _userReadRepository;


        public CreateStoryVoteCommandHandler(IStoryVoteWriteRepository repository, IMapper mapper, IStoryReadRepository storyReadRepository, IUserReadRepository userReadRepository) : base(repository)
        {
            _mapper = mapper;
            _storyReadRepository = storyReadRepository;
            _userReadRepository = userReadRepository;
        }

        public override async Task<Guid> Handle(CreateStoryVoteCommand request, CancellationToken cancellationToken)
        {
            var IsExistingUser = await ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository, i => i.Id == request.UserId);
            if (!IsExistingUser)
                throw new DatabaseExistingValueException("User is not found");
            var IsExistingPost = await ExistsDatabaseQuery<Domain.Story>.IsExistingAsync(_storyReadRepository, i => i.Id == i.UserId);
            if (!IsExistingPost)
                throw new DatabaseExistingValueException();
            var createVoteCommand = request as CreateStoryVoteCommand;
            var vote = _mapper.Map<StoryVote>(createVoteCommand);
            await _repository.AddAsync(vote);
            await _repository.SaveChangesAsync();
            return vote.Id;
        }
    }
} 