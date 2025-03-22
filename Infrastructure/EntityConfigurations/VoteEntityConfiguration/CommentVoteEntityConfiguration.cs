using Domain.Vote;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityConfigurations.VoteEntityConfiguration
{
    public class CommentVoteEntityConfiguration:BaseVoteEntityConfiguration<CommentVote>
    {
        public override void Configure(EntityTypeBuilder<CommentVote> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Comment).WithMany(i=> i.CommentVotes).HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User).WithMany(i => i.CommentVotes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
