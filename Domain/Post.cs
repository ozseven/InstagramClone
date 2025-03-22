using Domain.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Post:BaseEntity
    {
        public string PhotoLink { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<PostVote> PostVotes { get; set; }
        public virtual List<StoryVote> StoryVotes { get; set; }
    }
}
