using Domain.Vote;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations.VoteEntityConfiguration
{
    public class PostVoteEntityConfiguration: BaseVoteEntityConfiguration<PostVote>
    {
        public override void Configure(EntityTypeBuilder<PostVote> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Post).WithMany(i => i.PostVotes).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User).WithMany(i => i.PostVotes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
