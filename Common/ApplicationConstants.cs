using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ApplicationConstants
    {
        public const string RabbitMqHost = "localhost";
        public const string DefaultExchangeType = "direct";

        // User
        public const string UserExchangeName = "UserExchangeName";
        public const string UserCreateQueueName = "UserCreateQueueName";
        public const string UserUpdateQueueName = "UserUpdateQueueName";
        public const string UserDeleteQueueName = "UserDeleteQueueName";
        public const string UserEmailChangedQueueName = "UserEmailChangedQueueName";
        public const string UserPasswordChangedQueueName = "UserPasswordChangedQueueName";


        // Post
        public const string PostExchangeName = "PostExchangeName";
        public const string PostCreateQueueName = "PostCreateQueueName";
        public const string PostUpdateQueueName = "PostUpdateQueueName";
        public const string PostDeleteQueueName = "PostDeleteQueueName";

        // PostVote
        public const string PostVoteExchangeName = "PostVoteExchangeName";
        public const string PostVoteCreateQueueName = "PostVoteCreateQueueName";
        public const string PostVoteUpdateQueueName = "PostVoteUpdateQueueName";
        public const string PostVoteDeleteQueueName = "PostVoteDeleteQueueName";

        // Comment
        public const string CommentExchangeName = "CommentExchangeName";
        public const string CommentCreateQueueName = "CommentCreateQueueName";
        public const string CommentUpdateQueueName = "CommentUpdateQueueName";
        public const string CommentDeleteQueueName = "CommentDeleteQueueName";

        // CommentVote
        public const string CommentVoteExchangeName = "CommentVoteExchangeName";
        public const string CommentVoteCreateQueueName = "CommentVoteCreateQueueName";
        public const string CommentVoteUpdateQueueName = "CommentVoteUpdateQueueName";
        public const string CommentVoteDeleteQueueName = "CommentVoteDeleteQueueName";

        // Story
        public const string StoryExchangeName = "StoryExchangeName";
        public const string StoryCreateQueueName = "StoryCreateQueueName";
        public const string StoryUpdateQueueName = "StoryUpdateQueueName";
        public const string StoryDeleteQueueName = "StoryDeleteQueueName";

        // StoryVote
        public const string StoryVoteExchangeName = "StoryVoteExchangeName";
        public const string StoryVoteCreateQueueName = "StoryVoteCreateQueueName";
        public const string StoryVoteUpdateQueueName = "StoryVoteUpdateQueueName";
        public const string StoryVoteDeleteQueueName = "StoryVoteDeleteQueueName";
    }
}
