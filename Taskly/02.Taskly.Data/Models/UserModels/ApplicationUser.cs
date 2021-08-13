using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskly.Data.Interfaces;

namespace Taskly.Data.Models
{
    public class ApplicationUser : IdentityUser, ICreatable, IDeletable
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
            Roles = new HashSet<IdentityUserRole<string>>();
            Claims = new HashSet<IdentityUserClaim<string>>();
            Logins = new HashSet<IdentityUserLogin<string>>();
        }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public DateTime? DeletedOn { get; set; } = null;
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
