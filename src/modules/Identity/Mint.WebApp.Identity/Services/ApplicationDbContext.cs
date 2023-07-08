using Microsoft.EntityFrameworkCore;
using Mint.WebApp.Identity.Models;

namespace Mint.WebApp.Identity.Services;

/// <summary>
/// Identity Application Db Context
/// </summary>
public class ApplicationDbContext : DbContext
{
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="options"></param>
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	/// <summary>
	/// Users Table
	/// </summary>
	public DbSet<User> Users { get; set; }

	/// <summary>
	/// Roles Table
	/// </summary>
	public DbSet<Role> Roles { get; set; }

	/// <summary>
	/// Photos Table
	/// </summary>
	public DbSet<Photo> Photos { get; set; }

	/// <summary>
	/// User Roles Table
	/// </summary>
	public DbSet<UserRole> UserRoles { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<User>()
			.HasIndex(x => x.Email)
			.IsUnique(true);

		builder.Entity<User>()
			.HasIndex(x => x.Phone)
			.IsUnique(true);

		builder.Entity<Role>()
			.HasIndex(x => x.UniqueKey)
			.IsUnique(true);

		builder.Entity<UserRole>()
			.HasKey(x => new
			{
				x.RoleId,
				x.UserId,
			});

		builder.Entity<UserRole>()
			.HasOne(x => x.Role)
			.WithMany(x => x.UserRoles)
			.HasForeignKey(x => x.RoleId)
			.OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserRole>()
			.HasOne(x => x.User)
			.WithMany(x => x.UserRoles)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Entity<RefreshToken>()
			.HasOne(x => x.User)
			.WithMany(x => x.RefreshTokens)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Entity<User>()
			.HasOne(x => x.Photo)
			.WithMany(x => x.Users)
			.HasForeignKey(x => x.PhotoId)
			.OnDelete(DeleteBehavior.SetNull);
    }
}
