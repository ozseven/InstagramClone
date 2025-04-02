using Common.Models.RequestModels.Create.Entities.CreateVoteCommand;
using Common.Models.RequestModels.Update.UpdateVoteCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Create.VoteCommand
{
    public abstract class BaseCreateVoteCommandHandler<Repository,TCommand> : IRequestHandler<TCommand, Guid> where TCommand:BaseCreateVoteCommand
    {
        protected readonly Repository _repository;

        public BaseCreateVoteCommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public virtual Task<Guid> Handle(TCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Base method is not implemented. Please override this method in derived classes.");
        }
    }
}
