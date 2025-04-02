using Application.Interfaces.Repositories;
using AutoMapper;
using Common.Infrastructure.Exceptions;
using Common.Infrastructure.ExistsDatabase;
using Common.Models.RequestModels.Create.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Create
{
    public class CreateStoryCommandHandler : BaseCreateCommandHandler<CreateStoryCommand>
    {
        private readonly IStoryWriteRepository _storyWriteRepository;
        private readonly IMapper _mapper;
        private readonly IUserReadRepository _userReadRepository;

        public CreateStoryCommandHandler(IStoryWriteRepository storyWriteRepository, IMapper mapper,IUserReadRepository userReadRepository)
        {
            _storyWriteRepository = storyWriteRepository;
            _mapper = mapper;
            _userReadRepository = userReadRepository;
        }

        public override async Task<Guid> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {

            var IsExistUser = await ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository, i => i.Id == request.UserId);
            if (!IsExistUser)
            {
                throw new DatabaseExistingValueException();
            }
            var story = _mapper.Map<Domain.Story>(request);
            await _storyWriteRepository.AddAsync(story);
            await _storyWriteRepository.SaveChangesAsync();
            return story.Id;
        }
    }
}
