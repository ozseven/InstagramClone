using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Update
{
    public abstract class BaseUpdateCommand:BaseCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
