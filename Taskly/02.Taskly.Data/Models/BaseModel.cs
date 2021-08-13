using System;
using System.ComponentModel.DataAnnotations;
using Taskly.Data.Interfaces;

namespace Taskly.Data.Models
{
    public abstract class BaseModel<TKey> : ICreatable, IDeletable
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        public DateTime? DeletedOn { get; set; } = null;

        public bool IsDeleted { get; set; } = false;
    }

    public abstract class BaseModel : ICreatable, IDeletable
    {
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        public DateTime? DeletedOn { get; set; } = null;

        public bool IsDeleted { get; set; } = false;
    }
}
