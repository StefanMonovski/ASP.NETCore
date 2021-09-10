using AutoMapper;
using Taskly.Services.DataTransferObjects;
using Taskly.Web.ViewModels;

namespace Taskly.Web.Mapping
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<ProjectDto, ProjectsViewModel>();
            CreateMap<ProjectDto, ProjectViewModel>();
            CreateMap<TaskDto, TaskViewModel>();
        }
    }
}
