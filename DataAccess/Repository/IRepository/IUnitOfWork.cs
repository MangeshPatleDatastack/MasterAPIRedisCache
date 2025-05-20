
using System;
using MasterAPI.DataAccess.Repository.IRepository;
using RedisService.DataAccess.Repository.IRepository;
using WorkerService.DataAccess.Repository.IRepository;
namespace WorkerService.DataAccess.Repository.IRepository;


public interface IUnitOfWork : IDisposable
{
	Task SaveAsync();
    public IProductRepository Product { get;}
    public ILocationRepository Location { get;}
    public ISP_Call SP_Call { get; }
    IDisposable BeginTransaction();

    public void Save();
}
