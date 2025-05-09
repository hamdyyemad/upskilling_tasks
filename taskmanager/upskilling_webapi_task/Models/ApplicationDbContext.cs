using Microsoft.EntityFrameworkCore;

namespace upskilling_webapi_task.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.TeamMember)
                .WithMany(m => m.Tasks)
                .HasForeignKey(t => t.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 