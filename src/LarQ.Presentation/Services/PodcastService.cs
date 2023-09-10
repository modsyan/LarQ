using System.Security.Claims;
using AutoMapper;
using LarQ.Common;
using LarQ.Common.Contracts;
using LarQ.Core.Contracts;
using LarQ.Core.Entities;
using LarQ.DataAccess.Repositories;
using LarQ.Services.Base;
using LarQ.Services.Contracts;
using LarQ.ViewModels;

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

    public async Task<IEnumerable<GetPodcastViewModel>> GetAll(int page = 0, int size = 20)
    {
        var podcasts =
            await UnitOfWork.Podcasts.GetAsync(new List<string> { "Host", "Episodes", "Subscribes" }, size, page);

        return podcasts.Select(podcast => new GetPodcastViewModel
        {
            Id = podcast.Id,
            Name = podcast.Name,
            Description = podcast.Description,
            HostId = podcast.HostId,
            HostName = podcast.Host.Name,
            CategoryId = podcast.CategoryId,
            CategoryName = podcast.Category.Name,
            CoverId = podcast.Cover.Id,
            // Cover = 
            Episodes = podcast.Episodes.Count,
            Subscribes = podcast.Subscribes.Count,
        });
    }

    public async Task<GetPodcastDetailViewModel> Get(Guid podcastId)
    {
        throw new NotImplementedException();
    }

    public async Task Create(CreateOrUpdatePodcastViewModel model)
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

        var cover = await _fileUploadExtension.UploadFormFile(model.Cover);

        var podcast = new Podcast
        {
            Name = model.Name,
            Description = model.Description,
            HostId = userId,
            Cover = cover,
            CategoryId = model.CategoryId,
        };

        await UnitOfWork.Podcasts.CreateAsync(podcast);
        await UnitOfWork.CompleteAsync();
    }

    public async Task Update(CreateOrUpdatePodcastViewModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<GetPodcastDetailViewModel> Remove(Guid podcastId)
    {
        throw new NotImplementedException();
    }
}