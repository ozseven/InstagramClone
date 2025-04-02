using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Create.Entities
{
    public abstract class BaseCreateCommand:BaseCommand // this class supports classes except user
    {
        public Guid UserId { get; set; }
    }
}
