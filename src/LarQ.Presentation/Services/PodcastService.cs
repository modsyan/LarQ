using System.Security.Claims;
using AutoMapper;
using LarQ.Core.Entities;
using LarQ.Common.Contracts;
using LarQ.Core.Contracts;
using LarQ.Services.Base;
using LarQ.Services.Contracts;
using LarQ.ViewModels;
using Host = LarQ.Core.Entities.Host;

namespace LarQ.Services;

public class PodcastService : BaseService<IPodcastService>, IPodcastService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IFileUploadExtension _fileUploadExtension;

    public PodcastService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<IPodcastService> logger,
        IFileUploadExtension fileUploadExtension, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper,
        logger)
    {
        _fileUploadExtension = fileUploadExtension;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<GetPodcastViewModel>> GetAll(CancellationToken cancellationToken, int page = 0,
        int size = 20)
    {
        // var podcasts =
        //     await UnitOfWork.Podcasts.GetAsync(includes: new List<string> { "Host", "Episodes", "Subscribes" }, size, page);

        var podcasts = await UnitOfWork.Podcasts.GetAsync(
            cancellationToken,
            includes: new List<string> { nameof(Podcast.Cover), nameof(Podcast.Host), nameof(Podcast.Category) },
            take: size,
            skip: page);

        var podcastViewModels = podcasts.Select(podcast =>
            new GetPodcastViewModel
            {
                Id = podcast.Id,
                Name = podcast.Name,
                Description = podcast.Description,
                HostId = podcast.HostId,
                HostName = podcast.Host.User.Name,
                CategoryId = podcast.CategoryId,
                // CategoryName = podcast.Category.Name,
                Cover = podcast.Cover,
                // Episodes = podcast.Episodes.Count,
                // Subscribes = podcast.Subscribes.Count,
            });

        return podcastViewModels;
    }

    public async Task<GetPodcastDetailViewModel> Get(Guid podcastId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task Create(CreateOrUpdatePodcastViewModel model, CancellationToken cancellationToken)
    {
        // var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
        // var path = Path.Combine(_imagesPath, coverName);

        // await using var stream = File.Create(path);
        // await model.Cover.CopyToAsync(stream);
        // await stream.DisposeAsync();
        //
        // var podcast = Mapper.Map<Podcast>(model);

        var userId = Guid.Parse(((ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity)
            .FindFirst(ClaimTypes.NameIdentifier).Value);

        // if (userId == Guid.Empty) return View.;

        var cover = await _fileUploadExtension.UploadFormFile(model.Cover);

        var podcast = new Podcast
        {
            Name = model.Name,
            Description = model.Description,
            Host = new Host() { UserId = userId, },
            Cover = cover,
            CategoryId = model.CategoryId,
        };

        await UnitOfWork.Podcasts.CreateAsync(podcast, cancellationToken);
        await UnitOfWork.CompleteAsync();
    }

    public async Task Update(CreateOrUpdatePodcastViewModel model, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<GetPodcastDetailViewModel> Remove(Guid podcastId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}