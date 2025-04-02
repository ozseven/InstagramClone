using Domain.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Create.Entities.CreateVoteCommand
{
    public abstract class BaseCreateVoteCommand:BaseCreateCommand
    {
        public Guid Id { get; set; }
        public Vote Vote { get; set; }
    }
}
