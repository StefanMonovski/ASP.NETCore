using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using Taskly.Data;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;

namespace Taskly.Services.Services
{
    public class PriorityService : IPriorityService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PriorityService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public List<PriorityDto> GetAllPriorities()
        {
            List<PriorityDto> prioritiesDto = context.Priorities
                .ProjectTo<PriorityDto>(mapper.ConfigurationProvider)
                .ToList();

            return prioritiesDto;
        }

        public PriorityDto GetPriority(int priorityId)
        {
            PriorityDto priorityDto = context.Priorities
                .Where(x => x.Id == priorityId)
                .ProjectTo<PriorityDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return priorityDto;
        }
    }
}
