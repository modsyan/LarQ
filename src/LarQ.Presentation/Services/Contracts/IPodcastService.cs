using LarQ.ViewModels;

namespace LarQ.Services.Contracts;

public interface IPodcastService
{

    Task Create(CreateUpdatePodcastViewModel model);
}