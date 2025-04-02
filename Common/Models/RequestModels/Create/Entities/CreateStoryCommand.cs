using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Create.Entities
{
    public class CreateStoryCommand : BaseCreateCommand
    {
        public string PhotoLink { get; set; }
    }
}
