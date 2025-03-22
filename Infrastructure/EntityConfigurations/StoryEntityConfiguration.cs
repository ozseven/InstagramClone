using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    public class StoryEntityConfiguration:BaseEntityConfiguration<Story>
    {
        public override void Configure(EntityTypeBuilder<Story> builder)
        {
            base.Configure(builder);
            builder.HasOne(i => i.User)
                .WithMany(i => i.Stories)
                .HasForeignKey(i => i.UserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
