using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public static class RepositoryExtentions
    {
        public static void AddBatch<T>(this IWriteRepository<T> repository, T[] items)
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }
}
