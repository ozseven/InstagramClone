using Domain;
using Domain.Vote;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations.VoteEntityConfiguration
{
    public class BaseVoteEntityConfiguration<TEntity>:BaseEntityConfiguration<TEntity> where TEntity : BaseVote
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            
        }
    }
}
