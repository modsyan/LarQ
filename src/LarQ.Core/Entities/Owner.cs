using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Owner : ApplicationUser
{
    public ICollection<Host> Hosts { get; set; } = new List<Host>();
}

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasMany(owner => owner.Hosts)
            .WithOne(host => host.Owner)
            .HasForeignKey(host => host.OwnerId)
            .OnDelete(DeleteBehavior.ClientCascade).IsRequired();
    }
}