using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    public class CommentEntityConfiguration:BaseEntityConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);
            // Kullanıcı silindiğinde, ona ait tüm yorumları sil
            builder.HasOne(i => i.User)
                .WithMany(i => i.Comments)
                .HasForeignKey(i => i.UserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            // Post silindiğinde, ona ait tüm yorumları sil
            builder.HasOne(i => i.Post)
                .WithMany(i => i.Comments)
                .HasForeignKey(i => i.PostId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
