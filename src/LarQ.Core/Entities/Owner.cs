using LarQ.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Owner: IEntity
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = default!;
    
    public ICollection<Host> Hosts { get; set; } = new List<Host>();
}

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasOne(owner => owner.User)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(owner => owner.Hosts)
            .WithOne(host => host.Owner)
            .HasForeignKey(host => host.OwnerId)
            .OnDelete(DeleteBehavior.ClientCascade).IsRequired();
    }
}