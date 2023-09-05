using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LarQ.DataAccess.Common;

namespace LarQ.Core.Common;

public abstract class BaseEntity : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public DateTime? CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}