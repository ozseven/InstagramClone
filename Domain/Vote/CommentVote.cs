﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Vote
{
    public class CommentVote:BaseVote
    {
        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
