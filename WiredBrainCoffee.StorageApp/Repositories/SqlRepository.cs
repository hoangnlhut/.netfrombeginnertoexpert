using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entities;
using System.Linq;
using WiredBrainCoffee.StorageApp.Data;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public SqlRepository(StorageAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public event EventHandler<T> itemAdded;

        public void Add(T item)
        {
            //item.Id = _dbSet.Any() ? _dbSet.Max(item => item.Id) + 1 : 1;
            _dbSet.Add(item);
            itemAdded.Invoke(this, item);
        }

        public T CreateItem()
        {
            return new T();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
