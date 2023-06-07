using System.Reflection;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    //public delegate void ItemAddedList<T>( T item);
    // "where" keyword describe the constraints on type parameters with T class
    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly List<T> _items;
        //public readonly ItemAddedList<T> _itemAdded;

        public T CreateItem()
        {
            return new T();
        }

        //public ListRepository(ItemAddedList<T> itemAddedList = null)
        public ListRepository()
        {
            _items = new List<T>();
            //_itemAdded = itemAddedList;
        }

        public void Add(T item)
        {
            item.Id = _items.Any() ? _items.Max(item => item.Id) + 1 : 1;
            _items.Add(item);
            //_itemAdded.GetMethodInfo().Invoke(this, new object[] { item });
        }

        public T GetById(int id)
        {
            return _items.Single(x => x.Id == id);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
    }
}
