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
    public class UpdatePostCommandHandler : BaseUpdateCommandHandler<UpdatePostCommand, Post>
    {
        public UpdatePostCommandHandler(IPostReadRepository readRepository, IUserReadRepository userReadRepository, IPostWriteRepository writeRepository, IMapper mapper) : base(readRepository, userReadRepository, writeRepository, mapper)
        {
        }
    }
}
