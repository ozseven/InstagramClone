using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Events
{
    public class UserEmailChange:IEvent
    {
        public Guid UserId { get; set; }
        public string NewEmail { get; set; }
        public string OldEmail { get; set; }

    }
}
