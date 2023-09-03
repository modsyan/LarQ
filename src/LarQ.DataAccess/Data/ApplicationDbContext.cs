﻿using LarQ.Core.Entities;
using LarQ.Core.Seeds;
using LarQ.DataAccess.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LarQ.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext
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
        modelBuilder.AddActorsSeeder();
    }

    // public DbSet<Actor> Actors { get; set; }
}