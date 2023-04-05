using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Models;

namespace Mint.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique(true);

        builder.Entity<User>()
            .HasIndex(x => x.Phone)
            .IsUnique(true);

        builder.Entity<UserRole>()
            .HasKey(x => new
            {
                x.RoleId,
                x.UserId,
            });

        builder.Entity<UserRole>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserRole>()
            .HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<User>().HasData(UserDataConstants.GetExampleUsers());
        builder.Entity<Role>().HasData(RoleDataContstants.GetExampleRoles());
        builder.Entity<UserRole>().HasData(UserRoleDataConstants.GetExampleUserRoles());
    }
}
