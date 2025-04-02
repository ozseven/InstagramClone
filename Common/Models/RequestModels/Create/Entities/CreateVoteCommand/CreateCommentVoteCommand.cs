using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Create.Entities.CreateVoteCommand
{
    public class CreateCommentVoteCommand:BaseCreateVoteCommand
    {
        public Guid PostId { get; set; }
    }
}
