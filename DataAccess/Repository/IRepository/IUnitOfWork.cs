
using System;
using RedisService.DataAccess.Repository.IRepository;
using WorkerService.DataAccess.Repository.IRepository;
namespace WorkerService.DataAccess.Repository.IRepository;


public interface IUnitOfWork : IDisposable
{
	Task SaveAsync();
    public IProductRepository Product { get;}
    public ISP_Call SP_Call { get; }
    IDisposable BeginTransaction();

    public void Save();
}
