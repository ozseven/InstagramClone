using AutoMapper;
using Common.Models.RequestModels.Create;
using Common.Models.RequestModels.Create.Entities;
using Common.Models.RequestModels.Create.Entities.CreateVoteCommand;
using Common.Models.RequestModels.Update;
using Common.Models.RequestModels.Update.UpdateVoteCommand;
using Domain;
using Domain.Vote;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (Gender)src.Gender));

            CreateMap<UpdateUserCommand, User>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (Gender)src.Gender));

            // Post mappings
            CreateMap<CreatePostCommand, Post>();
            CreateMap<UpdatePostCommand, Post>();

            // Comment mappings
            CreateMap<CreateCommentCommand, Comment>();
            CreateMap<UpdateCommentCommand, Comment>();

            // Story mappings
            CreateMap<CreateStoryCommand, Story>();
            CreateMap<UpdateStoryCommand, Story>();

            // Vote mappings
            CreateMap<CreatePostVoteCommand, PostVote>();
            CreateMap<UpdatePostVoteCommand, PostVote>();

            CreateMap<CreateCommentVoteCommand, CommentVote>();
            CreateMap<UpdateCommentVoteCommand, CommentVote>();

            CreateMap<CreateStoryVoteCommand, StoryVote>();
            CreateMap<UpdateStoryVoteCommand, StoryVote>();
        }
    }
} 