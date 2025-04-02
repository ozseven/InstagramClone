using Domain.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Update.UpdateVoteCommand
{
    public abstract class BaseUpdateVoteCommand : BaseUpdateCommand
    {
        public Vote Vote { get; set; }
    }
}
