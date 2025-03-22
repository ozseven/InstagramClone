using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Vote
{
    public abstract class BaseVote:BaseEntity
    {
        public Vote Vote { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
    public enum Vote
    {
        None,
        Like,
        Dislike,
        Awesome,
        Interesting,
        Hate
    }
}
