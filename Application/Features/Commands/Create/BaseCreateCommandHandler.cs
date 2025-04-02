using Common.Models.RequestModels.Create.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Create
{
    public abstract class BaseCreateCommandHandler<TCommand> : BaseCommandHandler, IRequestHandler<TCommand, Guid> where TCommand : BaseCreateCommand
    {
        public abstract Task<Guid> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
