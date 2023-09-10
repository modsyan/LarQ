using AutoMapper;
using LarQ.Core.Contracts;
using LarQ.Services.Base;
using LarQ.Services.Contracts;

namespace LarQ.Services;

public class ReactService : BaseService<IReactService>, IReactService
{
    public ReactService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<IReactService> logger)
        : base(unitOfWork, mapper, logger)
    {
    }
}