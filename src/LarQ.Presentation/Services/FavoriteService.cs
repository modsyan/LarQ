using AutoMapper;
using LarQ.Core.Contracts;
using LarQ.Services.Base;
using LarQ.Services.Contracts;

namespace LarQ.Services;

public class FavoriteService : BaseService<FavoriteService>, IFavoriteService
{
    public FavoriteService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FavoriteService> logger)
        : base(unitOfWork, mapper, logger)
    {
    }
}