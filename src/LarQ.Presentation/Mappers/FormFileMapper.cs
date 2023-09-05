// using AutoMapper;
// using LarQ.Common;
// using LarQ.Core.Entities;
//
// namespace LarQ.Mappers;
//
// public class FormFileMapper : ITypeConverter<IFormFile, UploadedFile> 
// {
//     private readonly IWebHostEnvironment _hostingEnvironment;
//
//     public FormFileMapper(IWebHostEnvironment hostingEnvironment)
//     {
//         _hostingEnvironment = hostingEnvironment;
//     }
//
//     public async Task<UploadedFile?> Convert(IFormFile source, Task<UploadedFile?> destination,
//         ResolutionContext context)
//     {
//         return await FileUploadExtension.UploadFormFile(_hostingEnvironment, source);
//     }
// }