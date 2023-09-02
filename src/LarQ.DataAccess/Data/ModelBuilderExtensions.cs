using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pluralize.NET;

namespace LarQ.Data;

public static class ModelBuilderExtensions
{
    public static void AddPluraizingTableNameConvention(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.SetTableName(new Pluralizer().Pluralize(entityType.GetTableName()));
        }
    }

    public static void AddSequentialGuidForIdConvention(this ModelBuilder modelBuilder)
    {
        modelBuilder.AddDefaultValuesSqlConvention("Id", typeof(Guid), "NEWSEQUENTIALID()");
    }

    private static void AddDefaultValuesSqlConvention(this ModelBuilder modelBuilder, string propertyName,
        Type propertyType, string defaultValueSql)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var property = entityType.GetProperties().SingleOrDefault(
                p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
            if (property is not null && property.ClrType == propertyType)
            {
                property.SetDefaultValueSql(defaultValueSql);
            }
        }
    }

    public static void AddEntityTypeConfigurations(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        var applyGenericMethod = typeof(ModelBuilder).GetMethods()
            .First(m => m.Name == nameof(ModelBuilder.ApplyConfiguration));

        var types = assemblies.SelectMany(a => a.GetExportedTypes())
            .Where(c => c is { IsClass: true, IsAbstract: false, IsPublic: true });

        foreach (var type in types)
        {
            foreach (var inter in type.GetInterfaces())
            {
                if (!inter.IsConstructedGenericType ||
                    inter.GetGenericTypeDefinition() != typeof(IEntityTypeConfiguration<>)) continue;

                var applyGeneric = applyGenericMethod.MakeGenericMethod(inter.GenericTypeArguments[0]);
                applyGeneric.Invoke(modelBuilder, new object?[] { Activator.CreateInstance(type) });
            }
        }
    }

    public static void RegisterAllEntities<TBase>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        var types = assemblies.SelectMany(a => a.GetExportedTypes())
            .Where(c => c is { IsClass: true, IsAbstract: false, IsPublic: true } && typeof(TBase).IsAssignableFrom(c));

        foreach (var type in types)
        {
            modelBuilder.Entity(type);
        }
    }
}