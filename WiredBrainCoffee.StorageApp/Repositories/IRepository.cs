using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    //Covariance Interface - only read
    public interface IReadRepository<out T>
    {
        T CreateItem();
        T GetById(int id);
        IEnumerable<T> GetAll();
    }

    //Contravariance Interface - only write
    public interface IWriteRepository<in T>
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }

    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
    }
}