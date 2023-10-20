using AutoMapper;
using LarQ.Core.Contracts;
using LarQ.Services.Base;
using LarQ.Services.Contracts;

namespace LarQ.Services;

public class OwnerService: BaseService<IOwnerService>, IOwnerService
{
    protected OwnerService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<IOwnerService> logger) : base(unitOfWork, mapper, logger)
    {
    }
}