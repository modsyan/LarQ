using LarQ.DataAccess.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LarQ.Core.Entities;

public class ApplicationRole: IdentityRole<Guid>, IEntity
{
    public string Description { get; set; } = string.Empty;
}