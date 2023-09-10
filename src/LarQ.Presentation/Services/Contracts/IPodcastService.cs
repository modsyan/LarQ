using LarQ.ViewModels;

namespace LarQ.Services.Contracts;

public interface IPodcastService
{
    Task<IEnumerable<GetPodcastViewModel>> GetAll(int page = 0, int size = 20);
    Task<GetPodcastDetailViewModel> Get(Guid podcastId);
    Task Create(CreateOrUpdatePodcastViewModel model);
    Task Update(CreateOrUpdatePodcastViewModel model);
    Task<GetPodcastDetailViewModel> Remove(Guid podcastId);
}