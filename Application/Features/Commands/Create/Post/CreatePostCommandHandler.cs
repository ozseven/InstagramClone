using Application.Interfaces.Repositories;
using AutoMapper;
using Common.Infrastructure.Exceptions;
using Common.Infrastructure.ExistsDatabase;
using Common.Models.RequestModels.Create.Entities;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Create
{
    public class CreatePostCommandHandler : BaseCreateCommandHandler<CreatePostCommand>
    {
        private readonly IPostWriteRepository _postWriteRepository;
        private readonly IMapper _mapper;
        private readonly IUserReadRepository _userReadRepository;

        public CreatePostCommandHandler(IPostWriteRepository postWriteRepository, IMapper mapper,IUserReadRepository userReadRepository)
        {
            _postWriteRepository = postWriteRepository;
            _mapper = mapper;
            _userReadRepository = userReadRepository;
        }

        public override async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var isUserExists =await  ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository, i => i.Id == request.UserId);
            if (!isUserExists)
                throw new DatabaseExistingValueException();

            var post = _mapper.Map<Domain.Post>(request);
            await _postWriteRepository.AddAsync(post);
            await _postWriteRepository.SaveChangesAsync();
            return post.Id;
        }
    }
}
