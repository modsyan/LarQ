using LarQ.Core.Common;
using LarQ.Core.Entities;
using LarQ.Core.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LarQ.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entities = typeof(IEntity).Assembly;

        modelBuilder.RegisterAllEntities<IEntity>(entities);

        modelBuilder.AddEntityTypeConfigurations(entities);

        modelBuilder.AddSequentialGuidForIdConvention();

        modelBuilder.AddPluraizingTableNameConvention();

        modelBuilder.AddCategorySeed();
        
        modelBuilder.AddUserApplicationSeeder();
        
        // modelBuilder.AddGuestSeeder();
    }

    // public DbSet<Actor> Actors { get; set; }
}