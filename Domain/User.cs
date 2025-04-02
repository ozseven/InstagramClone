using Domain.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhotoLink { get; set; }
        public string About { get; set; }
        public Gender Gender { get; set; }
        public Roles Role { get; set; } = Roles.User;
        public Boolean IsPrivate { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Post> Posts { get; set; }
        public virtual List<Story> Stories { get; set; }
        public virtual List<CommentVote> CommentVotes { get; set; }
        public virtual List<PostVote> PostVotes { get; set; }
        public virtual List<StoryVote> StoryVotes { get; set; }
    }

    public enum Gender
    {
        Unknown,
        Man,
        Woman
    }
    public enum Roles
    {
        Admin,
        User
    }
}
