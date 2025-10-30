using Microsoft.EntityFrameworkCore;
using WebForumApiApp.Models;
using Thread = WebForumApiApp.Models.Thread;

namespace WebForumApiApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
    }
    
    // DbSet'ы
    public DbSet<User> Users { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Thread>  Threads { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ThreadTag> ThreadTags { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // many-to-many for ThreadTag
        modelBuilder.Entity<ThreadTag>()
            .HasKey(t => new { t.ThreadId, t.TagId });
        
        modelBuilder.Entity<ThreadTag>()
            .HasOne(pt => pt.Thread)
            .WithMany(t => t.ThreadTags)
            .HasForeignKey(pt => pt.ThreadId);
        
        modelBuilder.Entity<ThreadTag>()
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.ThreadTags)
            .HasForeignKey(pt => pt.TagId);
        
        // Soft delete
        modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Thread>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Comment>().HasQueryFilter(x => !x.IsDeleted);
        
        // Unique index
        
        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<Tag>().HasIndex(t => t.Name).IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }
    
}