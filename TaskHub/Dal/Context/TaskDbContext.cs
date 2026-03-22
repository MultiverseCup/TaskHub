using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Context;

/// <summary>
/// Контекст базы данных задач
/// </summary>
public sealed class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Задачи
    /// </summary>
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

    /// <inheritdoc />
    // Dal/Context/TaskDbContext.cs
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("tasks");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).HasColumnName("title").HasMaxLength(500);
            entity.Property(x => x.CreatedByUserId).HasColumnName("created_by_user_id").IsRequired();
            entity.Property(x => x.CreatedUtc).HasColumnName("created_utc").IsRequired();

            entity.HasOne(typeof(User))
                .WithMany()
                .HasForeignKey("CreatedByUserId")
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<User>().ToTable("users");

        base.OnModelCreating(modelBuilder);
    }
}