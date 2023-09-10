using AutoMapper;
using LarQ.Core.Contracts;
using LarQ.Services.Base;
using LarQ.Services.Contracts;

namespace LarQ.Services;

public class PlaylistService : BaseService<IPlaylistService>, IPlaylistService
{
    public PlaylistService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<IPlaylistService> logger)
        : base(unitOfWork, mapper, logger)
    {
    }
}