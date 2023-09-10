using AutoMapper;
using LarQ.Core.Contracts;
using LarQ.Services.Base;
using LarQ.Services.Contracts;

namespace LarQ.Services;

public class SubscribeService : BaseService<ISubscribeService>, ISubscribeService
{
    public SubscribeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ISubscribeService> logger)
        : base(unitOfWork, mapper, logger)
    {
    }
}