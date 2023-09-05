using AutoMapper;
using LarQ.Core.Contracts;
using LarQ.Core.Entities;
using LarQ.DataAccess.Repositories;
using LarQ.Services.Base;
using LarQ.Services.Contracts;
using LarQ.ViewModels;

namespace LarQ.Services;

public class PodcastService : BaseService<IPodcastService>, IPodcastService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public PodcastService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<IPodcastService> logger,
        IWebHostEnvironment webHostEnvironment) : base(unitOfWork, mapper, logger)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task Create(CreateUpdatePodcastViewModel model)
    {
        // var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
        // var path = Path.Combine(_imagesPath, coverName);
        
        // await using var stream = File.Create(path);
        // await model.Cover.CopyToAsync(stream);
        // await stream.DisposeAsync();
        //
        
        
        var podcast = Mapper.Map<Podcast>(model);
    }
}