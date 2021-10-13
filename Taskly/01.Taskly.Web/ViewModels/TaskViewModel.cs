using System;

namespace Taskly.Web.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Schedule { get; set; }

        public bool IsCompleted { get; set; }

        public PriorityViewModel Priority { get; set; }
    }
}
