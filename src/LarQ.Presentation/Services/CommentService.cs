using AutoMapper;
using LarQ.Core.Contracts;
using LarQ.Services.Base;
using LarQ.Services.Contracts;

namespace LarQ.Services;

public class CommentService: BaseService<ICommentService>, ICommentService
{
    public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ICommentService> logger) : base(unitOfWork, mapper, logger)
    {
    }
}