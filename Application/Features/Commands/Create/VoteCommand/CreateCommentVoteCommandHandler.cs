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
    public class CreateCommentVoteCommandHandler : BaseCreateVoteCommandHandler<ICommentVoteWriteRepository,CreateCommentVoteCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICommentReadRepository _commentReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IPostReadRepository _postReadRepository;


        public CreateCommentVoteCommandHandler(ICommentVoteWriteRepository repository, IMapper mapper, ICommentReadRepository commentReadRepository, IUserReadRepository userReadRepository,IPostReadRepository postReadRepository) : base(repository)
        {
            _mapper = mapper;
            _commentReadRepository = commentReadRepository;
            _userReadRepository = userReadRepository;
            _postReadRepository = postReadRepository;
        }

        public override async Task<Guid> Handle(CreateCommentVoteCommand request, CancellationToken cancellationToken)
        {
            var IsExistUser =await ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository,i=>i.Id ==request.UserId);
            if (!IsExistUser)
                throw new DatabaseExistingValueException("User is not found!");
            var IsExistPost = await ExistsDatabaseQuery<Post>.IsExistingAsync(_postReadRepository, i => i.Id == request.PostId);
            if (!IsExistPost)
                throw new DatabaseExistingValueException("Post is not found");
            var vote = _mapper.Map<CommentVote>(request);
            await _repository.AddAsync(vote);
            await _repository.SaveChangesAsync();
            return vote.Id;
        }
    }
}