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
    public class UpdateCommentCommandHandler : BaseUpdateCommandHandler<UpdateCommentCommand, Comment>
    {
        public UpdateCommentCommandHandler(ICommentReadRepository readRepository, IUserReadRepository userReadRepository, ICommentWriteRepository writeRepository, IMapper mapper) : base(readRepository, userReadRepository, writeRepository, mapper)
        {
        }
    }
}
