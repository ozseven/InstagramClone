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
    public class CreateCommentCommandHandler : BaseCreateCommandHandler<CreateCommentCommand>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;
        private readonly IMapper _mapper;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IPostReadRepository _postReadRepository;

        public CreateCommentCommandHandler(
            ICommentWriteRepository commentWriteRepository, 
            IMapper mapper,
            IUserReadRepository userReadRepository,
            IPostReadRepository postReadRepository)
        {
            _commentWriteRepository = commentWriteRepository;
            _mapper = mapper;
            _userReadRepository = userReadRepository;
            _postReadRepository = postReadRepository;
        }

        public override async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            // Kullanıcının varlığını kontrol et
            var userExists = await ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository, u => u.Id == request.UserId);
            if (!userExists)
            {
                throw new DatabaseExistingValueException("Kullanıcı bulunamadı.");
            }

            // Post'un varlığını kontrol et
            var postExists = await ExistsDatabaseQuery<Post>.IsExistingAsync(_postReadRepository, p => p.Id == request.PostId);
            if (!postExists)
            {
                throw new DatabaseExistingValueException("Post bulunamadı.");
            }

            var entity = _mapper.Map<Domain.Comment>(request);
            await _commentWriteRepository.AddAsync(entity);
            await _commentWriteRepository.SaveChangesAsync();
            return entity.Id;
        }
    }
}
