using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Create.Entities
{
    public class CreateCommentCommand : BaseCreateCommand
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
    }
}
