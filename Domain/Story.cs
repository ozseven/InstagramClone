using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Story:BaseEntity
    {
        public string PhotoLink { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
