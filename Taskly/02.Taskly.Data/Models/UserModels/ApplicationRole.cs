using Microsoft.AspNetCore.Identity;
using System;
using Taskly.Data.Interfaces;

namespace Taskly.Data.Models
{
    public class ApplicationRole : IdentityRole, ICreatable, IDeletable
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
            Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public DateTime? DeletedOn { get; set; } = null;
        public bool IsDeleted { get; set; } = false;
    }
}
