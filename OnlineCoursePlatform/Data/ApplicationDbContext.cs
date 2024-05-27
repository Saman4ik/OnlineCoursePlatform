using Microsoft.EntityFrameworkCore;
using OnlineCoursePlatform.Modellar;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OnlineCoursePlatform.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Course)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CourseId);
    }
}
