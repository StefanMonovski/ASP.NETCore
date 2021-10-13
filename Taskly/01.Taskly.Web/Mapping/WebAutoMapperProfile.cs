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
            CreateMap<PriorityDto, PriorityViewModel>()
                .ForMember(x => x.PriorityTypeName, x => x.MapFrom(x => x.PriorityType.ToString()))
                .ForMember(x => x.PriorityColorName, x => x.MapFrom(x => x.PriorityColor.ToString()));
        }
    }
}
