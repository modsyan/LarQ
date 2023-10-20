using LarQ.ViewModels;

namespace LarQ.Services.Contracts;

public interface IPodcastService
{
    Task<IEnumerable<GetPodcastViewModel>> GetAll(CancellationToken cancellationToken, int page = 0, int size = 2);
    Task<GetPodcastDetailViewModel> Get(Guid podcastId, CancellationToken cancellationToken);
    Task Create(CreateOrUpdatePodcastViewModel model, CancellationToken cancellationToken);
    Task Update(CreateOrUpdatePodcastViewModel model, CancellationToken cancellationToken);
    Task<GetPodcastDetailViewModel> Remove(Guid podcastId, CancellationToken cancellationToken);
}