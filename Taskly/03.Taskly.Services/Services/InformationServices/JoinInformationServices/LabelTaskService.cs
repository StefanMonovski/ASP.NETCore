using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using Taskly.Data;
using Taskly.Data.Models;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Taskly.Services.Services
{
    public class LabelTaskService : ILabelTaskService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LabelTaskService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddLabelTaskAsync(int labelId, int taskId)
        {
            LabelTask labelTask = new()
            {
                LabelId = labelId,
                TaskId = taskId
            };

            await context.LabelsTasks.AddAsync(labelTask);
            await context.SaveChangesAsync();
        }

        public async Task DeleteLabelTaskAsync(int labelId, int taskId)
        {
            LabelTask labelTask = context.LabelsTasks
                .Where(x => x.LabelId == labelId && x.TaskId == taskId)
                .FirstOrDefault();

            context.LabelsTasks.Remove(labelTask);
            await context.SaveChangesAsync();
        }

        public List<LabelDto> GetAllLabelsFromTask(int taskId)
        {
            List<LabelDto> labelsDto = context.LabelsTasks
                .Where(x => x.TaskId == taskId)
                .Select(x => x.Label)
                .ProjectTo<LabelDto>(mapper.ConfigurationProvider)
                .ToList();

            return labelsDto;
        }
    }
}
