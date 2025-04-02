using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Update
{
    public class UpdateStoryCommand:BaseUpdateCommand
    {
        public string PhotoLink { get; set; }

    }
}
