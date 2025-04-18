
using Microsoft.EntityFrameworkCore.Storage;
using RedisService.DataAccess.Data;
using RedisService.DataAccess.Repository;
using RedisService.DataAccess.Repository.IRepository;
using WorkerService.DataAccess.Repository.IRepository;
namespace WorkerService.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
		public UnitOfWork(ApplicationDbContext db)   
        {
            _db = db;
            SP_Call = new SP_Call(_db);
            Product=new ProductRepository(_db);

        }
		public ISP_Call SP_Call { get; private set; }
        public IProductRepository Product { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public IDisposable BeginTransaction()
        {
            return _db.Database.BeginTransaction();
        }
    }
}
