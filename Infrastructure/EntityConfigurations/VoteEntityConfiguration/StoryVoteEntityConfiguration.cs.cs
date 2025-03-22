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
    public class StoryVoteEntityConfiguration:BaseVoteEntityConfiguration<StoryVote>
    {
        public virtual void Configure(EntityTypeBuilder<StoryVote> builder)
        {
            base.Configure(builder);
            builder.HasOne(sv => sv.Post)
                .WithMany(p => p.StoryVotes)
                .HasForeignKey(sv => sv.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User)
                .WithMany(i => i.StoryVotes)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
