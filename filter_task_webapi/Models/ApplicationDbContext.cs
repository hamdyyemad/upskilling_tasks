using Microsoft.EntityFrameworkCore;

namespace filter_task_webapi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(t => t.TeamMember)
                .WithMany(m => m.Tasks)
                .HasForeignKey(t => t.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 