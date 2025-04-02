using Application.Interfaces.Repositories;
using Application.Features.Commands.Create.VoteCommand;
using AutoMapper;
using Common.Models.RequestModels.Create.Entities.CreateVoteCommand;
using Domain.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.ExistsDatabase;
using Domain;
using Common.Infrastructure.Exceptions;

namespace Application.Features.Commands.Create
{
    public class CreatePostVoteCommandHandler : BaseCreateVoteCommandHandler<IPostVoteWriteRepository,CreatePostVoteCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IPostReadRepository _postReadRepository;

        public CreatePostVoteCommandHandler(IPostVoteWriteRepository repository, IMapper mapper, IUserReadRepository userReadRepository, IPostReadRepository postReadRepository) : base(repository)
        {
            _mapper = mapper;
            _userReadRepository = userReadRepository;
            _postReadRepository = postReadRepository;
        }

        public override async Task<Guid> Handle(CreatePostVoteCommand request, CancellationToken cancellationToken)
        {
            var IsExistingUser = await ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository,i=>i.Id==request.UserId);
            if (!IsExistingUser) 
                throw new DatabaseExistingValueException("User is not found");
            var IsExistingPost = await ExistsDatabaseQuery<Post>.IsExistingAsync(_postReadRepository,i=>i.Id==i.UserId);
            if (!IsExistingPost)
                throw new DatabaseExistingValueException();
            var vote = _mapper.Map<PostVote>(request);
            await _repository.AddAsync(vote);
            await _repository.SaveChangesAsync();
            return vote.Id;
        }
    }
} 