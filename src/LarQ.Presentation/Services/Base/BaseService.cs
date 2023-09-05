using AutoMapper;
using LarQ.Core.Contracts;
using LarQ.DataAccess.Repositories;

namespace LarQ.Services.Base;

public class BaseService<TService>
{
    protected readonly IUnitOfWork UnitOfWork;
    protected IMapper Mapper;
    protected ILogger<TService> Logger;

    protected BaseService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TService> logger) =>
        (UnitOfWork, Mapper, Logger) = (unitOfWork, mapper, logger);
}