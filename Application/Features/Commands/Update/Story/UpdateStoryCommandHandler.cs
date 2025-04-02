using Application.Interfaces.Repositories;
using AutoMapper;
using Common.Models.RequestModels.Update;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Update
{
    public class UpdateStoryCommandHandler : BaseUpdateCommandHandler<UpdateStoryCommand, Story>
    {
        public UpdateStoryCommandHandler(IStoryReadRepository readRepository, IUserReadRepository userReadRepository, IStoryWriteRepository writeRepository, IMapper mapper) : base(readRepository, userReadRepository, writeRepository, mapper)
        {
        }
    }
}
