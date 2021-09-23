using AutoMapper;
using System.Collections.Generic;
using Taskly.Data.Models;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Mapping
{
    public class ServicesAutoMapperProfile : Profile
    {
        public ServicesAutoMapperProfile()
        {
            CreateMap<Label, LabelDto>();
            CreateMap<Note, NoteDto>();
            CreateMap<Priority, PriorityDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentReaction, CommentReactionDto>();
            CreateMap<Reply, ReplyDto>();
            CreateMap<ReplyReaction, ReplyReactionDto>();
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectUser, ProjectUserDto>();
            CreateMap<Task, TaskDto>();
            CreateMap<ApplicationUser, UserDto>();
        }
    }
}
