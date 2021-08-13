using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using Taskly.Data.Extensions;
using Taskly.Data.Models;

namespace Taskly.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Label> Labels { get; set; }

        public DbSet<LabelNote> LabelsNotes { get; set; }

        public DbSet<LabelTask> LabelsTasks { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Priority> Priorities { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentReaction> CommentsReactions { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<ReplyReaction> RepliesReactions { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectUser> ProjectsUsers { get; set; }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            EnableCascadeDelete(builder, false);

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            builder.ApplySoftDeleteQueryFilter();
        }

        public override int SaveChanges()
        {
            ChangeTracker.SetSoftDelete();
            return base.SaveChanges();
        }

        public override System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetSoftDelete();
            return base.SaveChangesAsync(cancellationToken);
        }

        private static void EnableCascadeDelete(ModelBuilder builder, bool isEnabled)
        {
            var entityTypes = builder.Model.GetEntityTypes().ToList();

            DeleteBehavior deleteBehavior;
            if (isEnabled)
            {
                deleteBehavior = DeleteBehavior.Cascade;
            }
            else
            {
                deleteBehavior = DeleteBehavior.Restrict;
            }

            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = deleteBehavior;
            }
        }
    }
}
