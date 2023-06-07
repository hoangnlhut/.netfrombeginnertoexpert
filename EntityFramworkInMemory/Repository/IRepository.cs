namespace EntityFrameCoreInMemory.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        T CreateItem();
        T GetById(int id);
        void Remove(T item);
        void Save();
        IEnumerable<T> GetAll();

    }
}
