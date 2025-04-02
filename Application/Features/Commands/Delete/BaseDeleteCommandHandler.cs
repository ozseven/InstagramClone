using Application.Interfaces.Repositories;
using Common.Infrastructure.Exceptions;
using Common.Infrastructure.ExistsDatabase;
using Common.Models.RequestModels;
using Common.Models.RequestModels.Delete;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Delete
{
    public class BaseDeleteCommandHandler<TEntity,TRepository,TCommand>:BaseCommandHandler,IRequestHandler<TCommand,Guid> 
        where TEntity : BaseEntity , new()
        where TRepository :IWriteRepository<TEntity>
        where TCommand : BaseDeleteCommand,new()
    {
        private readonly TRepository _writeRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IReadRepository<TEntity> _readRepository;

        public BaseDeleteCommandHandler(TRepository writeRepository,IUserReadRepository userReadRepository, IReadRepository<TEntity> readRepository)
        {
            _writeRepository = writeRepository;
            _userReadRepository = userReadRepository;
            _readRepository = readRepository;
        }

        public async virtual Task<Guid> Handle(TCommand request,CancellationToken cancellationToken)
        {
            var IsUserExists = await ExistsDatabaseQuery<User>.IsExistingAsync(_userReadRepository, i => i.Id == request.UserId);
            if (!IsUserExists)
                throw new DatabaseExistingValueException("User is not found");
            var TEntityExists = await ExistsDatabaseQuery<TEntity>.IsExistingAsync(_readRepository, c => c.Id == request.Id);
            if (!TEntityExists)
            {
                throw new DatabaseExistingValueException("Entity is not found!");
            }

            var res = await _writeRepository.RemoveAsync(request.Id);
            if (!res)
            {
                throw new Exception("Failed to delete entity");
            }
            await _writeRepository.SaveChangesAsync();
            return request.Id;
        }
    }
}
