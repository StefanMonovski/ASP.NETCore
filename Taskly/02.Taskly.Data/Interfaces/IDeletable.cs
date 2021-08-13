using System;

namespace Taskly.Data.Interfaces
{
    public interface IDeletable
    {
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
