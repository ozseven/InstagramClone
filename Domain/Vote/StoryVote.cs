﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Vote
{
    public class StoryVote:BaseVote
    {
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
