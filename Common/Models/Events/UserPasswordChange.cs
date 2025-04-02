using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Events
{
    public class UserPasswordChange:IEvent
    {
        public Guid UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
