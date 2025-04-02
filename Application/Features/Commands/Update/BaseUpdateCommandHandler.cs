using Application.Interfaces.Repositories;
using AutoMapper;
using Common.Infrastructure.Exceptions;
using Common.Infrastructure.ExistsDatabase;
using Common.Models.RequestModels.Update;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public abstract class BaseUpdateCommandHandler<TCommand,TEntity> : BaseCommandHandler, IRequestHandler<TCommand, Guid> 
        where TCommand : BaseUpdateCommand
        where TEntity : BaseEntity,new()
    {
        private readonly IReadRepository<TEntity> _readRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IWriteRepository<TEntity> _writeRepository;
        private readonly IMapper _mapper;
        public BaseUpdateCommandHandler(IReadRepository<TEntity> readRepository,
                                        IUserReadRepository userReadRepository,
                                        IWriteRepository<TEntity> writeRepository,
                                        IMapper mapper)
        {
            _readRepository = readRepository;
            _userReadRepository = userReadRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public virtual async Task<Guid> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var commentExists = await ExistsDatabaseQuery<TEntity>.IsExistingAsync(_readRepository, c => c.Id == request.Id);
            if (!commentExists)
            {
                throw new DatabaseExistingValueException("Object not found!");
            }

            var userExists = await ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository, u => u.Id == request.UserId);
            if (!userExists)
            {
                throw new DatabaseExistingValueException("User not found!");
            }
            TEntity entity = await _readRepository.GetSingleAsync(i => i.Id == request.Id);
            _mapper.Map(request, entity);
            _writeRepository.Update(entity);
            await _writeRepository.SaveChangesAsync();
            return entity.Id;
        }
    }
}
