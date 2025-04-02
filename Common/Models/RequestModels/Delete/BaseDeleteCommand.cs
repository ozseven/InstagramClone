using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Delete
{
    public abstract class BaseDeleteCommand : BaseCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
