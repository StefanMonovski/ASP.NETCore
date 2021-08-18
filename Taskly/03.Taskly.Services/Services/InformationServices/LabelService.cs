using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskly.Data;
using Taskly.Data.Models;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;

namespace Taskly.Services.Services
{
    public class LabelService : ILabelService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LabelService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> AddLabelAsync(string title, int? colorArgb, string userId)
        {
            Label label = new()
            {
                Title = title,
                ColorArgb = colorArgb,
                CreatorId = userId,
            };

            await context.Labels.AddAsync(label);
            await context.SaveChangesAsync();

            return label.Id;
        }

        public async Task<int> DeleteLabelAsync(int labelId)
        {
            Label label = context.Labels
                .Where(x => x.Id == labelId)
                .FirstOrDefault();

            context.Labels.Remove(label);
            await context.SaveChangesAsync();

            return label.Id;
        }

        public async Task<int> UpdateLabelColorAsync(int labelId, int? colorArgb)
        {
            Label label = context.Labels
                .Where(x => x.Id == labelId)
                .FirstOrDefault();

            label.ColorArgb = colorArgb;
            await context.SaveChangesAsync();

            return label.Id;
        }

        public List<LabelDto> GetAllLabels()
        {
            List<LabelDto> labelsDto = context.Labels
                .ProjectTo<LabelDto>(mapper.ConfigurationProvider)
                .ToList();

            return labelsDto;
        }

        public LabelDto GetLabel(int labelId)
        {
            LabelDto labelDto = context.Labels
                .Where(x => x.Id == labelId)
                .ProjectTo<LabelDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();
            
            return labelDto;
        }
    }
}
