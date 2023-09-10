using AutoMapper;
using LarQ.Common;
using LarQ.Core.Entities;
using LarQ.ViewModels;

namespace LarQ.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // CreateMap<CreateUpdatePodcastViewModel, Podcast>()
        //     .ForMember(c => c.Cover, async expression =>
        //     {
        //         await FileUploadExtension.UploadFormFile(expression.);
        //     }).ForMember(m=>m.).;

        // CreateMap<CreateUpdatePodcastViewModel, Podcast>().ConvertUsing(async (c, p) =>
        // {
        //     return await FileUploadExtension.UploadFormFile(,c);
        // });

        CreateMap<CreateOrUpdatePodcastViewModel, Podcast>()
            .ForMember(p => p.Cover, expression => expression.Ignore());
    }
}