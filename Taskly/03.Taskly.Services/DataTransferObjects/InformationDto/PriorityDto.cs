using Taskly.Data.Enumerators;

namespace Taskly.Services.DataTransferObjects
{
    public class PriorityDto
    {
        public int Id { get; set; }

        public PriorityTypeEnum PriorityType { get; set; }

        public PriorityColorEnum PriorityColor { get; set; }
    }
}
